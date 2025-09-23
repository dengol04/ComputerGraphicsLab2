using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphicsLab2
{
    public partial class Task2 : Form
    {
        private Bitmap origBitmap;

        private int[] histogramR = new int[256];
        private int[] histogramG = new int[256];
        private int[] histogramB = new int[256];

        public Task2()
        {
            InitializeComponent();
        }

        private void butLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFD = new OpenFileDialog())
            {
                openFD.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;*.tiff";
                if (openFD.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //создаём копию, чтобы можно было менять изображение
                        origBitmap = new Bitmap(openFD.FileName);
                        picOriginal.Image = origBitmap;

                        butProcess.Enabled = true;

                        picR.Image = null;
                        picG.Image = null;
                        picB.Image = null;

                        chartR.Series.Clear();
                        chartG.Series.Clear();
                        chartB.Series.Clear();

                        chartR.Visible = false;
                        chartG.Visible = false;
                        chartB.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                    }
                }
            }
        }

        private void butProcess_Click(object sender, EventArgs e)
        {

            Bitmap bmpR = new Bitmap(origBitmap.Width, origBitmap.Height);
            Bitmap bmpG = new Bitmap(origBitmap.Width, origBitmap.Height);
            Bitmap bmpB = new Bitmap(origBitmap.Width, origBitmap.Height);

            Array.Clear(histogramR, 0, histogramR.Length);
            Array.Clear(histogramG, 0, histogramG.Length);
            Array.Clear(histogramB, 0, histogramB.Length);

            // обрабатываем каждый пиксель
            for (int y = 0; y < origBitmap.Height; y++)
            {
                for (int x = 0; x < origBitmap.Width; x++)
                {
                    Color originalColor = origBitmap.GetPixel(x, y);

                    Color colorR = Color.FromArgb(originalColor.R, 0, 0);
                    bmpR.SetPixel(x, y, colorR);

                    Color colorG = Color.FromArgb(0, originalColor.G, 0);
                    bmpG.SetPixel(x, y, colorG);

                    Color colorB = Color.FromArgb(0, 0, originalColor.B);
                    bmpB.SetPixel(x, y, colorB);

                    histogramR[originalColor.R]++;
                    histogramG[originalColor.G]++;
                    histogramB[originalColor.B]++;
                }
            }

            picR.Image = bmpR;
            picG.Image = bmpG;
            picB.Image = bmpB;

            DrawHistograms();
        }

        private void DrawHistograms()
        {
            DrawChart(chartR, histogramR, Color.Red);
            DrawChart(chartG, histogramG, Color.Green);
            DrawChart(chartB, histogramB, Color.Blue);
        }

        private void DrawChart(System.Windows.Forms.DataVisualization.Charting.Chart chart,
                                    int[] data, Color color)
        {
            chart.Visible = true;
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea("DefaultArea");
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 255;
            chartArea.AxisY.Title = "Пиксели";
            chart.ChartAreas.Add(chartArea);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series("DataSeries")
            {
                //ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line, 
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area,
                Color = color,
                //BorderWidth = 2
            };

            for (int i = 0; i < data.Length; i++)
            {
                series.Points.AddXY(i, data[i]);
            }

            chart.Series.Add(series);
            chart.Legends.Clear();
        }
    }
}
