namespace LottoTeamQuiz
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.grid_Viewer = new System.Windows.Forms.DataGridView();
            this.cbo_lottoNum = new System.Windows.Forms.ComboBox();
            this.btn_Analyze = new System.Windows.Forms.Button();
            this.largImgList = new System.Windows.Forms.ImageList(this.components);
            this.list_Img = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolProcBar = new System.Windows.Forms.ToolStripProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Viewer)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "회차 라벨";
            // 
            // grid_Viewer
            // 
            this.grid_Viewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Viewer.Location = new System.Drawing.Point(12, 235);
            this.grid_Viewer.Name = "grid_Viewer";
            this.grid_Viewer.ReadOnly = true;
            this.grid_Viewer.RowTemplate.Height = 23;
            this.grid_Viewer.Size = new System.Drawing.Size(709, 193);
            this.grid_Viewer.TabIndex = 1;
            this.grid_Viewer.SelectionChanged += new System.EventHandler(this.grid_Viewer_SelectionChanged);
            // 
            // cbo_lottoNum
            // 
            this.cbo_lottoNum.FormattingEnabled = true;
            this.cbo_lottoNum.Location = new System.Drawing.Point(571, 70);
            this.cbo_lottoNum.Name = "cbo_lottoNum";
            this.cbo_lottoNum.Size = new System.Drawing.Size(88, 20);
            this.cbo_lottoNum.TabIndex = 2;
            this.cbo_lottoNum.Text = "전체";
            this.cbo_lottoNum.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_Analyze
            // 
            this.btn_Analyze.Location = new System.Drawing.Point(768, 235);
            this.btn_Analyze.Name = "btn_Analyze";
            this.btn_Analyze.Size = new System.Drawing.Size(75, 24);
            this.btn_Analyze.TabIndex = 4;
            this.btn_Analyze.Text = "통계";
            this.btn_Analyze.UseVisualStyleBackColor = true;
            this.btn_Analyze.Click += new System.EventHandler(this.btn_Analyze_Click);
            // 
            // largImgList
            // 
            this.largImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.largImgList.ImageSize = new System.Drawing.Size(16, 16);
            this.largImgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // list_Img
            // 
            this.list_Img.BackColor = System.Drawing.SystemColors.Menu;
            this.list_Img.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_Img.Location = new System.Drawing.Point(44, 118);
            this.list_Img.Name = "list_Img";
            this.list_Img.Size = new System.Drawing.Size(825, 97);
            this.list_Img.TabIndex = 6;
            this.list_Img.UseCompatibleStateImageBehavior = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTime,
            this.toolProcBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(925, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolTime
            // 
            this.toolTime.Name = "toolTime";
            this.toolTime.Size = new System.Drawing.Size(121, 17);
            this.toolTime.Text = "toolStripStatusLabel1";
            // 
            // toolProcBar
            // 
            this.toolProcBar.Name = "toolProcBar";
            this.toolProcBar.Size = new System.Drawing.Size(100, 16);
            this.toolProcBar.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.list_Img);
            this.Controls.Add(this.btn_Analyze);
            this.Controls.Add(this.cbo_lottoNum);
            this.Controls.Add(this.grid_Viewer);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Viewer)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grid_Viewer;
        private System.Windows.Forms.ComboBox cbo_lottoNum;
        private System.Windows.Forms.Button btn_Analyze;
        private System.Windows.Forms.ImageList largImgList;
        private System.Windows.Forms.ListView list_Img;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolTime;
        private System.Windows.Forms.ToolStripProgressBar toolProcBar;
        private System.Windows.Forms.Timer timer1;
    }
}

