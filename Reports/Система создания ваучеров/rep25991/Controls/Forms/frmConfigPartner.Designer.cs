namespace rep25991.Controls.Forms
{
    partial class frmConfigPartner
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
            this.btnDeleteLogo = new System.Windows.Forms.Button();
            this.edtPartnerLogo = new System.Windows.Forms.PictureBox();
            this.btnCreateLogo = new System.Windows.Forms.Button();
            this.edtName = new System.Windows.Forms.TextBox();
            this.edtAddress = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCreate = new System.Windows.Forms.ToolStripButton();
            this.btnGetFromMT = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.edtFormatDate = new System.Windows.Forms.ComboBox();
            this.edtContactPerson = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtFormat = new rep25991.Controls.ConvertationEditor();
            this.edtOutAvia = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.edtPartnerLogo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логотип:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название партнера для ваучера:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Адрес партнера для ваучера:";
            // 
            // btnDeleteLogo
            // 
            this.btnDeleteLogo.Location = new System.Drawing.Point(327, 57);
            this.btnDeleteLogo.Name = "btnDeleteLogo";
            this.btnDeleteLogo.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteLogo.TabIndex = 3;
            this.btnDeleteLogo.Text = "Удалить";
            this.btnDeleteLogo.UseVisualStyleBackColor = true;
            this.btnDeleteLogo.Click += new System.EventHandler(this.btnDeleteLogo_Click);
            // 
            // edtPartnerLogo
            // 
            this.edtPartnerLogo.Location = new System.Drawing.Point(195, 57);
            this.edtPartnerLogo.Name = "edtPartnerLogo";
            this.edtPartnerLogo.Size = new System.Drawing.Size(126, 51);
            this.edtPartnerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.edtPartnerLogo.TabIndex = 10;
            this.edtPartnerLogo.TabStop = false;
            // 
            // btnCreateLogo
            // 
            this.btnCreateLogo.Location = new System.Drawing.Point(327, 85);
            this.btnCreateLogo.Name = "btnCreateLogo";
            this.btnCreateLogo.Size = new System.Drawing.Size(75, 23);
            this.btnCreateLogo.TabIndex = 11;
            this.btnCreateLogo.Text = "Загрузить";
            this.btnCreateLogo.UseVisualStyleBackColor = true;
            this.btnCreateLogo.Click += new System.EventHandler(this.btnCreateLogo_Click);
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(195, 114);
            this.edtName.Name = "edtName";
            this.edtName.ReadOnly = true;
            this.edtName.Size = new System.Drawing.Size(293, 20);
            this.edtName.TabIndex = 12;
            this.edtName.Leave += new System.EventHandler(this.edtName_Leave);
            // 
            // edtAddress
            // 
            this.edtAddress.Location = new System.Drawing.Point(195, 140);
            this.edtAddress.Name = "edtAddress";
            this.edtAddress.ReadOnly = true;
            this.edtAddress.Size = new System.Drawing.Size(293, 20);
            this.edtAddress.TabIndex = 13;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnCancel,
            this.tsBtnCreate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(509, 31);
            this.toolStrip1.TabIndex = 16;
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
            this.tsBtnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tsBtnCreate
            // 
            this.tsBtnCreate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCreate.Image = global::rep25991.Properties.Resources.Apply_Check;
            this.tsBtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreate.Name = "tsBtnCreate";
            this.tsBtnCreate.Size = new System.Drawing.Size(98, 28);
            this.tsBtnCreate.Text = "Применить";
            this.tsBtnCreate.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGetFromMT
            // 
            this.btnGetFromMT.Location = new System.Drawing.Point(408, 57);
            this.btnGetFromMT.Name = "btnGetFromMT";
            this.btnGetFromMT.Size = new System.Drawing.Size(89, 23);
            this.btnGetFromMT.TabIndex = 17;
            this.btnGetFromMT.Text = "Взять из МТ";
            this.btnGetFromMT.UseVisualStyleBackColor = true;
            this.btnGetFromMT.Click += new System.EventHandler(this.btnGetFromMT_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Формат даты:";
            // 
            // edtFormatDate
            // 
            this.edtFormatDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edtFormatDate.FormattingEnabled = true;
            this.edtFormatDate.Location = new System.Drawing.Point(195, 162);
            this.edtFormatDate.Name = "edtFormatDate";
            this.edtFormatDate.Size = new System.Drawing.Size(214, 21);
            this.edtFormatDate.TabIndex = 20;
            // 
            // edtContactPerson
            // 
            this.edtContactPerson.Location = new System.Drawing.Point(195, 189);
            this.edtContactPerson.Name = "edtContactPerson";
            this.edtContactPerson.Size = new System.Drawing.Size(314, 20);
            this.edtContactPerson.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Контактное лицо:";
            // 
            // edtFormat
            // 
            this.edtFormat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtFormat.ExampleText = "...";
            this.edtFormat.Location = new System.Drawing.Point(0, 249);
            this.edtFormat.MinimumSize = new System.Drawing.Size(513, 179);
            this.edtFormat.Name = "edtFormat";
            this.edtFormat.Size = new System.Drawing.Size(513, 179);
            this.edtFormat.TabIndex = 23;
            this.edtFormat.TextChange += new System.EventHandler(this.edtFormat_TextChange);
            // 
            // edtOutAvia
            // 
            this.edtOutAvia.AutoSize = true;
            this.edtOutAvia.Location = new System.Drawing.Point(195, 214);
            this.edtOutAvia.Name = "edtOutAvia";
            this.edtOutAvia.Size = new System.Drawing.Size(15, 14);
            this.edtOutAvia.TabIndex = 24;
            this.edtOutAvia.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Выводить авиа рейс:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Формат вывода туриста";
            // 
            // frmConfigPartner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 428);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edtOutAvia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtFormat);
            this.Controls.Add(this.edtContactPerson);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edtFormatDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGetFromMT);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.edtAddress);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.btnCreateLogo);
            this.Controls.Add(this.edtPartnerLogo);
            this.Controls.Add(this.btnDeleteLogo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfigPartner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка вывода партнера";
            ((System.ComponentModel.ISupportInitialize)(this.edtPartnerLogo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteLogo;
        private System.Windows.Forms.PictureBox edtPartnerLogo;
        private System.Windows.Forms.Button btnCreateLogo;
        private System.Windows.Forms.TextBox edtName;
        private System.Windows.Forms.TextBox edtAddress;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
        private System.Windows.Forms.ToolStripButton tsBtnCreate;
        private System.Windows.Forms.Button btnGetFromMT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox edtFormatDate;
        private System.Windows.Forms.TextBox edtContactPerson;
        private System.Windows.Forms.Label label5;
        private ConvertationEditor edtFormat;
        private System.Windows.Forms.CheckBox edtOutAvia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}