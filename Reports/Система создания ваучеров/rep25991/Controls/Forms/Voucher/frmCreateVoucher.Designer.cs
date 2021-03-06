﻿namespace rep25991.Controls.Forms.Voucher
{
    partial class frmCreateVoucher
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
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCreate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSplit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtTourName = new System.Windows.Forms.TextBox();
            this.edtCountryName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.edtVoucherNumber = new System.Windows.Forms.TextBox();
            this.edtBronNumber = new System.Windows.Forms.TextBox();
            this.edtContactInfo = new System.Windows.Forms.TextBox();
            this.edtPartnerLogo = new System.Windows.Forms.PictureBox();
            this.edtPartnerContact = new System.Windows.Forms.TextBox();
            this.edtPartnerName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTurist = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlServiceLine = new System.Windows.Forms.Panel();
            this.edtService = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtDateEnd = new System.Windows.Forms.DateTimePicker();
            this.edtDateBeg = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPartnerLogo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlServiceLine.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnCancel,
            this.tsBtnCreate,
            this.tsBtnSplit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(684, 31);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCancel.Image = global::rep25991.Properties.Resources.Stop;
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(77, 28);
            this.tsBtnCancel.Text = "Отмена";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // tsBtnCreate
            // 
            this.tsBtnCreate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCreate.Image = global::rep25991.Properties.Resources.Apply_Check;
            this.tsBtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreate.Name = "tsBtnCreate";
            this.tsBtnCreate.Size = new System.Drawing.Size(78, 28);
            this.tsBtnCreate.Text = "Создать";
            this.tsBtnCreate.Click += new System.EventHandler(this.tsBtnCreate_Click);
            // 
            // tsBtnSplit
            // 
            this.tsBtnSplit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnSplit.Enabled = false;
            this.tsBtnSplit.Image = global::rep25991.Properties.Resources.Edit_Text;
            this.tsBtnSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSplit.Name = "tsBtnSplit";
            this.tsBtnSplit.Size = new System.Drawing.Size(144, 28);
            this.tsBtnSplit.Text = "Разбить по строкам";
            this.tsBtnSplit.Click += new System.EventHandler(this.tsBtnSplit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtTourName);
            this.groupBox1.Controls.Add(this.edtCountryName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.edtVoucherNumber);
            this.groupBox1.Controls.Add(this.edtBronNumber);
            this.groupBox1.Controls.Add(this.edtContactInfo);
            this.groupBox1.Controls.Add(this.edtPartnerLogo);
            this.groupBox1.Controls.Add(this.edtPartnerContact);
            this.groupBox1.Controls.Add(this.edtPartnerName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 152);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Шапка ваучера";
            // 
            // edtTourName
            // 
            this.edtTourName.Enabled = false;
            this.edtTourName.Location = new System.Drawing.Point(456, 81);
            this.edtTourName.Name = "edtTourName";
            this.edtTourName.ReadOnly = true;
            this.edtTourName.Size = new System.Drawing.Size(207, 20);
            this.edtTourName.TabIndex = 19;
            // 
            // edtCountryName
            // 
            this.edtCountryName.Location = new System.Drawing.Point(456, 14);
            this.edtCountryName.Name = "edtCountryName";
            this.edtCountryName.Size = new System.Drawing.Size(207, 20);
            this.edtCountryName.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(365, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Название тура:";
            // 
            // edtVoucherNumber
            // 
            this.edtVoucherNumber.Location = new System.Drawing.Point(456, 125);
            this.edtVoucherNumber.Name = "edtVoucherNumber";
            this.edtVoucherNumber.ReadOnly = true;
            this.edtVoucherNumber.Size = new System.Drawing.Size(207, 20);
            this.edtVoucherNumber.TabIndex = 7;
            // 
            // edtBronNumber
            // 
            this.edtBronNumber.Location = new System.Drawing.Point(456, 103);
            this.edtBronNumber.Name = "edtBronNumber";
            this.edtBronNumber.Size = new System.Drawing.Size(207, 20);
            this.edtBronNumber.TabIndex = 6;
            // 
            // edtContactInfo
            // 
            this.edtContactInfo.Location = new System.Drawing.Point(456, 36);
            this.edtContactInfo.Name = "edtContactInfo";
            this.edtContactInfo.Size = new System.Drawing.Size(207, 20);
            this.edtContactInfo.TabIndex = 4;
            // 
            // edtPartnerLogo
            // 
            this.edtPartnerLogo.Location = new System.Drawing.Point(135, 86);
            this.edtPartnerLogo.Name = "edtPartnerLogo";
            this.edtPartnerLogo.Size = new System.Drawing.Size(126, 51);
            this.edtPartnerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.edtPartnerLogo.TabIndex = 9;
            this.edtPartnerLogo.TabStop = false;
            // 
            // edtPartnerContact
            // 
            this.edtPartnerContact.Enabled = false;
            this.edtPartnerContact.Location = new System.Drawing.Point(135, 58);
            this.edtPartnerContact.Name = "edtPartnerContact";
            this.edtPartnerContact.ReadOnly = true;
            this.edtPartnerContact.Size = new System.Drawing.Size(528, 20);
            this.edtPartnerContact.TabIndex = 2;
            // 
            // edtPartnerName
            // 
            this.edtPartnerName.Enabled = false;
            this.edtPartnerName.Location = new System.Drawing.Point(135, 36);
            this.edtPartnerName.Name = "edtPartnerName";
            this.edtPartnerName.ReadOnly = true;
            this.edtPartnerName.Size = new System.Drawing.Size(207, 20);
            this.edtPartnerName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "№ Ваучера:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(395, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "№ Брони:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Контактное лицо:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Страна заезда:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Логотип партнера:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Адрес партнера:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Партнер:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbTurist);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 256);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Туристы на ваучере";
            // 
            // lbTurist
            // 
            this.lbTurist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTurist.FormattingEnabled = true;
            this.lbTurist.Location = new System.Drawing.Point(3, 16);
            this.lbTurist.Name = "lbTurist";
            this.lbTurist.Size = new System.Drawing.Size(325, 237);
            this.lbTurist.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlServiceLine);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(331, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 256);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Услуга в ваучере";
            // 
            // pnlServiceLine
            // 
            this.pnlServiceLine.Controls.Add(this.edtService);
            this.pnlServiceLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlServiceLine.Location = new System.Drawing.Point(3, 49);
            this.pnlServiceLine.Name = "pnlServiceLine";
            this.pnlServiceLine.Size = new System.Drawing.Size(347, 204);
            this.pnlServiceLine.TabIndex = 2;
            // 
            // edtService
            // 
            this.edtService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtService.Location = new System.Drawing.Point(0, 0);
            this.edtService.Multiline = true;
            this.edtService.Name = "edtService";
            this.edtService.Size = new System.Drawing.Size(347, 204);
            this.edtService.TabIndex = 0;
            this.edtService.TextChanged += new System.EventHandler(this.edtService_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edtDateEnd);
            this.panel1.Controls.Add(this.edtDateBeg);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 33);
            this.panel1.TabIndex = 0;
            // 
            // edtDateEnd
            // 
            this.edtDateEnd.CustomFormat = "dd.MM.yyyy";
            this.edtDateEnd.Enabled = false;
            this.edtDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtDateEnd.Location = new System.Drawing.Point(253, 6);
            this.edtDateEnd.Name = "edtDateEnd";
            this.edtDateEnd.Size = new System.Drawing.Size(93, 20);
            this.edtDateEnd.TabIndex = 1;
            // 
            // edtDateBeg
            // 
            this.edtDateBeg.CustomFormat = "dd.MM.yyyy";
            this.edtDateBeg.Enabled = false;
            this.edtDateBeg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtDateBeg.Location = new System.Drawing.Point(122, 6);
            this.edtDateBeg.Name = "edtDateBeg";
            this.edtDateBeg.Size = new System.Drawing.Size(97, 20);
            this.edtDateBeg.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(225, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "по:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Действие ваучера с:";
            // 
            // frmCreateVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 439);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCreateVoucher";
            this.Text = "Создание ваучера";
            this.Load += new System.EventHandler(this.frmCreateVoucher_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPartnerLogo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.pnlServiceLine.ResumeLayout(false);
            this.pnlServiceLine.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
        private System.Windows.Forms.ToolStripButton tsBtnCreate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox edtCountryName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox edtVoucherNumber;
        private System.Windows.Forms.TextBox edtBronNumber;
        private System.Windows.Forms.TextBox edtContactInfo;
        private System.Windows.Forms.PictureBox edtPartnerLogo;
        private System.Windows.Forms.TextBox edtPartnerContact;
        private System.Windows.Forms.TextBox edtPartnerName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbTurist;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnlServiceLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker edtDateEnd;
        private System.Windows.Forms.DateTimePicker edtDateBeg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox edtTourName;
        private System.Windows.Forms.TextBox edtService;
        private System.Windows.Forms.ToolStripButton tsBtnSplit;
    }
}