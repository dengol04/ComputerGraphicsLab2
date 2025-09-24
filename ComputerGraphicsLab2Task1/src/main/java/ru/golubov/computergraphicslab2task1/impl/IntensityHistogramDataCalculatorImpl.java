package ru.golubov.computergraphicslab2task1.impl;

import javafx.scene.image.Image;
import javafx.scene.image.PixelReader;
import ru.golubov.computergraphicslab2task1.IntensityHistogramDataCalculator;

public class IntensityHistogramDataCalculatorImpl implements IntensityHistogramDataCalculator {
    private Image originalImage;

    public IntensityHistogramDataCalculatorImpl(Image originalImage) {
        this.originalImage = originalImage;
    }

    @Override
    public int[] calculate() {
        PixelReader originalImagePixelReader = originalImage.getPixelReader();
        int[] resultCalculation = new int[256];
        for (int x = 0; x < originalImage.getWidth(); ++x)
            for (int y = 0; y < originalImage.getHeight(); ++y) {
                short intensityOfCurrentPixel = (short)Math.round(originalImagePixelReader.getColor(x, y).getRed() * 250);
                ++resultCalculation[intensityOfCurrentPixel];
            }

        return resultCalculation;
    }
}
