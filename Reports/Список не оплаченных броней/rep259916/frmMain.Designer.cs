namespace rep259916
{
    partial class frmMain
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnOnlyBron = new System.Windows.Forms.ToolStripButton();
            this.tsBtnOnlyCruise = new System.Windows.Forms.ToolStripButton();
            this.tsBtnOnlyNotNormalPercent = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsEdtCountryName = new System.Windows.Forms.ToolStripComboBox();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnOnlyBron,
            this.tsBtnOnlyCruise,
            this.tsBtnOnlyNotNormalPercent,
            this.toolStripLabel1,
            this.tsEdtCountryName});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(655, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnOnlyBron
            // 
            this.tsBtnOnlyBron.Image = global::rep259916.Properties.Resources.Print;
            this.tsBtnOnlyBron.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOnlyBron.Name = "tsBtnOnlyBron";
            this.tsBtnOnlyBron.Size = new System.Drawing.Size(113, 28);
            this.tsBtnOnlyBron.Text = "Только Брони";
            this.tsBtnOnlyBron.Click += new System.EventHandler(this.tsBtnOnlyBron_Click);
            // 
            // tsBtnOnlyCruise
            // 
            this.tsBtnOnlyCruise.Image = global::rep259916.Properties.Resources.Print;
            this.tsBtnOnlyCruise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOnlyCruise.Name = "tsBtnOnlyCruise";
            this.tsBtnOnlyCruise.Size = new System.Drawing.Size(119, 28);
            this.tsBtnOnlyCruise.Text = "Только Круизы";
            this.tsBtnOnlyCruise.Click += new System.EventHandler(this.tsBtnOnlyCruise_Click);
            // 
            // tsBtnOnlyNotNormalPercent
            // 
            this.tsBtnOnlyNotNormalPercent.Image = global::rep259916.Properties.Resources.Print;
            this.tsBtnOnlyNotNormalPercent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOnlyNotNormalPercent.Name = "tsBtnOnlyNotNormalPercent";
            this.tsBtnOnlyNotNormalPercent.Size = new System.Drawing.Size(74, 28);
            this.tsBtnOnlyNotNormalPercent.Text = "> 100%";
            this.tsBtnOnlyNotNormalPercent.Click += new System.EventHandler(this.tsBtnOnlyNotNormalPercent_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 28);
            this.toolStripLabel1.Text = "Страна";
            // 
            // tsEdtCountryName
            // 
            this.tsEdtCountryName.Name = "tsEdtCountryName";
            this.tsEdtCountryName.Size = new System.Drawing.Size(121, 31);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.Location = new System.Drawing.Point(0, 31);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(655, 320);
            this.reportViewer.TabIndex = 1;
            this.reportViewer.BookmarkNavigation += new Microsoft.Reporting.WinForms.BookmarkNavigationEventHandler(this.reportViewer_BookmarkNavigation);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 351);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "Список не оплаченных броней";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnOnlyBron;
        private System.Windows.Forms.ToolStripButton tsBtnOnlyCruise;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tsEdtCountryName;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.ToolStripButton tsBtnOnlyNotNormalPercent;
    }
}

