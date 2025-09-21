using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComputerGraphicsLab2
{
    internal class GrayScaleConverter
    {
        private Image originalImage;

        public GrayScaleConverter(Image originalImage)
        {
            this.originalImage = originalImage;
        }

        public Image convertToPAL_NTSC()
        {
            Bitmap bitmap = new Bitmap(originalImage);

            for (int x = 0; x < bitmap.Width; ++x)
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    Color originalColorOfPixel = bitmap.GetPixel(x, y);
                    byte Y = (byte)(0.299 * originalColorOfPixel.R + 0.587 * originalColorOfPixel.G +
                        0.114 * originalColorOfPixel.B);

                    bitmap.SetPixel(x, y, Color.FromArgb(Y, Y, Y));
                }

            return bitmap;
        }

        public Image convertToHDTV()
        {
            Bitmap bitmap = new Bitmap(originalImage);

            for (int x = 0; x < bitmap.Width; ++x)
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    Color originalColorOfPixel = bitmap.GetPixel(x, y);
                    byte Y = (byte)(0.2126 * originalColorOfPixel.R + 0.7152 * originalColorOfPixel.G +
                        0.0722 * originalColorOfPixel.B);

                    bitmap.SetPixel(x, y, Color.FromArgb(Y, Y, Y));
                }

            return bitmap;
        }
    }
}
