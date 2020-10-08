namespace QuanLySV
{
    partial class ThongKeDiemRenLuyen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbTKDRL = new System.Windows.Forms.Label();
            this.chartTKDRL = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartTKDRL)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTKDRL
            // 
            this.lbTKDRL.AutoSize = true;
            this.lbTKDRL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTKDRL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTKDRL.Location = new System.Drawing.Point(210, 13);
            this.lbTKDRL.Name = "lbTKDRL";
            this.lbTKDRL.Size = new System.Drawing.Size(197, 19);
            this.lbTKDRL.TabIndex = 3;
            this.lbTKDRL.Text = "Thống kê điểm rèn luyện";
            // 
            // chartTKDRL
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTKDRL.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTKDRL.Legends.Add(legend2);
            this.chartTKDRL.Location = new System.Drawing.Point(12, 44);
            this.chartTKDRL.Name = "chartTKDRL";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "SeriesTKDTL";
            this.chartTKDRL.Series.Add(series2);
            this.chartTKDRL.Size = new System.Drawing.Size(597, 394);
            this.chartTKDRL.TabIndex = 2;
            this.chartTKDRL.Text = "chart1";
            // 
            // ThongKeDiemRenLuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 450);
            this.Controls.Add(this.lbTKDRL);
            this.Controls.Add(this.chartTKDRL);
            this.Name = "ThongKeDiemRenLuyen";
            this.Text = "Thống kê điểm rèn luyện";
            this.Load += new System.EventHandler(this.ThongKeDiemRenLuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTKDRL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTKDRL;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTKDRL;
    }
}