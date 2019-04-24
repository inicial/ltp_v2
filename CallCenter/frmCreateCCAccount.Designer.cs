namespace CallCenter
{
    partial class frmCreateCCAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.cbPartner = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wbInfo = new System.Windows.Forms.WebBrowser();
            this.toolStripPanel = new System.Windows.Forms.ToolStrip();
            this.tsBtnCreateAccount = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAccountViewer = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.toolStripPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Месяц:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Год:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Партнер:";
            // 
            // cbMonth
            // 
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(71, 73);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(315, 21);
            this.cbMonth.TabIndex = 2;
            this.cbMonth.EnabledChanged += new System.EventHandler(this.cbMonth_EnabledChanged);
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(71, 19);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(315, 21);
            this.cbYear.TabIndex = 1;
            this.cbYear.EnabledChanged += new System.EventHandler(this.cbYear_EnabledChanged);
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // cbPartner
            // 
            this.cbPartner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartner.FormattingEnabled = true;
            this.cbPartner.Location = new System.Drawing.Point(71, 46);
            this.cbPartner.Name = "cbPartner";
            this.cbPartner.Size = new System.Drawing.Size(315, 21);
            this.cbPartner.TabIndex = 0;
            this.cbPartner.EnabledChanged += new System.EventHandler(this.cbPartner_EnabledChanged);
            this.cbPartner.SelectedIndexChanged += new System.EventHandler(this.cbPartner_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMonth);
            this.groupBox1.Controls.Add(this.cbPartner);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbYear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные для создания счета";
            // 
            // wbInfo
            // 
            this.wbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbInfo.Location = new System.Drawing.Point(0, 157);
            this.wbInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbInfo.Name = "wbInfo";
            this.wbInfo.Size = new System.Drawing.Size(413, 269);
            this.wbInfo.TabIndex = 1;
            // 
            // toolStripPanel
            // 
            this.toolStripPanel.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnCreateAccount,
            this.tsBtnAccountViewer});
            this.toolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanel.Name = "toolStripPanel";
            this.toolStripPanel.Size = new System.Drawing.Size(413, 31);
            this.toolStripPanel.TabIndex = 2;
            this.toolStripPanel.Text = "toolStrip1";
            // 
            // tsBtnCreateAccount
            // 
            this.tsBtnCreateAccount.Image = global::CallCenter.Properties.Resources.Add;
            this.tsBtnCreateAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreateAccount.Name = "tsBtnCreateAccount";
            this.tsBtnCreateAccount.Size = new System.Drawing.Size(105, 28);
            this.tsBtnCreateAccount.Text = "Создать счет";
            this.tsBtnCreateAccount.Click += new System.EventHandler(this.tsBtnCreateAccount_Click);
            // 
            // tsBtnAccountViewer
            // 
            this.tsBtnAccountViewer.Image = global::CallCenter.Properties.Resources.Print;
            this.tsBtnAccountViewer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAccountViewer.Name = "tsBtnAccountViewer";
            this.tsBtnAccountViewer.Size = new System.Drawing.Size(109, 28);
            this.tsBtnAccountViewer.Text = "Открыть счет";
            this.tsBtnAccountViewer.Click += new System.EventHandler(this.tsBtnAccountViewer_Click);
            // 
            // frmCreateCCAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 426);
            this.Controls.Add(this.wbInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(421, 450);
            this.Name = "frmCreateCCAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание счета для CallCenter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStripPanel.ResumeLayout(false);
            this.toolStripPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.ComboBox cbPartner;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser wbInfo;
        private System.Windows.Forms.ToolStrip toolStripPanel;
        private System.Windows.Forms.ToolStripButton tsBtnCreateAccount;
        private System.Windows.Forms.ToolStripButton tsBtnAccountViewer;
    }
}