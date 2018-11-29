namespace LottoTeamQuiz
{
    partial class FrmAnalyze
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
            this.btn_NumAnalyze = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.chart_Analyze = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Analyze)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_NumAnalyze
            // 
            this.btn_NumAnalyze.Location = new System.Drawing.Point(36, 55);
            this.btn_NumAnalyze.Name = "btn_NumAnalyze";
            this.btn_NumAnalyze.Size = new System.Drawing.Size(104, 23);
            this.btn_NumAnalyze.TabIndex = 0;
            this.btn_NumAnalyze.Text = "번호별 통계";
            this.btn_NumAnalyze.UseVisualStyleBackColor = true;
            this.btn_NumAnalyze.Click += new System.EventHandler(this.btn_NumAnalyze_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(187, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "번호별 통꼐";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(319, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(453, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(577, 55);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // chart_Analyze
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_Analyze.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_Analyze.Legends.Add(legend2);
            this.chart_Analyze.Location = new System.Drawing.Point(36, 127);
            this.chart_Analyze.Name = "chart_Analyze";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_Analyze.Series.Add(series2);
            this.chart_Analyze.Size = new System.Drawing.Size(717, 311);
            this.chart_Analyze.TabIndex = 5;
            this.chart_Analyze.Text = "chart1";
            // 
            // FrmAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart_Analyze);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_NumAnalyze);
            this.Name = "FrmAnalyze";
            this.Text = "FrmAnalyze";
            ((System.ComponentModel.ISupportInitialize)(this.chart_Analyze)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_NumAnalyze;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Analyze;
    }
}