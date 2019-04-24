namespace ltp_v2.AccountCreator
{
    partial class frmAccountControl
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
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.fltAccountType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.fltCacheType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.fltYear = new System.Windows.Forms.ToolStripComboBox();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.reportViewer = new ltp_v2.Controls.Forms.lwMRViwer();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.fltAccountType,
            this.toolStripLabel2,
            this.fltCacheType,
            this.toolStripLabel3,
            this.fltYear,
            this.tsBtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(772, 31);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(28, 28);
            this.toolStripLabel1.Text = "Тип";
            // 
            // fltAccountType
            // 
            this.fltAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fltAccountType.Name = "fltAccountType";
            this.fltAccountType.Size = new System.Drawing.Size(121, 31);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(47, 28);
            this.toolStripLabel2.Text = "Оплата";
            // 
            // fltCacheType
            // 
            this.fltCacheType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fltCacheType.Name = "fltCacheType";
            this.fltCacheType.Size = new System.Drawing.Size(121, 31);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(67, 28);
            this.toolStripLabel3.Text = "Месяц/Год";
            // 
            // fltYear
            // 
            this.fltYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fltYear.Name = "fltYear";
            this.fltYear.Size = new System.Drawing.Size(121, 31);
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Image = global::ltp_v2.AccountCreator.LocalResource.Refresh;
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(89, 28);
            this.tsBtnRefresh.Text = "Обновить";
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.Location = new System.Drawing.Point(0, 31);
            this.reportViewer.MailAddress = "";
            this.reportViewer.MailMessage = "";
            this.reportViewer.MailSubject = "";
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ShowBackButton = false;
            this.reportViewer.ShowContextMenu = false;
            this.reportViewer.ShowCredentialPrompts = false;
            this.reportViewer.ShowDocumentMapButton = false;
            this.reportViewer.ShowFindControls = false;
            this.reportViewer.ShowParameterPrompts = false;
            this.reportViewer.ShowPromptAreaButton = false;
            this.reportViewer.ShowRefreshButton = false;
            this.reportViewer.ShowSendButton = false;
            this.reportViewer.ShowStopButton = false;
            this.reportViewer.Size = new System.Drawing.Size(772, 474);
            this.reportViewer.TabIndex = 6;
            this.reportViewer.BookmarkNavigation += new Microsoft.Reporting.WinForms.BookmarkNavigationEventHandler(this.reportViewer_BookmarkNavigation);
            // 
            // frmAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 505);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmAccountControl";
            this.Text = "Журнал счетов";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox fltAccountType;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private ltp_v2.Controls.Forms.lwMRViwer reportViewer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox fltCacheType;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox fltYear;
    }
}