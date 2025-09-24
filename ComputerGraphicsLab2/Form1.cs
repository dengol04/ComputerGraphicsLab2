using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastBitmap;

namespace ComputerGraphicsLab2
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap processedImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(ofd.FileName);
                pictureBox1.Image = originalImage;
            }
        }

        private void ApplyChanges()
        {
            if (originalImage == null) return;

            processedImage = new Bitmap(originalImage);
            int hueShift = trackBarHue.Value;
            double satShift = trackBarSat.Value/100.0;
            double valShift = trackBarVal.Value/100.0;

            using (var fastBitmap = new FastBitmap.FastBitmap(processedImage))
            {
                for (int x = 0; x < fastBitmap.Width; x++)
                {
                    for (int y = 0; y < fastBitmap.Height; y++)
                    {
                        Color c = fastBitmap[x, y];

                        //RGB → HSV
                        RgbToHsv(c, out double h, out double s, out double v);

                        //Apply
                        h = (h + hueShift) % 360;
                        if (h < 0)
                            h += 360;

                        s = Math.Min(1, Math.Max(0, s * satShift));
                        v = Math.Min(1, Math.Max(0, v * valShift));

                        //HSV → RGB
                        Color newColor = FromHSV(h, s, v);
                        fastBitmap[x, y] = newColor;
                    }
                }
            }

            pictureBox2.Image = processedImage;
        }

        private void RgbToHsv(Color c, out double h, out double s, out double v)
        {
            double r = c.R / 255.0;
            double g = c.G / 255.0;
            double b = c.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            //Hue
            if (delta == 0)
                h = 0;
            else if (max == r && g >= b)
                h = 60 * (g - b) / delta;
            else if (max == r && g < b)
                h = 60 * (g - b) / delta + 360;
            else if (max == g)
                h = 60 * (b - r) / delta + 120;
            else // max == b
                h = 60 * (r - g) / delta + 240;

            //Saturation
            if (max == 0)
                s = 0;
            else
                s = 1 - (min / max);

            //Value
            v = max;
        }


        private void trackBar_Scroll(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (processedImage == null) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                processedImage.Save(sfd.FileName);
            }
        }

        public static Color FromHSV(double h, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(h / 60)) % 6;
            double f = h / 60 - Math.Floor(h / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            switch (hi)
            {
                case 0: return Color.FromArgb(255, v, t, p);
                case 1: return Color.FromArgb(255, q, v, p);
                case 2: return Color.FromArgb(255, p, v, t);
                case 3: return Color.FromArgb(255, p, q, v);
                case 4: return Color.FromArgb(255, t, p, v);
                default: return Color.FromArgb(255, v, p, q);
            }
        }
    }
}
