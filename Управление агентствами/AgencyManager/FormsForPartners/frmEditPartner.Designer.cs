using ltp_v2.Controls.Forms;
using System.Windows.Forms;
using System.ComponentModel;
namespace AgencyManager.FormsForPartners
{
    partial class frmEditPartner
    {
        private lwGroupContainer gcPassword;
        private lwGroupContainer gcDogovors;
        private lwGroupContainer groupBox1;
        private lwGroupContainer groupContainer1;
        private lwGroupContainer groupContainer2;
        private lwGroupContainer gcAccount;
        private lwGroupContainer groupContainer4;
        private IContainer components;
        private ErrorProvider errorProvider1;
        private Label lbl_NAME;
        private Label lbl_ADDITIONALINFO;
        private Label lbl_BossType;
        private Label lbl_Cod;
        private Label lbl_MobilePhone;
        private Label lbl_EMAIL;
        private Label lbl_EMailBuh;
        private Label lbl_EmailSpam;
        private Label lbl_Http;
        private Label lbl_LEGALPOSTINDEX;
        private Label lbl_PostIndex;
        private Label lbl_PHONES;
        private Label lbl_CityDictionary;
        private Label lbl_LEGALADDRESS;
        private Label lbl_Address;
        private Label lbl_CountryDictionary;
        private Label lbl_CODEOKONH;
        private Label lbl_CODEOKPO;
        private Label lbl_KPP;
        private Label lbl_INN;
        private Label lbl_FullName;
        private Label lbl_MetroID;
        private Label lbl_CodeOGRN;
        private Label lbl_CodeOKATO;
        private Label lbl_CodeOKVED;
        private Label lbl_Fax;
        private Label label38;
        private Label lbl_StartWorkAgency;
        private Label lbl_NameEng;
        private Label lbl_OWNER;
        private Label lbl_BossName;
        private Label lbl_LICENSENUMBER;
        private Label lbl_RegisterSeries;
        private Label lbl_RegisterNumber;
        private lwComboBox mt_MetroID;
        private lwComboBox mt_CountryDictionary;
        private Panel pnlLayer0Fill;
        private Panel pnlLayer0Left;
        private Panel pnlLayer1F0Top;
        private GroupBox pnlListTypesPartner;
        private lwTextBox mt_ADDITIONALINFO;
        private lwTextBox mt_Address;
        private lwTextBox mt_BossType;
        private lwTextBox mt_BossName;
        private lwTextBox mt_Cod;
        private lwTextBox mt_CODEOKONH;
        private lwTextBox mt_CODEOKPO;
        private lwComboBox mt_CityDictionary;
        private lwTextBox mt_EMAIL;
        private lwTextBox mt_Fax;
        private lwTextBox mt_FullName;
        private lwTextBox mt_Http;
        private lwTextBox mt_INN;
        private lwTextBox mt_KPP;
        private lwTextBox mt_LEGALADDRESS;
        private lwTextBox mt_LEGALPOSTINDEX;
        private lwTextBox mt_LICENSENUMBER;
        private lwTextBox mt_NAME;
        private lwTextBox mt_NameEng;
        private lwComboBox mt_OWNER;
        private lwComboBox PR_PGKey;
        private lwTextBox mt_PHONES;
        private lwTextBox mt_PostIndex;
        private lwTextBox PR_RegisterNumber;
        private lwTextBox mt_RegisterSeries;
        private lwTextBox mt_CodeOGRN;
        private lwTextBox mt_CodeOKATO;
        private lwTextBox mt_CodeOKVED;
        private lwTextBox mt_EMailBuh;
        private lwTextBox mt_EmailSpam;
        private lwTextBox mt_MobilePhone;
        private lwDateTimePicker PRL_StartWorkAgency;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPartner));
            this.pnlLayer0Left = new System.Windows.Forms.Panel();
            this.gcSubAgency = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.SubAgencyDGV = new System.Windows.Forms.DataGridView();
            this.gcPassword = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOnLine = new System.Windows.Forms.TabPage();
            this.tabAvia = new System.Windows.Forms.TabPage();
            this.gcDogovors = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.groupContainer4 = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.mt_OWNER = new ltp_v2.Controls.Forms.lwComboBox();
            this.lbl_OWNER = new System.Windows.Forms.Label();
            this.gcAccount = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.pnlAccounts = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAddAccount = new System.Windows.Forms.ToolStripButton();
            this.groupContainer2 = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.mt_Address = new ltp_v2.Controls.Forms.lwTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mt_LEGALPOSTINDEX = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_PostIndex = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_LEGALADDRESS = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_Fax = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_EmailSpam = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_PHONES = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_EMailBuh = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_EMAIL = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_MobilePhone = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_INN = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_NAME = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_KPP = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_BossName = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_BossType = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_FullName = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_NameEng = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_Http = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_CodeOKVED = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_CodeOKATO = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_CodeOGRN = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_CODEOKPO = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_CODEOKONH = new ltp_v2.Controls.Forms.lwTextBox();
            this.PR_RegisterNumber = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_RegisterSeries = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_ADDITIONALINFO = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_LICENSENUMBER = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_BossWorkWith = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_BossFName = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_BossSName = new ltp_v2.Controls.Forms.lwTextBox();
            this.PRL_BossMobilePhone = new ltp_v2.Controls.Forms.lwTextBox();
            this.PRL_UnicalBossCode = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_EmailBoss = new ltp_v2.Controls.Forms.lwTextBox();
            this.lbl_PostIndex = new System.Windows.Forms.Label();
            this.lbl_LEGALPOSTINDEX = new System.Windows.Forms.Label();
            this.lbl_LEGALADDRESS = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_CountryDictionary = new System.Windows.Forms.Label();
            this.mt_CountryDictionary = new ltp_v2.Controls.Forms.lwComboBox();
            this.lbl_CityDictionary = new System.Windows.Forms.Label();
            this.mt_CityDictionary = new ltp_v2.Controls.Forms.lwComboBox();
            this.mt_MetroID = new ltp_v2.Controls.Forms.lwComboBox();
            this.lbl_MetroID = new System.Windows.Forms.Label();
            this.groupContainer1 = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_PHONES = new System.Windows.Forms.Label();
            this.lbl_Http = new System.Windows.Forms.Label();
            this.lbl_EmailSpam = new System.Windows.Forms.Label();
            this.lbl_Fax = new System.Windows.Forms.Label();
            this.lbl_MobilePhone = new System.Windows.Forms.Label();
            this.lbl_EMailBuh = new System.Windows.Forms.Label();
            this.lbl_EMAIL = new System.Windows.Forms.Label();
            this.groupBox1 = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_INN = new System.Windows.Forms.Label();
            this.lbl_CODEOKPO = new System.Windows.Forms.Label();
            this.lbl_CodeOKVED = new System.Windows.Forms.Label();
            this.lbl_KPP = new System.Windows.Forms.Label();
            this.lbl_CodeOKATO = new System.Windows.Forms.Label();
            this.lbl_CODEOKONH = new System.Windows.Forms.Label();
            this.lbl_CodeOGRN = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_BossName = new System.Windows.Forms.Label();
            this.lbl_BossType = new System.Windows.Forms.Label();
            this.lbl_RegisterNumber = new System.Windows.Forms.Label();
            this.lbl_LICENSENUMBER = new System.Windows.Forms.Label();
            this.lbl_RegisterSeries = new System.Windows.Forms.Label();
            this.lbl_ADDITIONALINFO = new System.Windows.Forms.Label();
            this.lbl_BossWorkWith = new System.Windows.Forms.Label();
            this.lbl_BossFName = new System.Windows.Forms.Label();
            this.lbl_BossSName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateUBC = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PRL_StartWorkAgency = new ltp_v2.Controls.Forms.lwDateTimePicker();
            this.lbl_StartWorkAgency = new System.Windows.Forms.Label();
            this.lbl_FullName = new System.Windows.Forms.Label();
            this.lbl_NameEng = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_NAME = new System.Windows.Forms.Label();
            this.lbl_Cod = new System.Windows.Forms.Label();
            this.mt_Cod = new ltp_v2.Controls.Forms.lwTextBox();
            this.pnlLayer1F0Top = new System.Windows.Forms.Panel();
            this.PR_PGKey = new ltp_v2.Controls.Forms.lwComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.pnlLayer0Fill = new System.Windows.Forms.Panel();
            this.pnlListTypesPartner = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnHistory = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSendMail = new System.Windows.Forms.ToolStripButton();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCallCenter = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAKA = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlLayer0Left.SuspendLayout();
            this.gcSubAgency.PnlContainer.SuspendLayout();
            this.gcSubAgency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubAgencyDGV)).BeginInit();
            this.gcPassword.PnlContainer.SuspendLayout();
            this.gcPassword.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.gcDogovors.SuspendLayout();
            this.groupContainer4.PnlContainer.SuspendLayout();
            this.groupContainer4.SuspendLayout();
            this.gcAccount.PnlContainer.SuspendLayout();
            this.gcAccount.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupContainer2.PnlContainer.SuspendLayout();
            this.groupContainer2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupContainer1.PnlContainer.SuspendLayout();
            this.groupContainer1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.PnlContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlLayer1F0Top.SuspendLayout();
            this.pnlLayer0Fill.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLayer0Left
            // 
            this.pnlLayer0Left.AutoScroll = true;
            this.pnlLayer0Left.Controls.Add(this.gcSubAgency);
            this.pnlLayer0Left.Controls.Add(this.gcPassword);
            this.pnlLayer0Left.Controls.Add(this.gcDogovors);
            this.pnlLayer0Left.Controls.Add(this.groupContainer4);
            this.pnlLayer0Left.Controls.Add(this.gcAccount);
            this.pnlLayer0Left.Controls.Add(this.groupContainer2);
            this.pnlLayer0Left.Controls.Add(this.groupContainer1);
            this.pnlLayer0Left.Controls.Add(this.groupBox1);
            this.pnlLayer0Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLayer0Left.Location = new System.Drawing.Point(0, 31);
            this.pnlLayer0Left.Name = "pnlLayer0Left";
            this.pnlLayer0Left.Size = new System.Drawing.Size(649, 542);
            this.pnlLayer0Left.TabIndex = 1;
            this.pnlLayer0Left.TabStop = true;
            // 
            // gcSubAgency
            // 
            this.gcSubAgency.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcSubAgency.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gcSubAgency.FullView = true;
            this.gcSubAgency.Location = new System.Drawing.Point(0, 1853);
            this.gcSubAgency.Name = "gcSubAgency";
            // 
            // gcSubAgency.PnlContainer
            // 
            this.gcSubAgency.PnlContainer.Controls.Add(this.SubAgencyDGV);
            this.gcSubAgency.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcSubAgency.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gcSubAgency.PnlContainer.Name = "PnlContainer";
            this.gcSubAgency.PnlContainer.Size = new System.Drawing.Size(632, 147);
            this.gcSubAgency.PnlContainer.TabIndex = 1;
            this.gcSubAgency.Size = new System.Drawing.Size(632, 170);
            this.gcSubAgency.TabIndex = 7;
            this.gcSubAgency.TextHeader = "Суб. агентства";
            // 
            // SubAgencyDGV
            // 
            this.SubAgencyDGV.AllowUserToAddRows = false;
            this.SubAgencyDGV.AllowUserToDeleteRows = false;
            this.SubAgencyDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SubAgencyDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.SubAgencyDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubAgencyDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubAgencyDGV.Location = new System.Drawing.Point(0, 0);
            this.SubAgencyDGV.MultiSelect = false;
            this.SubAgencyDGV.Name = "SubAgencyDGV";
            this.SubAgencyDGV.ReadOnly = true;
            this.SubAgencyDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SubAgencyDGV.Size = new System.Drawing.Size(632, 147);
            this.SubAgencyDGV.TabIndex = 24;
            // 
            // gcPassword
            // 
            this.gcPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gcPassword.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gcPassword.FullView = true;
            this.gcPassword.Location = new System.Drawing.Point(0, 1492);
            this.gcPassword.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.gcPassword.Name = "gcPassword";
            // 
            // gcPassword.PnlContainer
            // 
            this.gcPassword.PnlContainer.Controls.Add(this.tabControl1);
            this.gcPassword.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcPassword.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gcPassword.PnlContainer.Name = "PnlContainer";
            this.gcPassword.PnlContainer.Size = new System.Drawing.Size(632, 338);
            this.gcPassword.PnlContainer.TabIndex = 1;
            this.gcPassword.Size = new System.Drawing.Size(632, 361);
            this.gcPassword.TabIndex = 6;
            this.gcPassword.TabStop = false;
            this.gcPassword.TextHeader = "Коды доступа";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOnLine);
            this.tabControl1.Controls.Add(this.tabAvia);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(632, 338);
            this.tabControl1.TabIndex = 0;
            // 
            // tabOnLine
            // 
            this.tabOnLine.Location = new System.Drawing.Point(4, 22);
            this.tabOnLine.Name = "tabOnLine";
            this.tabOnLine.Padding = new System.Windows.Forms.Padding(3);
            this.tabOnLine.Size = new System.Drawing.Size(624, 312);
            this.tabOnLine.TabIndex = 0;
            this.tabOnLine.Text = "On-Line";
            this.tabOnLine.UseVisualStyleBackColor = true;
            // 
            // tabAvia
            // 
            this.tabAvia.Location = new System.Drawing.Point(4, 22);
            this.tabAvia.Name = "tabAvia";
            this.tabAvia.Padding = new System.Windows.Forms.Padding(3);
            this.tabAvia.Size = new System.Drawing.Size(641, 312);
            this.tabAvia.TabIndex = 2;
            this.tabAvia.Text = "Avia";
            this.tabAvia.UseVisualStyleBackColor = true;
            // 
            // gcDogovors
            // 
            this.gcDogovors.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcDogovors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gcDogovors.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gcDogovors.FullView = true;
            this.gcDogovors.Location = new System.Drawing.Point(0, 1221);
            this.gcDogovors.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.gcDogovors.Name = "gcDogovors";
            // 
            // gcDogovors.PnlContainer
            // 
            this.gcDogovors.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcDogovors.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gcDogovors.PnlContainer.Name = "PnlContainer";
            this.gcDogovors.PnlContainer.Size = new System.Drawing.Size(632, 248);
            this.gcDogovors.PnlContainer.TabIndex = 1;
            this.gcDogovors.Size = new System.Drawing.Size(632, 271);
            this.gcDogovors.TabIndex = 5;
            this.gcDogovors.TabStop = false;
            this.gcDogovors.TextHeader = "Договора";
            // 
            // groupContainer4
            // 
            this.groupContainer4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupContainer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupContainer4.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupContainer4.FullView = true;
            this.groupContainer4.Location = new System.Drawing.Point(0, 1147);
            this.groupContainer4.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.groupContainer4.Name = "groupContainer4";
            // 
            // groupContainer4.PnlContainer
            // 
            this.groupContainer4.PnlContainer.Controls.Add(this.mt_OWNER);
            this.groupContainer4.PnlContainer.Controls.Add(this.lbl_OWNER);
            this.groupContainer4.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupContainer4.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.groupContainer4.PnlContainer.Name = "PnlContainer";
            this.groupContainer4.PnlContainer.Size = new System.Drawing.Size(632, 51);
            this.groupContainer4.PnlContainer.TabIndex = 1;
            this.groupContainer4.Size = new System.Drawing.Size(632, 74);
            this.groupContainer4.TabIndex = 4;
            this.groupContainer4.TabStop = false;
            this.groupContainer4.TextHeader = "Ведущий менеджер";
            // 
            // mt_OWNER
            // 
            this.mt_OWNER.ChangeBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mt_OWNER.ErrorBackGroundColor = System.Drawing.Color.Red;
            this.mt_OWNER.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_OWNER.ErrorProvider = null;
            this.mt_OWNER.FormattingEnabled = true;
            this.mt_OWNER.IsNotNullValue = true;
            this.mt_OWNER.Location = new System.Drawing.Point(90, 12);
            this.mt_OWNER.MessageInformationError = "";
            this.mt_OWNER.Name = "mt_OWNER";
            this.mt_OWNER.Size = new System.Drawing.Size(520, 21);
            this.mt_OWNER.TabIndex = 0;
            // 
            // lbl_OWNER
            // 
            this.lbl_OWNER.AutoSize = true;
            this.lbl_OWNER.Location = new System.Drawing.Point(13, 15);
            this.lbl_OWNER.Name = "lbl_OWNER";
            this.lbl_OWNER.Size = new System.Drawing.Size(34, 13);
            this.lbl_OWNER.TabIndex = 0;
            this.lbl_OWNER.Text = "ФИО";
            // 
            // gcAccount
            // 
            this.gcAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gcAccount.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gcAccount.FullView = true;
            this.gcAccount.Location = new System.Drawing.Point(0, 846);
            this.gcAccount.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.gcAccount.Name = "gcAccount";
            // 
            // gcAccount.PnlContainer
            // 
            this.gcAccount.PnlContainer.AutoScroll = true;
            this.gcAccount.PnlContainer.Controls.Add(this.pnlAccounts);
            this.gcAccount.PnlContainer.Controls.Add(this.panel1);
            this.gcAccount.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcAccount.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gcAccount.PnlContainer.Name = "PnlContainer";
            this.gcAccount.PnlContainer.Size = new System.Drawing.Size(632, 278);
            this.gcAccount.PnlContainer.TabIndex = 1;
            this.gcAccount.Size = new System.Drawing.Size(632, 301);
            this.gcAccount.TabIndex = 3;
            this.gcAccount.TabStop = false;
            this.gcAccount.TextHeader = "Банковские счета";
            // 
            // pnlAccounts
            // 
            this.pnlAccounts.AutoScroll = true;
            this.pnlAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccounts.Location = new System.Drawing.Point(0, 30);
            this.pnlAccounts.Name = "pnlAccounts";
            this.pnlAccounts.Size = new System.Drawing.Size(632, 248);
            this.pnlAccounts.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 30);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAddAccount});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(632, 31);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsBtnAddAccount
            // 
            this.tsBtnAddAccount.Image = global::AgencyManager.Properties.Resources.Add;
            this.tsBtnAddAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddAccount.Name = "tsBtnAddAccount";
            this.tsBtnAddAccount.Size = new System.Drawing.Size(87, 28);
            this.tsBtnAddAccount.Text = "Добавить";
            this.tsBtnAddAccount.Click += new System.EventHandler(this.tsBtnAddAccount_Click);
            // 
            // groupContainer2
            // 
            this.groupContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupContainer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupContainer2.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupContainer2.FullView = true;
            this.groupContainer2.Location = new System.Drawing.Point(0, 699);
            this.groupContainer2.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.groupContainer2.Name = "groupContainer2";
            // 
            // groupContainer2.PnlContainer
            // 
            this.groupContainer2.PnlContainer.Controls.Add(this.tableLayoutPanel6);
            this.groupContainer2.PnlContainer.Controls.Add(this.tableLayoutPanel5);
            this.groupContainer2.PnlContainer.Controls.Add(this.mt_MetroID);
            this.groupContainer2.PnlContainer.Controls.Add(this.lbl_MetroID);
            this.groupContainer2.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupContainer2.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.groupContainer2.PnlContainer.Name = "PnlContainer";
            this.groupContainer2.PnlContainer.Size = new System.Drawing.Size(632, 124);
            this.groupContainer2.PnlContainer.TabIndex = 1;
            this.groupContainer2.Size = new System.Drawing.Size(632, 147);
            this.groupContainer2.TabIndex = 2;
            this.groupContainer2.TabStop = false;
            this.groupContainer2.TextHeader = "Адреса";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel6.Controls.Add(this.lbl_Address, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.mt_Address, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lbl_PostIndex, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.mt_LEGALPOSTINDEX, 3, 1);
            this.tableLayoutPanel6.Controls.Add(this.mt_PostIndex, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.mt_LEGALADDRESS, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.lbl_LEGALPOSTINDEX, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.lbl_LEGALADDRESS, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(632, 55);
            this.tableLayoutPanel6.TabIndex = 8;
            // 
            // lbl_Address
            // 
            this.lbl_Address.AutoSize = true;
            this.lbl_Address.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Address.Location = new System.Drawing.Point(13, 0);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.Size = new System.Drawing.Size(104, 27);
            this.lbl_Address.TabIndex = 1;
            this.lbl_Address.Text = "Физический адрес";
            this.lbl_Address.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mt_Address
            // 
            this.mt_Address.BackColor = System.Drawing.SystemColors.Window;
            this.mt_Address.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Address.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Address.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_Address, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_Address.Location = new System.Drawing.Point(123, 3);
            this.mt_Address.MessageInformationError = "";
            this.mt_Address.Name = "mt_Address";
            this.mt_Address.RegexVerify = "";
            this.mt_Address.Size = new System.Drawing.Size(306, 20);
            this.mt_Address.TabIndex = 0;
            this.mt_Address.VerifyMaxLength = 160;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // mt_LEGALPOSTINDEX
            // 
            this.mt_LEGALPOSTINDEX.BackColor = System.Drawing.SystemColors.Window;
            this.mt_LEGALPOSTINDEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_LEGALPOSTINDEX.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_LEGALPOSTINDEX.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_LEGALPOSTINDEX, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_LEGALPOSTINDEX.Location = new System.Drawing.Point(515, 30);
            this.mt_LEGALPOSTINDEX.MessageInformationError = "";
            this.mt_LEGALPOSTINDEX.Name = "mt_LEGALPOSTINDEX";
            this.mt_LEGALPOSTINDEX.RegexVerify = "";
            this.mt_LEGALPOSTINDEX.Size = new System.Drawing.Size(114, 20);
            this.mt_LEGALPOSTINDEX.TabIndex = 3;
            this.mt_LEGALPOSTINDEX.VerifyMaxLength = 6;
            // 
            // mt_PostIndex
            // 
            this.mt_PostIndex.BackColor = System.Drawing.SystemColors.Window;
            this.mt_PostIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_PostIndex.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_PostIndex.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_PostIndex, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_PostIndex.Location = new System.Drawing.Point(515, 3);
            this.mt_PostIndex.MessageInformationError = "";
            this.mt_PostIndex.Name = "mt_PostIndex";
            this.mt_PostIndex.RegexVerify = "";
            this.mt_PostIndex.Size = new System.Drawing.Size(114, 20);
            this.mt_PostIndex.TabIndex = 1;
            this.mt_PostIndex.VerifyMaxLength = 6;
            // 
            // mt_LEGALADDRESS
            // 
            this.mt_LEGALADDRESS.BackColor = System.Drawing.SystemColors.Window;
            this.mt_LEGALADDRESS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_LEGALADDRESS.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_LEGALADDRESS.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_LEGALADDRESS, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_LEGALADDRESS.Location = new System.Drawing.Point(123, 30);
            this.mt_LEGALADDRESS.MessageInformationError = "";
            this.mt_LEGALADDRESS.Name = "mt_LEGALADDRESS";
            this.mt_LEGALADDRESS.RegexVerify = "";
            this.mt_LEGALADDRESS.Size = new System.Drawing.Size(306, 20);
            this.mt_LEGALADDRESS.TabIndex = 2;
            this.mt_LEGALADDRESS.VerifyMaxLength = 160;
            // 
            // mt_Fax
            // 
            this.mt_Fax.BackColor = System.Drawing.SystemColors.Window;
            this.mt_Fax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Fax.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Fax.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_Fax, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_Fax.Location = new System.Drawing.Point(163, 49);
            this.mt_Fax.MessageInformationError = "Формат +74957866860 где +(код страны)(код города)(номер телефона) разделение чере" +
    "з ;";
            this.mt_Fax.Name = "mt_Fax";
            this.mt_Fax.RegexVerify = "((\\+[0-9]{1,2}|)(\\([0-9]{2,5}\\)|)[0-9]{1,4}(-|)[0-9]{1,4}((-|)[0-9]{1,4}|)(;|$)|$" +
    ")+";
            this.mt_Fax.Size = new System.Drawing.Size(466, 20);
            this.mt_Fax.TabIndex = 2;
            this.mt_Fax.VerifyMaxLength = 20;
            // 
            // mt_EmailSpam
            // 
            this.mt_EmailSpam.BackColor = System.Drawing.SystemColors.Window;
            this.mt_EmailSpam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_EmailSpam.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_EmailSpam.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_EmailSpam, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_EmailSpam.Location = new System.Drawing.Point(163, 118);
            this.mt_EmailSpam.MessageInformationError = "Разделение ящиков через ;";
            this.mt_EmailSpam.Name = "mt_EmailSpam";
            this.mt_EmailSpam.RegexVerify = "(([-!#$%&\\\'*+\\\\.\\/0-9=?A-Za-z^_{|}~]+@[A-Za-z0-9\\._-]+\\.[A-Za-z]{2,6}(;|$))+|$)+";
            this.mt_EmailSpam.Size = new System.Drawing.Size(466, 20);
            this.mt_EmailSpam.TabIndex = 5;
            this.mt_EmailSpam.VerifyMaxLength = 50;
            // 
            // mt_PHONES
            // 
            this.mt_PHONES.BackColor = System.Drawing.SystemColors.Window;
            this.mt_PHONES.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_PHONES.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_PHONES.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_PHONES, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_PHONES.Location = new System.Drawing.Point(163, 3);
            this.mt_PHONES.MessageInformationError = "Это поле обязательное. Формат +74957866860 где +(код страны)(код города)(номер те" +
    "лефона) разделение через ;";
            this.mt_PHONES.Name = "mt_PHONES";
            this.mt_PHONES.RegexVerify = "((\\+[0-9]{1,2}|)(\\([0-9]{2,5}\\)|)[0-9]{1,4}(-|)[0-9]{1,4}((-|)[0-9]{1,4}|)(;|$))+" +
    "";
            this.mt_PHONES.Size = new System.Drawing.Size(466, 20);
            this.mt_PHONES.TabIndex = 0;
            this.mt_PHONES.VerifyMaxLength = 254;
            // 
            // mt_EMailBuh
            // 
            this.mt_EMailBuh.BackColor = System.Drawing.SystemColors.Window;
            this.mt_EMailBuh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_EMailBuh.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_EMailBuh.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_EMailBuh, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_EMailBuh.Location = new System.Drawing.Point(163, 95);
            this.mt_EMailBuh.MessageInformationError = "Разделение ящиков через ;";
            this.mt_EMailBuh.Name = "mt_EMailBuh";
            this.mt_EMailBuh.RegexVerify = "(([-!#$%&\\\'*+\\\\.\\/0-9=?A-Za-z^_{|}~]+@[A-Za-z0-9\\._-]+\\.[A-Za-z]{2,6}(;|$))+|$)+";
            this.mt_EMailBuh.Size = new System.Drawing.Size(466, 20);
            this.mt_EMailBuh.TabIndex = 4;
            this.mt_EMailBuh.VerifyMaxLength = 50;
            // 
            // mt_EMAIL
            // 
            this.mt_EMAIL.BackColor = System.Drawing.SystemColors.Window;
            this.mt_EMAIL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_EMAIL.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_EMAIL.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_EMAIL, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_EMAIL.Location = new System.Drawing.Point(163, 72);
            this.mt_EMAIL.MessageInformationError = "Обязательное поле разделение ящиков через ;";
            this.mt_EMAIL.Name = "mt_EMAIL";
            this.mt_EMAIL.RegexVerify = "([-!#$%&\\\'*+\\\\.\\/0-9=?A-Za-z^_{|}~]+@[A-Za-z0-9\\._-]+\\.[A-Za-z]{2,6}(;|$))+";
            this.mt_EMAIL.Size = new System.Drawing.Size(466, 20);
            this.mt_EMAIL.TabIndex = 3;
            this.mt_EMAIL.VerifyMaxLength = 50;
            // 
            // mt_MobilePhone
            // 
            this.mt_MobilePhone.BackColor = System.Drawing.SystemColors.Window;
            this.mt_MobilePhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_MobilePhone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_MobilePhone.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_MobilePhone, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_MobilePhone.Location = new System.Drawing.Point(163, 26);
            this.mt_MobilePhone.MessageInformationError = "Формат +74957866860 где +(код страны)(код города)(номер телефона) разделение чере" +
    "з ;";
            this.mt_MobilePhone.Name = "mt_MobilePhone";
            this.mt_MobilePhone.RegexVerify = "((\\+[0-9]{1,2}|)(\\([0-9]{2,5}\\)|)[0-9]{1,4}(-|)[0-9]{1,4}((-|)[0-9]{1,4}|)(;|$)|$" +
    ")+";
            this.mt_MobilePhone.Size = new System.Drawing.Size(466, 20);
            this.mt_MobilePhone.TabIndex = 1;
            this.mt_MobilePhone.VerifyMaxLength = 255;
            // 
            // mt_INN
            // 
            this.mt_INN.BackColor = System.Drawing.SystemColors.Window;
            this.mt_INN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_INN.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_INN.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_INN, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_INN.Location = new System.Drawing.Point(103, 3);
            this.mt_INN.MessageInformationError = "Поле должно содержать 2 или более символа или оставаться пустым";
            this.mt_INN.Name = "mt_INN";
            this.mt_INN.RegexVerify = "$|(\\s*\\S+\\s*){2,}";
            this.mt_INN.Size = new System.Drawing.Size(210, 20);
            this.mt_INN.TabIndex = 0;
            this.mt_INN.VerifyMaxLength = 50;
            // 
            // mt_NAME
            // 
            this.mt_NAME.AcceptsReturn = true;
            this.mt_NAME.BackColor = System.Drawing.SystemColors.Window;
            this.mt_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_NAME.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_NAME.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_NAME, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_NAME.Location = new System.Drawing.Point(163, 3);
            this.mt_NAME.MessageInformationError = "Это поле обязательное";
            this.mt_NAME.Name = "mt_NAME";
            this.mt_NAME.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_NAME.Size = new System.Drawing.Size(316, 20);
            this.mt_NAME.TabIndex = 1;
            this.mt_NAME.VerifyMaxLength = 50;
            // 
            // mt_KPP
            // 
            this.mt_KPP.BackColor = System.Drawing.SystemColors.Window;
            this.mt_KPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_KPP.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_KPP.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_KPP, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_KPP.Location = new System.Drawing.Point(103, 29);
            this.mt_KPP.MessageInformationError = "";
            this.mt_KPP.Name = "mt_KPP";
            this.mt_KPP.RegexVerify = "";
            this.mt_KPP.Size = new System.Drawing.Size(210, 20);
            this.mt_KPP.TabIndex = 1;
            this.mt_KPP.VerifyMaxLength = 30;
            // 
            // mt_BossName
            // 
            this.mt_BossName.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel3.SetColumnSpan(this.mt_BossName, 3);
            this.mt_BossName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_BossName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_BossName.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_BossName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_BossName.Location = new System.Drawing.Point(163, 3);
            this.mt_BossName.MessageInformationError = "Обязательное для заполнения, должно содержать 2 или более символа";
            this.mt_BossName.Name = "mt_BossName";
            this.mt_BossName.RegexVerify = "(\\s*\\S+\\s*){2,}";
            this.mt_BossName.Size = new System.Drawing.Size(466, 20);
            this.mt_BossName.TabIndex = 0;
            this.mt_BossName.VerifyMaxLength = 20;
            // 
            // mt_BossType
            // 
            this.mt_BossType.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel3.SetColumnSpan(this.mt_BossType, 3);
            this.mt_BossType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_BossType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_BossType.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_BossType, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_BossType.Location = new System.Drawing.Point(163, 128);
            this.mt_BossType.MessageInformationError = "Обязательное поле";
            this.mt_BossType.Name = "mt_BossType";
            this.mt_BossType.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_BossType.Size = new System.Drawing.Size(466, 20);
            this.mt_BossType.TabIndex = 1;
            this.mt_BossType.VerifyMaxLength = 50;
            // 
            // mt_FullName
            // 
            this.mt_FullName.BackColor = System.Drawing.SystemColors.Window;
            this.mt_FullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_FullName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_FullName.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_FullName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_FullName.Location = new System.Drawing.Point(163, 3);
            this.mt_FullName.MessageInformationError = "Это поле обязательное";
            this.mt_FullName.Name = "mt_FullName";
            this.mt_FullName.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_FullName.Size = new System.Drawing.Size(472, 20);
            this.mt_FullName.TabIndex = 2;
            this.mt_FullName.VerifyMaxLength = 160;
            // 
            // mt_NameEng
            // 
            this.mt_NameEng.BackColor = System.Drawing.SystemColors.Window;
            this.mt_NameEng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_NameEng.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_NameEng.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_NameEng, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_NameEng.Location = new System.Drawing.Point(163, 29);
            this.mt_NameEng.MessageInformationError = "Это поле обязательное";
            this.mt_NameEng.Name = "mt_NameEng";
            this.mt_NameEng.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_NameEng.Size = new System.Drawing.Size(472, 20);
            this.mt_NameEng.TabIndex = 3;
            this.mt_NameEng.VerifyMaxLength = 80;
            // 
            // mt_Http
            // 
            this.mt_Http.BackColor = System.Drawing.SystemColors.Window;
            this.mt_Http.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Http.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Http.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_Http, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_Http.Location = new System.Drawing.Point(163, 164);
            this.mt_Http.MessageInformationError = "";
            this.mt_Http.Name = "mt_Http";
            this.mt_Http.RegexVerify = "";
            this.mt_Http.Size = new System.Drawing.Size(466, 20);
            this.mt_Http.TabIndex = 6;
            this.mt_Http.VerifyMaxLength = 254;
            // 
            // mt_CodeOKVED
            // 
            this.mt_CodeOKVED.BackColor = System.Drawing.SystemColors.Window;
            this.mt_CodeOKVED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CodeOKVED.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CodeOKVED.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_CodeOKVED, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_CodeOKVED.Location = new System.Drawing.Point(419, 107);
            this.mt_CodeOKVED.MessageInformationError = "";
            this.mt_CodeOKVED.Name = "mt_CodeOKVED";
            this.mt_CodeOKVED.RegexVerify = "";
            this.mt_CodeOKVED.Size = new System.Drawing.Size(210, 20);
            this.mt_CodeOKVED.TabIndex = 6;
            this.mt_CodeOKVED.VerifyMaxLength = 50;
            // 
            // mt_CodeOKATO
            // 
            this.mt_CodeOKATO.BackColor = System.Drawing.SystemColors.Window;
            this.mt_CodeOKATO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CodeOKATO.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CodeOKATO.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_CodeOKATO, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_CodeOKATO.Location = new System.Drawing.Point(419, 81);
            this.mt_CodeOKATO.MessageInformationError = "";
            this.mt_CodeOKATO.Name = "mt_CodeOKATO";
            this.mt_CodeOKATO.RegexVerify = "";
            this.mt_CodeOKATO.Size = new System.Drawing.Size(210, 20);
            this.mt_CodeOKATO.TabIndex = 5;
            this.mt_CodeOKATO.VerifyMaxLength = 50;
            // 
            // mt_CodeOGRN
            // 
            this.mt_CodeOGRN.BackColor = System.Drawing.SystemColors.Window;
            this.mt_CodeOGRN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CodeOGRN.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CodeOGRN.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_CodeOGRN, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_CodeOGRN.Location = new System.Drawing.Point(419, 55);
            this.mt_CodeOGRN.MessageInformationError = "";
            this.mt_CodeOGRN.Name = "mt_CodeOGRN";
            this.mt_CodeOGRN.RegexVerify = "";
            this.mt_CodeOGRN.Size = new System.Drawing.Size(210, 20);
            this.mt_CodeOGRN.TabIndex = 4;
            this.mt_CodeOGRN.VerifyMaxLength = 30;
            // 
            // mt_CODEOKPO
            // 
            this.mt_CODEOKPO.BackColor = System.Drawing.SystemColors.Window;
            this.mt_CODEOKPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CODEOKPO.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CODEOKPO.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_CODEOKPO, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_CODEOKPO.Location = new System.Drawing.Point(419, 3);
            this.mt_CODEOKPO.MessageInformationError = "";
            this.mt_CODEOKPO.Name = "mt_CODEOKPO";
            this.mt_CODEOKPO.RegexVerify = "";
            this.mt_CODEOKPO.Size = new System.Drawing.Size(210, 20);
            this.mt_CODEOKPO.TabIndex = 2;
            this.mt_CODEOKPO.VerifyMaxLength = 30;
            // 
            // mt_CODEOKONH
            // 
            this.mt_CODEOKONH.BackColor = System.Drawing.SystemColors.Window;
            this.mt_CODEOKONH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CODEOKONH.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CODEOKONH.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_CODEOKONH, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_CODEOKONH.Location = new System.Drawing.Point(419, 29);
            this.mt_CODEOKONH.MessageInformationError = "";
            this.mt_CODEOKONH.Name = "mt_CODEOKONH";
            this.mt_CODEOKONH.RegexVerify = "";
            this.mt_CODEOKONH.Size = new System.Drawing.Size(210, 20);
            this.mt_CODEOKONH.TabIndex = 3;
            this.mt_CODEOKONH.VerifyMaxLength = 30;
            // 
            // PR_RegisterNumber
            // 
            this.PR_RegisterNumber.BackColor = System.Drawing.SystemColors.Window;
            this.PR_RegisterNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PR_RegisterNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.PR_RegisterNumber.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.PR_RegisterNumber, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.PR_RegisterNumber.Location = new System.Drawing.Point(449, 203);
            this.PR_RegisterNumber.MessageInformationError = "";
            this.PR_RegisterNumber.Name = "PR_RegisterNumber";
            this.PR_RegisterNumber.RegexVerify = "";
            this.PR_RegisterNumber.Size = new System.Drawing.Size(180, 20);
            this.PR_RegisterNumber.TabIndex = 5;
            this.PR_RegisterNumber.VerifyMaxLength = 50;
            // 
            // mt_RegisterSeries
            // 
            this.mt_RegisterSeries.BackColor = System.Drawing.SystemColors.Window;
            this.mt_RegisterSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_RegisterSeries.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_RegisterSeries.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_RegisterSeries, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_RegisterSeries.Location = new System.Drawing.Point(163, 203);
            this.mt_RegisterSeries.MessageInformationError = "";
            this.mt_RegisterSeries.Name = "mt_RegisterSeries";
            this.mt_RegisterSeries.RegexVerify = "";
            this.mt_RegisterSeries.Size = new System.Drawing.Size(180, 20);
            this.mt_RegisterSeries.TabIndex = 4;
            this.mt_RegisterSeries.VerifyMaxLength = 10;
            // 
            // mt_ADDITIONALINFO
            // 
            this.mt_ADDITIONALINFO.BackColor = System.Drawing.SystemColors.Window;
            this.mt_ADDITIONALINFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_ADDITIONALINFO.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_ADDITIONALINFO.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_ADDITIONALINFO, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_ADDITIONALINFO.Location = new System.Drawing.Point(449, 178);
            this.mt_ADDITIONALINFO.MessageInformationError = "";
            this.mt_ADDITIONALINFO.Name = "mt_ADDITIONALINFO";
            this.mt_ADDITIONALINFO.RegexVerify = "";
            this.mt_ADDITIONALINFO.Size = new System.Drawing.Size(180, 20);
            this.mt_ADDITIONALINFO.TabIndex = 3;
            this.mt_ADDITIONALINFO.VerifyMaxLength = 50;
            // 
            // mt_LICENSENUMBER
            // 
            this.mt_LICENSENUMBER.BackColor = System.Drawing.SystemColors.Window;
            this.mt_LICENSENUMBER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_LICENSENUMBER.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_LICENSENUMBER.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_LICENSENUMBER, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_LICENSENUMBER.Location = new System.Drawing.Point(163, 178);
            this.mt_LICENSENUMBER.MessageInformationError = "";
            this.mt_LICENSENUMBER.Name = "mt_LICENSENUMBER";
            this.mt_LICENSENUMBER.RegexVerify = "";
            this.mt_LICENSENUMBER.Size = new System.Drawing.Size(180, 20);
            this.mt_LICENSENUMBER.TabIndex = 2;
            this.mt_LICENSENUMBER.VerifyMaxLength = 50;
            // 
            // mt_BossWorkWith
            // 
            this.mt_BossWorkWith.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel3.SetColumnSpan(this.mt_BossWorkWith, 3);
            this.mt_BossWorkWith.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_BossWorkWith.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_BossWorkWith.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_BossWorkWith, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_BossWorkWith.Location = new System.Drawing.Point(163, 153);
            this.mt_BossWorkWith.MessageInformationError = "Обязательное поле";
            this.mt_BossWorkWith.Name = "mt_BossWorkWith";
            this.mt_BossWorkWith.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_BossWorkWith.Size = new System.Drawing.Size(466, 20);
            this.mt_BossWorkWith.TabIndex = 11;
            this.mt_BossWorkWith.VerifyMaxLength = 40;
            // 
            // mt_BossFName
            // 
            this.mt_BossFName.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel3.SetColumnSpan(this.mt_BossFName, 3);
            this.mt_BossFName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_BossFName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_BossFName.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_BossFName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_BossFName.Location = new System.Drawing.Point(163, 28);
            this.mt_BossFName.MessageInformationError = "Обязательное для заполнения, должно содержать 2 или более символа";
            this.mt_BossFName.Name = "mt_BossFName";
            this.mt_BossFName.RegexVerify = "(\\s*\\S+\\s*){2,}";
            this.mt_BossFName.Size = new System.Drawing.Size(466, 20);
            this.mt_BossFName.TabIndex = 14;
            this.mt_BossFName.VerifyMaxLength = 20;
            // 
            // mt_BossSName
            // 
            this.mt_BossSName.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel3.SetColumnSpan(this.mt_BossSName, 3);
            this.mt_BossSName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_BossSName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_BossSName.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_BossSName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_BossSName.Location = new System.Drawing.Point(163, 53);
            this.mt_BossSName.MessageInformationError = "Поле должно содержать 2 или более символа или оставаться пустым";
            this.mt_BossSName.Name = "mt_BossSName";
            this.mt_BossSName.RegexVerify = "$|(\\s*\\S+\\s*){2,}";
            this.mt_BossSName.Size = new System.Drawing.Size(466, 20);
            this.mt_BossSName.TabIndex = 15;
            this.mt_BossSName.VerifyMaxLength = 20;
            // 
            // PRL_BossMobilePhone
            // 
            this.PRL_BossMobilePhone.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel3.SetColumnSpan(this.PRL_BossMobilePhone, 2);
            this.PRL_BossMobilePhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PRL_BossMobilePhone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.PRL_BossMobilePhone.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.PRL_BossMobilePhone, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.PRL_BossMobilePhone.Location = new System.Drawing.Point(349, 103);
            this.PRL_BossMobilePhone.MessageInformationError = "Формат +74957866860 где +(код страны)(код города)(номер телефона) разделение чере" +
    "з ;";
            this.PRL_BossMobilePhone.Name = "PRL_BossMobilePhone";
            this.PRL_BossMobilePhone.RegexVerify = "\\+[0-9]{10,14}|";
            this.PRL_BossMobilePhone.Size = new System.Drawing.Size(280, 20);
            this.PRL_BossMobilePhone.TabIndex = 18;
            this.PRL_BossMobilePhone.VerifyMaxLength = 20;
            // 
            // PRL_UnicalBossCode
            // 
            this.PRL_UnicalBossCode.BackColor = System.Drawing.SystemColors.Window;
            this.PRL_UnicalBossCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PRL_UnicalBossCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.PRL_UnicalBossCode.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.PRL_UnicalBossCode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.PRL_UnicalBossCode.Location = new System.Drawing.Point(3, 78);
            this.PRL_UnicalBossCode.MessageInformationError = "Формат +74957866860 где +(код страны)(код города)(номер телефона) разделение чере" +
    "з ;";
            this.PRL_UnicalBossCode.Name = "PRL_UnicalBossCode";
            this.PRL_UnicalBossCode.ReadOnly = true;
            this.PRL_UnicalBossCode.RegexVerify = "";
            this.PRL_UnicalBossCode.Size = new System.Drawing.Size(154, 20);
            this.PRL_UnicalBossCode.TabIndex = 19;
            this.PRL_UnicalBossCode.VerifyMaxLength = 20;
            this.PRL_UnicalBossCode.Visible = false;
            // 
            // mt_EmailBoss
            // 
            this.mt_EmailBoss.BackColor = System.Drawing.SystemColors.Window;
            this.mt_EmailBoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_EmailBoss.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_EmailBoss.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.mt_EmailBoss, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_EmailBoss.Location = new System.Drawing.Point(163, 141);
            this.mt_EmailBoss.MessageInformationError = "Разделение ящиков через ;";
            this.mt_EmailBoss.Name = "mt_EmailBoss";
            this.mt_EmailBoss.RegexVerify = "(([-!#$%&\\\'*+\\\\.\\/0-9=?A-Za-z^_{|}~]+@[A-Za-z0-9\\._-]+\\.[A-Za-z]{2,6}(;|$))+|$)+";
            this.mt_EmailBoss.Size = new System.Drawing.Size(466, 20);
            this.mt_EmailBoss.TabIndex = 6;
            this.mt_EmailBoss.VerifyMaxLength = 50;
            // 
            // lbl_PostIndex
            // 
            this.lbl_PostIndex.AutoSize = true;
            this.lbl_PostIndex.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_PostIndex.Location = new System.Drawing.Point(464, 0);
            this.lbl_PostIndex.Name = "lbl_PostIndex";
            this.lbl_PostIndex.Size = new System.Drawing.Size(45, 27);
            this.lbl_PostIndex.TabIndex = 4;
            this.lbl_PostIndex.Text = "Индекс";
            this.lbl_PostIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_LEGALPOSTINDEX
            // 
            this.lbl_LEGALPOSTINDEX.AutoSize = true;
            this.lbl_LEGALPOSTINDEX.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_LEGALPOSTINDEX.Location = new System.Drawing.Point(464, 27);
            this.lbl_LEGALPOSTINDEX.Name = "lbl_LEGALPOSTINDEX";
            this.lbl_LEGALPOSTINDEX.Size = new System.Drawing.Size(45, 28);
            this.lbl_LEGALPOSTINDEX.TabIndex = 5;
            this.lbl_LEGALPOSTINDEX.Text = "Индекс";
            this.lbl_LEGALPOSTINDEX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_LEGALADDRESS
            // 
            this.lbl_LEGALADDRESS.AutoSize = true;
            this.lbl_LEGALADDRESS.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_LEGALADDRESS.Location = new System.Drawing.Point(9, 27);
            this.lbl_LEGALADDRESS.Name = "lbl_LEGALADDRESS";
            this.lbl_LEGALADDRESS.Size = new System.Drawing.Size(108, 28);
            this.lbl_LEGALADDRESS.TabIndex = 2;
            this.lbl_LEGALADDRESS.Text = "Юридический адрес";
            this.lbl_LEGALADDRESS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.lbl_CountryDictionary, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.mt_CountryDictionary, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lbl_CityDictionary, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.mt_CityDictionary, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(632, 27);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // lbl_CountryDictionary
            // 
            this.lbl_CountryDictionary.AutoSize = true;
            this.lbl_CountryDictionary.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CountryDictionary.Location = new System.Drawing.Point(34, 0);
            this.lbl_CountryDictionary.Name = "lbl_CountryDictionary";
            this.lbl_CountryDictionary.Size = new System.Drawing.Size(43, 27);
            this.lbl_CountryDictionary.TabIndex = 0;
            this.lbl_CountryDictionary.Text = "Страна";
            this.lbl_CountryDictionary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mt_CountryDictionary
            // 
            this.mt_CountryDictionary.ChangeBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mt_CountryDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CountryDictionary.ErrorBackGroundColor = System.Drawing.Color.Red;
            this.mt_CountryDictionary.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CountryDictionary.ErrorProvider = null;
            this.mt_CountryDictionary.FormattingEnabled = true;
            this.mt_CountryDictionary.IsNotNullValue = true;
            this.mt_CountryDictionary.Location = new System.Drawing.Point(83, 3);
            this.mt_CountryDictionary.MessageInformationError = "";
            this.mt_CountryDictionary.Name = "mt_CountryDictionary";
            this.mt_CountryDictionary.Size = new System.Drawing.Size(230, 21);
            this.mt_CountryDictionary.TabIndex = 0;
            this.mt_CountryDictionary.SelectedIndexChanged += new System.EventHandler(this.mt_CNKey_SelectedIndexChanged);
            // 
            // lbl_CityDictionary
            // 
            this.lbl_CityDictionary.AutoSize = true;
            this.lbl_CityDictionary.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CityDictionary.Location = new System.Drawing.Point(356, 0);
            this.lbl_CityDictionary.Name = "lbl_CityDictionary";
            this.lbl_CityDictionary.Size = new System.Drawing.Size(37, 27);
            this.lbl_CityDictionary.TabIndex = 3;
            this.lbl_CityDictionary.Text = "Город";
            this.lbl_CityDictionary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mt_CityDictionary
            // 
            this.mt_CityDictionary.ChangeBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mt_CityDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CityDictionary.ErrorBackGroundColor = System.Drawing.Color.Red;
            this.mt_CityDictionary.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CityDictionary.ErrorProvider = this.errorProvider1;
            this.mt_CityDictionary.FormattingEnabled = true;
            this.mt_CityDictionary.IsNotNullValue = true;
            this.mt_CityDictionary.Location = new System.Drawing.Point(399, 3);
            this.mt_CityDictionary.MessageInformationError = "Это обязательное поле";
            this.mt_CityDictionary.Name = "mt_CityDictionary";
            this.mt_CityDictionary.Size = new System.Drawing.Size(230, 21);
            this.mt_CityDictionary.TabIndex = 1;
            // 
            // mt_MetroID
            // 
            this.mt_MetroID.ChangeBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mt_MetroID.ErrorBackGroundColor = System.Drawing.Color.Red;
            this.mt_MetroID.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_MetroID.ErrorProvider = this.errorProvider1;
            this.mt_MetroID.FormattingEnabled = true;
            this.mt_MetroID.IsNotNullValue = false;
            this.mt_MetroID.Location = new System.Drawing.Point(124, 88);
            this.mt_MetroID.MessageInformationError = "";
            this.mt_MetroID.Name = "mt_MetroID";
            this.mt_MetroID.Size = new System.Drawing.Size(183, 21);
            this.mt_MetroID.TabIndex = 0;
            // 
            // lbl_MetroID
            // 
            this.lbl_MetroID.AutoSize = true;
            this.lbl_MetroID.Location = new System.Drawing.Point(26, 91);
            this.lbl_MetroID.Name = "lbl_MetroID";
            this.lbl_MetroID.Size = new System.Drawing.Size(83, 13);
            this.lbl_MetroID.TabIndex = 6;
            this.lbl_MetroID.Text = "Станция метро";
            // 
            // groupContainer1
            // 
            this.groupContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupContainer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupContainer1.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupContainer1.FullView = true;
            this.groupContainer1.Location = new System.Drawing.Point(0, 485);
            this.groupContainer1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.groupContainer1.Name = "groupContainer1";
            // 
            // groupContainer1.PnlContainer
            // 
            this.groupContainer1.PnlContainer.Controls.Add(this.tableLayoutPanel4);
            this.groupContainer1.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupContainer1.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.groupContainer1.PnlContainer.Name = "PnlContainer";
            this.groupContainer1.PnlContainer.Size = new System.Drawing.Size(632, 191);
            this.groupContainer1.PnlContainer.TabIndex = 1;
            this.groupContainer1.Size = new System.Drawing.Size(632, 214);
            this.groupContainer1.TabIndex = 1;
            this.groupContainer1.TabStop = false;
            this.groupContainer1.TextHeader = "Координаты для связи";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.mt_EmailBoss, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.lbl_PHONES, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.mt_Http, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.mt_Fax, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.lbl_Http, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.mt_EmailSpam, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.mt_PHONES, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.mt_EMailBuh, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.lbl_EmailSpam, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.lbl_Fax, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.mt_EMAIL, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.lbl_MobilePhone, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbl_EMailBuh, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.lbl_EMAIL, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.mt_MobilePhone, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(632, 191);
            this.tableLayoutPanel4.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(47, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "E-Mail Руководителя";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_PHONES
            // 
            this.lbl_PHONES.AutoSize = true;
            this.lbl_PHONES.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_PHONES.Location = new System.Drawing.Point(97, 0);
            this.lbl_PHONES.Name = "lbl_PHONES";
            this.lbl_PHONES.Size = new System.Drawing.Size(60, 23);
            this.lbl_PHONES.TabIndex = 0;
            this.lbl_PHONES.Text = "Телефоны";
            this.lbl_PHONES.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Http
            // 
            this.lbl_Http.AutoSize = true;
            this.lbl_Http.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Http.Location = new System.Drawing.Point(55, 161);
            this.lbl_Http.Name = "lbl_Http";
            this.lbl_Http.Size = new System.Drawing.Size(102, 30);
            this.lbl_Http.TabIndex = 5;
            this.lbl_Http.Text = "Адрес в интернете";
            this.lbl_Http.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_EmailSpam
            // 
            this.lbl_EmailSpam.AutoSize = true;
            this.lbl_EmailSpam.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_EmailSpam.Location = new System.Drawing.Point(55, 115);
            this.lbl_EmailSpam.Name = "lbl_EmailSpam";
            this.lbl_EmailSpam.Size = new System.Drawing.Size(102, 23);
            this.lbl_EmailSpam.TabIndex = 4;
            this.lbl_EmailSpam.Text = "E-Mail оповещения";
            this.lbl_EmailSpam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Fax
            // 
            this.lbl_Fax.AutoSize = true;
            this.lbl_Fax.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Fax.Location = new System.Drawing.Point(121, 46);
            this.lbl_Fax.Name = "lbl_Fax";
            this.lbl_Fax.Size = new System.Drawing.Size(36, 23);
            this.lbl_Fax.TabIndex = 23;
            this.lbl_Fax.Text = "Факс";
            this.lbl_Fax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_MobilePhone
            // 
            this.lbl_MobilePhone.AutoSize = true;
            this.lbl_MobilePhone.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_MobilePhone.Location = new System.Drawing.Point(23, 23);
            this.lbl_MobilePhone.Name = "lbl_MobilePhone";
            this.lbl_MobilePhone.Size = new System.Drawing.Size(134, 23);
            this.lbl_MobilePhone.TabIndex = 1;
            this.lbl_MobilePhone.Text = "Моб.тел. для экстренной";
            this.lbl_MobilePhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_EMailBuh
            // 
            this.lbl_EMailBuh.AutoSize = true;
            this.lbl_EMailBuh.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_EMailBuh.Location = new System.Drawing.Point(56, 92);
            this.lbl_EMailBuh.Name = "lbl_EMailBuh";
            this.lbl_EMailBuh.Size = new System.Drawing.Size(101, 23);
            this.lbl_EMailBuh.TabIndex = 3;
            this.lbl_EMailBuh.Text = "E-Mail бухгалтерии";
            this.lbl_EMailBuh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_EMAIL
            // 
            this.lbl_EMAIL.AutoSize = true;
            this.lbl_EMAIL.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_EMAIL.Location = new System.Drawing.Point(68, 69);
            this.lbl_EMAIL.Name = "lbl_EMAIL";
            this.lbl_EMAIL.Size = new System.Drawing.Size(89, 23);
            this.lbl_EMAIL.TabIndex = 2;
            this.lbl_EMAIL.Text = "E-Mail рассылки";
            this.lbl_EMAIL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.FullView = true;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.groupBox1.Name = "groupBox1";
            // 
            // groupBox1.PnlContainer
            // 
            this.groupBox1.PnlContainer.AutoSize = true;
            this.groupBox1.PnlContainer.Controls.Add(this.tableLayoutPanel7);
            this.groupBox1.PnlContainer.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.PnlContainer.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.PnlContainer.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.groupBox1.PnlContainer.Name = "PnlContainer";
            this.groupBox1.PnlContainer.Size = new System.Drawing.Size(632, 462);
            this.groupBox1.PnlContainer.TabIndex = 1;
            this.groupBox1.PnlContainer.TabStop = true;
            this.groupBox1.Size = new System.Drawing.Size(632, 485);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TextHeader = "Основная информация";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 4;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.lbl_INN, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.mt_CodeOKVED, 3, 4);
            this.tableLayoutPanel7.Controls.Add(this.mt_INN, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.mt_CodeOKATO, 3, 3);
            this.tableLayoutPanel7.Controls.Add(this.lbl_CODEOKPO, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.mt_CodeOGRN, 3, 2);
            this.tableLayoutPanel7.Controls.Add(this.mt_CODEOKPO, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.lbl_CodeOKVED, 2, 4);
            this.tableLayoutPanel7.Controls.Add(this.mt_CODEOKONH, 3, 1);
            this.tableLayoutPanel7.Controls.Add(this.lbl_KPP, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.lbl_CodeOKATO, 2, 3);
            this.tableLayoutPanel7.Controls.Add(this.mt_KPP, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.lbl_CODEOKONH, 2, 1);
            this.tableLayoutPanel7.Controls.Add(this.lbl_CodeOGRN, 2, 2);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 332);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 5;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(632, 130);
            this.tableLayoutPanel7.TabIndex = 16;
            // 
            // lbl_INN
            // 
            this.lbl_INN.AutoSize = true;
            this.lbl_INN.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_INN.Location = new System.Drawing.Point(66, 0);
            this.lbl_INN.Name = "lbl_INN";
            this.lbl_INN.Size = new System.Drawing.Size(31, 26);
            this.lbl_INN.TabIndex = 0;
            this.lbl_INN.Text = "ИНН";
            this.lbl_INN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CODEOKPO
            // 
            this.lbl_CODEOKPO.AutoSize = true;
            this.lbl_CODEOKPO.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CODEOKPO.Location = new System.Drawing.Point(338, 0);
            this.lbl_CODEOKPO.Name = "lbl_CODEOKPO";
            this.lbl_CODEOKPO.Size = new System.Drawing.Size(75, 26);
            this.lbl_CODEOKPO.TabIndex = 3;
            this.lbl_CODEOKPO.Text = "Код по ОКПО";
            this.lbl_CODEOKPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CodeOKVED
            // 
            this.lbl_CodeOKVED.AutoSize = true;
            this.lbl_CodeOKVED.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CodeOKVED.Location = new System.Drawing.Point(331, 104);
            this.lbl_CodeOKVED.Name = "lbl_CodeOKVED";
            this.lbl_CodeOKVED.Size = new System.Drawing.Size(82, 26);
            this.lbl_CodeOKVED.TabIndex = 11;
            this.lbl_CodeOKVED.Text = "Код по ОКВЭД";
            this.lbl_CodeOKVED.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_KPP
            // 
            this.lbl_KPP.AutoSize = true;
            this.lbl_KPP.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_KPP.Location = new System.Drawing.Point(67, 26);
            this.lbl_KPP.Name = "lbl_KPP";
            this.lbl_KPP.Size = new System.Drawing.Size(30, 26);
            this.lbl_KPP.TabIndex = 1;
            this.lbl_KPP.Text = "КПП";
            this.lbl_KPP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CodeOKATO
            // 
            this.lbl_CodeOKATO.AutoSize = true;
            this.lbl_CodeOKATO.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CodeOKATO.Location = new System.Drawing.Point(332, 78);
            this.lbl_CodeOKATO.Name = "lbl_CodeOKATO";
            this.lbl_CodeOKATO.Size = new System.Drawing.Size(81, 26);
            this.lbl_CodeOKATO.TabIndex = 10;
            this.lbl_CodeOKATO.Text = "Код по ОКАТО";
            this.lbl_CodeOKATO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CODEOKONH
            // 
            this.lbl_CODEOKONH.AutoSize = true;
            this.lbl_CODEOKONH.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CODEOKONH.Location = new System.Drawing.Point(331, 26);
            this.lbl_CODEOKONH.Name = "lbl_CODEOKONH";
            this.lbl_CODEOKONH.Size = new System.Drawing.Size(82, 26);
            this.lbl_CODEOKONH.TabIndex = 4;
            this.lbl_CODEOKONH.Text = "Код по ОКОНХ";
            this.lbl_CODEOKONH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CodeOGRN
            // 
            this.lbl_CodeOGRN.AutoSize = true;
            this.lbl_CodeOGRN.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CodeOGRN.Location = new System.Drawing.Point(340, 52);
            this.lbl_CodeOGRN.Name = "lbl_CodeOGRN";
            this.lbl_CodeOGRN.Size = new System.Drawing.Size(73, 26);
            this.lbl_CodeOGRN.TabIndex = 9;
            this.lbl_CodeOGRN.Text = "Код по ОГРН";
            this.lbl_CodeOGRN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.mt_BossSName, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.mt_BossFName, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.mt_BossWorkWith, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.lbl_BossName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.mt_BossName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.PR_RegisterNumber, 3, 8);
            this.tableLayoutPanel3.Controls.Add(this.lbl_BossType, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.lbl_RegisterNumber, 2, 8);
            this.tableLayoutPanel3.Controls.Add(this.mt_RegisterSeries, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.mt_BossType, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.mt_ADDITIONALINFO, 3, 7);
            this.tableLayoutPanel3.Controls.Add(this.lbl_LICENSENUMBER, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.lbl_RegisterSeries, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.lbl_ADDITIONALINFO, 2, 7);
            this.tableLayoutPanel3.Controls.Add(this.mt_LICENSENUMBER, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.lbl_BossWorkWith, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.lbl_BossFName, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_BossSName, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.PRL_BossMobilePhone, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.PRL_UnicalBossCode, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnCreateUBC, 2, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 107);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 9;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(632, 225);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // lbl_BossName
            // 
            this.lbl_BossName.AutoSize = true;
            this.lbl_BossName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BossName.Location = new System.Drawing.Point(24, 0);
            this.lbl_BossName.Name = "lbl_BossName";
            this.lbl_BossName.Size = new System.Drawing.Size(133, 25);
            this.lbl_BossName.TabIndex = 3;
            this.lbl_BossName.Text = "Руководитель Фамилия:";
            this.lbl_BossName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_BossType
            // 
            this.lbl_BossType.AutoSize = true;
            this.lbl_BossType.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BossType.Location = new System.Drawing.Point(92, 125);
            this.lbl_BossType.Name = "lbl_BossType";
            this.lbl_BossType.Size = new System.Drawing.Size(65, 25);
            this.lbl_BossType.TabIndex = 9;
            this.lbl_BossType.Text = "Должность";
            this.lbl_BossType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_RegisterNumber
            // 
            this.lbl_RegisterNumber.AutoSize = true;
            this.lbl_RegisterNumber.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_RegisterNumber.Location = new System.Drawing.Point(402, 200);
            this.lbl_RegisterNumber.Name = "lbl_RegisterNumber";
            this.lbl_RegisterNumber.Size = new System.Drawing.Size(41, 25);
            this.lbl_RegisterNumber.TabIndex = 7;
            this.lbl_RegisterNumber.Text = "Номер";
            this.lbl_RegisterNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_LICENSENUMBER
            // 
            this.lbl_LICENSENUMBER.AutoSize = true;
            this.lbl_LICENSENUMBER.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_LICENSENUMBER.Location = new System.Drawing.Point(100, 175);
            this.lbl_LICENSENUMBER.Name = "lbl_LICENSENUMBER";
            this.lbl_LICENSENUMBER.Size = new System.Drawing.Size(57, 25);
            this.lbl_LICENSENUMBER.TabIndex = 4;
            this.lbl_LICENSENUMBER.Text = "Лицензия";
            this.lbl_LICENSENUMBER.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_RegisterSeries
            // 
            this.lbl_RegisterSeries.AutoSize = true;
            this.lbl_RegisterSeries.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_RegisterSeries.Location = new System.Drawing.Point(17, 200);
            this.lbl_RegisterSeries.Name = "lbl_RegisterSeries";
            this.lbl_RegisterSeries.Size = new System.Drawing.Size(140, 25);
            this.lbl_RegisterSeries.TabIndex = 5;
            this.lbl_RegisterSeries.Text = "Реестровый номер серия:";
            this.lbl_RegisterSeries.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ADDITIONALINFO
            // 
            this.lbl_ADDITIONALINFO.AutoSize = true;
            this.lbl_ADDITIONALINFO.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_ADDITIONALINFO.Location = new System.Drawing.Point(377, 175);
            this.lbl_ADDITIONALINFO.Name = "lbl_ADDITIONALINFO";
            this.lbl_ADDITIONALINFO.Size = new System.Drawing.Size(66, 25);
            this.lbl_ADDITIONALINFO.TabIndex = 8;
            this.lbl_ADDITIONALINFO.Text = "Выдана, от.";
            this.lbl_ADDITIONALINFO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_BossWorkWith
            // 
            this.lbl_BossWorkWith.AutoSize = true;
            this.lbl_BossWorkWith.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BossWorkWith.Location = new System.Drawing.Point(21, 150);
            this.lbl_BossWorkWith.Name = "lbl_BossWorkWith";
            this.lbl_BossWorkWith.Size = new System.Drawing.Size(136, 25);
            this.lbl_BossWorkWith.TabIndex = 10;
            this.lbl_BossWorkWith.Text = "Действует на основание:";
            this.lbl_BossWorkWith.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_BossFName
            // 
            this.lbl_BossFName.AutoSize = true;
            this.lbl_BossFName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BossFName.Location = new System.Drawing.Point(125, 25);
            this.lbl_BossFName.Name = "lbl_BossFName";
            this.lbl_BossFName.Size = new System.Drawing.Size(32, 25);
            this.lbl_BossFName.TabIndex = 12;
            this.lbl_BossFName.Text = "Имя:";
            this.lbl_BossFName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_BossSName
            // 
            this.lbl_BossSName.AutoSize = true;
            this.lbl_BossSName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BossSName.Location = new System.Drawing.Point(100, 50);
            this.lbl_BossSName.Name = "lbl_BossSName";
            this.lbl_BossSName.Size = new System.Drawing.Size(57, 25);
            this.lbl_BossSName.TabIndex = 13;
            this.lbl_BossSName.Text = "Отчество:";
            this.lbl_BossSName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(175, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Уникальный код руководителя:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(202, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "№ Моб.тел. руководителя:";
            // 
            // btnCreateUBC
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.btnCreateUBC, 2);
            this.btnCreateUBC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateUBC.Location = new System.Drawing.Point(347, 76);
            this.btnCreateUBC.Margin = new System.Windows.Forms.Padding(1);
            this.btnCreateUBC.Name = "btnCreateUBC";
            this.btnCreateUBC.Size = new System.Drawing.Size(284, 23);
            this.btnCreateUBC.TabIndex = 20;
            this.btnCreateUBC.Text = "Создать УКР";
            this.btnCreateUBC.UseVisualStyleBackColor = true;
            this.btnCreateUBC.Click += new System.EventHandler(this.btnCreateUBC_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.PRL_StartWorkAgency, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_StartWorkAgency, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_FullName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mt_FullName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_NameEng, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mt_NameEng, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(632, 81);
            this.tableLayoutPanel1.TabIndex = 13;
            this.tableLayoutPanel1.TabStop = true;
            // 
            // PRL_StartWorkAgency
            // 
            this.PRL_StartWorkAgency.ChangeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PRL_StartWorkAgency.Dock = System.Windows.Forms.DockStyle.Left;
            this.PRL_StartWorkAgency.Location = new System.Drawing.Point(163, 55);
            this.PRL_StartWorkAgency.Name = "PRL_StartWorkAgency";
            this.PRL_StartWorkAgency.Size = new System.Drawing.Size(142, 23);
            this.PRL_StartWorkAgency.TabIndex = 4;
            this.PRL_StartWorkAgency.Value = new System.DateTime(2009, 6, 25, 16, 44, 40, 734);
            // 
            // lbl_StartWorkAgency
            // 
            this.lbl_StartWorkAgency.AutoSize = true;
            this.lbl_StartWorkAgency.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_StartWorkAgency.Location = new System.Drawing.Point(5, 52);
            this.lbl_StartWorkAgency.Name = "lbl_StartWorkAgency";
            this.lbl_StartWorkAgency.Size = new System.Drawing.Size(152, 29);
            this.lbl_StartWorkAgency.TabIndex = 11;
            this.lbl_StartWorkAgency.Text = "Дата начала работы с нами:";
            this.lbl_StartWorkAgency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_FullName
            // 
            this.lbl_FullName.AutoSize = true;
            this.lbl_FullName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_FullName.Location = new System.Drawing.Point(61, 0);
            this.lbl_FullName.Name = "lbl_FullName";
            this.lbl_FullName.Size = new System.Drawing.Size(96, 26);
            this.lbl_FullName.TabIndex = 1;
            this.lbl_FullName.Text = "Полное название";
            this.lbl_FullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_NameEng
            // 
            this.lbl_NameEng.AutoSize = true;
            this.lbl_NameEng.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_NameEng.Location = new System.Drawing.Point(39, 26);
            this.lbl_NameEng.Name = "lbl_NameEng";
            this.lbl_NameEng.Size = new System.Drawing.Size(118, 26);
            this.lbl_NameEng.TabIndex = 2;
            this.lbl_NameEng.Text = "Английское название";
            this.lbl_NameEng.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.mt_NAME, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_NAME, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Cod, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.mt_Cod, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(632, 26);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // lbl_NAME
            // 
            this.lbl_NAME.AutoSize = true;
            this.lbl_NAME.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_NAME.Location = new System.Drawing.Point(57, 0);
            this.lbl_NAME.Name = "lbl_NAME";
            this.lbl_NAME.Size = new System.Drawing.Size(100, 26);
            this.lbl_NAME.TabIndex = 0;
            this.lbl_NAME.Text = "Краткое название";
            this.lbl_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Cod
            // 
            this.lbl_Cod.AutoSize = true;
            this.lbl_Cod.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Cod.Location = new System.Drawing.Point(503, 0);
            this.lbl_Cod.Name = "lbl_Cod";
            this.lbl_Cod.Size = new System.Drawing.Size(26, 26);
            this.lbl_Cod.TabIndex = 10;
            this.lbl_Cod.Text = "Код";
            this.lbl_Cod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mt_Cod
            // 
            this.mt_Cod.BackColor = System.Drawing.SystemColors.Window;
            this.mt_Cod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Cod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Cod.ErrorProvider = null;
            this.mt_Cod.Location = new System.Drawing.Point(535, 3);
            this.mt_Cod.MessageInformationError = "Это обязательное поле";
            this.mt_Cod.Name = "mt_Cod";
            this.mt_Cod.ReadOnly = true;
            this.mt_Cod.RegexVerify = "";
            this.mt_Cod.Size = new System.Drawing.Size(94, 20);
            this.mt_Cod.TabIndex = 1;
            this.mt_Cod.VerifyMaxLength = -1;
            // 
            // pnlLayer1F0Top
            // 
            this.pnlLayer1F0Top.Controls.Add(this.PR_PGKey);
            this.pnlLayer1F0Top.Controls.Add(this.label38);
            this.pnlLayer1F0Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLayer1F0Top.Location = new System.Drawing.Point(0, 0);
            this.pnlLayer1F0Top.Name = "pnlLayer1F0Top";
            this.pnlLayer1F0Top.Size = new System.Drawing.Size(188, 63);
            this.pnlLayer1F0Top.TabIndex = 1;
            // 
            // PR_PGKey
            // 
            this.PR_PGKey.ChangeBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PR_PGKey.ErrorBackGroundColor = System.Drawing.Color.Red;
            this.PR_PGKey.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.PR_PGKey.ErrorProvider = this.errorProvider1;
            this.PR_PGKey.FormattingEnabled = true;
            this.PR_PGKey.IsNotNullValue = true;
            this.PR_PGKey.Location = new System.Drawing.Point(9, 29);
            this.PR_PGKey.MessageInformationError = "";
            this.PR_PGKey.Name = "PR_PGKey";
            this.PR_PGKey.Size = new System.Drawing.Size(167, 21);
            this.PR_PGKey.TabIndex = 6;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 11);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(42, 13);
            this.label38.TabIndex = 4;
            this.label38.Text = "Группа";
            // 
            // pnlLayer0Fill
            // 
            this.pnlLayer0Fill.Controls.Add(this.pnlListTypesPartner);
            this.pnlLayer0Fill.Controls.Add(this.pnlLayer1F0Top);
            this.pnlLayer0Fill.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLayer0Fill.Location = new System.Drawing.Point(654, 31);
            this.pnlLayer0Fill.Name = "pnlLayer0Fill";
            this.pnlLayer0Fill.Size = new System.Drawing.Size(188, 542);
            this.pnlLayer0Fill.TabIndex = 2;
            // 
            // pnlListTypesPartner
            // 
            this.pnlListTypesPartner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListTypesPartner.Location = new System.Drawing.Point(0, 63);
            this.pnlListTypesPartner.Name = "pnlListTypesPartner";
            this.pnlListTypesPartner.Size = new System.Drawing.Size(188, 479);
            this.pnlListTypesPartner.TabIndex = 2;
            this.pnlListTypesPartner.TabStop = false;
            this.pnlListTypesPartner.Text = "Классификация по признакам";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave,
            this.tsBtnCancel,
            this.toolStripSeparator1,
            this.tsBtnHistory,
            this.tsBtnSendMail,
            this.tsBtnClose,
            this.tsBtnCallCenter,
            this.tsBtnAKA});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(842, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = global::AgencyManager.Properties.Resources.Apply_Check;
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(93, 28);
            this.tsBtnSave.Text = "Сохранить";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Image = global::AgencyManager.Properties.Resources.Stop;
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(89, 28);
            this.tsBtnCancel.Text = "Отменить";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsBtnHistory
            // 
            this.tsBtnHistory.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnHistory.Image")));
            this.tsBtnHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHistory.Name = "tsBtnHistory";
            this.tsBtnHistory.Size = new System.Drawing.Size(82, 28);
            this.tsBtnHistory.Text = "История";
            this.tsBtnHistory.Click += new System.EventHandler(this.tsBtnHistory_Click);
            // 
            // tsBtnSendMail
            // 
            this.tsBtnSendMail.Image = global::AgencyManager.Properties.Resources.EMail;
            this.tsBtnSendMail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSendMail.Name = "tsBtnSendMail";
            this.tsBtnSendMail.Size = new System.Drawing.Size(86, 28);
            this.tsBtnSendMail.Text = "Передать";
            this.tsBtnSendMail.Click += new System.EventHandler(this.tsBtnSendMail_Click);
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
            // tsBtnCallCenter
            // 
            this.tsBtnCallCenter.Image = global::AgencyManager.Properties.Resources.Phone;
            this.tsBtnCallCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCallCenter.Name = "tsBtnCallCenter";
            this.tsBtnCallCenter.Size = new System.Drawing.Size(90, 28);
            this.tsBtnCallCenter.Text = "CallCenter";
            this.tsBtnCallCenter.Click += new System.EventHandler(this.tsBtnCallCenter_Click);
            // 
            // tsBtnAKA
            // 
            this.tsBtnAKA.Image = global::AgencyManager.Properties.Resources.Contact;
            this.tsBtnAKA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAKA.Name = "tsBtnAKA";
            this.tsBtnAKA.Size = new System.Drawing.Size(58, 28);
            this.tsBtnAKA.Text = "АКА";
            this.tsBtnAKA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsBtnAKA.Click += new System.EventHandler(this.tsBtnAKA_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(649, 31);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 542);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // frmEditPartner
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(842, 573);
            this.Controls.Add(this.pnlLayer0Left);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLayer0Fill);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "frmEditPartner";
            this.Text = "Изменение информации о партнере: ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditPartner_FormClosing);
            this.Load += new System.EventHandler(this.frmEditPartner_Load);
            this.pnlLayer0Left.ResumeLayout(false);
            this.pnlLayer0Left.PerformLayout();
            this.gcSubAgency.PnlContainer.ResumeLayout(false);
            this.gcSubAgency.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubAgencyDGV)).EndInit();
            this.gcPassword.PnlContainer.ResumeLayout(false);
            this.gcPassword.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.gcDogovors.ResumeLayout(false);
            this.groupContainer4.PnlContainer.ResumeLayout(false);
            this.groupContainer4.PnlContainer.PerformLayout();
            this.groupContainer4.ResumeLayout(false);
            this.gcAccount.PnlContainer.ResumeLayout(false);
            this.gcAccount.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupContainer2.PnlContainer.ResumeLayout(false);
            this.groupContainer2.PnlContainer.PerformLayout();
            this.groupContainer2.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupContainer1.PnlContainer.ResumeLayout(false);
            this.groupContainer1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox1.PnlContainer.ResumeLayout(false);
            this.groupBox1.PnlContainer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlLayer1F0Top.ResumeLayout(false);
            this.pnlLayer1F0Top.PerformLayout();
            this.pnlLayer0Fill.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel7;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripButton tsBtnSave;
        private ToolStripButton tsBtnClose;
        private ToolStripButton tsBtnCancel;
        private ToolStripButton tsBtnHistory;
        private ToolStripButton tsBtnSendMail;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStrip toolStrip2;
        private ToolStripButton tsBtnAddAccount;
        private Panel pnlAccounts;
        private ToolStripButton tsBtnCallCenter;
        private lwTextBox mt_BossWorkWith;
        private Label lbl_BossWorkWith;
        private Label lbl_BossFName;
        private lwTextBox mt_BossSName;
        private lwTextBox mt_BossFName;
        private Label lbl_BossSName;
        private lwGroupContainer gcSubAgency;
        private DataGridView SubAgencyDGV;
        private Label label1;
        private Label label2;
        private lwTextBox PRL_BossMobilePhone;
        private lwTextBox PRL_UnicalBossCode;
        private Button btnCreateUBC;
        private ToolStripButton tsBtnAKA;
        private TabControl tabControl1;
        private TabPage tabOnLine;
        private TabPage tabAvia;
        private lwTextBox mt_EmailBoss;
        private Label label3;
        private Splitter splitter1;
    }
}