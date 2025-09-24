namespace ComputerGraphicsLab2
{
    partial class Task2
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picG = new System.Windows.Forms.PictureBox();
            this.picR = new System.Windows.Forms.PictureBox();
            this.picB = new System.Windows.Forms.PictureBox();
            this.chartB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartG = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.butProcess = new System.Windows.Forms.Button();
            this.butLoadImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartB)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartG)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOriginal.Location = new System.Drawing.Point(310, 3);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(301, 206);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 2;
            this.picOriginal.TabStop = false;
            this.picOriginal.WaitOnLoad = true;
            // 
            // picG
            // 
            this.picG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picG.Location = new System.Drawing.Point(310, 215);
            this.picG.Name = "picG";
            this.picG.Size = new System.Drawing.Size(301, 204);
            this.picG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picG.TabIndex = 3;
            this.picG.TabStop = false;
            // 
            // picR
            // 
            this.picR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picR.Location = new System.Drawing.Point(3, 215);
            this.picR.Name = "picR";
            this.picR.Size = new System.Drawing.Size(301, 204);
            this.picR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picR.TabIndex = 4;
            this.picR.TabStop = false;
            // 
            // picB
            // 
            this.picB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picB.Location = new System.Drawing.Point(617, 215);
            this.picB.Name = "picB";
            this.picB.Size = new System.Drawing.Size(302, 204);
            this.picB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picB.TabIndex = 5;
            this.picB.TabStop = false;
            // 
            // chartB
            // 
            this.chartB.BackColor = System.Drawing.SystemColors.Control;
            this.chartB.BackSecondaryColor = System.Drawing.SystemColors.Control;
            this.chartB.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chartB.ChartAreas.Add(chartArea1);
            this.chartB.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartB.Legends.Add(legend1);
            this.chartB.Location = new System.Drawing.Point(617, 425);
            this.chartB.Name = "chartB";
            this.chartB.Size = new System.Drawing.Size(302, 206);
            this.chartB.TabIndex = 6;
            this.chartB.Text = "chart1";
            this.chartB.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33223F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33555F));
            this.tableLayoutPanel1.Controls.Add(this.chartR, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chartG, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.picB, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.picG, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.picR, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartB, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.picOriginal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.butProcess, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.butLoadImage, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.55482F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.22259F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.22259F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(922, 634);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // chartR
            // 
            this.chartR.BackColor = System.Drawing.SystemColors.Control;
            this.chartR.BackSecondaryColor = System.Drawing.SystemColors.Control;
            this.chartR.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea2.Name = "ChartArea1";
            this.chartR.ChartAreas.Add(chartArea2);
            this.chartR.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartR.Legends.Add(legend2);
            this.chartR.Location = new System.Drawing.Point(3, 425);
            this.chartR.Name = "chartR";
            this.chartR.Size = new System.Drawing.Size(301, 206);
            this.chartR.TabIndex = 9;
            this.chartR.Text = "chart1";
            this.chartR.Visible = false;
            // 
            // chartG
            // 
            this.chartG.BackColor = System.Drawing.SystemColors.Control;
            this.chartG.BackSecondaryColor = System.Drawing.SystemColors.Control;
            this.chartG.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea3.Name = "ChartArea1";
            this.chartG.ChartAreas.Add(chartArea3);
            this.chartG.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartG.Legends.Add(legend3);
            this.chartG.Location = new System.Drawing.Point(310, 425);
            this.chartG.Name = "chartG";
            this.chartG.Size = new System.Drawing.Size(301, 206);
            this.chartG.TabIndex = 8;
            this.chartG.Text = "chart1";
            this.chartG.Visible = false;
            // 
            // butProcess
            // 
            this.butProcess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.butProcess.Enabled = false;
            this.butProcess.Location = new System.Drawing.Point(678, 66);
            this.butProcess.Name = "butProcess";
            this.butProcess.Size = new System.Drawing.Size(180, 80);
            this.butProcess.TabIndex = 1;
            this.butProcess.Text = "Обработать изображение";
            this.butProcess.UseVisualStyleBackColor = true;
            this.butProcess.Click += new System.EventHandler(this.butProcess_Click);
            // 
            // butLoadImage
            // 
            this.butLoadImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.butLoadImage.Location = new System.Drawing.Point(64, 66);
            this.butLoadImage.Name = "butLoadImage";
            this.butLoadImage.Size = new System.Drawing.Size(179, 80);
            this.butLoadImage.TabIndex = 10;
            this.butLoadImage.Text = "Загрузить изображение";
            this.butLoadImage.UseVisualStyleBackColor = true;
            this.butLoadImage.Click += new System.EventHandler(this.butLoadImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 634);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartB)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picG;
        private System.Windows.Forms.PictureBox picR;
        private System.Windows.Forms.PictureBox picB;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartR;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartG;
        private System.Windows.Forms.Button butProcess;
        private System.Windows.Forms.Button butLoadImage;
    }
}

