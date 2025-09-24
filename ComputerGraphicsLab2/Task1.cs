using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphicsLab2
{
    public partial class Task1 : Form
    {
        private string imagePath;
        private GrayScaleConverter grayScaleConverter;

        public Task1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            imagePath = openFileDialog1.FileName;
            Image image = getImageFromFile(imagePath);

            grayScaleConverter = new GrayScaleConverter(image);

            Image imageForPAL = grayScaleConverter.convertToPAL_NTSC();

            Image imageForHumansEyes = grayScaleConverter.convertToHDTV();

            GrayImagesForTask1 grayImagesForm = new GrayImagesForTask1(imageForPAL, imageForHumansEyes);
            grayImagesForm.ShowDialog();
        }

        private Image getImageFromFile(string fileName)
        {
            Image image = null;
            try
            {
                image = Image.FromFile(imagePath);
            }
            catch (Exception error)
            {
                createErrorDialogForm(error.Message);
            }

            return image;
        }

        private void createErrorDialogForm(string errorMessage)
        {
            Form errorForm = new Form();
            Label errorLabel = new Label();
            errorLabel.Text = errorMessage;
            errorForm.Controls.Add(errorLabel);
            errorForm.ShowDialog();
        }
    }
}
