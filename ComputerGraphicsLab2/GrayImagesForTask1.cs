using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphicsLab2
{
    public partial class GrayImagesForTask1 : Form
    {
        Image imageInColorSpacesUsedInPAL_NTSC;
        Image imageInColorForHumansEyes;
        public GrayImagesForTask1()
        {
            InitializeComponent();
        }
        public GrayImagesForTask1(Image imageInColorSpacesUsedInPAL_NTSC, Image imageInColorForHumansEyes)
        {
            InitializeComponent();
            this.imageInColorSpacesUsedInPAL_NTSC = imageInColorSpacesUsedInPAL_NTSC;
            this.imageInColorForHumansEyes = imageInColorForHumansEyes;
        }

        private void GrayImagesForTask1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = imageInColorSpacesUsedInPAL_NTSC;
            pictureBox2.Image = imageInColorForHumansEyes;

            Bitmap bitmapForPAL = new Bitmap(imageInColorSpacesUsedInPAL_NTSC);
            Bitmap bitmapForHumanEyes = new Bitmap(imageInColorForHumansEyes);
            Bitmap differenceBitmap = new Bitmap(imageInColorForHumansEyes.Width, imageInColorForHumansEyes.Height);

            for (int x = 0; x < differenceBitmap.Width; ++x)
                for (int y = 0; y < differenceBitmap.Height; ++y)
                {
                    byte difference = (byte)Math.Abs(bitmapForPAL.GetPixel(x, y).R - bitmapForHumanEyes.GetPixel(x, y).R);
                    differenceBitmap.SetPixel(x, y, Color.FromArgb(difference, difference, difference));
                }

            pictureBox3.Image = differenceBitmap; 
        }

    }
}
