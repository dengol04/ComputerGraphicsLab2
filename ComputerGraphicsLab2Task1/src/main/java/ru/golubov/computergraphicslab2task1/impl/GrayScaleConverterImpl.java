package ru.golubov.computergraphicslab2task1.impl;

import javafx.scene.image.Image;
import javafx.scene.image.PixelReader;
import javafx.scene.image.PixelWriter;
import javafx.scene.image.WritableImage;
import javafx.scene.paint.Color;
import ru.golubov.computergraphicslab2task1.GrayScaleConverter;

public class GrayScaleConverterImpl implements GrayScaleConverter {
    private Image originaImage;
    private enum ColorType {
        PAL_NTSC,
        HDTV
    }
    public GrayScaleConverterImpl(Image originalImage) {
        this.originaImage = originalImage;
    }
    @Override
    public Image convertToPAL_NTSC() {
        Image convertedImage = convertTo(ColorType.PAL_NTSC);
        return convertedImage;
    }

    @Override
    public Image convertToHDTV() {
        Image convertedImage = convertTo(ColorType.HDTV);
        return convertedImage;
    }

    private Image convertTo(ColorType colorType) {
        WritableImage convertedImage = new WritableImage(originaImage.getPixelReader(), (int)originaImage.getWidth(),
                (int)originaImage.getHeight());

        PixelReader originalImagePixelReader = originaImage.getPixelReader();
        PixelWriter convertedIImagePixelWriter = convertedImage.getPixelWriter();
        for (int x = 0; x < (int) originaImage.getWidth(); ++x)
            for (int y = 0; y < (int) originaImage.getHeight(); ++y) {
                Color originalImagePixelColor = originalImagePixelReader.getColor(x, y);
                double Y;
                if (colorType == ColorType.PAL_NTSC)
                    Y = 0.299*originalImagePixelColor.getRed() + 0.587*originalImagePixelColor.getGreen() +
                            0.114*originalImagePixelColor.getBlue();
                else
                    Y = 0.2126*originalImagePixelColor.getRed() + 0.7152*originalImagePixelColor.getGreen() +
                            0.0722*originalImagePixelColor.getBlue();
                convertedIImagePixelWriter.setColor(x, y, Color.color(Y, Y ,Y));
            }

        return convertedImage;
    }
}
