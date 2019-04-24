namespace AgencyManager
{
    partial class frmStart
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
            this.tsLblPermission = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnListNewRegistration = new System.Windows.Forms.ToolStripButton();
            this.tsBtnListPartners = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.АктивацияДоговораПоФаксуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.АктивацияДоговораПоОригиналуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ПодписаниеДоговоровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ПечатьКонвертаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.передачаКонвертовКурьерамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналОборотаДоговоровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnNotActive = new System.Windows.Forms.ToolStripButton();
            this.tsBtnTmpDogovor = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDeactive = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsBtnDeactiveNextDay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnDeactive7Days = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnDeactive14Days = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnEndDogovor = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsBtnEndDogovorNextDay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnEndDogovor7Days = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnEndDogovor14Days = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnArhive = new System.Windows.Forms.ToolStripDropDownButton();
            this.АрхивацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ИнформацияОАрхивеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnCC = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsBtnCCCreateAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnCCAccountSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnCCSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnConfigure = new System.Windows.Forms.ToolStripDropDownButton();
            this.шаблоныДоговоровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыДоговоровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приемДоговоровОтАгентствToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsLblPermission
            // 
            this.tsLblPermission.Name = "tsLblPermission";
            this.tsLblPermission.Size = new System.Drawing.Size(288, 15);
            this.tsLblPermission.Text = "Доступ: Полный";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(288, 15);
            this.toolStripLabel1.Text = "Статистика";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblPermission,
            this.tsBtnListNewRegistration,
            this.tsBtnListPartners,
            this.toolStripDropDownButton1,
            this.toolStripLabel1,
            this.tsBtnNotActive,
            this.tsBtnTmpDogovor,
            this.tsBtnDeactive,
            this.tsBtnEndDogovor,
            this.tsBtnArhive,
            this.tsBtnCC,
            this.toolStripLabel2,
            this.tsBtnConfigure});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(290, 557);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnListNewRegistration
            // 
            this.tsBtnListNewRegistration.Image = global::AgencyManager.Properties.Resources.UserGroupAdd;
            this.tsBtnListNewRegistration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnListNewRegistration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnListNewRegistration.Name = "tsBtnListNewRegistration";
            this.tsBtnListNewRegistration.Size = new System.Drawing.Size(288, 36);
            this.tsBtnListNewRegistration.Text = "Новые регистрации";
            this.tsBtnListNewRegistration.Click += new System.EventHandler(this.tsBtnListNewRegistration_Click);
            // 
            // tsBtnListPartners
            // 
            this.tsBtnListPartners.Image = global::AgencyManager.Properties.Resources.Contact;
            this.tsBtnListPartners.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnListPartners.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnListPartners.Name = "tsBtnListPartners";
            this.tsBtnListPartners.Size = new System.Drawing.Size(288, 36);
            this.tsBtnListPartners.Text = "Регистрированные агентства";
            this.tsBtnListPartners.Click += new System.EventHandler(this.tsBtnListPartners_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.АктивацияДоговораПоФаксуToolStripMenuItem,
            this.АктивацияДоговораПоОригиналуToolStripMenuItem,
            this.ПодписаниеДоговоровToolStripMenuItem,
            this.ПечатьКонвертаToolStripMenuItem,
            this.передачаКонвертовКурьерамToolStripMenuItem,
            this.журналОборотаДоговоровToolStripMenuItem,
            this.приемДоговоровОтАгентствToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::AgencyManager.Properties.Resources.Register_Contract;
            this.toolStripDropDownButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(288, 36);
            this.toolStripDropDownButton1.Text = "Договора";
            // 
            // АктивацияДоговораПоФаксуToolStripMenuItem
            // 
            this.АктивацияДоговораПоФаксуToolStripMenuItem.Name = "АктивацияДоговораПоФаксуToolStripMenuItem";
            this.АктивацияДоговораПоФаксуToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.АктивацияДоговораПоФаксуToolStripMenuItem.Text = "Активация договора по копии";
            this.АктивацияДоговораПоФаксуToolStripMenuItem.Click += new System.EventHandler(this.АктивацияДоговораПоФаксуToolStripMenuItem_Click);
            // 
            // АктивацияДоговораПоОригиналуToolStripMenuItem
            // 
            this.АктивацияДоговораПоОригиналуToolStripMenuItem.Name = "АктивацияДоговораПоОригиналуToolStripMenuItem";
            this.АктивацияДоговораПоОригиналуToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.АктивацияДоговораПоОригиналуToolStripMenuItem.Text = "Активация договора по оригиналу";
            this.АктивацияДоговораПоОригиналуToolStripMenuItem.Click += new System.EventHandler(this.активацияДоговораПоОригиналуToolStripMenuItem_Click);
            // 
            // ПодписаниеДоговоровToolStripMenuItem
            // 
            this.ПодписаниеДоговоровToolStripMenuItem.Name = "ПодписаниеДоговоровToolStripMenuItem";
            this.ПодписаниеДоговоровToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.ПодписаниеДоговоровToolStripMenuItem.Text = "Подписание договоров";
            this.ПодписаниеДоговоровToolStripMenuItem.Click += new System.EventHandler(this.подписаниеДоговоровToolStripMenuItem_Click);
            // 
            // ПечатьКонвертаToolStripMenuItem
            // 
            this.ПечатьКонвертаToolStripMenuItem.Name = "ПечатьКонвертаToolStripMenuItem";
            this.ПечатьКонвертаToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.ПечатьКонвертаToolStripMenuItem.Text = "Опись договоров/печать конверта";
            this.ПечатьКонвертаToolStripMenuItem.Click += new System.EventHandler(this.печатьКонвертаToolStripMenuItem_Click);
            // 
            // передачаКонвертовКурьерамToolStripMenuItem
            // 
            this.передачаКонвертовКурьерамToolStripMenuItem.Name = "передачаКонвертовКурьерамToolStripMenuItem";
            this.передачаКонвертовКурьерамToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.передачаКонвертовКурьерамToolStripMenuItem.Text = "Передача конвертов курьерам";
            this.передачаКонвертовКурьерамToolStripMenuItem.Click += new System.EventHandler(this.передачаКонвертовКурьерамToolStripMenuItem_Click);
            // 
            // журналОборотаДоговоровToolStripMenuItem
            // 
            this.журналОборотаДоговоровToolStripMenuItem.Name = "журналОборотаДоговоровToolStripMenuItem";
            this.журналОборотаДоговоровToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.журналОборотаДоговоровToolStripMenuItem.Text = "Журнал оборота договоров";
            this.журналОборотаДоговоровToolStripMenuItem.Click += new System.EventHandler(this.журналОборотаДоговоровToolStripMenuItem_Click);
            // 
            // tsBtnNotActive
            // 
            this.tsBtnNotActive.Image = global::AgencyManager.Properties.Resources.Contract_NonContract;
            this.tsBtnNotActive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnNotActive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNotActive.Name = "tsBtnNotActive";
            this.tsBtnNotActive.Size = new System.Drawing.Size(288, 36);
            this.tsBtnNotActive.Text = "Неактивных договоров:";
            this.tsBtnNotActive.Click += new System.EventHandler(this.tsBtnNotActive_Click);
            // 
            // tsBtnTmpDogovor
            // 
            this.tsBtnTmpDogovor.Image = global::AgencyManager.Properties.Resources.Contract_Wait;
            this.tsBtnTmpDogovor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnTmpDogovor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnTmpDogovor.Name = "tsBtnTmpDogovor";
            this.tsBtnTmpDogovor.Size = new System.Drawing.Size(288, 36);
            this.tsBtnTmpDogovor.Text = "Договоров заключенных по копии:";
            this.tsBtnTmpDogovor.Click += new System.EventHandler(this.tsBtnTmpDogovor_Click);
            // 
            // tsBtnDeactive
            // 
            this.tsBtnDeactive.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnDeactiveNextDay,
            this.tsBtnDeactive7Days,
            this.tsBtnDeactive14Days});
            this.tsBtnDeactive.Image = global::AgencyManager.Properties.Resources.Contract_End;
            this.tsBtnDeactive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnDeactive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDeactive.Name = "tsBtnDeactive";
            this.tsBtnDeactive.Size = new System.Drawing.Size(288, 36);
            this.tsBtnDeactive.Text = "Агентств, отключение завтра:";
            // 
            // tsBtnDeactiveNextDay
            // 
            this.tsBtnDeactiveNextDay.Name = "tsBtnDeactiveNextDay";
            this.tsBtnDeactiveNextDay.Size = new System.Drawing.Size(160, 22);
            this.tsBtnDeactiveNextDay.Text = "Завтра:";
            this.tsBtnDeactiveNextDay.Click += new System.EventHandler(this.tsBtnDeactiveNextDay_Click);
            // 
            // tsBtnDeactive7Days
            // 
            this.tsBtnDeactive7Days.Name = "tsBtnDeactive7Days";
            this.tsBtnDeactive7Days.Size = new System.Drawing.Size(160, 22);
            this.tsBtnDeactive7Days.Text = "Через неделю:";
            this.tsBtnDeactive7Days.Click += new System.EventHandler(this.tsBtnDeactive7Days_Click);
            // 
            // tsBtnDeactive14Days
            // 
            this.tsBtnDeactive14Days.Name = "tsBtnDeactive14Days";
            this.tsBtnDeactive14Days.Size = new System.Drawing.Size(160, 22);
            this.tsBtnDeactive14Days.Text = "Через 2 недели:";
            this.tsBtnDeactive14Days.Click += new System.EventHandler(this.tsBtnDeactive14Days_Click);
            // 
            // tsBtnEndDogovor
            // 
            this.tsBtnEndDogovor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnEndDogovorNextDay,
            this.tsBtnEndDogovor7Days,
            this.tsBtnEndDogovor14Days});
            this.tsBtnEndDogovor.Image = global::AgencyManager.Properties.Resources.Contract_End;
            this.tsBtnEndDogovor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnEndDogovor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEndDogovor.Name = "tsBtnEndDogovor";
            this.tsBtnEndDogovor.Size = new System.Drawing.Size(288, 36);
            this.tsBtnEndDogovor.Text = "Агентсв, завершается договор завтра:";
            // 
            // tsBtnEndDogovorNextDay
            // 
            this.tsBtnEndDogovorNextDay.Name = "tsBtnEndDogovorNextDay";
            this.tsBtnEndDogovorNextDay.Size = new System.Drawing.Size(160, 22);
            this.tsBtnEndDogovorNextDay.Text = "Завтра:";
            this.tsBtnEndDogovorNextDay.Click += new System.EventHandler(this.tsBtnEndDogovorNextDay_Click);
            // 
            // tsBtnEndDogovor7Days
            // 
            this.tsBtnEndDogovor7Days.Name = "tsBtnEndDogovor7Days";
            this.tsBtnEndDogovor7Days.Size = new System.Drawing.Size(160, 22);
            this.tsBtnEndDogovor7Days.Text = "Через неделю:";
            this.tsBtnEndDogovor7Days.Click += new System.EventHandler(this.tsBtnEndDogovor7Days_Click);
            // 
            // tsBtnEndDogovor14Days
            // 
            this.tsBtnEndDogovor14Days.Name = "tsBtnEndDogovor14Days";
            this.tsBtnEndDogovor14Days.Size = new System.Drawing.Size(160, 22);
            this.tsBtnEndDogovor14Days.Text = "Через 2 недели:";
            this.tsBtnEndDogovor14Days.Click += new System.EventHandler(this.tsBtnEndDogovor14Days_Click);
            // 
            // tsBtnArhive
            // 
            this.tsBtnArhive.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.АрхивацияToolStripMenuItem,
            this.ИнформацияОАрхивеToolStripMenuItem});
            this.tsBtnArhive.Image = global::AgencyManager.Properties.Resources.Export;
            this.tsBtnArhive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnArhive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnArhive.Name = "tsBtnArhive";
            this.tsBtnArhive.Size = new System.Drawing.Size(288, 36);
            this.tsBtnArhive.Text = "Архивирование документов";
            // 
            // АрхивацияToolStripMenuItem
            // 
            this.АрхивацияToolStripMenuItem.Name = "АрхивацияToolStripMenuItem";
            this.АрхивацияToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.АрхивацияToolStripMenuItem.Text = "Архивация";
            this.АрхивацияToolStripMenuItem.Click += new System.EventHandler(this.tsBtnShowArhiveDocument_Click);
            // 
            // ИнформацияОАрхивеToolStripMenuItem
            // 
            this.ИнформацияОАрхивеToolStripMenuItem.Name = "ИнформацияОАрхивеToolStripMenuItem";
            this.ИнформацияОАрхивеToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.ИнформацияОАрхивеToolStripMenuItem.Text = "Информация о архиве";
            this.ИнформацияОАрхивеToolStripMenuItem.Click += new System.EventHandler(this.tsBtnShowArhiveInfo_Click);
            // 
            // tsBtnCC
            // 
            this.tsBtnCC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnCCCreateAccount,
            this.tsBtnCCAccountSummary,
            this.tsBtnCCSummary});
            this.tsBtnCC.Image = global::AgencyManager.Properties.Resources.Phone;
            this.tsBtnCC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnCC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCC.Name = "tsBtnCC";
            this.tsBtnCC.Size = new System.Drawing.Size(288, 36);
            this.tsBtnCC.Text = "Управление CallCenter";
            this.tsBtnCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsBtnCCCreateAccount
            // 
            this.tsBtnCCCreateAccount.Name = "tsBtnCCCreateAccount";
            this.tsBtnCCCreateAccount.Size = new System.Drawing.Size(249, 22);
            this.tsBtnCCCreateAccount.Text = "Выставление счетов";
            this.tsBtnCCCreateAccount.Click += new System.EventHandler(this.tsBtnCCCreateAccount_Click);
            // 
            // tsBtnCCAccountSummary
            // 
            this.tsBtnCCAccountSummary.Name = "tsBtnCCAccountSummary";
            this.tsBtnCCAccountSummary.Size = new System.Drawing.Size(249, 22);
            this.tsBtnCCAccountSummary.Text = "Отслеживание оплат по счетам";
            this.tsBtnCCAccountSummary.Click += new System.EventHandler(this.tsBtnCCAccountSummary_Click);
            // 
            // tsBtnCCSummary
            // 
            this.tsBtnCCSummary.Name = "tsBtnCCSummary";
            this.tsBtnCCSummary.Size = new System.Drawing.Size(249, 22);
            this.tsBtnCCSummary.Text = "Отчеты";
            this.tsBtnCCSummary.Click += new System.EventHandler(this.tsBtnCCSummary_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(288, 15);
            this.toolStripLabel2.Text = "Настройки";
            // 
            // tsBtnConfigure
            // 
            this.tsBtnConfigure.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шаблоныДоговоровToolStripMenuItem,
            this.типыДоговоровToolStripMenuItem});
            this.tsBtnConfigure.Image = global::AgencyManager.Properties.Resources.Config_Tools;
            this.tsBtnConfigure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnConfigure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnConfigure.Name = "tsBtnConfigure";
            this.tsBtnConfigure.Size = new System.Drawing.Size(288, 36);
            this.tsBtnConfigure.Text = "Настройки";
            // 
            // шаблоныДоговоровToolStripMenuItem
            // 
            this.шаблоныДоговоровToolStripMenuItem.Name = "шаблоныДоговоровToolStripMenuItem";
            this.шаблоныДоговоровToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.шаблоныДоговоровToolStripMenuItem.Text = "Шаблоны договоров";
            this.шаблоныДоговоровToolStripMenuItem.Click += new System.EventHandler(this.шаблоныДоговоровToolStripMenuItem_Click);
            // 
            // типыДоговоровToolStripMenuItem
            // 
            this.типыДоговоровToolStripMenuItem.Name = "типыДоговоровToolStripMenuItem";
            this.типыДоговоровToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.типыДоговоровToolStripMenuItem.Text = "Типы договоров";
            this.типыДоговоровToolStripMenuItem.Click += new System.EventHandler(this.типыДоговоровToolStripMenuItem_Click);
            // 
            // приемДоговоровОтАгентствToolStripMenuItem
            // 
            this.приемДоговоровОтАгентствToolStripMenuItem.Name = "приемДоговоровОтАгентствToolStripMenuItem";
            this.приемДоговоровОтАгентствToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.приемДоговоровОтАгентствToolStripMenuItem.Text = "Прием договоров от агентств";
            this.приемДоговоровОтАгентствToolStripMenuItem.Click += new System.EventHandler(this.приемДоговоровОтАгентствToolStripMenuItem_Click);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 557);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Работа с агентствами";
            this.Shown += new System.EventHandler(this.frmStart_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripLabel tsLblPermission;
        private System.Windows.Forms.ToolStripButton tsBtnListNewRegistration;
        private System.Windows.Forms.ToolStripButton tsBtnListPartners;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsBtnNotActive;
        private System.Windows.Forms.ToolStripButton tsBtnTmpDogovor;
        private System.Windows.Forms.ToolStripDropDownButton tsBtnDeactive;
        private System.Windows.Forms.ToolStripMenuItem tsBtnDeactiveNextDay;
        private System.Windows.Forms.ToolStripMenuItem tsBtnDeactive7Days;
        private System.Windows.Forms.ToolStripMenuItem tsBtnDeactive14Days;
        private System.Windows.Forms.ToolStripDropDownButton tsBtnEndDogovor;
        private System.Windows.Forms.ToolStripMenuItem tsBtnEndDogovorNextDay;
        private System.Windows.Forms.ToolStripMenuItem tsBtnEndDogovor7Days;
        private System.Windows.Forms.ToolStripMenuItem tsBtnEndDogovor14Days;
        private System.Windows.Forms.ToolStripDropDownButton tsBtnConfigure;
        private System.Windows.Forms.ToolStripMenuItem шаблоныДоговоровToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tsBtnArhive;
        private System.Windows.Forms.ToolStripMenuItem АрхивацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ИнформацияОАрхивеToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsBtnCC;
        private System.Windows.Forms.ToolStripMenuItem tsBtnCCCreateAccount;
        private System.Windows.Forms.ToolStripMenuItem tsBtnCCAccountSummary;
        private System.Windows.Forms.ToolStripMenuItem tsBtnCCSummary;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem АктивацияДоговораПоФаксуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ПодписаниеДоговоровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыДоговоровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ПечатьКонвертаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem АктивацияДоговораПоОригиналуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналОборотаДоговоровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem передачаКонвертовКурьерамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приемДоговоровОтАгентствToolStripMenuItem;

    }
}