using ltp_v2.Controls.Forms;
namespace AgencyManager
{
    partial class frmMasterPartners
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PartnersDGV = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlFilter = new System.Windows.Forms.GroupBox();
            this.edt_filter_Login = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.edt_filter_Code = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.edt_Filter_PartnerType = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.edt_filter_EMail = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.edt_filter_Fax = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.edt_filter_Phone = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.edt_filter_Inn = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.edt_filter_Name = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.edt_Filter_DogovorType = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsBtnMoveToMaster = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCreateNew = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSendMail = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHistory = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssCountRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.wbPrtInfo = new System.Windows.Forms.WebBrowser();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edt_filter_DogovorNum = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PartnersDGV)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Необходимый тип договора;";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(34, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "E-Mail:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(41, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Факс:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PartnersDGV
            // 
            this.PartnersDGV.AllowUserToAddRows = false;
            this.PartnersDGV.AllowUserToDeleteRows = false;
            this.PartnersDGV.AllowUserToResizeRows = false;
            this.PartnersDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PartnersDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.PartnersDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PartnersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartnersDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartnersDGV.Location = new System.Drawing.Point(236, 31);
            this.PartnersDGV.Name = "PartnersDGV";
            this.PartnersDGV.ReadOnly = true;
            this.PartnersDGV.RowHeadersVisible = false;
            this.PartnersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PartnersDGV.Size = new System.Drawing.Size(815, 283);
            this.PartnersDGV.TabIndex = 0;
            this.PartnersDGV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.PartnersDGV_RowEnter);
            this.PartnersDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.PartnersDGV_DataBindingComplete);
            this.PartnersDGV.SelectionChanged += new System.EventHandler(this.PartnersDGV_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(20, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Телефон:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(44, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ИНН:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(19, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Название:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.edt_filter_Login);
            this.pnlFilter.Controls.Add(this.label11);
            this.pnlFilter.Controls.Add(this.edt_filter_Code);
            this.pnlFilter.Controls.Add(this.label9);
            this.pnlFilter.Controls.Add(this.edt_Filter_PartnerType);
            this.pnlFilter.Controls.Add(this.label8);
            this.pnlFilter.Controls.Add(this.label5);
            this.pnlFilter.Controls.Add(this.edt_filter_EMail);
            this.pnlFilter.Controls.Add(this.label7);
            this.pnlFilter.Controls.Add(this.edt_filter_Fax);
            this.pnlFilter.Controls.Add(this.label6);
            this.pnlFilter.Controls.Add(this.edt_filter_Phone);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.edt_filter_Inn);
            this.pnlFilter.Controls.Add(this.edt_filter_Name);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(0);
            this.pnlFilter.Size = new System.Drawing.Size(236, 273);
            this.pnlFilter.TabIndex = 0;
            this.pnlFilter.TabStop = false;
            this.pnlFilter.Text = "Фильтрация данных";
            // 
            // edt_filter_Login
            // 
            this.edt_filter_Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_Login.Location = new System.Drawing.Point(75, 197);
            this.edt_filter_Login.Name = "edt_filter_Login";
            this.edt_filter_Login.OldText = null;
            this.edt_filter_Login.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_Login.TabIndex = 6;
            this.edt_filter_Login.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(36, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Логин:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edt_filter_Code
            // 
            this.edt_filter_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_Code.Location = new System.Drawing.Point(75, 44);
            this.edt_filter_Code.Name = "edt_filter_Code";
            this.edt_filter_Code.OldText = null;
            this.edt_filter_Code.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_Code.TabIndex = 0;
            this.edt_filter_Code.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(47, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Код:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edt_Filter_PartnerType
            // 
            this.edt_Filter_PartnerType.BackColor = System.Drawing.SystemColors.Window;
            this.edt_Filter_PartnerType.Location = new System.Drawing.Point(14, 241);
            this.edt_Filter_PartnerType.Name = "edt_Filter_PartnerType";
            this.edt_Filter_PartnerType.ReadOnly = true;
            this.edt_Filter_PartnerType.Size = new System.Drawing.Size(210, 20);
            this.edt_Filter_PartnerType.TabIndex = 7;
            this.edt_Filter_PartnerType.Click += new System.EventHandler(this.edt_Filter_PartnerType_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Необходимый тип партнера;";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "label5";
            // 
            // edt_filter_EMail
            // 
            this.edt_filter_EMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_EMail.Location = new System.Drawing.Point(75, 148);
            this.edt_filter_EMail.Name = "edt_filter_EMail";
            this.edt_filter_EMail.OldText = null;
            this.edt_filter_EMail.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_EMail.TabIndex = 4;
            this.edt_filter_EMail.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // edt_filter_Fax
            // 
            this.edt_filter_Fax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_Fax.Location = new System.Drawing.Point(75, 122);
            this.edt_filter_Fax.Name = "edt_filter_Fax";
            this.edt_filter_Fax.OldText = null;
            this.edt_filter_Fax.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_Fax.TabIndex = 3;
            this.edt_filter_Fax.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // edt_filter_Phone
            // 
            this.edt_filter_Phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_Phone.Location = new System.Drawing.Point(75, 96);
            this.edt_filter_Phone.Name = "edt_filter_Phone";
            this.edt_filter_Phone.OldText = null;
            this.edt_filter_Phone.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_Phone.TabIndex = 2;
            this.edt_filter_Phone.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // edt_filter_Inn
            // 
            this.edt_filter_Inn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_Inn.Location = new System.Drawing.Point(75, 174);
            this.edt_filter_Inn.Name = "edt_filter_Inn";
            this.edt_filter_Inn.OldText = null;
            this.edt_filter_Inn.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_Inn.TabIndex = 5;
            this.edt_filter_Inn.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // edt_filter_Name
            // 
            this.edt_filter_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_Name.Location = new System.Drawing.Point(75, 70);
            this.edt_filter_Name.Name = "edt_filter_Name";
            this.edt_filter_Name.OldText = null;
            this.edt_filter_Name.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_Name.TabIndex = 1;
            this.edt_filter_Name.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // edt_Filter_DogovorType
            // 
            this.edt_Filter_DogovorType.BackColor = System.Drawing.SystemColors.Window;
            this.edt_Filter_DogovorType.Location = new System.Drawing.Point(8, 70);
            this.edt_Filter_DogovorType.Name = "edt_Filter_DogovorType";
            this.edt_Filter_DogovorType.ReadOnly = true;
            this.edt_Filter_DogovorType.Size = new System.Drawing.Size(210, 20);
            this.edt_Filter_DogovorType.TabIndex = 1;
            this.edt_Filter_DogovorType.Click += new System.EventHandler(this.edt_Filter_DogovorType_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnRefresh,
            this.toolStripSeparator1,
            this.tsBtnMoveToMaster,
            this.tsBtnCreateNew,
            this.tsBtnEdit,
            this.tsBtnSendMail,
            this.tsBtnHistory});
            this.toolStrip1.Location = new System.Drawing.Point(236, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(815, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Image = global::AgencyManager.Properties.Resources.Refresh;
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(89, 28);
            this.tsBtnRefresh.Text = "Обновить";
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // tsBtnMoveToMaster
            // 
            this.tsBtnMoveToMaster.Image = global::AgencyManager.Properties.Resources.Construction;
            this.tsBtnMoveToMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnMoveToMaster.Name = "tsBtnMoveToMaster";
            this.tsBtnMoveToMaster.Size = new System.Drawing.Size(112, 28);
            this.tsBtnMoveToMaster.Text = "Использовать";
            this.tsBtnMoveToMaster.Click += new System.EventHandler(this.tsBtnMoveToMaster_Click);
            // 
            // tsBtnCreateNew
            // 
            this.tsBtnCreateNew.Image = global::AgencyManager.Properties.Resources.Add;
            this.tsBtnCreateNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreateNew.Name = "tsBtnCreateNew";
            this.tsBtnCreateNew.Size = new System.Drawing.Size(114, 28);
            this.tsBtnCreateNew.Text = "Создать новое";
            this.tsBtnCreateNew.Click += new System.EventHandler(this.tsBtnCreateNew_Click);
            // 
            // tsBtnEdit
            // 
            this.tsBtnEdit.Image = global::AgencyManager.Properties.Resources.Edit;
            this.tsBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEdit.Name = "tsBtnEdit";
            this.tsBtnEdit.Size = new System.Drawing.Size(89, 28);
            this.tsBtnEdit.Text = "Изменить";
            this.tsBtnEdit.Click += new System.EventHandler(this.tsBtnEdit_Click);
            // 
            // tsBtnSendMail
            // 
            this.tsBtnSendMail.Image = global::AgencyManager.Properties.Resources.EMail;
            this.tsBtnSendMail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSendMail.Name = "tsBtnSendMail";
            this.tsBtnSendMail.Size = new System.Drawing.Size(137, 28);
            this.tsBtnSendMail.Text = "Отправить данные";
            this.tsBtnSendMail.Click += new System.EventHandler(this.tsBtnSendMail_Click);
            // 
            // tsBtnHistory
            // 
            this.tsBtnHistory.Image = global::AgencyManager.Properties.Resources.Contact;
            this.tsBtnHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHistory.Name = "tsBtnHistory";
            this.tsBtnHistory.Size = new System.Drawing.Size(82, 28);
            this.tsBtnHistory.Text = "История";
            this.tsBtnHistory.Click += new System.EventHandler(this.tsBtnHistory_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssCountRows});
            this.statusStrip1.Location = new System.Drawing.Point(236, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(815, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssCountRows
            // 
            this.tssCountRows.Name = "tssCountRows";
            this.tssCountRows.Size = new System.Drawing.Size(97, 17);
            this.tssCountRows.Text = "Итого на экране";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.wbPrtInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(236, 319);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 181);
            this.panel1.TabIndex = 21;
            // 
            // wbPrtInfo
            // 
            this.wbPrtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPrtInfo.Location = new System.Drawing.Point(0, 0);
            this.wbPrtInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPrtInfo.Name = "wbPrtInfo";
            this.wbPrtInfo.Size = new System.Drawing.Size(815, 181);
            this.wbPrtInfo.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(236, 314);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(815, 5);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(4, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "№ Договора:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edt_filter_DogovorNum);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.edt_Filter_DogovorType);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 177);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтрация по договорам";
            // 
            // edt_filter_DogovorNum
            // 
            this.edt_filter_DogovorNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_DogovorNum.Location = new System.Drawing.Point(75, 19);
            this.edt_filter_DogovorNum.Name = "edt_filter_DogovorNum";
            this.edt_filter_DogovorNum.OldText = null;
            this.edt_filter_DogovorNum.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_DogovorNum.TabIndex = 0;
            this.edt_filter_DogovorNum.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.pnlFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 522);
            this.panel2.TabIndex = 0;
            // 
            // frmMasterPartners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 522);
            this.Controls.Add(this.PartnersDGV);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "frmMasterPartners";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список агентств в Мастер-тур";
            this.Load += new System.EventHandler(this.frmMasterPartners_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PartnersDGV)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private lwFilterTextBox edt_filter_EMail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private lwFilterTextBox edt_filter_Phone;
        private lwFilterTextBox edt_filter_Fax;
        private System.Windows.Forms.DataGridView PartnersDGV;
        private System.Windows.Forms.Label label4;
        private lwFilterTextBox edt_filter_Inn;
        private lwFilterTextBox edt_filter_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.GroupBox pnlFilter;
        private System.Windows.Forms.ToolStripButton tsBtnMoveToMaster;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssCountRows;
        private System.Windows.Forms.TextBox edt_Filter_DogovorType;
        private System.Windows.Forms.ToolStripButton tsBtnCreateNew;
        private System.Windows.Forms.ToolStripButton tsBtnEdit;
        private System.Windows.Forms.ToolStripButton tsBtnSendMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox edt_Filter_PartnerType;
        private System.Windows.Forms.Label label8;
        private lwFilterTextBox edt_filter_Code;
        private System.Windows.Forms.Label label9;
        private lwFilterTextBox edt_filter_DogovorNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser wbPrtInfo;
        private System.Windows.Forms.ToolStripButton tsBtnHistory;
        private lwFilterTextBox edt_filter_Login;
        private System.Windows.Forms.Label label11;
    }
}