namespace LottoTeamQuiz
{
    partial class StaticsEX
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
            this.IndexedGrid = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.indexGrid = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.descGrid = new System.Windows.Forms.DataGridView();
            this.IndexedGrid.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // IndexedGrid
            // 
            this.IndexedGrid.Controls.Add(this.tabPage1);
            this.IndexedGrid.Controls.Add(this.tabPage2);
            this.IndexedGrid.Location = new System.Drawing.Point(41, 57);
            this.IndexedGrid.Name = "IndexedGrid";
            this.IndexedGrid.SelectedIndex = 0;
            this.IndexedGrid.Size = new System.Drawing.Size(673, 344);
            this.IndexedGrid.TabIndex = 0;
            this.IndexedGrid.SelectedIndexChanged += new System.EventHandler(this.IndexedGrid_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.indexGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(665, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "번호순";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // indexGrid
            // 
            this.indexGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.indexGrid.Location = new System.Drawing.Point(141, 74);
            this.indexGrid.Name = "indexGrid";
            this.indexGrid.RowTemplate.Height = 23;
            this.indexGrid.Size = new System.Drawing.Size(406, 218);
            this.indexGrid.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.descGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(665, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "당첨순";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // descGrid
            // 
            this.descGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.descGrid.Location = new System.Drawing.Point(98, 60);
            this.descGrid.Name = "descGrid";
            this.descGrid.RowTemplate.Height = 23;
            this.descGrid.Size = new System.Drawing.Size(406, 218);
            this.descGrid.TabIndex = 1;
            // 
            // StaticsEX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.IndexedGrid);
            this.Name = "StaticsEX";
            this.Text = "StaticsEX";
            this.Load += new System.EventHandler(this.StaticsEX_Load);
            this.IndexedGrid.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.indexGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.descGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl IndexedGrid;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView indexGrid;
        private System.Windows.Forms.DataGridView descGrid;
    }
}