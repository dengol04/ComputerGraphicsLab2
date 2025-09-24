package ru.golubov.computergraphicslab2task1;

import javafx.application.Application;
import javafx.geometry.Pos;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.chart.*;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.ColumnConstraints;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.Priority;
import javafx.scene.layout.VBox;
import javafx.stage.FileChooser;
import javafx.stage.Modality;
import javafx.stage.Stage;
import ru.golubov.computergraphicslab2task1.impl.DifferenceBetweenHalftoneImagesFinderImpl;
import ru.golubov.computergraphicslab2task1.impl.GrayScaleConverterImpl;
import ru.golubov.computergraphicslab2task1.impl.IntensityHistogramDataCalculatorImpl;

import java.io.File;
import java.io.IOException;
import java.util.Arrays;
import java.util.List;

public class Lab2Task1 extends Application {
    Image originalImage;
    Image imageInColorsPAL_NTSC;
    Image imageInColorsHDTV;
    GrayScaleConverter grayScaleConverter;
    DifferenceBetweenHalftoneImagesFinder differenceBetweenHalftoneImagesFinder;
    Stage primaryStage;
    @Override
    public void start(Stage stage) throws IOException {
        primaryStage = stage;
        FileChooser fileChooser = new FileChooser();

        Button chooserFileButton = new Button("Choose file");

        chooserFileButton.setOnAction(e -> {
            File choosenFile = fileChooser.showOpenDialog(stage);

            try {
                originalImage = new Image(choosenFile.toURI().toString());
                if (originalImage.isError())
                    throw new IllegalArgumentException("Error loading image: " + choosenFile.toURI());
            } catch (IllegalArgumentException error) {
                createErrorStage(error.getMessage());
            }

            grayScaleConverter = new GrayScaleConverterImpl(originalImage);

            imageInColorsPAL_NTSC = grayScaleConverter.convertToPAL_NTSC();
            imageInColorsHDTV = grayScaleConverter.convertToHDTV();

            differenceBetweenHalftoneImagesFinder = new DifferenceBetweenHalftoneImagesFinderImpl(imageInColorsPAL_NTSC,
                    imageInColorsHDTV);

            GridPane gridPaneForGrayImagesScene = generateGridPaneForGrayImagesScene();

            generateGrayImagesAndHistogramsForGrayImagesScene(gridPaneForGrayImagesScene);

            Scene grayImagesScene = new Scene(gridPaneForGrayImagesScene);
            stage.setScene(grayImagesScene);
        });


        Scene scene = new Scene(chooserFileButton, 320, 240);
        stage.setTitle("Task1");
        stage.setScene(scene);
        stage.show();
    }

    private void generateGrayImagesAndHistogramsForGrayImagesScene(GridPane container) {
        Image[] images = new Image[] {imageInColorsPAL_NTSC, imageInColorsHDTV, differenceBetweenHalftoneImagesFinder.findDifference()};

        IntensityHistogramDataCalculator intensityHistogramDataCalculatorForPAL_NTSC = new IntensityHistogramDataCalculatorImpl(imageInColorsPAL_NTSC);
        IntensityHistogramDataCalculator intensityHistogramDataCalculatorForHDTV = new IntensityHistogramDataCalculatorImpl(imageInColorsHDTV);
        List<BarChart<String, Number>> histograms = Arrays.asList(
                createHistogramChart(intensityHistogramDataCalculatorForPAL_NTSC.calculate(), "PAL/NTSC"),
                createHistogramChart(intensityHistogramDataCalculatorForHDTV.calculate(), "HDTV"),
                createDifferenceHistogram("Разность полутоновых изображений")
        );

        for (int i = 0; i < 3; ++i) {
            ImageView imageView = new ImageView(images[i]);
            imageView.setPreserveRatio(true);
            imageView.setSmooth(true);
            VBox vbox = new VBox(10);
            vbox.setAlignment(Pos.CENTER);
            imageView.fitWidthProperty().bind(vbox.widthProperty().subtract(40));
            var barchart = histograms.get(i);
            vbox.getChildren().addAll(imageView, barchart);
            container.add(vbox, i, 0);
        }
    }

    private GridPane generateGridPaneForGrayImagesScene() {
        GridPane gridPaneForGrayImagesScene = new GridPane();
        gridPaneForGrayImagesScene.setAlignment(Pos.CENTER);

        for (int i = 0; i < 3; i++) {
            ColumnConstraints col = new ColumnConstraints();
            col.setPercentWidth(33);
            col.setHgrow(Priority.ALWAYS);
            gridPaneForGrayImagesScene.getColumnConstraints().add(col);
        }

        return gridPaneForGrayImagesScene;
    }

    private BarChart<String, Number> createHistogramChart(int[] histogramData, String histogramTitle) {
        CategoryAxis xAxis = new CategoryAxis();
        xAxis.setLabel("Яркость");

        NumberAxis yAxis = new NumberAxis();
        yAxis.setLabel("Количество пикселей");

        BarChart<String, Number> barChart = new BarChart<>(xAxis, yAxis);
        barChart.setTitle(histogramTitle);
        barChart.setLegendVisible(false);

        XYChart.Series<String, Number> series = new XYChart.Series<>();

        for (int i = 0; i < histogramData.length; i++) {
            series.getData().add(new XYChart.Data<>(String.valueOf(i), histogramData[i]));
        }

        barChart.getData().add(series);

        return barChart;
    }

    private BarChart<String, Number> createDifferenceHistogram(String title) {
        IntensityHistogramDataCalculator intensityHistogramDataCalculatorHDTV = new IntensityHistogramDataCalculatorImpl(imageInColorsHDTV);
        int[] histogramDataHDTV = intensityHistogramDataCalculatorHDTV.calculate();
        IntensityHistogramDataCalculator intensityHistogramDataCalculatorPAL_NTSC = new IntensityHistogramDataCalculatorImpl(imageInColorsPAL_NTSC);
        int[] histogramDataPAL_NTSC = intensityHistogramDataCalculatorPAL_NTSC.calculate();

        CategoryAxis xAxis = new CategoryAxis();
        NumberAxis yAxis = new NumberAxis();
        xAxis.setLabel("Интенсивность");
        yAxis.setLabel("Количество пикселей");

        BarChart<String, Number> chart = new BarChart<>(xAxis, yAxis);
        chart.setTitle(title);
        chart.setLegendVisible(true);

        XYChart.Series<String, Number> series1 = new XYChart.Series<>();
        series1.setName("PAL/NTSC (0.299R+0.587G+0.114B)");

        XYChart.Series<String, Number> series2 = new XYChart.Series<>();
        series2.setName("HDTV (0.2126R+0.7152+0.0722B)");

        int groupSize = 10;
        for (int rangeStart = 0; rangeStart < 256; rangeStart += groupSize) {
            int rangeEnd = Math.min(rangeStart + groupSize - 1, 255);
            String rangeLabel = rangeStart + "-" + rangeEnd;

            int sum1 = 0;
            int sum2 = 0;
            for (int i = rangeStart; i <= rangeEnd; ++i) {
                sum1 += histogramDataPAL_NTSC[i];
                sum2 += histogramDataHDTV[i];
            }

            series1.getData().add(new XYChart.Data<>(rangeLabel, sum1));
            series2.getData().add(new XYChart.Data<>(rangeLabel, sum2));
        }

        chart.getData().addAll(series1, series2);

        chart.setStyle("-fx-bar-fill: derive(-fx-background, -30%);");

        return chart;
    }

    private void createErrorStage(String errorMessage) {
        Stage errorStage = new Stage();
        errorStage.initModality(Modality.APPLICATION_MODAL);
        errorStage.initOwner(primaryStage);

        Group errorStageSceneRoot = new Group();

        Label errorLabel = new Label("Error: " + errorMessage);
        errorStageSceneRoot.getChildren().add(errorLabel);

        Scene errorStageScene = new Scene(errorStageSceneRoot, 500, 100);
        errorStage.setScene(errorStageScene);
        errorStage.show();
    }

    public static void main(String[] args) {
        launch();
    }
}