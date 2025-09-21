package ru.golubov.computergraphicslab2task1;

import javafx.scene.image.Image;

public interface GrayScaleConverter {
    Image convertToPAL_NTSC();
    Image convertToHDTV();
}
