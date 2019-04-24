using ltp_v2.Controls.Forms;
namespace CallCenter
{
    partial class frmCallCenter
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
            this.components = new System.ComponentModel.Container();
            this.gbCountrryList = new System.Windows.Forms.GroupBox();
            this.edt_CountryList = new System.Windows.Forms.CheckedListBox();
            this.btn_SelectAllCountry = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edt_Phones = new System.Windows.Forms.ListBox();
            this.btnAddPhone = new System.Windows.Forms.Button();
            this.edtPhone = new System.Windows.Forms.TextBox();
            this.btnDelSelectPhone = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edt_TypeCallCenter = new System.Windows.Forms.ComboBox();
            this.edt_CRDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edt_MetroList = new ltp_v2.Controls.Forms.lwComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.edt_AgencyName = new System.Windows.Forms.TextBox();
            this.edt_Rait = new System.Windows.Forms.NumericUpDown();
            this.toolStripPanel = new System.Windows.Forms.ToolStrip();
            this.tsBtnOk = new System.Windows.Forms.ToolStripButton();
            this.edt_IsUsedCallCenter = new System.Windows.Forms.ToolStripButton();
            this.edt_IsFreeService = new System.Windows.Forms.ToolStripButton();
            this.gbCountrryList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Rait)).BeginInit();
            this.toolStripPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCountrryList
            // 
            this.gbCountrryList.Controls.Add(this.edt_CountryList);
            this.gbCountrryList.Controls.Add(this.btn_SelectAllCountry);
            this.gbCountrryList.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCountrryList.Location = new System.Drawing.Point(0, 316);
            this.gbCountrryList.Name = "gbCountrryList";
            this.gbCountrryList.Size = new System.Drawing.Size(465, 130);
            this.gbCountrryList.TabIndex = 23;
            this.gbCountrryList.TabStop = false;
            this.gbCountrryList.Text = "Список продаваемых стран";
            // 
            // edt_CountryList
            // 
            this.edt_CountryList.FormattingEnabled = true;
            this.edt_CountryList.Location = new System.Drawing.Point(6, 19);
            this.edt_CountryList.Name = "edt_CountryList";
            this.edt_CountryList.Size = new System.Drawing.Size(254, 94);
            this.edt_CountryList.TabIndex = 9;
            // 
            // btn_SelectAllCountry
            // 
            this.btn_SelectAllCountry.Location = new System.Drawing.Point(272, 19);
            this.btn_SelectAllCountry.Name = "btn_SelectAllCountry";
            this.btn_SelectAllCountry.Size = new System.Drawing.Size(81, 23);
            this.btn_SelectAllCountry.TabIndex = 13;
            this.btn_SelectAllCountry.Text = "Выбрать все";
            this.btn_SelectAllCountry.UseVisualStyleBackColor = true;
            this.btn_SelectAllCountry.Click += new System.EventHandler(this.btn_SelectAllCountry_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edt_Phones);
            this.groupBox1.Controls.Add(this.btnAddPhone);
            this.groupBox1.Controls.Add(this.edtPhone);
            this.groupBox1.Controls.Add(this.btnDelSelectPhone);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 116);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Телефоны";
            // 
            // edt_Phones
            // 
            this.edt_Phones.FormattingEnabled = true;
            this.edt_Phones.Location = new System.Drawing.Point(6, 13);
            this.edt_Phones.Name = "edt_Phones";
            this.edt_Phones.Size = new System.Drawing.Size(260, 69);
            this.edt_Phones.TabIndex = 7;
            // 
            // btnAddPhone
            // 
            this.btnAddPhone.Location = new System.Drawing.Point(276, 88);
            this.btnAddPhone.Name = "btnAddPhone";
            this.btnAddPhone.Size = new System.Drawing.Size(83, 21);
            this.btnAddPhone.TabIndex = 17;
            this.btnAddPhone.Text = "Добавить";
            this.btnAddPhone.UseVisualStyleBackColor = true;
            this.btnAddPhone.Click += new System.EventHandler(this.btnAddPhone_Click);
            // 
            // edtPhone
            // 
            this.edtPhone.Location = new System.Drawing.Point(6, 89);
            this.edtPhone.Name = "edtPhone";
            this.edtPhone.Size = new System.Drawing.Size(260, 20);
            this.edtPhone.TabIndex = 16;
            // 
            // btnDelSelectPhone
            // 
            this.btnDelSelectPhone.Location = new System.Drawing.Point(278, 13);
            this.btnDelSelectPhone.Name = "btnDelSelectPhone";
            this.btnDelSelectPhone.Size = new System.Drawing.Size(83, 35);
            this.btnDelSelectPhone.TabIndex = 14;
            this.btnDelSelectPhone.Text = "Удалить выбранное";
            this.btnDelSelectPhone.UseVisualStyleBackColor = true;
            this.btnDelSelectPhone.Click += new System.EventHandler(this.btnDelSelectPhone_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.edt_TypeCallCenter);
            this.groupBox3.Controls.Add(this.edt_CRDate);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.edt_MetroList);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.edt_AgencyName);
            this.groupBox3.Controls.Add(this.edt_Rait);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 169);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Информация";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Тип перевода:";
            // 
            // edt_TypeCallCenter
            // 
            this.edt_TypeCallCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_TypeCallCenter.FormattingEnabled = true;
            this.edt_TypeCallCenter.Location = new System.Drawing.Point(98, 12);
            this.edt_TypeCallCenter.Name = "edt_TypeCallCenter";
            this.edt_TypeCallCenter.Size = new System.Drawing.Size(355, 21);
            this.edt_TypeCallCenter.TabIndex = 14;
            this.edt_TypeCallCenter.SelectedIndexChanged += new System.EventHandler(this.edt_TypeCallCenter_SelectedIndexChanged);
            // 
            // edt_CRDate
            // 
            this.edt_CRDate.Location = new System.Drawing.Point(117, 113);
            this.edt_CRDate.Name = "edt_CRDate";
            this.edt_CRDate.Size = new System.Drawing.Size(126, 20);
            this.edt_CRDate.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Дата подключения:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название агенства:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Станция метро:";
            // 
            // edt_MetroList
            // 
            this.edt_MetroList.ChangeBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.edt_MetroList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_MetroList.ErrorBackGroundColor = System.Drawing.Color.Red;
            this.edt_MetroList.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.edt_MetroList.ErrorProvider = this.errorProvider1;
            this.edt_MetroList.FormattingEnabled = true;
            this.edt_MetroList.IsNotNullValue = true;
            this.edt_MetroList.Location = new System.Drawing.Point(98, 86);
            this.edt_MetroList.MessageInformationError = "";
            this.edt_MetroList.Name = "edt_MetroList";
            this.edt_MetroList.Size = new System.Drawing.Size(355, 21);
            this.edt_MetroList.TabIndex = 3;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Рейтинг:";
            // 
            // edt_AgencyName
            // 
            this.edt_AgencyName.Location = new System.Drawing.Point(117, 39);
            this.edt_AgencyName.Name = "edt_AgencyName";
            this.edt_AgencyName.ReadOnly = true;
            this.edt_AgencyName.Size = new System.Drawing.Size(236, 20);
            this.edt_AgencyName.TabIndex = 10;
            // 
            // edt_Rait
            // 
            this.edt_Rait.Location = new System.Drawing.Point(233, 62);
            this.edt_Rait.Name = "edt_Rait";
            this.edt_Rait.Size = new System.Drawing.Size(120, 20);
            this.edt_Rait.TabIndex = 5;
            // 
            // toolStripPanel
            // 
            this.toolStripPanel.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnOk,
            this.edt_IsUsedCallCenter,
            this.edt_IsFreeService});
            this.toolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanel.Name = "toolStripPanel";
            this.toolStripPanel.Size = new System.Drawing.Size(465, 31);
            this.toolStripPanel.TabIndex = 25;
            this.toolStripPanel.Text = "toolStrip1";
            // 
            // tsBtnOk
            // 
            this.tsBtnOk.Image = global::CallCenter.Properties.Resources.Apply_Check;
            this.tsBtnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOk.Name = "tsBtnOk";
            this.tsBtnOk.Size = new System.Drawing.Size(149, 28);
            this.tsBtnOk.Text = "Применить/Сохранить";
            this.tsBtnOk.Click += new System.EventHandler(this.tsBtnOk_Click);
            // 
            // edt_IsUsedCallCenter
            // 
            this.edt_IsUsedCallCenter.CheckOnClick = true;
            this.edt_IsUsedCallCenter.Image = global::CallCenter.Properties.Resources.UnCheck;
            this.edt_IsUsedCallCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.edt_IsUsedCallCenter.Name = "edt_IsUsedCallCenter";
            this.edt_IsUsedCallCenter.Size = new System.Drawing.Size(101, 28);
            this.edt_IsUsedCallCenter.Text = "Не активный";
            this.edt_IsUsedCallCenter.CheckedChanged += new System.EventHandler(this.edt_IsUsedCallCenter_CheckedChanged);
            // 
            // edt_IsFreeService
            // 
            this.edt_IsFreeService.CheckOnClick = true;
            this.edt_IsFreeService.Image = global::CallCenter.Properties.Resources.UnCheck;
            this.edt_IsFreeService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.edt_IsFreeService.Name = "edt_IsFreeService";
            this.edt_IsFreeService.Size = new System.Drawing.Size(131, 28);
            this.edt_IsFreeService.Text = "На платной основе";
            this.edt_IsFreeService.CheckedChanged += new System.EventHandler(this.edt_IsFreeService_CheckedChanged);
            // 
            // frmCallCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(465, 447);
            this.Controls.Add(this.gbCountrryList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStripPanel);
            this.Name = "frmCallCenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление CallCenter: ";
            this.gbCountrryList.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Rait)).EndInit();
            this.toolStripPanel.ResumeLayout(false);
            this.toolStripPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCountrryList;
        private System.Windows.Forms.CheckedListBox edt_CountryList;
        private System.Windows.Forms.Button btn_SelectAllCountry;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox edt_Phones;
        private System.Windows.Forms.Button btnAddPhone;
        private System.Windows.Forms.TextBox edtPhone;
        private System.Windows.Forms.Button btnDelSelectPhone;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox edt_TypeCallCenter;
        private System.Windows.Forms.DateTimePicker edt_CRDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private lwComboBox edt_MetroList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edt_AgencyName;
        private System.Windows.Forms.NumericUpDown edt_Rait;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStrip toolStripPanel;
        private System.Windows.Forms.ToolStripButton tsBtnOk;
        private System.Windows.Forms.ToolStripButton edt_IsUsedCallCenter;
        private System.Windows.Forms.ToolStripButton edt_IsFreeService;
    }
}