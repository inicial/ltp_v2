namespace Rep22341
{
    partial class frmPrint
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbFltNotUsedPersons = new System.Windows.Forms.CheckBox();
            this.cbFltHotelStateOK = new System.Windows.Forms.CheckBox();
            this.cbFilterPaidBilets = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbSplitPartner = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbExportType = new System.Windows.Forms.ListBox();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(187, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 406);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Надстройки";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbFltNotUsedPersons);
            this.groupBox4.Controls.Add(this.cbFltHotelStateOK);
            this.groupBox4.Controls.Add(this.cbFilterPaidBilets);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(258, 308);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Фильтры";
            // 
            // cbFltNotUsedPersons
            // 
            this.cbFltNotUsedPersons.AutoSize = true;
            this.cbFltNotUsedPersons.Location = new System.Drawing.Point(6, 69);
            this.cbFltNotUsedPersons.Name = "cbFltNotUsedPersons";
            this.cbFltNotUsedPersons.Size = new System.Drawing.Size(169, 17);
            this.cbFltNotUsedPersons.TabIndex = 4;
            this.cbFltNotUsedPersons.Text = "Только еще не выписанные";
            this.cbFltNotUsedPersons.UseVisualStyleBackColor = true;
            // 
            // cbFltHotelStateOK
            // 
            this.cbFltHotelStateOK.AutoSize = true;
            this.cbFltHotelStateOK.Location = new System.Drawing.Point(6, 46);
            this.cbFltHotelStateOK.Name = "cbFltHotelStateOK";
            this.cbFltHotelStateOK.Size = new System.Drawing.Size(216, 17);
            this.cbFltHotelStateOK.TabIndex = 3;
            this.cbFltHotelStateOK.Text = "Только с подтвержденными отелями";
            this.cbFltHotelStateOK.UseVisualStyleBackColor = true;
            // 
            // cbFilterPaidBilets
            // 
            this.cbFilterPaidBilets.FormattingEnabled = true;
            this.cbFilterPaidBilets.Location = new System.Drawing.Point(6, 19);
            this.cbFilterPaidBilets.Name = "cbFilterPaidBilets";
            this.cbFilterPaidBilets.Size = new System.Drawing.Size(151, 21);
            this.cbFilterPaidBilets.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 369);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 34);
            this.panel1.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(65, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(119, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Создать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbSplitPartner);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 45);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Разделение";
            // 
            // cbSplitPartner
            // 
            this.cbSplitPartner.AutoSize = true;
            this.cbSplitPartner.Enabled = false;
            this.cbSplitPartner.Location = new System.Drawing.Point(6, 19);
            this.cbSplitPartner.Name = "cbSplitPartner";
            this.cbSplitPartner.Size = new System.Drawing.Size(96, 17);
            this.cbSplitPartner.TabIndex = 1;
            this.cbSplitPartner.Text = "на Партнеров";
            this.cbSplitPartner.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbExportType);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 406);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип шаблона печати";
            // 
            // cbExportType
            // 
            this.cbExportType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbExportType.FormattingEnabled = true;
            this.cbExportType.Location = new System.Drawing.Point(3, 16);
            this.cbExportType.Name = "cbExportType";
            this.cbExportType.Size = new System.Drawing.Size(181, 387);
            this.cbExportType.TabIndex = 1;
            this.cbExportType.SelectedIndexChanged += new System.EventHandler(this.cbExportType_SelectedIndexChanged);
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 406);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPrint";
            this.Text = "Печатная форма";
            this.Load += new System.EventHandler(this.frmPrint_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbFilterPaidBilets;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbSplitPartner;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox cbExportType;
        private System.Windows.Forms.CheckBox cbFltHotelStateOK;
        private System.Windows.Forms.CheckBox cbFltNotUsedPersons;
    }
}