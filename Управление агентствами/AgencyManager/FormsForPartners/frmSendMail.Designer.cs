namespace AgencyManager.FormsForPartners
{
    partial class frmSendMail
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabOnLine = new System.Windows.Forms.TabPage();
            this.tabAvia = new System.Windows.Forms.TabPage();
            this.gbDogovors = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edt_Email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edt_Phones = new System.Windows.Forms.TextBox();
            this.edt_FullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edt_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edt_INN = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnSendOnLine = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSendRootLogin = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSendAvia = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSendDogovors = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSend = new System.Windows.Forms.ToolStripButton();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.TabControl.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabOnLine);
            this.TabControl.Controls.Add(this.tabAvia);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabControl.Location = new System.Drawing.Point(0, 410);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(800, 228);
            this.TabControl.TabIndex = 32;
            // 
            // tabOnLine
            // 
            this.tabOnLine.Location = new System.Drawing.Point(4, 22);
            this.tabOnLine.Name = "tabOnLine";
            this.tabOnLine.Size = new System.Drawing.Size(792, 202);
            this.tabOnLine.TabIndex = 0;
            this.tabOnLine.Text = "On-Line";
            this.tabOnLine.UseVisualStyleBackColor = true;
            // 
            // tabAvia
            // 
            this.tabAvia.Location = new System.Drawing.Point(4, 22);
            this.tabAvia.Name = "tabAvia";
            this.tabAvia.Size = new System.Drawing.Size(792, 202);
            this.tabAvia.TabIndex = 2;
            this.tabAvia.Text = "Avia";
            this.tabAvia.UseVisualStyleBackColor = true;
            // 
            // gbDogovors
            // 
            this.gbDogovors.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDogovors.Location = new System.Drawing.Point(0, 165);
            this.gbDogovors.Name = "gbDogovors";
            this.gbDogovors.Size = new System.Drawing.Size(800, 245);
            this.gbDogovors.TabIndex = 30;
            this.gbDogovors.TabStop = false;
            this.gbDogovors.Text = "Договора";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.toolStrip2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(800, 165);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Данные по партнеру";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edt_Email);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.edt_Phones);
            this.panel1.Controls.Add(this.edt_FullName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.edt_Name);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.edt_INN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(150, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 146);
            this.panel1.TabIndex = 18;
            // 
            // edt_Email
            // 
            this.edt_Email.Location = new System.Drawing.Point(112, 117);
            this.edt_Email.Name = "edt_Email";
            this.edt_Email.ReadOnly = true;
            this.edt_Email.Size = new System.Drawing.Size(286, 20);
            this.edt_Email.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "E-Mail:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Краткое название:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "ИНН:";
            // 
            // edt_Phones
            // 
            this.edt_Phones.Location = new System.Drawing.Point(112, 91);
            this.edt_Phones.Name = "edt_Phones";
            this.edt_Phones.ReadOnly = true;
            this.edt_Phones.Size = new System.Drawing.Size(286, 20);
            this.edt_Phones.TabIndex = 16;
            // 
            // edt_FullName
            // 
            this.edt_FullName.Location = new System.Drawing.Point(112, 38);
            this.edt_FullName.Name = "edt_FullName";
            this.edt_FullName.ReadOnly = true;
            this.edt_FullName.Size = new System.Drawing.Size(286, 20);
            this.edt_FullName.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Полное название:";
            // 
            // edt_Name
            // 
            this.edt_Name.Location = new System.Drawing.Point(112, 12);
            this.edt_Name.Name = "edt_Name";
            this.edt_Name.ReadOnly = true;
            this.edt_Name.Size = new System.Drawing.Size(286, 20);
            this.edt_Name.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Телефон:";
            // 
            // edt_INN
            // 
            this.edt_INN.Location = new System.Drawing.Point(112, 65);
            this.edt_INN.Name = "edt_INN";
            this.edt_INN.ReadOnly = true;
            this.edt_INN.Size = new System.Drawing.Size(286, 20);
            this.edt_INN.TabIndex = 15;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsBtnSendOnLine,
            this.tsBtnSendRootLogin,
            this.tsBtnSendAvia,
            this.tsBtnSendDogovors});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(147, 146);
            this.toolStrip2.TabIndex = 17;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(102, 15);
            this.toolStripLabel1.Text = "Передать данные";
            // 
            // tsBtnSendOnLine
            // 
            this.tsBtnSendOnLine.CheckOnClick = true;
            this.tsBtnSendOnLine.Image = global::AgencyManager.Properties.Resources.UnCheck;
            this.tsBtnSendOnLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnSendOnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSendOnLine.Name = "tsBtnSendOnLine";
            this.tsBtnSendOnLine.Size = new System.Drawing.Size(113, 20);
            this.tsBtnSendOnLine.Text = "Данные ONLine";
            this.tsBtnSendOnLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsBtnSendOnLine.CheckedChanged += new System.EventHandler(this.tsBtnSendOnLine_CheckedChanged);
            // 
            // tsBtnSendRootLogin
            // 
            this.tsBtnSendRootLogin.CheckOnClick = true;
            this.tsBtnSendRootLogin.Enabled = false;
            this.tsBtnSendRootLogin.Image = global::AgencyManager.Properties.Resources.UnCheck;
            this.tsBtnSendRootLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnSendRootLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSendRootLogin.Name = "tsBtnSendRootLogin";
            this.tsBtnSendRootLogin.Size = new System.Drawing.Size(118, 20);
            this.tsBtnSendRootLogin.Text = "Главный ONLine";
            this.tsBtnSendRootLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsBtnSendRootLogin.CheckedChanged += new System.EventHandler(this.tsBtnSendOnLine_CheckedChanged);
            // 
            // tsBtnSendAvia
            // 
            this.tsBtnSendAvia.CheckOnClick = true;
            this.tsBtnSendAvia.Image = global::AgencyManager.Properties.Resources.UnCheck;
            this.tsBtnSendAvia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnSendAvia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSendAvia.Name = "tsBtnSendAvia";
            this.tsBtnSendAvia.Size = new System.Drawing.Size(96, 20);
            this.tsBtnSendAvia.Text = "Данные Avia";
            this.tsBtnSendAvia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsBtnSendAvia.CheckedChanged += new System.EventHandler(this.tsBtnSendOnLine_CheckedChanged);
            // 
            // tsBtnSendDogovors
            // 
            this.tsBtnSendDogovors.Checked = true;
            this.tsBtnSendDogovors.CheckOnClick = true;
            this.tsBtnSendDogovors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnSendDogovors.Image = global::AgencyManager.Properties.Resources.Check;
            this.tsBtnSendDogovors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnSendDogovors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSendDogovors.Name = "tsBtnSendDogovors";
            this.tsBtnSendDogovors.Size = new System.Drawing.Size(146, 20);
            this.tsBtnSendDogovors.Text = "Выбранные договора";
            this.tsBtnSendDogovors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsBtnSendDogovors.CheckedChanged += new System.EventHandler(this.tsBtnSendOnLine_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSend,
            this.tsBtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(817, 31);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnSend
            // 
            this.tsBtnSend.Image = global::AgencyManager.Properties.Resources.EMail;
            this.tsBtnSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSend.Name = "tsBtnSend";
            this.tsBtnSend.Size = new System.Drawing.Size(86, 28);
            this.tsBtnSend.Text = "Передать";
            this.tsBtnSend.Click += new System.EventHandler(this.tsBtnSend_Click);
            // 
            // tsBtnClose
            // 
            this.tsBtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnClose.Image = global::AgencyManager.Properties.Resources.Stop;
            this.tsBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClose.Name = "tsBtnClose";
            this.tsBtnClose.Size = new System.Drawing.Size(81, 28);
            this.tsBtnClose.Text = "Закрыть";
            this.tsBtnClose.Click += new System.EventHandler(this.tsBtnClose_Click);
            // 
            // pnlControls
            // 
            this.pnlControls.AutoScroll = true;
            this.pnlControls.Controls.Add(this.TabControl);
            this.pnlControls.Controls.Add(this.gbDogovors);
            this.pnlControls.Controls.Add(this.groupBox3);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(0, 31);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(817, 395);
            this.pnlControls.TabIndex = 34;
            // 
            // frmSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 426);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSendMail";
            this.Text = "Отправка данных партнеру по Е-Mail:";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSendMail_FormClosing);
            this.TabControl.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabOnLine;
        private System.Windows.Forms.TabPage tabAvia;
        private System.Windows.Forms.GroupBox gbDogovors;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edt_FullName;
        private System.Windows.Forms.TextBox edt_Name;
        private System.Windows.Forms.TextBox edt_INN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edt_Phones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnSend;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsBtnSendOnLine;
        private System.Windows.Forms.ToolStripButton tsBtnSendRootLogin;
        private System.Windows.Forms.ToolStripButton tsBtnSendAvia;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.ToolStripButton tsBtnSendDogovors;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox edt_Email;
        private System.Windows.Forms.Label label5;
    }
}