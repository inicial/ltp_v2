using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;
using ltp_v2.Framework;
using ltp_v2.Controls;

namespace AgencyManager
{
    public partial class frmStart : Form
    {
        #region Переменные
        Form _FormDialog;
        Form FormDialog
        {
            set
            {
                this.Hide();
                _FormDialog = value;
                _FormDialog.ShowDialog();
                _FormDialog.ClearFormFromMemory();
                this.Show();
            }
        }

        IQueryable<int> PRListTempDogovor;
        IQueryable<int> PRListDropNextday;
        IQueryable<int> PRListDrop7days;
        IQueryable<int> PRListDrop14days;

        IQueryable<int> PRListEndNextday;
        IQueryable<int> PRListEnd7days;
        IQueryable<int> PRListEnd14days;
        /// <summary>
        /// Список ключей партнера которые имеют не активированные договора
        /// </summary>
        IQueryable<int> PRListWithDogovorNotReg;
        PartnersListDataContext PLDC;
        #endregion

        public frmStart()
        {
            InitializeComponent();
            var CurrentPermission = Permission.Get;
            tsLblPermission.Text = "Доступ:";
            if (CurrentPermission.LTP_AC_Dog_Full)
                tsLblPermission.Text += " ПОЛНЫЙ";
            else
            {
                if (CurrentPermission.LTP_AC_Dog_Agency)
                    tsLblPermission.Text += " АГЕНТСКИЕ";
                if (CurrentPermission.LTP_AC_Dog_AviaZD)
                    tsLblPermission.Text += " АВИА ЖД";
                if (CurrentPermission.LTP_AC_Dog_Cruize)
                    tsLblPermission.Text += " КРУИЗ";
                if (CurrentPermission.LTP_AC_Dog_FIT)
                    tsLblPermission.Text += " FIT";
                if (CurrentPermission.LTP_AC_CallCenter)
                    tsLblPermission.Text += " CallCenter";
            }

            tsBtnListNewRegistration.Enabled
                = АктивацияДоговораПоФаксуToolStripMenuItem.Enabled
                = АктивацияДоговораПоОригиналуToolStripMenuItem.Enabled
                = ПечатьКонвертаToolStripMenuItem.Enabled
                = ПодписаниеДоговоровToolStripMenuItem.Enabled
                = ИнформацияОАрхивеToolStripMenuItem.Enabled
                = АрхивацияToolStripMenuItem.Enabled
                = tsBtnTmpDogovor.Enabled
                = tsBtnDeactive.Enabled
                = tsBtnEndDogovor.Enabled
                = tsBtnConfigure.Enabled
                = tsBtnNotActive.Enabled
                = tsBtnArhive.Enabled
                = CurrentPermission.LTP_AC_NewRegistration;

            передачаКонвертовКурьерамToolStripMenuItem.Enabled = (ltp_v2.Framework.ApplicationConf.CourierMySqlConnection != "" && CurrentPermission.LTP_AC_NewRegistration);

            типыДоговоровToolStripMenuItem.Enabled
                = (ltp_v2.Framework.SqlConnection.ConnectionUserName.ToLower() == "sa" ||
                ltp_v2.Framework.SqlConnection.ConnectionUserName.ToLower() == "sysadm");

            tsBtnCC.Enabled = CurrentPermission.LTP_AC_CallCenter;
        }

        private void frmStart_Shown(object sender, EventArgs e)
        {
            PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);

            // Список договоров у партнеров использующих тип партнера = 3
            var ListRootDogovorsWithPartnersUsingType3 =
                from xPD in PLDC.LTP_PrtDogs.SetPermissionFilter()
                where
                        xPD.tbl_Partners.PrtTypesToPartners.Count(xPTP => xPTP.PTP_PTId == 3) > 0 // тип партнера = 3
                        && xPD.tbl_Partners.PR_Filial == 0 // не является филиалом
                        && xPD.LTPD_PDKey.HasValue // Активированный договор
                select new { 
                    PartnerKey = xPD.LTPD_PRKey, 
                    DateEnd = (xPD.LTPD_TempActive ? xPD.LTPD_DateStart.AddDays(xPD.LTPD_TempActiveCountDayUse) : xPD.LTPD_DateEnd),
                    IsRoot = xPD.PrtDogTypes.LTP_DogType.LDT_IsRoot
                };
           
            #region Список агенств на отключение
            tsBtnDeactiveNextDay.Text = tsBtnDeactive.Text = "Агенстств, отключение завтра: " + (
                PRListDropNextday = (
                        from x in ListRootDogovorsWithPartnersUsingType3
                        where   x.DateEnd.Date == DateTime.Now.Date
                                && x.IsRoot
                        select x.PartnerKey)
                    .Distinct()
                ).Count();

            tsBtnDeactive7Days.Text = "Агенстств, отключение от завтра до 7 дней: " + (
                PRListDrop7days = (
                        from x in ListRootDogovorsWithPartnersUsingType3
                        where  x.DateEnd.Date >= DateTime.Now.AddDays(1).Date
                               && x.DateEnd.Date <= DateTime.Now.AddDays(7).Date
                               && x.IsRoot
                        select x.PartnerKey)
                    .Distinct()
                ).Count();

            tsBtnDeactive14Days.Text = "Агенстств, отключение от 7 до 14 дней: " + (
                PRListDrop14days = (
                        from x in ListRootDogovorsWithPartnersUsingType3
                        where x.DateEnd.Date >= DateTime.Now.AddDays(8).Date
                               && x.DateEnd.Date <= DateTime.Now.AddDays(14).Date
                               && x.IsRoot
                        select x.PartnerKey)
                    .Distinct()
                ).Count();
            #endregion

            #region Список агентств с завершающимся договором
            tsBtnEndDogovorNextDay.Text = tsBtnEndDogovor.Text = "Агентсв, завершается договор завтра:" + (
                PRListEndNextday = (
                        from x in ListRootDogovorsWithPartnersUsingType3
                        where x.DateEnd.Date == DateTime.Now.Date
                        select x.PartnerKey)
                    .Distinct()
                ).Count();

            tsBtnEndDogovor7Days.Text = "Агентсв, завершается от завтра до 7 дней:" + (
                PRListEnd7days = (
                        from x in ListRootDogovorsWithPartnersUsingType3
                        where x.DateEnd.Date >= DateTime.Now.AddDays(1).Date
                                && x.DateEnd.Date <= DateTime.Now.AddDays(7).Date
                        select x.PartnerKey)
                    .Distinct()
                ).Count();

            tsBtnEndDogovor14Days.Text = "Агентсв, завершается от 7 до 14 дней:" + (
                PRListEnd14days = (
                        from x in ListRootDogovorsWithPartnersUsingType3
                        where x.DateEnd.Date >= DateTime.Now.AddDays(8).Date
                                && x.DateEnd.Date <= DateTime.Now.AddDays(14).Date
                        select x.PartnerKey)
                    .Distinct()
                ).Count();
            #endregion

            tsBtnListNewRegistration.Text =
                "Новые регистрации: " + PLDC.LTP_TempPartners_By_Permission.Where(x => x.MakeDateTime == null
                ).Count()
                + " сегодня:" + PLDC.LTP_TempPartners_By_Permission.Where(x => x.InsertedDateTime.Date >= DateTime.Now.Date 
                    && x.MakeDateTime == null
                ).Count();

            tsBtnNotActive.Text = "Неактивных договоров: " + (PRListWithDogovorNotReg =
                PLDC.LTP_PrtDogs.SetPermissionFilter().Where(
                    x => x.Parent_LTPD_Key == 0 
                        || x.LTPD_PDKey == null
                ).Select(x => x.LTPD_PRKey)).Count();

            tsBtnTmpDogovor.Text = "Договоров заключенных по копии: " + (PRListTempDogovor = 
                PLDC.LTP_PrtDogs.SetPermissionFilter().Where(
                    x => x.LTPD_TempActive
                ).Select(x => x.LTPD_PRKey)).Count();
        }

        private void tsBtnListNewRegistration_Click(object sender, EventArgs e)
        {
            FormDialog = new frmNewRegistration();
        }
        
        private void tsBtnListPartners_Click(object sender, EventArgs e)
        {
            FormDialog = new frmMasterPartners();
        }

        private void tsBtnNotActive_Click(object sender, EventArgs e)
        {
            FormDialog = new frmMasterPartners(PRListWithDogovorNotReg, PLDC);
        }

        private void tsBtnDeactiveNextDay_Click(object sender, EventArgs e)
        {
            FormDialog = new frmMasterPartners(PRListDropNextday, PLDC);
        }

        private void tsBtnDeactive7Days_Click(object sender, EventArgs e)
        {
            FormDialog = new frmMasterPartners(PRListDrop7days, PLDC);
        }

        private void tsBtnDeactive14Days_Click(object sender, EventArgs e)
        {
            FormDialog = new frmMasterPartners(PRListDrop14days, PLDC);
        }

        private void tsBtnTmpDogovor_Click(object sender, EventArgs e)
        {
            FormDialog = new frmMasterPartners(PRListTempDogovor, PLDC);
        }

        private void шаблоныДоговоровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDialog = new FormsForDogovor.frmDogovorShablonManagement();
        }

        private void типыДоговоровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDialog = new FormsForDogovor.frmDogovorTypeManagement();
        }

        private void tsBtnEndDogovorNextDay_Click(object sender, EventArgs e)
        {
            FormDialog = new frmMasterPartners(PRListEndNextday, PLDC);
        }

        private void tsBtnEndDogovor7Days_Click(object sender, EventArgs e)
        {
            FormDialog = new frmMasterPartners(PRListEnd7days, PLDC);
        }

        private void tsBtnEndDogovor14Days_Click(object sender, EventArgs e)
        {
            FormDialog = new frmMasterPartners(PRListEnd14days, PLDC);
        }

        private void tsBtnShowArhiveDocument_Click(object sender, EventArgs e)
        {
            FormDialog = new Arhivarius.frmPacket();
        }

        private void tsBtnShowArhiveInfo_Click(object sender, EventArgs e)
        {
            FormDialog = new Arhivarius.frmInformation();
        }

        private void tsBtnCCCreateAccount_Click(object sender, EventArgs e)
        {
            FormDialog = new CallCenter.frmCreateCCAccount();
        }

        private void tsBtnCCAccountSummary_Click(object sender, EventArgs e)
        {
            FormDialog = new ltp_v2.AccountCreator.frmAccountControl(1);
        }

        private void tsBtnCCSummary_Click(object sender, EventArgs e)
        {
            FormDialog = new CallCenter.frmSummaryReport();
        }

        private void подписаниеДоговоровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDialog = new FormsForDogovor.frmSigningDogovors();
        }

        private void журналОборотаДоговоровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDialog = new AgencyManager.FormsForDogovor.frmJournalCirculationDogovors();
        }

        private void печатьКонвертаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDialog = new AgencyManager.FormsForDogovor.frmPrintingEnvelopes();
        }

        private void АктивацияДоговораПоФаксуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDialog = new FormsForDogovor.frmActivateDogovor(true);
        }

        private void активацияДоговораПоОригиналуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDialog = new FormsForDogovor.frmActivateDogovor(false);
        }

        private void передачаКонвертовКурьерамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDialog = new FormsForDogovor.frmSendToCourier();
        }

        private void приемДоговоровОтАгентствToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDialog = new FormsForDogovor.frmGettingDogovor();
        }
    }
}
