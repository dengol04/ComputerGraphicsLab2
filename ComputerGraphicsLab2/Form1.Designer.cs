namespace ComputerGraphicsLab2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TrackBar trackBarHue;
        private System.Windows.Forms.TrackBar trackBarSat;
        private System.Windows.Forms.TrackBar trackBarVal;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.trackBarHue = new System.Windows.Forms.TrackBar();
            this.trackBarSat = new System.Windows.Forms.TrackBar();
            this.trackBarVal = new System.Windows.Forms.TrackBar();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVal)).BeginInit();

            this.SuspendLayout();

            // pictureBox1 (оригинал)
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // pictureBox2 (результат)
            this.pictureBox2.Location = new System.Drawing.Point(330, 12);
            this.pictureBox2.Size = new System.Drawing.Size(300, 300);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // trackBarHue
            this.trackBarHue.Location = new System.Drawing.Point(12, 330);
            this.trackBarHue.Minimum = -180;
            this.trackBarHue.Maximum = 180;
            this.trackBarHue.Value = 0;
            this.trackBarHue.Width = 300;
            this.trackBarHue.Scroll += new System.EventHandler(this.trackBar_Scroll);

            // trackBarSat
            this.trackBarSat.Location = new System.Drawing.Point(330, 330);
            this.trackBarSat.Minimum = 0;
            this.trackBarSat.Maximum = 200;
            this.trackBarSat.Value = 100;
            this.trackBarSat.Width = 300;
            this.trackBarSat.Scroll += new System.EventHandler(this.trackBar_Scroll);

            // trackBarVal
            this.trackBarVal.Location = new System.Drawing.Point(12, 380);
            this.trackBarVal.Minimum = 0;
            this.trackBarVal.Maximum = 200;
            this.trackBarVal.Value = 100;
            this.trackBarVal.Width = 300;
            this.trackBarVal.Scroll += new System.EventHandler(this.trackBar_Scroll);

            // btnLoad
            this.btnLoad.Location = new System.Drawing.Point(330, 380);
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(450, 380);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(650, 430);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.trackBarHue);
            this.Controls.Add(this.trackBarSat);
            this.Controls.Add(this.trackBarVal);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Text = "HSV";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVal)).EndInit();

            this.ResumeLayout(false);
        }
    }
}
