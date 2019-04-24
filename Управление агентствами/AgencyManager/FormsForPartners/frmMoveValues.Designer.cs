namespace AgencyManager.FormsForPartners
{
    using System.Windows.Forms;
    using System.ComponentModel;
    using ltp_v2.Controls.Forms;

    partial class frmMoveValues
    {
        private IContainer components = null;
        private ErrorProvider errorProvider1;
        private lwGroupContainer gbBuhgalteria;
        private lwGroupContainer gbContact;
        private lwGroupContainer gbContactValue;
        private lwGroupContainer gbRegistration;
        private Label lbl_Name;
        private Label lbl_MobilePhone;
        private Label lbl_EmailRasilka;
        private Label lbl_EmailSpam;
        private Label lbl_EMailBuh;
        private Label lbl_BIK;
        private Label lbl_INN;
        private Label lbl_RS;
        private Label lbl_KS;
        private Label lbl_KPP;
        private Label lbl_CodeOGRN;
        private Label lbl_FullName;
        private Label lbl_CodeOKPO;
        private Label lbl_BankName;
        private Label lbl_BossName;
        private Label lbl_Country;
        private Label lbl_Metro;
        private Label lbl_CodeOKONH;
        private Label lbl_CodeOKATO;
        private Label lbl_CodeOKVED;
        private Label lbl_Boss;
        private Label lbl_LegalPostIndex;
        private Label lbl_City;
        private Label lbl_NameLat;
        private Label lbl_LegalAdress;
        private Label lbl_PostIndex;
        private Label lbl_Adress;
        private Label lbl_Phone;
        private Label lbl_Fax1;
        private Label lbl_Fax2;
        private CheckBox move_Adress;
        private CheckBox move_Boss;
        private CheckBox move_BossName;
        private CheckBox move_City;
        private CheckBox move_CodeOGRN;
        private CheckBox move_CodeOKATO;
        private CheckBox move_CodeOKONH;
        private CheckBox move_CodeOKPO;
        private CheckBox move_CodeOKVED;
        private CheckBox move_EMailBuh;
        private CheckBox move_EmailRasilka;
        private CheckBox move_EmailSpam;
        private CheckBox move_Fax1;
        private CheckBox move_Fax2;
        private CheckBox move_FullName;
        private CheckBox move_INN;
        private CheckBox move_KPP;
        private CheckBox move_LegalAdress;
        private CheckBox move_LegalPostIndex;
        private CheckBox move_Metro;
        private CheckBox move_MobilePhone;
        private CheckBox move_Name;
        private CheckBox move_NameLat;
        private CheckBox move_Phone;
        private CheckBox move_PostIndex;
        private lwTextBox mt_Adress;
        private lwTextBox mt_Boss;
        private lwTextBox mt_BossName;
        private lwTextBox mt_City;
        private TextBox mt_CityKey;
        private lwTextBox mt_CodeOGRN;
        private lwTextBox mt_CodeOKATO;
        private lwTextBox mt_CodeOKONH;
        private lwTextBox mt_CodeOKPO;
        private lwTextBox mt_CodeOKVED;
        private lwTextBox mt_Country;
        private lwTextBox mt_EMailBuh;
        private lwTextBox mt_EmailRasilka;
        private lwTextBox mt_EmailSpam;
        private lwTextBox mt_Fax1;
        private lwTextBox mt_Fax2;
        private lwTextBox mt_FullName;
        private lwTextBox mt_INN;
        private lwTextBox mt_KPP;
        private lwTextBox mt_LegalAdress;
        private lwTextBox mt_LegalPostIndex;
        private lwTextBox mt_Metro;
        private TextBox mt_MetroKey;
        private lwTextBox mt_MobilePhone;
        private lwTextBox mt_Name;
        private lwTextBox mt_NameLat;
        private lwTextBox mt_Phone;
        private lwTextBox mt_PostIndex;
        private Panel panel1;
        private TextBox tmp_Adress;
        private TextBox tmp_BankName;
        private TextBox tmp_BIK;
        private TextBox tmp_Boss;
        private TextBox tmp_BossName;
        private ComboBox tmp_City;
        private TextBox tmp_CodeOGRN;
        private TextBox tmp_CodeOKATO;
        private TextBox tmp_CodeOKONH;
        private TextBox tmp_CodeOKPO;
        private TextBox tmp_CodeOKVED;
        private ComboBox tmp_Country;
        private TextBox tmp_EMailBuh;
        private TextBox tmp_EmailRasilka;
        private TextBox tmp_EmailSpam;
        private TextBox tmp_Fax1;
        private TextBox tmp_Fax2;
        private TextBox tmp_FullName;
        private TextBox tmp_INN;
        private TextBox tmp_KPP;
        private TextBox tmp_KS;
        private TextBox tmp_LegalAdress;
        private TextBox tmp_LegalPostIndex;
        private lwComboBox tmp_Metro;
        private TextBox tmp_MobilePhone;
        private TextBox tmp_Name;
        private TextBox tmp_NameLat;
        private TextBox tmp_Phone;
        private TextBox tmp_PostIndex;
        private TextBox tmp_RS;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoveValues));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lwGroupContainer1 = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.gbPresentsAccount = new System.Windows.Forms.GroupBox();
            this.pnlAccounts = new System.Windows.Forms.Panel();
            this.pnlNewAccountInformation = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_BankName = new System.Windows.Forms.Label();
            this.tmp_BankName = new System.Windows.Forms.TextBox();
            this.tmp_RS = new System.Windows.Forms.TextBox();
            this.lbl_KS = new System.Windows.Forms.Label();
            this.lbl_RS = new System.Windows.Forms.Label();
            this.tmp_KS = new System.Windows.Forms.TextBox();
            this.tmp_BIK = new System.Windows.Forms.TextBox();
            this.lbl_BIK = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsNewAccount = new System.Windows.Forms.ToolStripButton();
            this.gbContactValue = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.move_EmailBoss = new System.Windows.Forms.CheckBox();
            this.mt_EmailBoss = new ltp_v2.Controls.Forms.lwTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mt_BossSName = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_BossWorkWith = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_Boss = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_BossName = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_CodeOKVED = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_CodeOKATO = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_CodeOKONH = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_CodeOKPO = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_KPP = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_CodeOGRN = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_EMailBuh = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_Metro = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_EmailSpam = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_EmailRasilka = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_City = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_MobilePhone = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_Fax2 = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_Country = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_Fax1 = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_PostIndex = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_Phone = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_LegalAdress = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_LegalPostIndex = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_Adress = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_FullName = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_NameLat = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_Name = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_INN = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_BossFName = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_License = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_AdditionalInfo = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_UnicalBossCode = new ltp_v2.Controls.Forms.lwTextBox();
            this.mt_BossMobilePhone = new ltp_v2.Controls.Forms.lwTextBox();
            this.tmp_EmailBoss = new System.Windows.Forms.TextBox();
            this.lbl_BossMobilePhone = new System.Windows.Forms.Label();
            this.lbl_EmailBoss = new System.Windows.Forms.Label();
            this.move_BossSName = new System.Windows.Forms.CheckBox();
            this.tmp_BossSName = new System.Windows.Forms.TextBox();
            this.move_BossFName = new System.Windows.Forms.CheckBox();
            this.tmp_BossFName = new System.Windows.Forms.TextBox();
            this.lbl_BossFName = new System.Windows.Forms.Label();
            this.move_BossWorkWith = new System.Windows.Forms.CheckBox();
            this.tmp_BossWorkWith = new System.Windows.Forms.TextBox();
            this.lbl_BossName = new System.Windows.Forms.Label();
            this.move_Boss = new System.Windows.Forms.CheckBox();
            this.tmp_BossName = new System.Windows.Forms.TextBox();
            this.move_BossName = new System.Windows.Forms.CheckBox();
            this.tmp_Boss = new System.Windows.Forms.TextBox();
            this.lbl_Boss = new System.Windows.Forms.Label();
            this.lbl_BossWorkWith = new System.Windows.Forms.Label();
            this.lbl_BossSName = new System.Windows.Forms.Label();
            this.lbl_UnicalBossCode = new System.Windows.Forms.Label();
            this.move_BossMobilePhone = new System.Windows.Forms.CheckBox();
            this.tmp_BossMobilePhone = new System.Windows.Forms.TextBox();
            this.tmp_UnicalBossCode = new System.Windows.Forms.CheckBox();
            this.gbBuhgalteria = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_INN = new System.Windows.Forms.Label();
            this.tmp_INN = new System.Windows.Forms.TextBox();
            this.move_CodeOKVED = new System.Windows.Forms.CheckBox();
            this.tmp_CodeOKVED = new System.Windows.Forms.TextBox();
            this.move_INN = new System.Windows.Forms.CheckBox();
            this.lbl_CodeOKVED = new System.Windows.Forms.Label();
            this.move_CodeOKATO = new System.Windows.Forms.CheckBox();
            this.lbl_KPP = new System.Windows.Forms.Label();
            this.tmp_CodeOKATO = new System.Windows.Forms.TextBox();
            this.tmp_KPP = new System.Windows.Forms.TextBox();
            this.lbl_CodeOKATO = new System.Windows.Forms.Label();
            this.move_KPP = new System.Windows.Forms.CheckBox();
            this.lbl_CodeOGRN = new System.Windows.Forms.Label();
            this.move_CodeOKONH = new System.Windows.Forms.CheckBox();
            this.tmp_CodeOGRN = new System.Windows.Forms.TextBox();
            this.tmp_CodeOKONH = new System.Windows.Forms.TextBox();
            this.move_CodeOGRN = new System.Windows.Forms.CheckBox();
            this.lbl_CodeOKONH = new System.Windows.Forms.Label();
            this.lbl_CodeOKPO = new System.Windows.Forms.Label();
            this.tmp_CodeOKPO = new System.Windows.Forms.TextBox();
            this.move_CodeOKPO = new System.Windows.Forms.CheckBox();
            this.gbContact = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_PostIndex = new System.Windows.Forms.Label();
            this.mt_MetroKey = new System.Windows.Forms.TextBox();
            this.mt_CityKey = new System.Windows.Forms.TextBox();
            this.tmp_PostIndex = new System.Windows.Forms.TextBox();
            this.move_EMailBuh = new System.Windows.Forms.CheckBox();
            this.tmp_EMailBuh = new System.Windows.Forms.TextBox();
            this.lbl_EMailBuh = new System.Windows.Forms.Label();
            this.move_PostIndex = new System.Windows.Forms.CheckBox();
            this.tmp_EmailSpam = new System.Windows.Forms.TextBox();
            this.move_EmailSpam = new System.Windows.Forms.CheckBox();
            this.lbl_EmailSpam = new System.Windows.Forms.Label();
            this.lbl_Country = new System.Windows.Forms.Label();
            this.move_EmailRasilka = new System.Windows.Forms.CheckBox();
            this.tmp_EmailRasilka = new System.Windows.Forms.TextBox();
            this.tmp_Country = new System.Windows.Forms.ComboBox();
            this.lbl_EmailRasilka = new System.Windows.Forms.Label();
            this.lbl_Fax1 = new System.Windows.Forms.Label();
            this.move_MobilePhone = new System.Windows.Forms.CheckBox();
            this.lbl_City = new System.Windows.Forms.Label();
            this.tmp_Fax1 = new System.Windows.Forms.TextBox();
            this.lbl_MobilePhone = new System.Windows.Forms.Label();
            this.lbl_Fax2 = new System.Windows.Forms.Label();
            this.move_Fax2 = new System.Windows.Forms.CheckBox();
            this.tmp_Phone = new System.Windows.Forms.TextBox();
            this.tmp_Fax2 = new System.Windows.Forms.TextBox();
            this.tmp_City = new System.Windows.Forms.ComboBox();
            this.move_City = new System.Windows.Forms.CheckBox();
            this.lbl_Metro = new System.Windows.Forms.Label();
            this.tmp_Metro = new ltp_v2.Controls.Forms.lwComboBox();
            this.move_Fax1 = new System.Windows.Forms.CheckBox();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.move_Metro = new System.Windows.Forms.CheckBox();
            this.lbl_LegalPostIndex = new System.Windows.Forms.Label();
            this.lbl_Adress = new System.Windows.Forms.Label();
            this.tmp_Adress = new System.Windows.Forms.TextBox();
            this.move_Adress = new System.Windows.Forms.CheckBox();
            this.tmp_LegalPostIndex = new System.Windows.Forms.TextBox();
            this.move_LegalPostIndex = new System.Windows.Forms.CheckBox();
            this.tmp_LegalAdress = new System.Windows.Forms.TextBox();
            this.move_Phone = new System.Windows.Forms.CheckBox();
            this.lbl_LegalAdress = new System.Windows.Forms.Label();
            this.move_LegalAdress = new System.Windows.Forms.CheckBox();
            this.tmp_MobilePhone = new System.Windows.Forms.TextBox();
            this.gbRegistration = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_AdditionalInfo = new System.Windows.Forms.Label();
            this.lbl_License = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.tmp_Name = new System.Windows.Forms.TextBox();
            this.move_FullName = new System.Windows.Forms.CheckBox();
            this.tmp_FullName = new System.Windows.Forms.TextBox();
            this.lbl_FullName = new System.Windows.Forms.Label();
            this.move_Name = new System.Windows.Forms.CheckBox();
            this.move_NameLat = new System.Windows.Forms.CheckBox();
            this.tmp_NameLat = new System.Windows.Forms.TextBox();
            this.lbl_NameLat = new System.Windows.Forms.Label();
            this.tmp_License = new System.Windows.Forms.TextBox();
            this.move_License = new System.Windows.Forms.CheckBox();
            this.tmp_AdditionalInfo = new System.Windows.Forms.TextBox();
            this.move_AdditionalInfo = new System.Windows.Forms.CheckBox();
            this.AddsInformation = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.pnlNeedDogovors = new System.Windows.Forms.Panel();
            this.clbNeedDogovors = new System.Windows.Forms.CheckedListBox();
            this.cbGroupDogovorType = new System.Windows.Forms.ComboBox();
            this.pnlNeedPasswords = new System.Windows.Forms.Panel();
            this.clbNeedPasswords = new System.Windows.Forms.CheckedListBox();
            this.PnlContainer = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsLblAccreditationCard = new System.Windows.Forms.ToolStripLabel();
            this.panel1.SuspendLayout();
            this.lwGroupContainer1.PnlContainer.SuspendLayout();
            this.lwGroupContainer1.SuspendLayout();
            this.gbPresentsAccount.SuspendLayout();
            this.pnlNewAccountInformation.PnlContainer.SuspendLayout();
            this.pnlNewAccountInformation.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.gbContactValue.PnlContainer.SuspendLayout();
            this.gbContactValue.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbBuhgalteria.PnlContainer.SuspendLayout();
            this.gbBuhgalteria.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbContact.PnlContainer.SuspendLayout();
            this.gbContact.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbRegistration.PnlContainer.SuspendLayout();
            this.gbRegistration.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.AddsInformation.PnlContainer.SuspendLayout();
            this.AddsInformation.SuspendLayout();
            this.pnlNeedDogovors.SuspendLayout();
            this.pnlNeedPasswords.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lwGroupContainer1);
            this.panel1.Controls.Add(this.pnlNewAccountInformation);
            this.panel1.Controls.Add(this.gbContactValue);
            this.panel1.Controls.Add(this.gbBuhgalteria);
            this.panel1.Controls.Add(this.gbContact);
            this.panel1.Controls.Add(this.gbRegistration);
            this.panel1.Controls.Add(this.AddsInformation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 499);
            this.panel1.TabIndex = 1;
            // 
            // lwGroupContainer1
            // 
            this.lwGroupContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lwGroupContainer1.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lwGroupContainer1.FullView = true;
            this.lwGroupContainer1.Location = new System.Drawing.Point(0, 1265);
            this.lwGroupContainer1.Name = "lwGroupContainer1";
            // 
            // lwGroupContainer1.PnlContainer
            // 
            this.lwGroupContainer1.PnlContainer.Controls.Add(this.gbPresentsAccount);
            this.lwGroupContainer1.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lwGroupContainer1.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.lwGroupContainer1.PnlContainer.Name = "PnlContainer";
            this.lwGroupContainer1.PnlContainer.Size = new System.Drawing.Size(709, 265);
            this.lwGroupContainer1.PnlContainer.TabIndex = 1;
            this.lwGroupContainer1.Size = new System.Drawing.Size(709, 288);
            this.lwGroupContainer1.TabIndex = 6;
            this.lwGroupContainer1.TextHeader = "Доступные банковские счета";
            // 
            // gbPresentsAccount
            // 
            this.gbPresentsAccount.Controls.Add(this.pnlAccounts);
            this.gbPresentsAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPresentsAccount.Location = new System.Drawing.Point(0, 0);
            this.gbPresentsAccount.Name = "gbPresentsAccount";
            this.gbPresentsAccount.Size = new System.Drawing.Size(709, 265);
            this.gbPresentsAccount.TabIndex = 154;
            this.gbPresentsAccount.TabStop = false;
            this.gbPresentsAccount.Text = "Доступные банковские счета";
            // 
            // pnlAccounts
            // 
            this.pnlAccounts.AutoScroll = true;
            this.pnlAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccounts.Location = new System.Drawing.Point(3, 16);
            this.pnlAccounts.Name = "pnlAccounts";
            this.pnlAccounts.Size = new System.Drawing.Size(703, 246);
            this.pnlAccounts.TabIndex = 0;
            // 
            // pnlNewAccountInformation
            // 
            this.pnlNewAccountInformation.AutoSize = true;
            this.pnlNewAccountInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNewAccountInformation.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.pnlNewAccountInformation.FullView = true;
            this.pnlNewAccountInformation.Location = new System.Drawing.Point(0, 1119);
            this.pnlNewAccountInformation.Name = "pnlNewAccountInformation";
            // 
            // pnlNewAccountInformation.PnlContainer
            // 
            this.pnlNewAccountInformation.PnlContainer.AutoSize = true;
            this.pnlNewAccountInformation.PnlContainer.Controls.Add(this.tableLayoutPanel5);
            this.pnlNewAccountInformation.PnlContainer.Controls.Add(this.toolStrip2);
            this.pnlNewAccountInformation.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNewAccountInformation.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.pnlNewAccountInformation.PnlContainer.Name = "PnlContainer";
            this.pnlNewAccountInformation.PnlContainer.Size = new System.Drawing.Size(709, 123);
            this.pnlNewAccountInformation.PnlContainer.TabIndex = 1;
            this.pnlNewAccountInformation.Size = new System.Drawing.Size(709, 146);
            this.pnlNewAccountInformation.TabIndex = 5;
            this.pnlNewAccountInformation.TextHeader = "Банковский счет при регистрации";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.lbl_BankName, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tmp_BankName, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tmp_RS, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.lbl_KS, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.lbl_RS, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.tmp_KS, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.tmp_BIK, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lbl_BIK, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(709, 92);
            this.tableLayoutPanel5.TabIndex = 155;
            // 
            // lbl_BankName
            // 
            this.lbl_BankName.AutoSize = true;
            this.lbl_BankName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_BankName.Location = new System.Drawing.Point(28, 0);
            this.lbl_BankName.Name = "lbl_BankName";
            this.lbl_BankName.Size = new System.Drawing.Size(119, 23);
            this.lbl_BankName.TabIndex = 152;
            this.lbl_BankName.Text = "Наименование банка:";
            this.lbl_BankName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmp_BankName
            // 
            this.tmp_BankName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_BankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_BankName.Location = new System.Drawing.Point(153, 3);
            this.tmp_BankName.MaxLength = 100;
            this.tmp_BankName.Name = "tmp_BankName";
            this.tmp_BankName.Size = new System.Drawing.Size(553, 20);
            this.tmp_BankName.TabIndex = 0;
            // 
            // tmp_RS
            // 
            this.tmp_RS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_RS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_RS.Location = new System.Drawing.Point(153, 72);
            this.tmp_RS.MaxLength = 30;
            this.tmp_RS.Name = "tmp_RS";
            this.tmp_RS.Size = new System.Drawing.Size(553, 20);
            this.tmp_RS.TabIndex = 3;
            // 
            // lbl_KS
            // 
            this.lbl_KS.AutoSize = true;
            this.lbl_KS.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_KS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_KS.Location = new System.Drawing.Point(120, 46);
            this.lbl_KS.Name = "lbl_KS";
            this.lbl_KS.Size = new System.Drawing.Size(27, 23);
            this.lbl_KS.TabIndex = 144;
            this.lbl_KS.Text = "к/с:";
            this.lbl_KS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_RS
            // 
            this.lbl_RS.AutoSize = true;
            this.lbl_RS.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_RS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_RS.Location = new System.Drawing.Point(120, 69);
            this.lbl_RS.Name = "lbl_RS";
            this.lbl_RS.Size = new System.Drawing.Size(27, 23);
            this.lbl_RS.TabIndex = 142;
            this.lbl_RS.Text = "р/с:";
            this.lbl_RS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmp_KS
            // 
            this.tmp_KS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_KS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_KS.Location = new System.Drawing.Point(153, 49);
            this.tmp_KS.MaxLength = 50;
            this.tmp_KS.Name = "tmp_KS";
            this.tmp_KS.Size = new System.Drawing.Size(553, 20);
            this.tmp_KS.TabIndex = 2;
            // 
            // tmp_BIK
            // 
            this.tmp_BIK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_BIK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_BIK.Location = new System.Drawing.Point(153, 26);
            this.tmp_BIK.MaxLength = 30;
            this.tmp_BIK.Name = "tmp_BIK";
            this.tmp_BIK.Size = new System.Drawing.Size(553, 20);
            this.tmp_BIK.TabIndex = 1;
            // 
            // lbl_BIK
            // 
            this.lbl_BIK.AutoSize = true;
            this.lbl_BIK.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BIK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_BIK.Location = new System.Drawing.Point(115, 23);
            this.lbl_BIK.Name = "lbl_BIK";
            this.lbl_BIK.Size = new System.Drawing.Size(32, 23);
            this.lbl_BIK.TabIndex = 138;
            this.lbl_BIK.Text = "БИК:";
            this.lbl_BIK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNewAccount});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(709, 31);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsNewAccount
            // 
            this.tsNewAccount.Image = ((System.Drawing.Image)(resources.GetObject("tsNewAccount.Image")));
            this.tsNewAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNewAccount.Name = "tsNewAccount";
            this.tsNewAccount.Size = new System.Drawing.Size(114, 28);
            this.tsNewAccount.Text = "Добавить счет";
            this.tsNewAccount.Click += new System.EventHandler(this.tsNewAccount_Click);
            // 
            // gbContactValue
            // 
            this.gbContactValue.AutoSize = true;
            this.gbContactValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbContactValue.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gbContactValue.FullView = true;
            this.gbContactValue.Location = new System.Drawing.Point(0, 912);
            this.gbContactValue.Name = "gbContactValue";
            // 
            // gbContactValue.PnlContainer
            // 
            this.gbContactValue.PnlContainer.AutoSize = true;
            this.gbContactValue.PnlContainer.Controls.Add(this.tableLayoutPanel4);
            this.gbContactValue.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbContactValue.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gbContactValue.PnlContainer.Name = "PnlContainer";
            this.gbContactValue.PnlContainer.Size = new System.Drawing.Size(709, 184);
            this.gbContactValue.PnlContainer.TabIndex = 1;
            this.gbContactValue.Size = new System.Drawing.Size(709, 207);
            this.gbContactValue.TabIndex = 4;
            this.gbContactValue.TextHeader = "Контактные данные директора компании";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.move_EmailBoss, 2, 7);
            this.tableLayoutPanel4.Controls.Add(this.mt_EmailBoss, 3, 7);
            this.tableLayoutPanel4.Controls.Add(this.tmp_EmailBoss, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.lbl_BossMobilePhone, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.mt_BossSName, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.lbl_EmailBoss, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.move_BossSName, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.tmp_BossSName, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.mt_BossFName, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.move_BossFName, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.tmp_BossFName, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbl_BossFName, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.mt_BossWorkWith, 3, 4);
            this.tableLayoutPanel4.Controls.Add(this.move_BossWorkWith, 2, 4);
            this.tableLayoutPanel4.Controls.Add(this.tmp_BossWorkWith, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.lbl_BossName, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.mt_Boss, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.move_Boss, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.tmp_BossName, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.move_BossName, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.tmp_Boss, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.mt_BossName, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbl_Boss, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.lbl_BossWorkWith, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.lbl_BossSName, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.lbl_UnicalBossCode, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.move_BossMobilePhone, 2, 6);
            this.tableLayoutPanel4.Controls.Add(this.tmp_BossMobilePhone, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.mt_UnicalBossCode, 3, 5);
            this.tableLayoutPanel4.Controls.Add(this.mt_BossMobilePhone, 3, 6);
            this.tableLayoutPanel4.Controls.Add(this.tmp_UnicalBossCode, 2, 5);
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(709, 184);
            this.tableLayoutPanel4.TabIndex = 143;
            // 
            // move_EmailBoss
            // 
            this.move_EmailBoss.AutoSize = true;
            this.move_EmailBoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_EmailBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_EmailBoss.Location = new System.Drawing.Point(411, 164);
            this.move_EmailBoss.Name = "move_EmailBoss";
            this.move_EmailBoss.Size = new System.Drawing.Size(94, 17);
            this.move_EmailBoss.TabIndex = 152;
            this.move_EmailBoss.Text = "Перенести ->";
            this.move_EmailBoss.UseVisualStyleBackColor = true;
            // 
            // mt_EmailBoss
            // 
            this.mt_EmailBoss.BackColor = System.Drawing.SystemColors.Window;
            this.mt_EmailBoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_EmailBoss.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_EmailBoss.ErrorProvider = this.errorProvider1;
            this.mt_EmailBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_EmailBoss, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_EmailBoss.Location = new System.Drawing.Point(511, 164);
            this.mt_EmailBoss.MessageInformationError = "разделение ящиков через ;";
            this.mt_EmailBoss.Name = "mt_EmailBoss";
            this.mt_EmailBoss.RegexVerify = "(([-!#$%&\\\'*+\\\\.\\/0-9=?A-Za-z^_{|}~]+@[A-Za-z0-9\\._-]+\\.[A-Za-z]{2,6}(;|$))+|$)+";
            this.mt_EmailBoss.Size = new System.Drawing.Size(195, 20);
            this.mt_EmailBoss.TabIndex = 153;
            this.mt_EmailBoss.VerifyMaxLength = 50;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // mt_BossSName
            // 
            this.mt_BossSName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_BossSName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_BossSName.ErrorProvider = this.errorProvider1;
            this.mt_BossSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorProvider1.SetIconAlignment(this.mt_BossSName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_BossSName.Location = new System.Drawing.Point(511, 49);
            this.mt_BossSName.MessageInformationError = "Поле должно содержать 2 или более символа или оставаться пустым";
            this.mt_BossSName.Name = "mt_BossSName";
            this.mt_BossSName.RegexVerify = "$|(\\s*\\S+\\s*){2,}";
            this.mt_BossSName.Size = new System.Drawing.Size(195, 20);
            this.mt_BossSName.TabIndex = 9;
            this.mt_BossSName.VerifyMaxLength = 20;
            // 
            // mt_BossWorkWith
            // 
            this.mt_BossWorkWith.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_BossWorkWith.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_BossWorkWith.ErrorProvider = this.errorProvider1;
            this.mt_BossWorkWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorProvider1.SetIconAlignment(this.mt_BossWorkWith, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_BossWorkWith.Location = new System.Drawing.Point(511, 95);
            this.mt_BossWorkWith.MessageInformationError = "Поле является обязательным";
            this.mt_BossWorkWith.Name = "mt_BossWorkWith";
            this.mt_BossWorkWith.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_BossWorkWith.Size = new System.Drawing.Size(195, 20);
            this.mt_BossWorkWith.TabIndex = 11;
            this.mt_BossWorkWith.VerifyMaxLength = 150;
            // 
            // mt_Boss
            // 
            this.mt_Boss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Boss.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Boss.ErrorProvider = this.errorProvider1;
            this.mt_Boss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorProvider1.SetIconAlignment(this.mt_Boss, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_Boss.Location = new System.Drawing.Point(511, 72);
            this.mt_Boss.MessageInformationError = "Поле является обязательным";
            this.mt_Boss.Name = "mt_Boss";
            this.mt_Boss.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_Boss.Size = new System.Drawing.Size(195, 20);
            this.mt_Boss.TabIndex = 10;
            this.mt_Boss.VerifyMaxLength = 50;
            // 
            // mt_BossName
            // 
            this.mt_BossName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_BossName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_BossName.ErrorProvider = this.errorProvider1;
            this.mt_BossName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorProvider1.SetIconAlignment(this.mt_BossName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_BossName.Location = new System.Drawing.Point(511, 3);
            this.mt_BossName.MessageInformationError = "Обязательное для заполнения, должно содержать 2 или более символа";
            this.mt_BossName.Name = "mt_BossName";
            this.mt_BossName.RegexVerify = "(\\s*\\S+\\s*){2,}";
            this.mt_BossName.Size = new System.Drawing.Size(195, 20);
            this.mt_BossName.TabIndex = 7;
            this.mt_BossName.VerifyMaxLength = 20;
            // 
            // mt_CodeOKVED
            // 
            this.mt_CodeOKVED.AcceptsReturn = true;
            this.mt_CodeOKVED.BackColor = System.Drawing.SystemColors.Window;
            this.mt_CodeOKVED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CodeOKVED.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CodeOKVED.ErrorProvider = this.errorProvider1;
            this.mt_CodeOKVED.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_CodeOKVED, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_CodeOKVED.Location = new System.Drawing.Point(482, 141);
            this.mt_CodeOKVED.MessageInformationError = "Это обязательное поле";
            this.mt_CodeOKVED.Name = "mt_CodeOKVED";
            this.mt_CodeOKVED.RegexVerify = "";
            this.mt_CodeOKVED.Size = new System.Drawing.Size(224, 20);
            this.mt_CodeOKVED.TabIndex = 13;
            this.mt_CodeOKVED.VerifyMaxLength = 50;
            // 
            // mt_CodeOKATO
            // 
            this.mt_CodeOKATO.AcceptsReturn = true;
            this.mt_CodeOKATO.BackColor = System.Drawing.SystemColors.Window;
            this.mt_CodeOKATO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CodeOKATO.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CodeOKATO.ErrorProvider = this.errorProvider1;
            this.mt_CodeOKATO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_CodeOKATO, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_CodeOKATO.Location = new System.Drawing.Point(482, 118);
            this.mt_CodeOKATO.MessageInformationError = "Это обязательное поле";
            this.mt_CodeOKATO.Name = "mt_CodeOKATO";
            this.mt_CodeOKATO.RegexVerify = "";
            this.mt_CodeOKATO.Size = new System.Drawing.Size(224, 20);
            this.mt_CodeOKATO.TabIndex = 12;
            this.mt_CodeOKATO.VerifyMaxLength = 50;
            // 
            // mt_CodeOKONH
            // 
            this.mt_CodeOKONH.AcceptsReturn = true;
            this.mt_CodeOKONH.BackColor = System.Drawing.SystemColors.Window;
            this.mt_CodeOKONH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CodeOKONH.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CodeOKONH.ErrorProvider = this.errorProvider1;
            this.mt_CodeOKONH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_CodeOKONH, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_CodeOKONH.Location = new System.Drawing.Point(482, 95);
            this.mt_CodeOKONH.MessageInformationError = "Это обязательное поле";
            this.mt_CodeOKONH.Name = "mt_CodeOKONH";
            this.mt_CodeOKONH.RegexVerify = "";
            this.mt_CodeOKONH.Size = new System.Drawing.Size(224, 20);
            this.mt_CodeOKONH.TabIndex = 11;
            this.mt_CodeOKONH.VerifyMaxLength = 30;
            // 
            // mt_CodeOKPO
            // 
            this.mt_CodeOKPO.AcceptsReturn = true;
            this.mt_CodeOKPO.BackColor = System.Drawing.SystemColors.Window;
            this.mt_CodeOKPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CodeOKPO.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CodeOKPO.ErrorProvider = this.errorProvider1;
            this.mt_CodeOKPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_CodeOKPO, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_CodeOKPO.Location = new System.Drawing.Point(482, 72);
            this.mt_CodeOKPO.MessageInformationError = "Это обязательное поле";
            this.mt_CodeOKPO.Name = "mt_CodeOKPO";
            this.mt_CodeOKPO.RegexVerify = "";
            this.mt_CodeOKPO.Size = new System.Drawing.Size(224, 20);
            this.mt_CodeOKPO.TabIndex = 10;
            this.mt_CodeOKPO.VerifyMaxLength = 30;
            // 
            // mt_KPP
            // 
            this.mt_KPP.AcceptsReturn = true;
            this.mt_KPP.BackColor = System.Drawing.SystemColors.Window;
            this.mt_KPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_KPP.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_KPP.ErrorProvider = this.errorProvider1;
            this.mt_KPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_KPP, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_KPP.Location = new System.Drawing.Point(482, 26);
            this.mt_KPP.MessageInformationError = "";
            this.mt_KPP.Name = "mt_KPP";
            this.mt_KPP.RegexVerify = "";
            this.mt_KPP.Size = new System.Drawing.Size(224, 20);
            this.mt_KPP.TabIndex = 8;
            this.mt_KPP.VerifyMaxLength = 30;
            // 
            // mt_CodeOGRN
            // 
            this.mt_CodeOGRN.AcceptsReturn = true;
            this.mt_CodeOGRN.BackColor = System.Drawing.SystemColors.Window;
            this.mt_CodeOGRN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_CodeOGRN.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_CodeOGRN.ErrorProvider = this.errorProvider1;
            this.mt_CodeOGRN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_CodeOGRN, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_CodeOGRN.Location = new System.Drawing.Point(482, 49);
            this.mt_CodeOGRN.MessageInformationError = "";
            this.mt_CodeOGRN.Name = "mt_CodeOGRN";
            this.mt_CodeOGRN.RegexVerify = "";
            this.mt_CodeOGRN.Size = new System.Drawing.Size(224, 20);
            this.mt_CodeOGRN.TabIndex = 9;
            this.mt_CodeOGRN.VerifyMaxLength = 30;
            // 
            // mt_EMailBuh
            // 
            this.mt_EMailBuh.BackColor = System.Drawing.SystemColors.Window;
            this.mt_EMailBuh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_EMailBuh.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_EMailBuh.ErrorProvider = this.errorProvider1;
            this.mt_EMailBuh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_EMailBuh, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_EMailBuh.Location = new System.Drawing.Point(482, 302);
            this.mt_EMailBuh.MessageInformationError = "Разделение ящиков через ;";
            this.mt_EMailBuh.Name = "mt_EMailBuh";
            this.mt_EMailBuh.RegexVerify = "(([-!#$%&\\\'*+\\\\.\\/0-9=?A-Za-z^_{|}~]+@[A-Za-z0-9\\._-]+\\.[A-Za-z]{2,6}(;|$))+|$)+";
            this.mt_EMailBuh.Size = new System.Drawing.Size(224, 20);
            this.mt_EMailBuh.TabIndex = 26;
            this.mt_EMailBuh.VerifyMaxLength = 50;
            // 
            // mt_Metro
            // 
            this.mt_Metro.AcceptsReturn = true;
            this.mt_Metro.BackColor = System.Drawing.SystemColors.Control;
            this.mt_Metro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Metro.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Metro.ErrorProvider = this.errorProvider1;
            this.mt_Metro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_Metro, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_Metro.Location = new System.Drawing.Point(482, 72);
            this.mt_Metro.MessageInformationError = "Это обязательное поле";
            this.mt_Metro.Name = "mt_Metro";
            this.mt_Metro.ReadOnly = true;
            this.mt_Metro.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_Metro.Size = new System.Drawing.Size(224, 20);
            this.mt_Metro.TabIndex = 40;
            this.mt_Metro.VerifyMaxLength = 0;
            // 
            // mt_EmailSpam
            // 
            this.mt_EmailSpam.BackColor = System.Drawing.SystemColors.Window;
            this.mt_EmailSpam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_EmailSpam.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_EmailSpam.ErrorProvider = this.errorProvider1;
            this.mt_EmailSpam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_EmailSpam, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_EmailSpam.Location = new System.Drawing.Point(482, 279);
            this.mt_EmailSpam.MessageInformationError = "Разделение ящиков через ;";
            this.mt_EmailSpam.Name = "mt_EmailSpam";
            this.mt_EmailSpam.RegexVerify = "(([-!#$%&\\\'*+\\\\.\\/0-9=?A-Za-z^_{|}~]+@[A-Za-z0-9\\._-]+\\.[A-Za-z]{2,6}(;|$))+|$)+";
            this.mt_EmailSpam.Size = new System.Drawing.Size(224, 20);
            this.mt_EmailSpam.TabIndex = 25;
            this.mt_EmailSpam.VerifyMaxLength = 50;
            // 
            // mt_EmailRasilka
            // 
            this.mt_EmailRasilka.BackColor = System.Drawing.SystemColors.Window;
            this.mt_EmailRasilka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_EmailRasilka.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_EmailRasilka.ErrorProvider = this.errorProvider1;
            this.mt_EmailRasilka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_EmailRasilka, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_EmailRasilka.Location = new System.Drawing.Point(482, 256);
            this.mt_EmailRasilka.MessageInformationError = "Обязательное поле разделение ящиков через ;";
            this.mt_EmailRasilka.Name = "mt_EmailRasilka";
            this.mt_EmailRasilka.RegexVerify = "([-!#$%&\\\'*+\\\\.\\/0-9=?A-Za-z^_{|}~]+@[A-Za-z0-9\\._-]+\\.[A-Za-z]{2,6}(;|$))+";
            this.mt_EmailRasilka.Size = new System.Drawing.Size(224, 20);
            this.mt_EmailRasilka.TabIndex = 24;
            this.mt_EmailRasilka.VerifyMaxLength = 50;
            // 
            // mt_City
            // 
            this.mt_City.AcceptsReturn = true;
            this.mt_City.BackColor = System.Drawing.SystemColors.Control;
            this.mt_City.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_City.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_City.ErrorProvider = this.errorProvider1;
            this.mt_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_City, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_City.Location = new System.Drawing.Point(482, 49);
            this.mt_City.MessageInformationError = "Это обязательное поле";
            this.mt_City.Name = "mt_City";
            this.mt_City.ReadOnly = true;
            this.mt_City.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_City.Size = new System.Drawing.Size(224, 20);
            this.mt_City.TabIndex = 39;
            this.mt_City.VerifyMaxLength = 0;
            // 
            // mt_MobilePhone
            // 
            this.mt_MobilePhone.BackColor = System.Drawing.SystemColors.Window;
            this.mt_MobilePhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_MobilePhone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_MobilePhone.ErrorProvider = this.errorProvider1;
            this.mt_MobilePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_MobilePhone, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_MobilePhone.Location = new System.Drawing.Point(482, 233);
            this.mt_MobilePhone.MessageInformationError = "Формат +74957866860 где +(код страны)(код города)(номер телефона) разделение чере" +
    "з ;";
            this.mt_MobilePhone.Name = "mt_MobilePhone";
            this.mt_MobilePhone.RegexVerify = "((\\+[0-9]{1,2}|)(\\([0-9]{2,5}\\)|)[0-9]{1,4}(-|)[0-9]{1,4}((-|)[0-9]{1,4}|)(;|$)|$" +
    ")+";
            this.mt_MobilePhone.Size = new System.Drawing.Size(224, 20);
            this.mt_MobilePhone.TabIndex = 23;
            this.mt_MobilePhone.VerifyMaxLength = 255;
            // 
            // mt_Fax2
            // 
            this.mt_Fax2.BackColor = System.Drawing.SystemColors.Window;
            this.mt_Fax2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Fax2.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Fax2.ErrorProvider = this.errorProvider1;
            this.mt_Fax2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_Fax2, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_Fax2.Location = new System.Drawing.Point(482, 210);
            this.mt_Fax2.MessageInformationError = "Формат +74957866860 где +(код страны)(код города)(номер телефона) разделение чере" +
    "з ;";
            this.mt_Fax2.Name = "mt_Fax2";
            this.mt_Fax2.RegexVerify = "((\\+[0-9]{1,2}|)(\\([0-9]{2,5}\\)|)[0-9]{1,4}(-|)[0-9]{1,4}((-|)[0-9]{1,4}|)(;|$)|$" +
    ")+";
            this.mt_Fax2.Size = new System.Drawing.Size(224, 20);
            this.mt_Fax2.TabIndex = 22;
            this.mt_Fax2.VerifyMaxLength = 20;
            // 
            // mt_Country
            // 
            this.mt_Country.AcceptsReturn = true;
            this.mt_Country.BackColor = System.Drawing.SystemColors.Control;
            this.mt_Country.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Country.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Country.ErrorProvider = this.errorProvider1;
            this.mt_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_Country, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_Country.Location = new System.Drawing.Point(482, 26);
            this.mt_Country.MessageInformationError = "";
            this.mt_Country.Name = "mt_Country";
            this.mt_Country.ReadOnly = true;
            this.mt_Country.RegexVerify = "";
            this.mt_Country.Size = new System.Drawing.Size(224, 20);
            this.mt_Country.TabIndex = 38;
            this.mt_Country.VerifyMaxLength = 0;
            // 
            // mt_Fax1
            // 
            this.mt_Fax1.BackColor = System.Drawing.SystemColors.Window;
            this.mt_Fax1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Fax1.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Fax1.ErrorProvider = this.errorProvider1;
            this.mt_Fax1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_Fax1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_Fax1.Location = new System.Drawing.Point(482, 187);
            this.mt_Fax1.MessageInformationError = "Формат +74957866860 где +(код страны)(код города)(номер телефона) разделение чере" +
    "з ;";
            this.mt_Fax1.Name = "mt_Fax1";
            this.mt_Fax1.RegexVerify = "((\\+[0-9]{1,2}|)(\\([0-9]{2,5}\\)|)[0-9]{1,4}(-|)[0-9]{1,4}((-|)[0-9]{1,4}|)(;|$)|$" +
    ")+";
            this.mt_Fax1.Size = new System.Drawing.Size(224, 20);
            this.mt_Fax1.TabIndex = 21;
            this.mt_Fax1.VerifyMaxLength = 20;
            // 
            // mt_PostIndex
            // 
            this.mt_PostIndex.AcceptsReturn = true;
            this.mt_PostIndex.BackColor = System.Drawing.SystemColors.Window;
            this.mt_PostIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_PostIndex.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_PostIndex.ErrorProvider = this.errorProvider1;
            this.mt_PostIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_PostIndex, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_PostIndex.Location = new System.Drawing.Point(482, 3);
            this.mt_PostIndex.MessageInformationError = "";
            this.mt_PostIndex.Name = "mt_PostIndex";
            this.mt_PostIndex.RegexVerify = "";
            this.mt_PostIndex.Size = new System.Drawing.Size(224, 20);
            this.mt_PostIndex.TabIndex = 13;
            this.mt_PostIndex.VerifyMaxLength = 6;
            // 
            // mt_Phone
            // 
            this.mt_Phone.BackColor = System.Drawing.SystemColors.Window;
            this.mt_Phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Phone.ErrorProvider = this.errorProvider1;
            this.mt_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_Phone, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_Phone.Location = new System.Drawing.Point(482, 164);
            this.mt_Phone.MessageInformationError = "Это поле обязательное. Формат +74957866860 где +(код страны)(код города)(номер те" +
    "лефона) разделение через ;";
            this.mt_Phone.Name = "mt_Phone";
            this.mt_Phone.RegexVerify = "((\\+[0-9]{1,2}|)(\\([0-9]{2,5}\\)|)[0-9]{1,4}(-|)[0-9]{1,4}((-|)[0-9]{1,4}|)(;|$))+" +
    "";
            this.mt_Phone.Size = new System.Drawing.Size(224, 20);
            this.mt_Phone.TabIndex = 20;
            this.mt_Phone.VerifyMaxLength = 254;
            // 
            // mt_LegalAdress
            // 
            this.mt_LegalAdress.AcceptsReturn = true;
            this.mt_LegalAdress.BackColor = System.Drawing.SystemColors.Window;
            this.mt_LegalAdress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_LegalAdress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_LegalAdress.ErrorProvider = this.errorProvider1;
            this.mt_LegalAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_LegalAdress, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_LegalAdress.Location = new System.Drawing.Point(482, 141);
            this.mt_LegalAdress.MessageInformationError = "Это обязательное поле";
            this.mt_LegalAdress.Name = "mt_LegalAdress";
            this.mt_LegalAdress.RegexVerify = "";
            this.mt_LegalAdress.Size = new System.Drawing.Size(224, 20);
            this.mt_LegalAdress.TabIndex = 19;
            this.mt_LegalAdress.VerifyMaxLength = 160;
            // 
            // mt_LegalPostIndex
            // 
            this.mt_LegalPostIndex.AcceptsReturn = true;
            this.mt_LegalPostIndex.BackColor = System.Drawing.SystemColors.Window;
            this.mt_LegalPostIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_LegalPostIndex.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_LegalPostIndex.ErrorProvider = this.errorProvider1;
            this.mt_LegalPostIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_LegalPostIndex, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_LegalPostIndex.Location = new System.Drawing.Point(482, 118);
            this.mt_LegalPostIndex.MessageInformationError = "Это обязательное поле";
            this.mt_LegalPostIndex.Name = "mt_LegalPostIndex";
            this.mt_LegalPostIndex.RegexVerify = "";
            this.mt_LegalPostIndex.Size = new System.Drawing.Size(224, 20);
            this.mt_LegalPostIndex.TabIndex = 18;
            this.mt_LegalPostIndex.VerifyMaxLength = 6;
            // 
            // mt_Adress
            // 
            this.mt_Adress.AcceptsReturn = true;
            this.mt_Adress.BackColor = System.Drawing.SystemColors.Window;
            this.mt_Adress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Adress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Adress.ErrorProvider = this.errorProvider1;
            this.mt_Adress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_Adress, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_Adress.Location = new System.Drawing.Point(482, 95);
            this.mt_Adress.MessageInformationError = "Это обязательное поле";
            this.mt_Adress.Name = "mt_Adress";
            this.mt_Adress.RegexVerify = "";
            this.mt_Adress.Size = new System.Drawing.Size(224, 20);
            this.mt_Adress.TabIndex = 17;
            this.mt_Adress.VerifyMaxLength = 160;
            // 
            // mt_FullName
            // 
            this.mt_FullName.AcceptsReturn = true;
            this.mt_FullName.BackColor = System.Drawing.SystemColors.Window;
            this.mt_FullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_FullName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_FullName.ErrorProvider = this.errorProvider1;
            this.mt_FullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_FullName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_FullName.Location = new System.Drawing.Point(482, 49);
            this.mt_FullName.MessageInformationError = "Это поле обязательное";
            this.mt_FullName.Name = "mt_FullName";
            this.mt_FullName.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_FullName.Size = new System.Drawing.Size(224, 20);
            this.mt_FullName.TabIndex = 5;
            this.mt_FullName.VerifyMaxLength = 160;
            // 
            // mt_NameLat
            // 
            this.mt_NameLat.AcceptsReturn = true;
            this.mt_NameLat.BackColor = System.Drawing.SystemColors.Window;
            this.mt_NameLat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_NameLat.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_NameLat.ErrorProvider = this.errorProvider1;
            this.mt_NameLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_NameLat, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_NameLat.Location = new System.Drawing.Point(482, 26);
            this.mt_NameLat.MessageInformationError = "Это поле обязательное";
            this.mt_NameLat.Name = "mt_NameLat";
            this.mt_NameLat.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_NameLat.Size = new System.Drawing.Size(224, 20);
            this.mt_NameLat.TabIndex = 4;
            this.mt_NameLat.VerifyMaxLength = 80;
            // 
            // mt_Name
            // 
            this.mt_Name.AcceptsReturn = true;
            this.mt_Name.BackColor = System.Drawing.SystemColors.Window;
            this.mt_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_Name.ErrorProvider = this.errorProvider1;
            this.mt_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_Name, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_Name.Location = new System.Drawing.Point(482, 3);
            this.mt_Name.MessageInformationError = "Это поле обязательное";
            this.mt_Name.Name = "mt_Name";
            this.mt_Name.RegexVerify = "(\\s*\\S+\\s*)+";
            this.mt_Name.Size = new System.Drawing.Size(224, 20);
            this.mt_Name.TabIndex = 3;
            this.mt_Name.VerifyMaxLength = 50;
            // 
            // mt_INN
            // 
            this.mt_INN.AcceptsReturn = true;
            this.mt_INN.BackColor = System.Drawing.SystemColors.Window;
            this.mt_INN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_INN.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_INN.ErrorProvider = this.errorProvider1;
            this.mt_INN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_INN, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_INN.Location = new System.Drawing.Point(482, 3);
            this.mt_INN.MessageInformationError = "Поле должно содержать 2 или более символа или оставаться пустым";
            this.mt_INN.Name = "mt_INN";
            this.mt_INN.RegexVerify = "$|(\\s*\\S+\\s*){2,}";
            this.mt_INN.Size = new System.Drawing.Size(224, 20);
            this.mt_INN.TabIndex = 7;
            this.mt_INN.VerifyMaxLength = 30;
            // 
            // mt_BossFName
            // 
            this.mt_BossFName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_BossFName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_BossFName.ErrorProvider = this.errorProvider1;
            this.mt_BossFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorProvider1.SetIconAlignment(this.mt_BossFName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_BossFName.Location = new System.Drawing.Point(511, 26);
            this.mt_BossFName.MessageInformationError = "Обязательное для заполнения, должно содержать 2 или более символа";
            this.mt_BossFName.Name = "mt_BossFName";
            this.mt_BossFName.RegexVerify = "(\\s*\\S+\\s*){2,}";
            this.mt_BossFName.Size = new System.Drawing.Size(195, 20);
            this.mt_BossFName.TabIndex = 8;
            this.mt_BossFName.VerifyMaxLength = 20;
            // 
            // mt_License
            // 
            this.mt_License.AcceptsReturn = true;
            this.mt_License.BackColor = System.Drawing.SystemColors.Window;
            this.mt_License.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_License.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_License.ErrorProvider = this.errorProvider1;
            this.mt_License.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_License, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_License.Location = new System.Drawing.Point(482, 72);
            this.mt_License.MessageInformationError = "";
            this.mt_License.Name = "mt_License";
            this.mt_License.RegexVerify = "";
            this.mt_License.Size = new System.Drawing.Size(224, 20);
            this.mt_License.TabIndex = 136;
            this.mt_License.VerifyMaxLength = 50;
            // 
            // mt_AdditionalInfo
            // 
            this.mt_AdditionalInfo.AcceptsReturn = true;
            this.mt_AdditionalInfo.BackColor = System.Drawing.SystemColors.Window;
            this.mt_AdditionalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_AdditionalInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_AdditionalInfo.ErrorProvider = this.errorProvider1;
            this.mt_AdditionalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.errorProvider1.SetIconAlignment(this.mt_AdditionalInfo, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_AdditionalInfo.Location = new System.Drawing.Point(482, 95);
            this.mt_AdditionalInfo.MessageInformationError = "";
            this.mt_AdditionalInfo.Name = "mt_AdditionalInfo";
            this.mt_AdditionalInfo.RegexVerify = "";
            this.mt_AdditionalInfo.Size = new System.Drawing.Size(224, 20);
            this.mt_AdditionalInfo.TabIndex = 140;
            this.mt_AdditionalInfo.VerifyMaxLength = 50;
            // 
            // mt_UnicalBossCode
            // 
            this.mt_UnicalBossCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mt_UnicalBossCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_UnicalBossCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_UnicalBossCode.ErrorProvider = this.errorProvider1;
            this.mt_UnicalBossCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mt_UnicalBossCode.ForeColor = System.Drawing.Color.Black;
            this.errorProvider1.SetIconAlignment(this.mt_UnicalBossCode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_UnicalBossCode.Location = new System.Drawing.Point(511, 118);
            this.mt_UnicalBossCode.MessageInformationError = "";
            this.mt_UnicalBossCode.Name = "mt_UnicalBossCode";
            this.mt_UnicalBossCode.ReadOnly = true;
            this.mt_UnicalBossCode.RegexVerify = "";
            this.mt_UnicalBossCode.Size = new System.Drawing.Size(195, 20);
            this.mt_UnicalBossCode.TabIndex = 12;
            this.mt_UnicalBossCode.VerifyMaxLength = 20;
            this.mt_UnicalBossCode.Visible = false;
            // 
            // mt_BossMobilePhone
            // 
            this.mt_BossMobilePhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_BossMobilePhone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.mt_BossMobilePhone.ErrorProvider = this.errorProvider1;
            this.mt_BossMobilePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorProvider1.SetIconAlignment(this.mt_BossMobilePhone, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.mt_BossMobilePhone.Location = new System.Drawing.Point(511, 141);
            this.mt_BossMobilePhone.MessageInformationError = "Формат +74957866860 где +(код страны)(код города)(номер телефона) разделение чере" +
    "з ;";
            this.mt_BossMobilePhone.Name = "mt_BossMobilePhone";
            this.mt_BossMobilePhone.RegexVerify = "\\+[0-9]{10,14}|";
            this.mt_BossMobilePhone.Size = new System.Drawing.Size(195, 20);
            this.mt_BossMobilePhone.TabIndex = 13;
            this.mt_BossMobilePhone.VerifyMaxLength = 20;
            // 
            // tmp_EmailBoss
            // 
            this.tmp_EmailBoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_EmailBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_EmailBoss.Location = new System.Drawing.Point(210, 164);
            this.tmp_EmailBoss.MaxLength = 50;
            this.tmp_EmailBoss.Name = "tmp_EmailBoss";
            this.tmp_EmailBoss.Size = new System.Drawing.Size(195, 20);
            this.tmp_EmailBoss.TabIndex = 154;
            // 
            // lbl_BossMobilePhone
            // 
            this.lbl_BossMobilePhone.AutoSize = true;
            this.lbl_BossMobilePhone.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BossMobilePhone.Location = new System.Drawing.Point(63, 138);
            this.lbl_BossMobilePhone.Name = "lbl_BossMobilePhone";
            this.lbl_BossMobilePhone.Size = new System.Drawing.Size(141, 23);
            this.lbl_BossMobilePhone.TabIndex = 151;
            this.lbl_BossMobilePhone.Text = "№ Моб.тел. руководителя:";
            this.lbl_BossMobilePhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_EmailBoss
            // 
            this.lbl_EmailBoss.AutoSize = true;
            this.lbl_EmailBoss.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_EmailBoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_EmailBoss.Location = new System.Drawing.Point(91, 161);
            this.lbl_EmailBoss.Name = "lbl_EmailBoss";
            this.lbl_EmailBoss.Size = new System.Drawing.Size(113, 23);
            this.lbl_EmailBoss.TabIndex = 155;
            this.lbl_EmailBoss.Text = "E-Mail Руководителя:";
            this.lbl_EmailBoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_BossSName
            // 
            this.move_BossSName.AutoSize = true;
            this.move_BossSName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_BossSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_BossSName.Location = new System.Drawing.Point(411, 49);
            this.move_BossSName.Name = "move_BossSName";
            this.move_BossSName.Size = new System.Drawing.Size(94, 17);
            this.move_BossSName.TabIndex = 2;
            this.move_BossSName.Text = "Перенести ->";
            this.move_BossSName.UseVisualStyleBackColor = true;
            this.move_BossSName.Click += new System.EventHandler(this.move_Checked);
            // 
            // tmp_BossSName
            // 
            this.tmp_BossSName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_BossSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_BossSName.Location = new System.Drawing.Point(210, 49);
            this.tmp_BossSName.MaxLength = 40;
            this.tmp_BossSName.Name = "tmp_BossSName";
            this.tmp_BossSName.Size = new System.Drawing.Size(195, 20);
            this.tmp_BossSName.TabIndex = 16;
            // 
            // move_BossFName
            // 
            this.move_BossFName.AutoSize = true;
            this.move_BossFName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_BossFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_BossFName.Location = new System.Drawing.Point(411, 26);
            this.move_BossFName.Name = "move_BossFName";
            this.move_BossFName.Size = new System.Drawing.Size(94, 17);
            this.move_BossFName.TabIndex = 1;
            this.move_BossFName.Text = "Перенести ->";
            this.move_BossFName.UseVisualStyleBackColor = true;
            this.move_BossFName.Click += new System.EventHandler(this.move_Checked);
            // 
            // tmp_BossFName
            // 
            this.tmp_BossFName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_BossFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_BossFName.Location = new System.Drawing.Point(210, 26);
            this.tmp_BossFName.MaxLength = 40;
            this.tmp_BossFName.Name = "tmp_BossFName";
            this.tmp_BossFName.Size = new System.Drawing.Size(195, 20);
            this.tmp_BossFName.TabIndex = 15;
            // 
            // lbl_BossFName
            // 
            this.lbl_BossFName.AutoSize = true;
            this.lbl_BossFName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BossFName.Location = new System.Drawing.Point(175, 23);
            this.lbl_BossFName.Name = "lbl_BossFName";
            this.lbl_BossFName.Size = new System.Drawing.Size(29, 23);
            this.lbl_BossFName.TabIndex = 148;
            this.lbl_BossFName.Text = "Имя";
            this.lbl_BossFName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_BossWorkWith
            // 
            this.move_BossWorkWith.AutoSize = true;
            this.move_BossWorkWith.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_BossWorkWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_BossWorkWith.Location = new System.Drawing.Point(411, 95);
            this.move_BossWorkWith.Name = "move_BossWorkWith";
            this.move_BossWorkWith.Size = new System.Drawing.Size(94, 17);
            this.move_BossWorkWith.TabIndex = 4;
            this.move_BossWorkWith.Text = "Перенести ->";
            this.move_BossWorkWith.UseVisualStyleBackColor = true;
            this.move_BossWorkWith.Click += new System.EventHandler(this.move_Checked);
            // 
            // tmp_BossWorkWith
            // 
            this.tmp_BossWorkWith.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_BossWorkWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_BossWorkWith.Location = new System.Drawing.Point(210, 95);
            this.tmp_BossWorkWith.MaxLength = 50;
            this.tmp_BossWorkWith.Name = "tmp_BossWorkWith";
            this.tmp_BossWorkWith.Size = new System.Drawing.Size(195, 20);
            this.tmp_BossWorkWith.TabIndex = 18;
            // 
            // lbl_BossName
            // 
            this.lbl_BossName.AutoSize = true;
            this.lbl_BossName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BossName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_BossName.Location = new System.Drawing.Point(145, 0);
            this.lbl_BossName.Name = "lbl_BossName";
            this.lbl_BossName.Size = new System.Drawing.Size(59, 23);
            this.lbl_BossName.TabIndex = 138;
            this.lbl_BossName.Text = "Фамилия:";
            this.lbl_BossName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_Boss
            // 
            this.move_Boss.AutoSize = true;
            this.move_Boss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_Boss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_Boss.Location = new System.Drawing.Point(411, 72);
            this.move_Boss.Name = "move_Boss";
            this.move_Boss.Size = new System.Drawing.Size(94, 17);
            this.move_Boss.TabIndex = 3;
            this.move_Boss.Text = "Перенести ->";
            this.move_Boss.UseVisualStyleBackColor = true;
            this.move_Boss.Click += new System.EventHandler(this.move_Checked);
            // 
            // tmp_BossName
            // 
            this.tmp_BossName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_BossName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_BossName.Location = new System.Drawing.Point(210, 3);
            this.tmp_BossName.MaxLength = 40;
            this.tmp_BossName.Name = "tmp_BossName";
            this.tmp_BossName.Size = new System.Drawing.Size(195, 20);
            this.tmp_BossName.TabIndex = 14;
            // 
            // move_BossName
            // 
            this.move_BossName.AutoSize = true;
            this.move_BossName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_BossName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_BossName.Location = new System.Drawing.Point(411, 3);
            this.move_BossName.Name = "move_BossName";
            this.move_BossName.Size = new System.Drawing.Size(94, 17);
            this.move_BossName.TabIndex = 0;
            this.move_BossName.Text = "Перенести ->";
            this.move_BossName.UseVisualStyleBackColor = true;
            this.move_BossName.Click += new System.EventHandler(this.move_Checked);
            // 
            // tmp_Boss
            // 
            this.tmp_Boss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_Boss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_Boss.Location = new System.Drawing.Point(210, 72);
            this.tmp_Boss.MaxLength = 50;
            this.tmp_Boss.Name = "tmp_Boss";
            this.tmp_Boss.Size = new System.Drawing.Size(195, 20);
            this.tmp_Boss.TabIndex = 17;
            // 
            // lbl_Boss
            // 
            this.lbl_Boss.AutoSize = true;
            this.lbl_Boss.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Boss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Boss.Location = new System.Drawing.Point(17, 69);
            this.lbl_Boss.Name = "lbl_Boss";
            this.lbl_Boss.Size = new System.Drawing.Size(187, 23);
            this.lbl_Boss.TabIndex = 142;
            this.lbl_Boss.Text = "Должность \"директора\" компании:";
            this.lbl_Boss.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_BossWorkWith
            // 
            this.lbl_BossWorkWith.AutoSize = true;
            this.lbl_BossWorkWith.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BossWorkWith.Location = new System.Drawing.Point(68, 92);
            this.lbl_BossWorkWith.Name = "lbl_BossWorkWith";
            this.lbl_BossWorkWith.Size = new System.Drawing.Size(136, 23);
            this.lbl_BossWorkWith.TabIndex = 143;
            this.lbl_BossWorkWith.Text = "Действует на основание:";
            this.lbl_BossWorkWith.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_BossSName
            // 
            this.lbl_BossSName.AutoSize = true;
            this.lbl_BossSName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_BossSName.Location = new System.Drawing.Point(150, 46);
            this.lbl_BossSName.Name = "lbl_BossSName";
            this.lbl_BossSName.Size = new System.Drawing.Size(54, 23);
            this.lbl_BossSName.TabIndex = 149;
            this.lbl_BossSName.Text = "Отчество";
            this.lbl_BossSName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_UnicalBossCode
            // 
            this.lbl_UnicalBossCode.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.lbl_UnicalBossCode, 2);
            this.lbl_UnicalBossCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_UnicalBossCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_UnicalBossCode.Location = new System.Drawing.Point(209, 115);
            this.lbl_UnicalBossCode.Name = "lbl_UnicalBossCode";
            this.lbl_UnicalBossCode.Size = new System.Drawing.Size(196, 23);
            this.lbl_UnicalBossCode.TabIndex = 150;
            this.lbl_UnicalBossCode.Text = "Уникальный код руководителя:";
            this.lbl_UnicalBossCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_BossMobilePhone
            // 
            this.move_BossMobilePhone.AutoSize = true;
            this.move_BossMobilePhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_BossMobilePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_BossMobilePhone.Location = new System.Drawing.Point(411, 141);
            this.move_BossMobilePhone.Name = "move_BossMobilePhone";
            this.move_BossMobilePhone.Size = new System.Drawing.Size(94, 17);
            this.move_BossMobilePhone.TabIndex = 6;
            this.move_BossMobilePhone.Text = "Перенести ->";
            this.move_BossMobilePhone.UseVisualStyleBackColor = true;
            this.move_BossMobilePhone.Click += new System.EventHandler(this.move_Checked);
            // 
            // tmp_BossMobilePhone
            // 
            this.tmp_BossMobilePhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_BossMobilePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_BossMobilePhone.Location = new System.Drawing.Point(210, 141);
            this.tmp_BossMobilePhone.MaxLength = 50;
            this.tmp_BossMobilePhone.Name = "tmp_BossMobilePhone";
            this.tmp_BossMobilePhone.Size = new System.Drawing.Size(195, 20);
            this.tmp_BossMobilePhone.TabIndex = 20;
            // 
            // tmp_UnicalBossCode
            // 
            this.tmp_UnicalBossCode.AutoSize = true;
            this.tmp_UnicalBossCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_UnicalBossCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_UnicalBossCode.Location = new System.Drawing.Point(411, 118);
            this.tmp_UnicalBossCode.Name = "tmp_UnicalBossCode";
            this.tmp_UnicalBossCode.Size = new System.Drawing.Size(94, 17);
            this.tmp_UnicalBossCode.TabIndex = 5;
            this.tmp_UnicalBossCode.Text = "Создать УКР если его нет";
            this.tmp_UnicalBossCode.UseVisualStyleBackColor = true;
            this.tmp_UnicalBossCode.CheckedChanged += new System.EventHandler(this.tmp_UnicalBossCode_CheckedChanged);
            // 
            // gbBuhgalteria
            // 
            this.gbBuhgalteria.AutoSize = true;
            this.gbBuhgalteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBuhgalteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbBuhgalteria.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gbBuhgalteria.FullView = true;
            this.gbBuhgalteria.Location = new System.Drawing.Point(0, 728);
            this.gbBuhgalteria.Name = "gbBuhgalteria";
            // 
            // gbBuhgalteria.PnlContainer
            // 
            this.gbBuhgalteria.PnlContainer.AutoSize = true;
            this.gbBuhgalteria.PnlContainer.Controls.Add(this.tableLayoutPanel3);
            this.gbBuhgalteria.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBuhgalteria.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gbBuhgalteria.PnlContainer.Name = "PnlContainer";
            this.gbBuhgalteria.PnlContainer.Size = new System.Drawing.Size(709, 161);
            this.gbBuhgalteria.PnlContainer.TabIndex = 1;
            this.gbBuhgalteria.Size = new System.Drawing.Size(709, 184);
            this.gbBuhgalteria.TabIndex = 3;
            this.gbBuhgalteria.TextHeader = "Данные для бухгалтерии";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lbl_INN, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.mt_CodeOKVED, 3, 6);
            this.tableLayoutPanel3.Controls.Add(this.tmp_INN, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.move_CodeOKVED, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.mt_CodeOKATO, 3, 5);
            this.tableLayoutPanel3.Controls.Add(this.tmp_CodeOKVED, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.move_INN, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_CodeOKVED, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.mt_CodeOKONH, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.mt_INN, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.mt_CodeOKPO, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.move_CodeOKATO, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.lbl_KPP, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tmp_CodeOKATO, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.tmp_KPP, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_CodeOKATO, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.mt_KPP, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.move_KPP, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_CodeOGRN, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.move_CodeOKONH, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.tmp_CodeOGRN, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.tmp_CodeOKONH, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.move_CodeOGRN, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbl_CodeOKONH, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.mt_CodeOGRN, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbl_CodeOKPO, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tmp_CodeOKPO, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.move_CodeOKPO, 2, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(709, 161);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lbl_INN
            // 
            this.lbl_INN.AutoSize = true;
            this.lbl_INN.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_INN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_INN.Location = new System.Drawing.Point(113, 0);
            this.lbl_INN.Name = "lbl_INN";
            this.lbl_INN.Size = new System.Drawing.Size(34, 23);
            this.lbl_INN.TabIndex = 140;
            this.lbl_INN.Text = "ИНН:";
            this.lbl_INN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmp_INN
            // 
            this.tmp_INN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_INN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_INN.Location = new System.Drawing.Point(153, 3);
            this.tmp_INN.MaxLength = 30;
            this.tmp_INN.Name = "tmp_INN";
            this.tmp_INN.Size = new System.Drawing.Size(223, 20);
            this.tmp_INN.TabIndex = 14;
            // 
            // move_CodeOKVED
            // 
            this.move_CodeOKVED.AutoSize = true;
            this.move_CodeOKVED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_CodeOKVED.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_CodeOKVED.Location = new System.Drawing.Point(382, 141);
            this.move_CodeOKVED.Name = "move_CodeOKVED";
            this.move_CodeOKVED.Size = new System.Drawing.Size(94, 17);
            this.move_CodeOKVED.TabIndex = 6;
            this.move_CodeOKVED.Text = "Перенести ->";
            this.move_CodeOKVED.UseVisualStyleBackColor = true;
            this.move_CodeOKVED.CheckStateChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_CodeOKVED
            // 
            this.tmp_CodeOKVED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_CodeOKVED.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_CodeOKVED.Location = new System.Drawing.Point(153, 141);
            this.tmp_CodeOKVED.MaxLength = 30;
            this.tmp_CodeOKVED.Name = "tmp_CodeOKVED";
            this.tmp_CodeOKVED.Size = new System.Drawing.Size(223, 20);
            this.tmp_CodeOKVED.TabIndex = 20;
            // 
            // move_INN
            // 
            this.move_INN.AutoSize = true;
            this.move_INN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_INN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_INN.Location = new System.Drawing.Point(382, 3);
            this.move_INN.Name = "move_INN";
            this.move_INN.Size = new System.Drawing.Size(94, 17);
            this.move_INN.TabIndex = 0;
            this.move_INN.Text = "Перенести ->";
            this.move_INN.UseVisualStyleBackColor = true;
            this.move_INN.CheckStateChanged += new System.EventHandler(this.move_Checked);
            // 
            // lbl_CodeOKVED
            // 
            this.lbl_CodeOKVED.AutoSize = true;
            this.lbl_CodeOKVED.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CodeOKVED.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_CodeOKVED.Location = new System.Drawing.Point(99, 138);
            this.lbl_CodeOKVED.Name = "lbl_CodeOKVED";
            this.lbl_CodeOKVED.Size = new System.Drawing.Size(48, 23);
            this.lbl_CodeOKVED.TabIndex = 178;
            this.lbl_CodeOKVED.Text = "ОКВЭД:";
            this.lbl_CodeOKVED.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_CodeOKATO
            // 
            this.move_CodeOKATO.AutoSize = true;
            this.move_CodeOKATO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_CodeOKATO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_CodeOKATO.Location = new System.Drawing.Point(382, 118);
            this.move_CodeOKATO.Name = "move_CodeOKATO";
            this.move_CodeOKATO.Size = new System.Drawing.Size(94, 17);
            this.move_CodeOKATO.TabIndex = 5;
            this.move_CodeOKATO.Text = "Перенести ->";
            this.move_CodeOKATO.UseVisualStyleBackColor = true;
            this.move_CodeOKATO.CheckStateChanged += new System.EventHandler(this.move_Checked);
            // 
            // lbl_KPP
            // 
            this.lbl_KPP.AutoSize = true;
            this.lbl_KPP.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_KPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_KPP.Location = new System.Drawing.Point(114, 23);
            this.lbl_KPP.Name = "lbl_KPP";
            this.lbl_KPP.Size = new System.Drawing.Size(33, 23);
            this.lbl_KPP.TabIndex = 146;
            this.lbl_KPP.Text = "КПП:";
            this.lbl_KPP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmp_CodeOKATO
            // 
            this.tmp_CodeOKATO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_CodeOKATO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_CodeOKATO.Location = new System.Drawing.Point(153, 118);
            this.tmp_CodeOKATO.MaxLength = 30;
            this.tmp_CodeOKATO.Name = "tmp_CodeOKATO";
            this.tmp_CodeOKATO.Size = new System.Drawing.Size(223, 20);
            this.tmp_CodeOKATO.TabIndex = 19;
            // 
            // tmp_KPP
            // 
            this.tmp_KPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_KPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_KPP.Location = new System.Drawing.Point(153, 26);
            this.tmp_KPP.MaxLength = 30;
            this.tmp_KPP.Name = "tmp_KPP";
            this.tmp_KPP.Size = new System.Drawing.Size(223, 20);
            this.tmp_KPP.TabIndex = 15;
            // 
            // lbl_CodeOKATO
            // 
            this.lbl_CodeOKATO.AutoSize = true;
            this.lbl_CodeOKATO.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CodeOKATO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_CodeOKATO.Location = new System.Drawing.Point(100, 115);
            this.lbl_CodeOKATO.Name = "lbl_CodeOKATO";
            this.lbl_CodeOKATO.Size = new System.Drawing.Size(47, 23);
            this.lbl_CodeOKATO.TabIndex = 174;
            this.lbl_CodeOKATO.Text = "ОКАТО:";
            this.lbl_CodeOKATO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_KPP
            // 
            this.move_KPP.AutoSize = true;
            this.move_KPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_KPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_KPP.Location = new System.Drawing.Point(382, 26);
            this.move_KPP.Name = "move_KPP";
            this.move_KPP.Size = new System.Drawing.Size(94, 17);
            this.move_KPP.TabIndex = 1;
            this.move_KPP.Text = "Перенести ->";
            this.move_KPP.UseVisualStyleBackColor = true;
            this.move_KPP.CheckStateChanged += new System.EventHandler(this.move_Checked);
            // 
            // lbl_CodeOGRN
            // 
            this.lbl_CodeOGRN.AutoSize = true;
            this.lbl_CodeOGRN.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CodeOGRN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_CodeOGRN.Location = new System.Drawing.Point(108, 46);
            this.lbl_CodeOGRN.Name = "lbl_CodeOGRN";
            this.lbl_CodeOGRN.Size = new System.Drawing.Size(39, 23);
            this.lbl_CodeOGRN.TabIndex = 148;
            this.lbl_CodeOGRN.Text = "ОГРН:";
            this.lbl_CodeOGRN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_CodeOKONH
            // 
            this.move_CodeOKONH.AutoSize = true;
            this.move_CodeOKONH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_CodeOKONH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_CodeOKONH.Location = new System.Drawing.Point(382, 95);
            this.move_CodeOKONH.Name = "move_CodeOKONH";
            this.move_CodeOKONH.Size = new System.Drawing.Size(94, 17);
            this.move_CodeOKONH.TabIndex = 4;
            this.move_CodeOKONH.Text = "Перенести ->";
            this.move_CodeOKONH.UseVisualStyleBackColor = true;
            this.move_CodeOKONH.CheckStateChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_CodeOGRN
            // 
            this.tmp_CodeOGRN.AccessibleDescription = "";
            this.tmp_CodeOGRN.AccessibleName = "";
            this.tmp_CodeOGRN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_CodeOGRN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_CodeOGRN.Location = new System.Drawing.Point(153, 49);
            this.tmp_CodeOGRN.MaxLength = 30;
            this.tmp_CodeOGRN.Name = "tmp_CodeOGRN";
            this.tmp_CodeOGRN.Size = new System.Drawing.Size(223, 20);
            this.tmp_CodeOGRN.TabIndex = 16;
            // 
            // tmp_CodeOKONH
            // 
            this.tmp_CodeOKONH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_CodeOKONH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_CodeOKONH.Location = new System.Drawing.Point(153, 95);
            this.tmp_CodeOKONH.MaxLength = 30;
            this.tmp_CodeOKONH.Name = "tmp_CodeOKONH";
            this.tmp_CodeOKONH.Size = new System.Drawing.Size(223, 20);
            this.tmp_CodeOKONH.TabIndex = 18;
            // 
            // move_CodeOGRN
            // 
            this.move_CodeOGRN.AutoSize = true;
            this.move_CodeOGRN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_CodeOGRN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_CodeOGRN.Location = new System.Drawing.Point(382, 49);
            this.move_CodeOGRN.Name = "move_CodeOGRN";
            this.move_CodeOGRN.Size = new System.Drawing.Size(94, 17);
            this.move_CodeOGRN.TabIndex = 2;
            this.move_CodeOGRN.Text = "Перенести ->";
            this.move_CodeOGRN.UseVisualStyleBackColor = true;
            this.move_CodeOGRN.CheckStateChanged += new System.EventHandler(this.move_Checked);
            // 
            // lbl_CodeOKONH
            // 
            this.lbl_CodeOKONH.AutoSize = true;
            this.lbl_CodeOKONH.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CodeOKONH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_CodeOKONH.Location = new System.Drawing.Point(99, 92);
            this.lbl_CodeOKONH.Name = "lbl_CodeOKONH";
            this.lbl_CodeOKONH.Size = new System.Drawing.Size(48, 23);
            this.lbl_CodeOKONH.TabIndex = 170;
            this.lbl_CodeOKONH.Text = "ОКОНХ:";
            this.lbl_CodeOKONH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CodeOKPO
            // 
            this.lbl_CodeOKPO.AutoSize = true;
            this.lbl_CodeOKPO.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_CodeOKPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_CodeOKPO.Location = new System.Drawing.Point(106, 69);
            this.lbl_CodeOKPO.Name = "lbl_CodeOKPO";
            this.lbl_CodeOKPO.Size = new System.Drawing.Size(41, 23);
            this.lbl_CodeOKPO.TabIndex = 150;
            this.lbl_CodeOKPO.Text = "ОКПО:";
            this.lbl_CodeOKPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmp_CodeOKPO
            // 
            this.tmp_CodeOKPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_CodeOKPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_CodeOKPO.Location = new System.Drawing.Point(153, 72);
            this.tmp_CodeOKPO.MaxLength = 30;
            this.tmp_CodeOKPO.Name = "tmp_CodeOKPO";
            this.tmp_CodeOKPO.Size = new System.Drawing.Size(223, 20);
            this.tmp_CodeOKPO.TabIndex = 17;
            // 
            // move_CodeOKPO
            // 
            this.move_CodeOKPO.AutoSize = true;
            this.move_CodeOKPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_CodeOKPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_CodeOKPO.Location = new System.Drawing.Point(382, 72);
            this.move_CodeOKPO.Name = "move_CodeOKPO";
            this.move_CodeOKPO.Size = new System.Drawing.Size(94, 17);
            this.move_CodeOKPO.TabIndex = 3;
            this.move_CodeOKPO.Text = "Перенести ->";
            this.move_CodeOKPO.UseVisualStyleBackColor = true;
            this.move_CodeOKPO.CheckStateChanged += new System.EventHandler(this.move_Checked);
            // 
            // gbContact
            // 
            this.gbContact.AutoSize = true;
            this.gbContact.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbContact.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gbContact.FullView = true;
            this.gbContact.Location = new System.Drawing.Point(0, 360);
            this.gbContact.Name = "gbContact";
            // 
            // gbContact.PnlContainer
            // 
            this.gbContact.PnlContainer.AutoSize = true;
            this.gbContact.PnlContainer.Controls.Add(this.tableLayoutPanel2);
            this.gbContact.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbContact.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gbContact.PnlContainer.Name = "PnlContainer";
            this.gbContact.PnlContainer.Size = new System.Drawing.Size(709, 345);
            this.gbContact.PnlContainer.TabIndex = 1;
            this.gbContact.Size = new System.Drawing.Size(709, 368);
            this.gbContact.TabIndex = 2;
            this.gbContact.TextHeader = "Адрес";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_PostIndex, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.mt_MetroKey, 3, 14);
            this.tableLayoutPanel2.Controls.Add(this.mt_EMailBuh, 3, 13);
            this.tableLayoutPanel2.Controls.Add(this.mt_CityKey, 1, 14);
            this.tableLayoutPanel2.Controls.Add(this.mt_Metro, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.mt_EmailSpam, 3, 12);
            this.tableLayoutPanel2.Controls.Add(this.tmp_PostIndex, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.move_EMailBuh, 2, 13);
            this.tableLayoutPanel2.Controls.Add(this.tmp_EMailBuh, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.mt_EmailRasilka, 3, 11);
            this.tableLayoutPanel2.Controls.Add(this.lbl_EMailBuh, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.mt_City, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.mt_MobilePhone, 3, 10);
            this.tableLayoutPanel2.Controls.Add(this.move_PostIndex, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tmp_EmailSpam, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.move_EmailSpam, 2, 12);
            this.tableLayoutPanel2.Controls.Add(this.mt_Fax2, 3, 9);
            this.tableLayoutPanel2.Controls.Add(this.lbl_EmailSpam, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.mt_Country, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.mt_Fax1, 3, 8);
            this.tableLayoutPanel2.Controls.Add(this.mt_PostIndex, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.mt_Phone, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Country, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.move_EmailRasilka, 2, 11);
            this.tableLayoutPanel2.Controls.Add(this.tmp_EmailRasilka, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.mt_LegalAdress, 3, 6);
            this.tableLayoutPanel2.Controls.Add(this.tmp_Country, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_EmailRasilka, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.mt_LegalPostIndex, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Fax1, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.move_MobilePhone, 2, 10);
            this.tableLayoutPanel2.Controls.Add(this.lbl_City, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.mt_Adress, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.tmp_Fax1, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.lbl_MobilePhone, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Fax2, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.move_Fax2, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.tmp_Phone, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.tmp_Fax2, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.tmp_City, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.move_City, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Metro, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tmp_Metro, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.move_Fax1, 2, 8);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Phone, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.move_Metro, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbl_LegalPostIndex, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Adress, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tmp_Adress, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.move_Adress, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.tmp_LegalPostIndex, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.move_LegalPostIndex, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.tmp_LegalAdress, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.move_Phone, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.lbl_LegalAdress, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.move_LegalAdress, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.tmp_MobilePhone, 1, 10);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 15;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(709, 345);
            this.tableLayoutPanel2.TabIndex = 170;
            // 
            // lbl_PostIndex
            // 
            this.lbl_PostIndex.AutoSize = true;
            this.lbl_PostIndex.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_PostIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_PostIndex.Location = new System.Drawing.Point(29, 0);
            this.lbl_PostIndex.Name = "lbl_PostIndex";
            this.lbl_PostIndex.Size = new System.Drawing.Size(118, 23);
            this.lbl_PostIndex.TabIndex = 121;
            this.lbl_PostIndex.Text = "Индекс факт. адреса:";
            this.lbl_PostIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mt_MetroKey
            // 
            this.mt_MetroKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mt_MetroKey.Location = new System.Drawing.Point(482, 325);
            this.mt_MetroKey.Name = "mt_MetroKey";
            this.mt_MetroKey.ReadOnly = true;
            this.mt_MetroKey.Size = new System.Drawing.Size(111, 20);
            this.mt_MetroKey.TabIndex = 12;
            this.mt_MetroKey.Visible = false;
            // 
            // mt_CityKey
            // 
            this.mt_CityKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mt_CityKey.Location = new System.Drawing.Point(153, 325);
            this.mt_CityKey.Name = "mt_CityKey";
            this.mt_CityKey.ReadOnly = true;
            this.mt_CityKey.Size = new System.Drawing.Size(111, 20);
            this.mt_CityKey.TabIndex = 8;
            this.mt_CityKey.Visible = false;
            // 
            // tmp_PostIndex
            // 
            this.tmp_PostIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_PostIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_PostIndex.Location = new System.Drawing.Point(153, 3);
            this.tmp_PostIndex.MaxLength = 6;
            this.tmp_PostIndex.Name = "tmp_PostIndex";
            this.tmp_PostIndex.Size = new System.Drawing.Size(223, 20);
            this.tmp_PostIndex.TabIndex = 27;
            // 
            // move_EMailBuh
            // 
            this.move_EMailBuh.AutoSize = true;
            this.move_EMailBuh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_EMailBuh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_EMailBuh.Location = new System.Drawing.Point(382, 302);
            this.move_EMailBuh.Name = "move_EMailBuh";
            this.move_EMailBuh.Size = new System.Drawing.Size(94, 17);
            this.move_EMailBuh.TabIndex = 12;
            this.move_EMailBuh.Text = "Перенести ->";
            this.move_EMailBuh.UseVisualStyleBackColor = true;
            this.move_EMailBuh.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_EMailBuh
            // 
            this.tmp_EMailBuh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_EMailBuh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_EMailBuh.Location = new System.Drawing.Point(153, 302);
            this.tmp_EMailBuh.MaxLength = 50;
            this.tmp_EMailBuh.Name = "tmp_EMailBuh";
            this.tmp_EMailBuh.Size = new System.Drawing.Size(223, 20);
            this.tmp_EMailBuh.TabIndex = 37;
            // 
            // lbl_EMailBuh
            // 
            this.lbl_EMailBuh.AutoSize = true;
            this.lbl_EMailBuh.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_EMailBuh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_EMailBuh.Location = new System.Drawing.Point(22, 299);
            this.lbl_EMailBuh.Name = "lbl_EMailBuh";
            this.lbl_EMailBuh.Size = new System.Drawing.Size(125, 23);
            this.lbl_EMailBuh.TabIndex = 137;
            this.lbl_EMailBuh.Text = "E-Mail для бухгалтерии:";
            this.lbl_EMailBuh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_PostIndex
            // 
            this.move_PostIndex.AutoSize = true;
            this.move_PostIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_PostIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_PostIndex.Location = new System.Drawing.Point(382, 3);
            this.move_PostIndex.Name = "move_PostIndex";
            this.move_PostIndex.Size = new System.Drawing.Size(94, 17);
            this.move_PostIndex.TabIndex = 0;
            this.move_PostIndex.Text = "Перенести ->";
            this.move_PostIndex.UseVisualStyleBackColor = true;
            this.move_PostIndex.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_EmailSpam
            // 
            this.tmp_EmailSpam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_EmailSpam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_EmailSpam.Location = new System.Drawing.Point(153, 279);
            this.tmp_EmailSpam.MaxLength = 50;
            this.tmp_EmailSpam.Name = "tmp_EmailSpam";
            this.tmp_EmailSpam.Size = new System.Drawing.Size(223, 20);
            this.tmp_EmailSpam.TabIndex = 36;
            // 
            // move_EmailSpam
            // 
            this.move_EmailSpam.AutoSize = true;
            this.move_EmailSpam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_EmailSpam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_EmailSpam.Location = new System.Drawing.Point(382, 279);
            this.move_EmailSpam.Name = "move_EmailSpam";
            this.move_EmailSpam.Size = new System.Drawing.Size(94, 17);
            this.move_EmailSpam.TabIndex = 11;
            this.move_EmailSpam.Text = "Перенести ->";
            this.move_EmailSpam.UseVisualStyleBackColor = true;
            this.move_EmailSpam.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // lbl_EmailSpam
            // 
            this.lbl_EmailSpam.AutoSize = true;
            this.lbl_EmailSpam.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_EmailSpam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_EmailSpam.Location = new System.Drawing.Point(21, 276);
            this.lbl_EmailSpam.Name = "lbl_EmailSpam";
            this.lbl_EmailSpam.Size = new System.Drawing.Size(126, 23);
            this.lbl_EmailSpam.TabIndex = 135;
            this.lbl_EmailSpam.Text = "E-Mail для оповещения:";
            this.lbl_EmailSpam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Country
            // 
            this.lbl_Country.AutoSize = true;
            this.lbl_Country.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Country.Location = new System.Drawing.Point(101, 23);
            this.lbl_Country.Name = "lbl_Country";
            this.lbl_Country.Size = new System.Drawing.Size(46, 23);
            this.lbl_Country.TabIndex = 166;
            this.lbl_Country.Text = "Страна:";
            this.lbl_Country.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_EmailRasilka
            // 
            this.move_EmailRasilka.AutoSize = true;
            this.move_EmailRasilka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_EmailRasilka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_EmailRasilka.Location = new System.Drawing.Point(382, 256);
            this.move_EmailRasilka.Name = "move_EmailRasilka";
            this.move_EmailRasilka.Size = new System.Drawing.Size(94, 17);
            this.move_EmailRasilka.TabIndex = 10;
            this.move_EmailRasilka.Text = "Перенести ->";
            this.move_EmailRasilka.UseVisualStyleBackColor = true;
            this.move_EmailRasilka.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_EmailRasilka
            // 
            this.tmp_EmailRasilka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_EmailRasilka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_EmailRasilka.Location = new System.Drawing.Point(153, 256);
            this.tmp_EmailRasilka.MaxLength = 50;
            this.tmp_EmailRasilka.Name = "tmp_EmailRasilka";
            this.tmp_EmailRasilka.Size = new System.Drawing.Size(223, 20);
            this.tmp_EmailRasilka.TabIndex = 35;
            // 
            // tmp_Country
            // 
            this.tmp_Country.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_Country.FormattingEnabled = true;
            this.tmp_Country.Location = new System.Drawing.Point(153, 26);
            this.tmp_Country.Name = "tmp_Country";
            this.tmp_Country.Size = new System.Drawing.Size(223, 21);
            this.tmp_Country.TabIndex = 14;
            this.tmp_Country.SelectedValueChanged += new System.EventHandler(this.tmp_Country_SelectedValueChanged);
            // 
            // lbl_EmailRasilka
            // 
            this.lbl_EmailRasilka.AutoSize = true;
            this.lbl_EmailRasilka.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_EmailRasilka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_EmailRasilka.Location = new System.Drawing.Point(34, 253);
            this.lbl_EmailRasilka.Name = "lbl_EmailRasilka";
            this.lbl_EmailRasilka.Size = new System.Drawing.Size(113, 23);
            this.lbl_EmailRasilka.TabIndex = 133;
            this.lbl_EmailRasilka.Text = "E-Mail для рассылки:";
            this.lbl_EmailRasilka.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Fax1
            // 
            this.lbl_Fax1.AutoSize = true;
            this.lbl_Fax1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Fax1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Fax1.Location = new System.Drawing.Point(102, 184);
            this.lbl_Fax1.Name = "lbl_Fax1";
            this.lbl_Fax1.Size = new System.Drawing.Size(45, 23);
            this.lbl_Fax1.TabIndex = 127;
            this.lbl_Fax1.Text = "Факс1:";
            this.lbl_Fax1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_MobilePhone
            // 
            this.move_MobilePhone.AutoSize = true;
            this.move_MobilePhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_MobilePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_MobilePhone.Location = new System.Drawing.Point(382, 233);
            this.move_MobilePhone.Name = "move_MobilePhone";
            this.move_MobilePhone.Size = new System.Drawing.Size(94, 17);
            this.move_MobilePhone.TabIndex = 9;
            this.move_MobilePhone.Text = "Перенести ->";
            this.move_MobilePhone.UseVisualStyleBackColor = true;
            this.move_MobilePhone.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // lbl_City
            // 
            this.lbl_City.AutoSize = true;
            this.lbl_City.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_City.Location = new System.Drawing.Point(107, 46);
            this.lbl_City.Name = "lbl_City";
            this.lbl_City.Size = new System.Drawing.Size(40, 23);
            this.lbl_City.TabIndex = 160;
            this.lbl_City.Text = "Город:";
            this.lbl_City.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmp_Fax1
            // 
            this.tmp_Fax1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_Fax1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_Fax1.Location = new System.Drawing.Point(153, 187);
            this.tmp_Fax1.MaxLength = 20;
            this.tmp_Fax1.Name = "tmp_Fax1";
            this.tmp_Fax1.Size = new System.Drawing.Size(223, 20);
            this.tmp_Fax1.TabIndex = 32;
            // 
            // lbl_MobilePhone
            // 
            this.lbl_MobilePhone.AutoSize = true;
            this.lbl_MobilePhone.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_MobilePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_MobilePhone.Location = new System.Drawing.Point(43, 230);
            this.lbl_MobilePhone.Name = "lbl_MobilePhone";
            this.lbl_MobilePhone.Size = new System.Drawing.Size(104, 23);
            this.lbl_MobilePhone.TabIndex = 131;
            this.lbl_MobilePhone.Text = "Мобильный номер:";
            this.lbl_MobilePhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Fax2
            // 
            this.lbl_Fax2.AutoSize = true;
            this.lbl_Fax2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Fax2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Fax2.Location = new System.Drawing.Point(102, 207);
            this.lbl_Fax2.Name = "lbl_Fax2";
            this.lbl_Fax2.Size = new System.Drawing.Size(45, 23);
            this.lbl_Fax2.TabIndex = 129;
            this.lbl_Fax2.Text = "Факс2:";
            this.lbl_Fax2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_Fax2
            // 
            this.move_Fax2.AutoSize = true;
            this.move_Fax2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_Fax2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_Fax2.Location = new System.Drawing.Point(382, 210);
            this.move_Fax2.Name = "move_Fax2";
            this.move_Fax2.Size = new System.Drawing.Size(94, 17);
            this.move_Fax2.TabIndex = 8;
            this.move_Fax2.Text = "Перенести ->";
            this.move_Fax2.UseVisualStyleBackColor = true;
            this.move_Fax2.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_Phone
            // 
            this.tmp_Phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_Phone.Location = new System.Drawing.Point(153, 164);
            this.tmp_Phone.MaxLength = 254;
            this.tmp_Phone.Name = "tmp_Phone";
            this.tmp_Phone.Size = new System.Drawing.Size(223, 20);
            this.tmp_Phone.TabIndex = 31;
            // 
            // tmp_Fax2
            // 
            this.tmp_Fax2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_Fax2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_Fax2.Location = new System.Drawing.Point(153, 210);
            this.tmp_Fax2.MaxLength = 20;
            this.tmp_Fax2.Name = "tmp_Fax2";
            this.tmp_Fax2.Size = new System.Drawing.Size(223, 20);
            this.tmp_Fax2.TabIndex = 33;
            // 
            // tmp_City
            // 
            this.tmp_City.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_City.FormattingEnabled = true;
            this.tmp_City.Location = new System.Drawing.Point(153, 49);
            this.tmp_City.Name = "tmp_City";
            this.tmp_City.Size = new System.Drawing.Size(223, 21);
            this.tmp_City.TabIndex = 15;
            // 
            // move_City
            // 
            this.move_City.AutoSize = true;
            this.move_City.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_City.Location = new System.Drawing.Point(382, 49);
            this.move_City.Name = "move_City";
            this.move_City.Size = new System.Drawing.Size(94, 17);
            this.move_City.TabIndex = 1;
            this.move_City.Text = "Перенести ->";
            this.move_City.UseVisualStyleBackColor = true;
            this.move_City.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // lbl_Metro
            // 
            this.lbl_Metro.AutoSize = true;
            this.lbl_Metro.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Metro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Metro.Location = new System.Drawing.Point(105, 69);
            this.lbl_Metro.Name = "lbl_Metro";
            this.lbl_Metro.Size = new System.Drawing.Size(42, 23);
            this.lbl_Metro.TabIndex = 169;
            this.lbl_Metro.Text = "Метро:";
            this.lbl_Metro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmp_Metro
            // 
            this.tmp_Metro.ChangeBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tmp_Metro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_Metro.ErrorBackGroundColor = System.Drawing.Color.Red;
            this.tmp_Metro.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.tmp_Metro.ErrorProvider = null;
            this.tmp_Metro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_Metro.FormattingEnabled = true;
            this.tmp_Metro.IsNotNullValue = false;
            this.tmp_Metro.Location = new System.Drawing.Point(153, 72);
            this.tmp_Metro.MessageInformationError = "";
            this.tmp_Metro.Name = "tmp_Metro";
            this.tmp_Metro.Size = new System.Drawing.Size(223, 21);
            this.tmp_Metro.TabIndex = 16;
            // 
            // move_Fax1
            // 
            this.move_Fax1.AutoSize = true;
            this.move_Fax1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_Fax1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_Fax1.Location = new System.Drawing.Point(382, 187);
            this.move_Fax1.Name = "move_Fax1";
            this.move_Fax1.Size = new System.Drawing.Size(94, 17);
            this.move_Fax1.TabIndex = 7;
            this.move_Fax1.Text = "Перенести ->";
            this.move_Fax1.UseVisualStyleBackColor = true;
            this.move_Fax1.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.AutoSize = true;
            this.lbl_Phone.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Phone.Location = new System.Drawing.Point(92, 161);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(55, 23);
            this.lbl_Phone.TabIndex = 125;
            this.lbl_Phone.Text = "Телефон:";
            this.lbl_Phone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_Metro
            // 
            this.move_Metro.AutoSize = true;
            this.move_Metro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_Metro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_Metro.Location = new System.Drawing.Point(382, 72);
            this.move_Metro.Name = "move_Metro";
            this.move_Metro.Size = new System.Drawing.Size(94, 17);
            this.move_Metro.TabIndex = 2;
            this.move_Metro.Text = "Перенести ->";
            this.move_Metro.UseVisualStyleBackColor = true;
            this.move_Metro.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // lbl_LegalPostIndex
            // 
            this.lbl_LegalPostIndex.AutoSize = true;
            this.lbl_LegalPostIndex.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_LegalPostIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_LegalPostIndex.Location = new System.Drawing.Point(40, 115);
            this.lbl_LegalPostIndex.Name = "lbl_LegalPostIndex";
            this.lbl_LegalPostIndex.Size = new System.Drawing.Size(107, 23);
            this.lbl_LegalPostIndex.TabIndex = 117;
            this.lbl_LegalPostIndex.Text = "Индекс юр. адреса:";
            this.lbl_LegalPostIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Adress
            // 
            this.lbl_Adress.AutoSize = true;
            this.lbl_Adress.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Adress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Adress.Location = new System.Drawing.Point(73, 92);
            this.lbl_Adress.Name = "lbl_Adress";
            this.lbl_Adress.Size = new System.Drawing.Size(74, 23);
            this.lbl_Adress.TabIndex = 123;
            this.lbl_Adress.Text = "Факт. адрес:";
            this.lbl_Adress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmp_Adress
            // 
            this.tmp_Adress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_Adress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_Adress.Location = new System.Drawing.Point(153, 95);
            this.tmp_Adress.MaxLength = 160;
            this.tmp_Adress.Name = "tmp_Adress";
            this.tmp_Adress.Size = new System.Drawing.Size(223, 20);
            this.tmp_Adress.TabIndex = 28;
            // 
            // move_Adress
            // 
            this.move_Adress.AutoSize = true;
            this.move_Adress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_Adress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_Adress.Location = new System.Drawing.Point(382, 95);
            this.move_Adress.Name = "move_Adress";
            this.move_Adress.Size = new System.Drawing.Size(94, 17);
            this.move_Adress.TabIndex = 3;
            this.move_Adress.Text = "Перенести ->";
            this.move_Adress.UseVisualStyleBackColor = true;
            this.move_Adress.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_LegalPostIndex
            // 
            this.tmp_LegalPostIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_LegalPostIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_LegalPostIndex.Location = new System.Drawing.Point(153, 118);
            this.tmp_LegalPostIndex.MaxLength = 6;
            this.tmp_LegalPostIndex.Name = "tmp_LegalPostIndex";
            this.tmp_LegalPostIndex.Size = new System.Drawing.Size(223, 20);
            this.tmp_LegalPostIndex.TabIndex = 29;
            // 
            // move_LegalPostIndex
            // 
            this.move_LegalPostIndex.AutoSize = true;
            this.move_LegalPostIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_LegalPostIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_LegalPostIndex.Location = new System.Drawing.Point(382, 118);
            this.move_LegalPostIndex.Name = "move_LegalPostIndex";
            this.move_LegalPostIndex.Size = new System.Drawing.Size(94, 17);
            this.move_LegalPostIndex.TabIndex = 4;
            this.move_LegalPostIndex.Text = "Перенести ->";
            this.move_LegalPostIndex.UseVisualStyleBackColor = true;
            this.move_LegalPostIndex.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_LegalAdress
            // 
            this.tmp_LegalAdress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_LegalAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_LegalAdress.Location = new System.Drawing.Point(153, 141);
            this.tmp_LegalAdress.MaxLength = 160;
            this.tmp_LegalAdress.Name = "tmp_LegalAdress";
            this.tmp_LegalAdress.Size = new System.Drawing.Size(223, 20);
            this.tmp_LegalAdress.TabIndex = 30;
            // 
            // move_Phone
            // 
            this.move_Phone.AutoSize = true;
            this.move_Phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_Phone.Location = new System.Drawing.Point(382, 164);
            this.move_Phone.Name = "move_Phone";
            this.move_Phone.Size = new System.Drawing.Size(94, 17);
            this.move_Phone.TabIndex = 6;
            this.move_Phone.Text = "Перенести ->";
            this.move_Phone.UseVisualStyleBackColor = true;
            this.move_Phone.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // lbl_LegalAdress
            // 
            this.lbl_LegalAdress.AutoSize = true;
            this.lbl_LegalAdress.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_LegalAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_LegalAdress.Location = new System.Drawing.Point(86, 138);
            this.lbl_LegalAdress.Name = "lbl_LegalAdress";
            this.lbl_LegalAdress.Size = new System.Drawing.Size(61, 23);
            this.lbl_LegalAdress.TabIndex = 119;
            this.lbl_LegalAdress.Text = "Юр. адрес:";
            this.lbl_LegalAdress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_LegalAdress
            // 
            this.move_LegalAdress.AutoSize = true;
            this.move_LegalAdress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_LegalAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_LegalAdress.Location = new System.Drawing.Point(382, 141);
            this.move_LegalAdress.Name = "move_LegalAdress";
            this.move_LegalAdress.Size = new System.Drawing.Size(94, 17);
            this.move_LegalAdress.TabIndex = 5;
            this.move_LegalAdress.Text = "Перенести ->";
            this.move_LegalAdress.UseVisualStyleBackColor = true;
            this.move_LegalAdress.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_MobilePhone
            // 
            this.tmp_MobilePhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_MobilePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_MobilePhone.Location = new System.Drawing.Point(153, 233);
            this.tmp_MobilePhone.MaxLength = 254;
            this.tmp_MobilePhone.Name = "tmp_MobilePhone";
            this.tmp_MobilePhone.Size = new System.Drawing.Size(223, 20);
            this.tmp_MobilePhone.TabIndex = 34;
            // 
            // gbRegistration
            // 
            this.gbRegistration.AutoSize = true;
            this.gbRegistration.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbRegistration.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gbRegistration.FullView = true;
            this.gbRegistration.Location = new System.Drawing.Point(0, 222);
            this.gbRegistration.Name = "gbRegistration";
            // 
            // gbRegistration.PnlContainer
            // 
            this.gbRegistration.PnlContainer.AutoSize = true;
            this.gbRegistration.PnlContainer.Controls.Add(this.tableLayoutPanel1);
            this.gbRegistration.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRegistration.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gbRegistration.PnlContainer.Name = "PnlContainer";
            this.gbRegistration.PnlContainer.Size = new System.Drawing.Size(709, 115);
            this.gbRegistration.PnlContainer.TabIndex = 1;
            this.gbRegistration.Size = new System.Drawing.Size(709, 138);
            this.gbRegistration.TabIndex = 1;
            this.gbRegistration.TextHeader = "Регистрационные данные";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_AdditionalInfo, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbl_License, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Name, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mt_FullName, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tmp_Name, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.move_FullName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.mt_NameLat, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tmp_FullName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_FullName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.move_Name, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.move_NameLat, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.mt_Name, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tmp_NameLat, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_NameLat, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tmp_License, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.move_License, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.mt_License, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.tmp_AdditionalInfo, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.move_AdditionalInfo, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.mt_AdditionalInfo, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(709, 115);
            this.tableLayoutPanel1.TabIndex = 133;
            // 
            // lbl_AdditionalInfo
            // 
            this.lbl_AdditionalInfo.AutoSize = true;
            this.lbl_AdditionalInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_AdditionalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_AdditionalInfo.Location = new System.Drawing.Point(81, 92);
            this.lbl_AdditionalInfo.Name = "lbl_AdditionalInfo";
            this.lbl_AdditionalInfo.Size = new System.Drawing.Size(66, 23);
            this.lbl_AdditionalInfo.TabIndex = 137;
            this.lbl_AdditionalInfo.Text = "Выдана, от:";
            this.lbl_AdditionalInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_License
            // 
            this.lbl_License.AutoSize = true;
            this.lbl_License.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_License.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_License.Location = new System.Drawing.Point(87, 69);
            this.lbl_License.Name = "lbl_License";
            this.lbl_License.Size = new System.Drawing.Size(60, 23);
            this.lbl_License.TabIndex = 133;
            this.lbl_License.Text = "Лицензия:";
            this.lbl_License.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Name.Location = new System.Drawing.Point(87, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(60, 23);
            this.lbl_Name.TabIndex = 124;
            this.lbl_Name.Text = "Название:";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmp_Name
            // 
            this.tmp_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_Name.Location = new System.Drawing.Point(153, 3);
            this.tmp_Name.MaxLength = 50;
            this.tmp_Name.Name = "tmp_Name";
            this.tmp_Name.Size = new System.Drawing.Size(223, 20);
            this.tmp_Name.TabIndex = 6;
            // 
            // move_FullName
            // 
            this.move_FullName.AutoSize = true;
            this.move_FullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_FullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_FullName.Location = new System.Drawing.Point(382, 49);
            this.move_FullName.Name = "move_FullName";
            this.move_FullName.Size = new System.Drawing.Size(94, 17);
            this.move_FullName.TabIndex = 2;
            this.move_FullName.Text = "Перенести ->";
            this.move_FullName.UseVisualStyleBackColor = true;
            this.move_FullName.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_FullName
            // 
            this.tmp_FullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_FullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_FullName.Location = new System.Drawing.Point(153, 49);
            this.tmp_FullName.MaxLength = 80;
            this.tmp_FullName.Name = "tmp_FullName";
            this.tmp_FullName.Size = new System.Drawing.Size(223, 20);
            this.tmp_FullName.TabIndex = 8;
            // 
            // lbl_FullName
            // 
            this.lbl_FullName.AutoSize = true;
            this.lbl_FullName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_FullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_FullName.Location = new System.Drawing.Point(48, 46);
            this.lbl_FullName.Name = "lbl_FullName";
            this.lbl_FullName.Size = new System.Drawing.Size(99, 23);
            this.lbl_FullName.TabIndex = 126;
            this.lbl_FullName.Text = "Полное название:";
            this.lbl_FullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // move_Name
            // 
            this.move_Name.AutoSize = true;
            this.move_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_Name.Location = new System.Drawing.Point(382, 3);
            this.move_Name.Name = "move_Name";
            this.move_Name.Size = new System.Drawing.Size(94, 17);
            this.move_Name.TabIndex = 0;
            this.move_Name.Text = "Перенести ->";
            this.move_Name.UseVisualStyleBackColor = true;
            this.move_Name.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // move_NameLat
            // 
            this.move_NameLat.AutoSize = true;
            this.move_NameLat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_NameLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_NameLat.Location = new System.Drawing.Point(382, 26);
            this.move_NameLat.Name = "move_NameLat";
            this.move_NameLat.Size = new System.Drawing.Size(94, 17);
            this.move_NameLat.TabIndex = 1;
            this.move_NameLat.Text = "Перенести ->";
            this.move_NameLat.UseVisualStyleBackColor = true;
            this.move_NameLat.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_NameLat
            // 
            this.tmp_NameLat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_NameLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_NameLat.Location = new System.Drawing.Point(153, 26);
            this.tmp_NameLat.MaxLength = 50;
            this.tmp_NameLat.Name = "tmp_NameLat";
            this.tmp_NameLat.Size = new System.Drawing.Size(223, 20);
            this.tmp_NameLat.TabIndex = 7;
            // 
            // lbl_NameLat
            // 
            this.lbl_NameLat.AutoSize = true;
            this.lbl_NameLat.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_NameLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_NameLat.Location = new System.Drawing.Point(8, 23);
            this.lbl_NameLat.Name = "lbl_NameLat";
            this.lbl_NameLat.Size = new System.Drawing.Size(139, 23);
            this.lbl_NameLat.TabIndex = 132;
            this.lbl_NameLat.Text = "Название на английском:";
            this.lbl_NameLat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmp_License
            // 
            this.tmp_License.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_License.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_License.Location = new System.Drawing.Point(153, 72);
            this.tmp_License.MaxLength = 80;
            this.tmp_License.Name = "tmp_License";
            this.tmp_License.Size = new System.Drawing.Size(223, 20);
            this.tmp_License.TabIndex = 134;
            // 
            // move_License
            // 
            this.move_License.AutoSize = true;
            this.move_License.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_License.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_License.Location = new System.Drawing.Point(382, 72);
            this.move_License.Name = "move_License";
            this.move_License.Size = new System.Drawing.Size(94, 17);
            this.move_License.TabIndex = 135;
            this.move_License.Text = "Перенести ->";
            this.move_License.UseVisualStyleBackColor = true;
            this.move_License.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // tmp_AdditionalInfo
            // 
            this.tmp_AdditionalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmp_AdditionalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmp_AdditionalInfo.Location = new System.Drawing.Point(153, 95);
            this.tmp_AdditionalInfo.MaxLength = 80;
            this.tmp_AdditionalInfo.Name = "tmp_AdditionalInfo";
            this.tmp_AdditionalInfo.Size = new System.Drawing.Size(223, 20);
            this.tmp_AdditionalInfo.TabIndex = 138;
            // 
            // move_AdditionalInfo
            // 
            this.move_AdditionalInfo.AutoSize = true;
            this.move_AdditionalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_AdditionalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move_AdditionalInfo.Location = new System.Drawing.Point(382, 95);
            this.move_AdditionalInfo.Name = "move_AdditionalInfo";
            this.move_AdditionalInfo.Size = new System.Drawing.Size(94, 17);
            this.move_AdditionalInfo.TabIndex = 139;
            this.move_AdditionalInfo.Text = "Перенести ->";
            this.move_AdditionalInfo.UseVisualStyleBackColor = true;
            this.move_AdditionalInfo.CheckedChanged += new System.EventHandler(this.move_Checked);
            // 
            // AddsInformation
            // 
            this.AddsInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddsInformation.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.AddsInformation.FullView = true;
            this.AddsInformation.Location = new System.Drawing.Point(0, 0);
            this.AddsInformation.Name = "AddsInformation";
            // 
            // AddsInformation.PnlContainer
            // 
            this.AddsInformation.PnlContainer.Controls.Add(this.pnlNeedDogovors);
            this.AddsInformation.PnlContainer.Controls.Add(this.pnlNeedPasswords);
            this.AddsInformation.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddsInformation.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.AddsInformation.PnlContainer.Name = "PnlContainer";
            this.AddsInformation.PnlContainer.Size = new System.Drawing.Size(709, 199);
            this.AddsInformation.PnlContainer.TabIndex = 0;
            this.AddsInformation.PnlContainer.TabStop = true;
            this.AddsInformation.Size = new System.Drawing.Size(709, 222);
            this.AddsInformation.TabIndex = 0;
            this.AddsInformation.TextHeader = "Дополнительные данные";
            // 
            // pnlNeedDogovors
            // 
            this.pnlNeedDogovors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNeedDogovors.Controls.Add(this.clbNeedDogovors);
            this.pnlNeedDogovors.Controls.Add(this.cbGroupDogovorType);
            this.pnlNeedDogovors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNeedDogovors.Location = new System.Drawing.Point(0, 0);
            this.pnlNeedDogovors.Name = "pnlNeedDogovors";
            this.pnlNeedDogovors.Size = new System.Drawing.Size(339, 199);
            this.pnlNeedDogovors.TabIndex = 1;
            this.pnlNeedDogovors.TabStop = true;
            // 
            // clbNeedDogovors
            // 
            this.clbNeedDogovors.CheckOnClick = true;
            this.clbNeedDogovors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbNeedDogovors.FormattingEnabled = true;
            this.clbNeedDogovors.Location = new System.Drawing.Point(0, 21);
            this.clbNeedDogovors.Name = "clbNeedDogovors";
            this.clbNeedDogovors.Size = new System.Drawing.Size(337, 176);
            this.clbNeedDogovors.TabIndex = 0;
            // 
            // cbGroupDogovorType
            // 
            this.cbGroupDogovorType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbGroupDogovorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroupDogovorType.FormattingEnabled = true;
            this.cbGroupDogovorType.Location = new System.Drawing.Point(0, 0);
            this.cbGroupDogovorType.Name = "cbGroupDogovorType";
            this.cbGroupDogovorType.Size = new System.Drawing.Size(337, 21);
            this.cbGroupDogovorType.TabIndex = 1;
            this.cbGroupDogovorType.SelectedIndexChanged += new System.EventHandler(this.cbGroupDogovorType_SelectedIndexChanged);
            // 
            // pnlNeedPasswords
            // 
            this.pnlNeedPasswords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNeedPasswords.Controls.Add(this.clbNeedPasswords);
            this.pnlNeedPasswords.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNeedPasswords.Location = new System.Drawing.Point(339, 0);
            this.pnlNeedPasswords.Name = "pnlNeedPasswords";
            this.pnlNeedPasswords.Size = new System.Drawing.Size(370, 199);
            this.pnlNeedPasswords.TabIndex = 0;
            // 
            // clbNeedPasswords
            // 
            this.clbNeedPasswords.CheckOnClick = true;
            this.clbNeedPasswords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbNeedPasswords.FormattingEnabled = true;
            this.clbNeedPasswords.Location = new System.Drawing.Point(0, 0);
            this.clbNeedPasswords.Name = "clbNeedPasswords";
            this.clbNeedPasswords.Size = new System.Drawing.Size(368, 197);
            this.clbNeedPasswords.TabIndex = 1;
            // 
            // PnlContainer
            // 
            this.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.PnlContainer.Name = "PnlContainer";
            this.PnlContainer.Size = new System.Drawing.Size(709, 199);
            this.PnlContainer.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave,
            this.tsBtnCancel,
            this.tsLblAccreditationCard});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(726, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSave.Image")));
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(93, 28);
            this.tsBtnSave.Text = "Сохранить";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCancel.Image")));
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(138, 28);
            this.tsBtnCancel.Text = "Закрыть/отменить";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // tsLblAccreditationCard
            // 
            this.tsLblAccreditationCard.ForeColor = System.Drawing.Color.Red;
            this.tsLblAccreditationCard.Name = "tsLblAccreditationCard";
            this.tsLblAccreditationCard.Size = new System.Drawing.Size(128, 28);
            this.tsLblAccreditationCard.Text = "tsLblAccreditationCard";
            // 
            // frmMoveValues
            // 
            this.ClientSize = new System.Drawing.Size(726, 530);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMoveValues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перенос данных партнера в Мастер-Тур";
            this.Resize += new System.EventHandler(this.frmMoveValues_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.lwGroupContainer1.PnlContainer.ResumeLayout(false);
            this.lwGroupContainer1.ResumeLayout(false);
            this.gbPresentsAccount.ResumeLayout(false);
            this.pnlNewAccountInformation.PnlContainer.ResumeLayout(false);
            this.pnlNewAccountInformation.PnlContainer.PerformLayout();
            this.pnlNewAccountInformation.ResumeLayout(false);
            this.pnlNewAccountInformation.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.gbContactValue.PnlContainer.ResumeLayout(false);
            this.gbContactValue.PnlContainer.PerformLayout();
            this.gbContactValue.ResumeLayout(false);
            this.gbContactValue.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbBuhgalteria.PnlContainer.ResumeLayout(false);
            this.gbBuhgalteria.PnlContainer.PerformLayout();
            this.gbBuhgalteria.ResumeLayout(false);
            this.gbBuhgalteria.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.gbContact.PnlContainer.ResumeLayout(false);
            this.gbContact.PnlContainer.PerformLayout();
            this.gbContact.ResumeLayout(false);
            this.gbContact.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gbRegistration.PnlContainer.ResumeLayout(false);
            this.gbRegistration.PnlContainer.PerformLayout();
            this.gbRegistration.ResumeLayout(false);
            this.gbRegistration.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.AddsInformation.PnlContainer.ResumeLayout(false);
            this.AddsInformation.ResumeLayout(false);
            this.pnlNeedDogovors.ResumeLayout(false);
            this.pnlNeedPasswords.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private lwGroupContainer AddsInformation;
        private Panel pnlNeedPasswords;
        private Panel pnlNeedDogovors;
        private CheckedListBox clbNeedDogovors;
        private lwGroupContainer pnlNewAccountInformation;
        private Panel PnlContainer;
        private ToolStrip toolStrip1;
        private ToolStripButton tsBtnSave;
        private ToolStripButton tsBtnCancel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private lwGroupContainer lwGroupContainer1;
        private GroupBox gbPresentsAccount;
        private Panel pnlAccounts;
        private ToolStrip toolStrip2;
        private ToolStripButton tsNewAccount;
        private TableLayoutPanel tableLayoutPanel5;
        private lwTextBox mt_BossWorkWith;
        private CheckBox move_BossWorkWith;
        private TextBox tmp_BossWorkWith;
        private Label lbl_BossWorkWith;
        private CheckedListBox clbNeedPasswords;
        private lwTextBox mt_BossSName;
        private CheckBox move_BossSName;
        private TextBox tmp_BossSName;
        private lwTextBox mt_BossFName;
        private CheckBox move_BossFName;
        private TextBox tmp_BossFName;
        private Label lbl_BossFName;
        private Label lbl_BossSName;
        private Label lbl_License;
        private TextBox tmp_License;
        private CheckBox move_License;
        private lwTextBox mt_License;
        private Label lbl_AdditionalInfo;
        private TextBox tmp_AdditionalInfo;
        private CheckBox move_AdditionalInfo;
        private lwTextBox mt_AdditionalInfo;
        private Label lbl_UnicalBossCode;
        private Label lbl_BossMobilePhone;
        private CheckBox tmp_UnicalBossCode;
        private lwTextBox mt_UnicalBossCode;
        private lwTextBox mt_BossMobilePhone;
        private CheckBox move_BossMobilePhone;
        private TextBox tmp_BossMobilePhone;
        private ToolStripLabel tsLblAccreditationCard;
        private ComboBox cbGroupDogovorType;
        private CheckBox move_EmailBoss;
        private ltp_v2.Controls.Forms.lwTextBox mt_EmailBoss;
        private TextBox tmp_EmailBoss;
        private Label lbl_EmailBoss;
    }
}
