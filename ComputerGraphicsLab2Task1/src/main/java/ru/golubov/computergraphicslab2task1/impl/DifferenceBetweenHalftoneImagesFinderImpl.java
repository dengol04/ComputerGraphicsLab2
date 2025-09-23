package ru.golubov.computergraphicslab2task1.impl;

import javafx.scene.image.Image;
import javafx.scene.image.PixelReader;
import javafx.scene.image.PixelWriter;
import javafx.scene.image.WritableImage;
import javafx.scene.paint.Color;
import ru.golubov.computergraphicslab2task1.DifferenceBetweenHalftoneImagesFinder;

public class DifferenceBetweenHalftoneImagesFinderImpl implements DifferenceBetweenHalftoneImagesFinder {
    private Image firstHalftoneImage;
    private Image secondHalftoneImage;
    public DifferenceBetweenHalftoneImagesFinderImpl(Image firstHalftoneImage, Image secondHalftoneImage) {
        this.firstHalftoneImage = firstHalftoneImage;
        this.secondHalftoneImage = secondHalftoneImage;
    }
    @Override
    public Image findDifference() {
        PixelReader firstHalftoneImagePixelReader = firstHalftoneImage.getPixelReader();
        PixelReader secondHalftoneImagePixelReader = secondHalftoneImage.getPixelReader();

        WritableImage differenceImage = new WritableImage(firstHalftoneImagePixelReader, (int)firstHalftoneImage.getWidth(),
                (int)firstHalftoneImage.getHeight());
        PixelWriter differenceImagePixelWriter = differenceImage.getPixelWriter();

        for (int x = 0; x < firstHalftoneImage.getWidth(); ++x)
            for (int y = 0; y < firstHalftoneImage.getHeight(); ++y) {
                double difference = Math.abs(firstHalftoneImagePixelReader.getColor(x, y).getBlue() -
                        secondHalftoneImagePixelReader.getColor(x, y).getBlue()) + 0.2;

                differenceImagePixelWriter.setColor(x, y, Color.color(difference, difference, difference));
            }

        return differenceImage;
    }
}
