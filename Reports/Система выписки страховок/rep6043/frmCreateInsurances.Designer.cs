namespace rep6043
{
    partial class frmCreateInsurances
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateInsurances));
            this.edt_Date = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.edt_Rate = new System.Windows.Forms.TextBox();
            this.gbInsBottom = new System.Windows.Forms.GroupBox();
            this.edt_Persons = new System.Windows.Forms.ListBox();
            this.edt_InsuranceFIO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbInsTop = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.edt_Terretory = new System.Windows.Forms.ListBox();
            this.pnlEdit_Terretory = new System.Windows.Forms.GroupBox();
            this.cb_Terretory = new System.Windows.Forms.ComboBox();
            this.btn_TerretoryAdd = new System.Windows.Forms.Button();
            this.btn_TerretoryDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edt_Conditions = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.edt_DateEnd = new System.Windows.Forms.TextBox();
            this.edt_DateBeg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edt_Number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edt_Duration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edt_TotalSumm = new System.Windows.Forms.TextBox();
            this.MenuBar = new System.Windows.Forms.ToolStrip();
            this.tsBtnCreate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRefreshData = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblError = new System.Windows.Forms.Label();
            this.gbInsBottom.SuspendLayout();
            this.gbInsTop.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlEdit_Terretory.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // edt_Date
            // 
            this.edt_Date.BackColor = System.Drawing.SystemColors.Window;
            this.edt_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_Date.ForeColor = System.Drawing.Color.Navy;
            this.edt_Date.Location = new System.Drawing.Point(188, 3);
            this.edt_Date.Name = "edt_Date";
            this.edt_Date.ReadOnly = true;
            this.edt_Date.Size = new System.Drawing.Size(116, 20);
            this.edt_Date.TabIndex = 27;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "print_v2.ico");
            this.imageList1.Images.SetKeyName(1, "refresh_v2.ico");
            this.imageList1.Images.SetKeyName(2, "add_v2.ico");
            this.imageList1.Images.SetKeyName(3, "delete_v2.ico");
            this.imageList1.Images.SetKeyName(4, "edit_v2.ico");
            this.imageList1.Images.SetKeyName(5, "exit_v2.ico");
            this.imageList1.Images.SetKeyName(6, "ok_v2.ico");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Общая премия:";
            // 
            // edt_Rate
            // 
            this.edt_Rate.BackColor = System.Drawing.SystemColors.Window;
            this.edt_Rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_Rate.ForeColor = System.Drawing.Color.Navy;
            this.edt_Rate.Location = new System.Drawing.Point(197, 31);
            this.edt_Rate.Name = "edt_Rate";
            this.edt_Rate.ReadOnly = true;
            this.edt_Rate.Size = new System.Drawing.Size(33, 20);
            this.edt_Rate.TabIndex = 20;
            // 
            // gbInsBottom
            // 
            this.gbInsBottom.Controls.Add(this.edt_Persons);
            this.gbInsBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInsBottom.Location = new System.Drawing.Point(0, 368);
            this.gbInsBottom.Name = "gbInsBottom";
            this.gbInsBottom.Size = new System.Drawing.Size(847, 120);
            this.gbInsBottom.TabIndex = 22;
            this.gbInsBottom.TabStop = false;
            this.gbInsBottom.Text = "Данные по туристу";
            // 
            // edt_Persons
            // 
            this.edt_Persons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edt_Persons.FormattingEnabled = true;
            this.edt_Persons.Location = new System.Drawing.Point(3, 16);
            this.edt_Persons.Name = "edt_Persons";
            this.edt_Persons.Size = new System.Drawing.Size(841, 101);
            this.edt_Persons.TabIndex = 20;
            // 
            // edt_InsuranceFIO
            // 
            this.edt_InsuranceFIO.BackColor = System.Drawing.SystemColors.Window;
            this.edt_InsuranceFIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_InsuranceFIO.ForeColor = System.Drawing.Color.Navy;
            this.edt_InsuranceFIO.Location = new System.Drawing.Point(512, 3);
            this.edt_InsuranceFIO.Name = "edt_InsuranceFIO";
            this.edt_InsuranceFIO.ReadOnly = true;
            this.edt_InsuranceFIO.Size = new System.Drawing.Size(217, 20);
            this.edt_InsuranceFIO.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(426, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Страхователь:";
            // 
            // gbInsTop
            // 
            this.gbInsTop.Controls.Add(this.splitContainer2);
            this.gbInsTop.Controls.Add(this.panel2);
            this.gbInsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInsTop.Location = new System.Drawing.Point(0, 66);
            this.gbInsTop.Name = "gbInsTop";
            this.gbInsTop.Size = new System.Drawing.Size(847, 302);
            this.gbInsTop.TabIndex = 21;
            this.gbInsTop.TabStop = false;
            this.gbInsTop.Text = "Основные данные по действию полиса";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 76);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(841, 223);
            this.splitContainer2.SplitterDistance = 268;
            this.splitContainer2.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.edt_Terretory);
            this.groupBox3.Controls.Add(this.pnlEdit_Terretory);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 223);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Территории действия:";
            // 
            // edt_Terretory
            // 
            this.edt_Terretory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edt_Terretory.FormattingEnabled = true;
            this.edt_Terretory.Location = new System.Drawing.Point(3, 16);
            this.edt_Terretory.Name = "edt_Terretory";
            this.edt_Terretory.Size = new System.Drawing.Size(262, 132);
            this.edt_Terretory.TabIndex = 19;
            // 
            // pnlEdit_Terretory
            // 
            this.pnlEdit_Terretory.Controls.Add(this.cb_Terretory);
            this.pnlEdit_Terretory.Controls.Add(this.btn_TerretoryAdd);
            this.pnlEdit_Terretory.Controls.Add(this.btn_TerretoryDelete);
            this.pnlEdit_Terretory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEdit_Terretory.Location = new System.Drawing.Point(3, 148);
            this.pnlEdit_Terretory.Name = "pnlEdit_Terretory";
            this.pnlEdit_Terretory.Size = new System.Drawing.Size(262, 72);
            this.pnlEdit_Terretory.TabIndex = 17;
            this.pnlEdit_Terretory.TabStop = false;
            this.pnlEdit_Terretory.Text = "Добавление/удаление территорий";
            // 
            // cb_Terretory
            // 
            this.cb_Terretory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Terretory.Location = new System.Drawing.Point(3, 16);
            this.cb_Terretory.Name = "cb_Terretory";
            this.cb_Terretory.Size = new System.Drawing.Size(256, 21);
            this.cb_Terretory.TabIndex = 5;
            // 
            // btn_TerretoryAdd
            // 
            this.btn_TerretoryAdd.ImageIndex = 2;
            this.btn_TerretoryAdd.ImageList = this.imageList1;
            this.btn_TerretoryAdd.Location = new System.Drawing.Point(7, 38);
            this.btn_TerretoryAdd.Name = "btn_TerretoryAdd";
            this.btn_TerretoryAdd.Size = new System.Drawing.Size(32, 28);
            this.btn_TerretoryAdd.TabIndex = 4;
            this.btn_TerretoryAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TerretoryAdd.UseVisualStyleBackColor = true;
            this.btn_TerretoryAdd.Click += new System.EventHandler(this.btn_TerretoryAdd_Click);
            // 
            // btn_TerretoryDelete
            // 
            this.btn_TerretoryDelete.ImageIndex = 3;
            this.btn_TerretoryDelete.ImageList = this.imageList1;
            this.btn_TerretoryDelete.Location = new System.Drawing.Point(39, 38);
            this.btn_TerretoryDelete.Name = "btn_TerretoryDelete";
            this.btn_TerretoryDelete.Size = new System.Drawing.Size(32, 28);
            this.btn_TerretoryDelete.TabIndex = 2;
            this.btn_TerretoryDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TerretoryDelete.UseVisualStyleBackColor = true;
            this.btn_TerretoryDelete.Click += new System.EventHandler(this.btn_TerretoryDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edt_Conditions);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(569, 223);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные по страхованию";
            // 
            // edt_Conditions
            // 
            this.edt_Conditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edt_Conditions.FormattingEnabled = true;
            this.edt_Conditions.Location = new System.Drawing.Point(3, 16);
            this.edt_Conditions.Name = "edt_Conditions";
            this.edt_Conditions.Size = new System.Drawing.Size(563, 204);
            this.edt_Conditions.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.edt_DateEnd);
            this.panel2.Controls.Add(this.edt_DateBeg);
            this.panel2.Controls.Add(this.edt_Date);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.edt_Number);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.edt_InsuranceFIO);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.edt_Duration);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.edt_Rate);
            this.panel2.Controls.Add(this.edt_TotalSumm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(841, 60);
            this.panel2.TabIndex = 3;
            // 
            // edt_DateEnd
            // 
            this.edt_DateEnd.BackColor = System.Drawing.SystemColors.Window;
            this.edt_DateEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_DateEnd.ForeColor = System.Drawing.Color.Navy;
            this.edt_DateEnd.Location = new System.Drawing.Point(498, 31);
            this.edt_DateEnd.Name = "edt_DateEnd";
            this.edt_DateEnd.ReadOnly = true;
            this.edt_DateEnd.Size = new System.Drawing.Size(93, 20);
            this.edt_DateEnd.TabIndex = 29;
            // 
            // edt_DateBeg
            // 
            this.edt_DateBeg.BackColor = System.Drawing.SystemColors.Window;
            this.edt_DateBeg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_DateBeg.ForeColor = System.Drawing.Color.Navy;
            this.edt_DateBeg.Location = new System.Drawing.Point(301, 31);
            this.edt_DateBeg.Name = "edt_DateBeg";
            this.edt_DateBeg.ReadOnly = true;
            this.edt_DateBeg.Size = new System.Drawing.Size(93, 20);
            this.edt_DateBeg.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(164, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "от";
            // 
            // edt_Number
            // 
            this.edt_Number.BackColor = System.Drawing.SystemColors.Window;
            this.edt_Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_Number.ForeColor = System.Drawing.Color.Navy;
            this.edt_Number.Location = new System.Drawing.Point(38, 3);
            this.edt_Number.Name = "edt_Number";
            this.edt_Number.ReadOnly = true;
            this.edt_Number.Size = new System.Drawing.Size(116, 20);
            this.edt_Number.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "№";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Дата завершения:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(763, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "дн.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Дата начала:";
            // 
            // edt_Duration
            // 
            this.edt_Duration.BackColor = System.Drawing.SystemColors.Window;
            this.edt_Duration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_Duration.ForeColor = System.Drawing.Color.Navy;
            this.edt_Duration.Location = new System.Drawing.Point(711, 31);
            this.edt_Duration.Name = "edt_Duration";
            this.edt_Duration.ReadOnly = true;
            this.edt_Duration.Size = new System.Drawing.Size(46, 20);
            this.edt_Duration.TabIndex = 17;
            this.edt_Duration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(597, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Продолжительность:";
            // 
            // edt_TotalSumm
            // 
            this.edt_TotalSumm.BackColor = System.Drawing.SystemColors.Window;
            this.edt_TotalSumm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_TotalSumm.ForeColor = System.Drawing.Color.Navy;
            this.edt_TotalSumm.Location = new System.Drawing.Point(89, 31);
            this.edt_TotalSumm.Name = "edt_TotalSumm";
            this.edt_TotalSumm.ReadOnly = true;
            this.edt_TotalSumm.Size = new System.Drawing.Size(102, 20);
            this.edt_TotalSumm.TabIndex = 19;
            // 
            // MenuBar
            // 
            this.MenuBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnCreate,
            this.tsBtnPrint,
            this.tsBtnRefreshData});
            this.MenuBar.Location = new System.Drawing.Point(0, 35);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(847, 31);
            this.MenuBar.TabIndex = 23;
            this.MenuBar.Text = "toolStrip1";
            // 
            // tsBtnCreate
            // 
            this.tsBtnCreate.Image = global::rep6043.Properties.Resources.Apply_Check;
            this.tsBtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreate.Name = "tsBtnCreate";
            this.tsBtnCreate.Size = new System.Drawing.Size(78, 28);
            this.tsBtnCreate.Text = "Создать";
            this.tsBtnCreate.Click += new System.EventHandler(this.tsBtnCreate_Click);
            // 
            // tsBtnPrint
            // 
            this.tsBtnPrint.Image = global::rep6043.Properties.Resources.Print;
            this.tsBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrint.Name = "tsBtnPrint";
            this.tsBtnPrint.Size = new System.Drawing.Size(74, 28);
            this.tsBtnPrint.Text = "Печать";
            this.tsBtnPrint.Click += new System.EventHandler(this.tsBtnPrint_Click);
            // 
            // tsBtnRefreshData
            // 
            this.tsBtnRefreshData.Image = global::rep6043.Properties.Resources.Refresh;
            this.tsBtnRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefreshData.Name = "tsBtnRefreshData";
            this.tsBtnRefreshData.Size = new System.Drawing.Size(195, 28);
            this.tsBtnRefreshData.Text = "Обновить данные по туристу";
            this.tsBtnRefreshData.Click += new System.EventHandler(this.tsBtnRefreshData_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblError.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblError.ForeColor = System.Drawing.Color.Black;
            this.lblError.Location = new System.Drawing.Point(0, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(847, 35);
            this.lblError.TabIndex = 24;
            this.lblError.Text = "lblError";
            this.lblError.Visible = false;
            this.lblError.VisibleChanged += new System.EventHandler(this.lblError_VisibleChanged);
            // 
            // frmCreateInsurances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 488);
            this.Controls.Add(this.gbInsBottom);
            this.Controls.Add(this.gbInsTop);
            this.Controls.Add(this.MenuBar);
            this.Controls.Add(this.lblError);
            this.MinimumSize = new System.Drawing.Size(863, 526);
            this.Name = "frmCreateInsurances";
            this.Text = "Создание страхового полиса";
            this.gbInsBottom.ResumeLayout(false);
            this.gbInsTop.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.pnlEdit_Terretory.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edt_Date;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox edt_Rate;
        private System.Windows.Forms.GroupBox gbInsBottom;
        private System.Windows.Forms.ListBox edt_Persons;
        private System.Windows.Forms.ToolStripButton tsBtnRefreshData;
        private System.Windows.Forms.TextBox edt_InsuranceFIO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbInsTop;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox edt_Terretory;
        private System.Windows.Forms.GroupBox pnlEdit_Terretory;
        private System.Windows.Forms.ComboBox cb_Terretory;
        private System.Windows.Forms.Button btn_TerretoryAdd;
        private System.Windows.Forms.Button btn_TerretoryDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox edt_Conditions;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edt_Number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edt_Duration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edt_TotalSumm;
        private System.Windows.Forms.ToolStripButton tsBtnPrint;
        private System.Windows.Forms.ToolStripButton tsBtnCreate;
        private System.Windows.Forms.ToolStrip MenuBar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox edt_DateEnd;
        private System.Windows.Forms.TextBox edt_DateBeg;
    }
}