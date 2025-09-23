package ru.golubov.computergraphicslab2task1;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXMLLoader;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.chart.BarChart;
import javafx.scene.chart.CategoryAxis;
import javafx.scene.chart.NumberAxis;
import javafx.scene.chart.XYChart;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.ColumnConstraints;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.Priority;
import javafx.scene.layout.VBox;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import ru.golubov.computergraphicslab2task1.impl.DifferenceBetweenHalftoneImagesFinderImpl;
import ru.golubov.computergraphicslab2task1.impl.GrayScaleConverterImpl;
import ru.golubov.computergraphicslab2task1.impl.IntensityHistogramDataCalculatorImpl;

import java.io.File;
import java.io.IOException;

public class HelloApplication extends Application {
    Image originalImage;
    Image imageInColorsPAL_NTSC;
    Image imageInColorsHDTV;
    GrayScaleConverter grayScaleConverter;
    DifferenceBetweenHalftoneImagesFinder differenceBetweenHalftoneImagesFinder;
    @Override
    public void start(Stage stage) throws IOException {
        FileChooser fileChooser = new FileChooser();

        Button chooserFileButton = new Button("Choose file");

        chooserFileButton.setOnAction(e -> {
            File choosenFile = fileChooser.showOpenDialog(stage);

            try {
                originalImage = new Image(choosenFile.toURI().toString());
            } catch (Exception error) {
                System.out.println("ERROR: " + error.getMessage());
            }

            grayScaleConverter = new GrayScaleConverterImpl(originalImage);

            imageInColorsPAL_NTSC = grayScaleConverter.convertToPAL_NTSC();
            imageInColorsHDTV = grayScaleConverter.convertToHDTV();

            differenceBetweenHalftoneImagesFinder = new DifferenceBetweenHalftoneImagesFinderImpl(imageInColorsPAL_NTSC,
                    imageInColorsHDTV);

            GridPane gridPane = new GridPane();
            gridPane.setAlignment(Pos.CENTER);

            for (int i = 0; i < 3; i++) {
                ColumnConstraints col = new ColumnConstraints();
                col.setPercentWidth(33);
                col.setHgrow(Priority.ALWAYS);
                gridPane.getColumnConstraints().add(col);
            }

            ImageView imageView1 = new ImageView(grayScaleConverter.convertToPAL_NTSC());
            imageView1.setPreserveRatio(true);
            imageView1.setSmooth(true);
            VBox container1 = new VBox(10);
            container1.setAlignment(Pos.CENTER);
            imageView1.fitWidthProperty().bind(container1.widthProperty().subtract(40));
            Label title1 = new Label("PAL/NTSC");
            container1.getChildren().addAll(imageView1, title1);
            gridPane.add(container1, 0, 0);

            ImageView imageView2 = new ImageView(grayScaleConverter.convertToHDTV());
            imageView2.setPreserveRatio(true);
            imageView2.setSmooth(true);
            VBox container2 = new VBox(10);
            container2.setAlignment(Pos.CENTER);
            imageView2.fitWidthProperty().bind(container2.widthProperty().subtract(40));
            Label title2 = new Label("HDTV");
            container2.getChildren().addAll(imageView2, title2);
            gridPane.add(container2, 1, 0);

            ImageView imageView3 = new ImageView(differenceBetweenHalftoneImagesFinder.findDifference());
            imageView3.setPreserveRatio(true);
            imageView3.setSmooth(true);
            VBox container3 = new VBox(10);
            container3.setAlignment(Pos.CENTER);
            imageView3.fitWidthProperty().bind(container3.widthProperty().subtract(40));
            Label title3 = new Label("Разность полутоновых изображений");
            container3.getChildren().addAll(imageView3, title3);
            gridPane.add(container3, 2, 0);



            Scene grayImagesScene = new Scene(gridPane);
            stage.setScene(grayImagesScene);

            IntensityHistogramDataCalculator intensityHistogramDataCalculator = new IntensityHistogramDataCalculatorImpl(imageInColorsPAL_NTSC);
            var barChart = createHistogramChart(intensityHistogramDataCalculator.calculate(), "PAL/NTSC");
            Scene histogramsScene = new Scene(barChart);
            Stage histogramsStage = new Stage();
            histogramsStage.setScene(histogramsScene);
            histogramsStage.show();

            intensityHistogramDataCalculator = new IntensityHistogramDataCalculatorImpl(imageInColorsHDTV);
            var barChartHDTV = createHistogramChart(intensityHistogramDataCalculator.calculate(), "HDTV");
            Scene histogramsSceneHDTV = new Scene(barChartHDTV);
            Stage histogramsStageHDTV = new Stage();
            histogramsStageHDTV.setScene(histogramsSceneHDTV);
            histogramsStageHDTV.show();

        });


        Scene scene = new Scene(chooserFileButton, 320, 240);
        stage.setTitle("Hello!");
        stage.setScene(scene);
        stage.show();
    }

    public Scene generateGrayImagesScene() {
        GridPane gridPane = new GridPane();
        gridPane.setAlignment(Pos.CENTER);

        for (int i = 0; i < 3; i++) {
            ColumnConstraints col = new ColumnConstraints();
            col.setPercentWidth(33);
            col.setHgrow(Priority.ALWAYS);
            gridPane.getColumnConstraints().add(col);
        }

        for (int i = 0; i < 3; i++) {
            VBox container = new VBox(10);
            container.setAlignment(Pos.CENTER);

            ImageView imageView = new ImageView();
            imageView.setPreserveRatio(true);
            imageView.setSmooth(true);

            imageView.fitWidthProperty().bind(container.widthProperty().subtract(40));

            ImageView[] imageViews = new ImageView[3];

            imageViews[i] = imageView;

            Label title = new Label("Image " + (i+1));
            Label desc = new Label("Description " + (i+1));
            desc.setWrapText(true);

            container.getChildren().addAll(imageView, title, desc);
            gridPane.add(container, i, 0);
        }

        Scene scene = new Scene(gridPane, 1200, 700);

        return scene;
    }

    private BarChart<String, Number> createHistogramChart(int[] histogramData, String histogramTitle) {
        // Создаем оси графика
        // CategoryAxis для X (значения яркости 0, 1, 2... 255)
        CategoryAxis xAxis = new CategoryAxis();
        xAxis.setLabel("Яркость");

        // NumberAxis для Y (количество пикселей)
        NumberAxis yAxis = new NumberAxis();
        yAxis.setLabel("Количество пикселей");

        // Создаем сам график
        BarChart<String, Number> barChart = new BarChart<>(xAxis, yAxis);
        barChart.setTitle(histogramTitle);
        barChart.setLegendVisible(false); // Скрываем легенду, она нам не нужна

        // Создаем серию данных для графика
        XYChart.Series<String, Number> series = new XYChart.Series<>();

        // Заполняем данными из массива histogramData
        for (int i = 0; i < histogramData.length; i++) {
            // Добавляем столбец для каждой яркости
            series.getData().add(new XYChart.Data<>(String.valueOf(i), histogramData[i]));
        }

        // Добавляем серию данных на график
        barChart.getData().add(series);

        return barChart;
    }

    public static void main(String[] args) {
        launch();
    }
}