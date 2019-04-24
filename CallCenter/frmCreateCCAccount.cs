using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ltp_v2.Framework;

namespace CallCenter
{
    public partial class frmCreateCCAccount : Form
    {
        #region Свойства
        private CallCenterDataContext PLDC;

        private int CountCallsInCurrentMonth
        {
            get
            {
                return (
                    from xH in PLDC.LCC_Histories
                    where xH.LCH_Date.Month == CurrentMonth
                        && xH.LCH_Date.Year == CurrentYear
                        && xH.LCH_TypeSend == 2
                        && xH.LCH_PRKey == CurrentPartnerKey
                    select xH).Count();
            }
        }

        private ltp_v2.AccountCreator.ObjectModel.LTA_Account AccountInCurrentMonth
        {
            get
            {
                ltp_v2.AccountCreator.ObjectModel.AccountDataContext accountDC = new ltp_v2.AccountCreator.ObjectModel.AccountDataContext(SqlConnection.ConnectionData);
                var q = from xA in accountDC.LTA_Accounts
                        where xA.AC_PRKey == CurrentPartnerKey
                            && xA.AC_IsAnull == null
                            && xA.AC_ATID == 1
                            && xA.AC_Param1 == (CurrentMonth < 10 ? "0" + CurrentMonth.ToString() : CurrentMonth.ToString()) + "." + CurrentYear
                        select xA;
                
                if (q.Count() == 0)
                    return null;

                return q.First();
            }
        }
        private int CurrentMonth { get { return ((StringInt)cbMonth.SelectedItem).Value; } }
        private int CurrentYear { get { return (int)cbYear.SelectedItem; } }
        private int CurrentPartnerKey { get { return ((tbl_Partner)cbPartner.SelectedItem).PR_KEY; } }
        #endregion

        #region События
        public event EventHandler AfterCreateAccount;
        #endregion

        #region Классы
        public class StringInt
        {
            public String Text;
            public int Value;

            public StringInt(string text, int value)
            {
                this.Text = text;
                this.Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
        #endregion

        #region Конструктор
        public frmCreateCCAccount()
        {
            PLDC = new CallCenterDataContext(SqlConnection.ConnectionData);

            InitializeComponent();

            var qYears = from xY in PLDC.LCC_Histories
                         group xY by xY.LCH_Date.Year into xYGroup
                         orderby xYGroup.Key descending
                         select xYGroup.Key;
            cbYear.Items.Clear();
            foreach (int valYear in qYears)
                cbYear.Items.Add(valYear);

            cbYear.SelectedIndex = 0;
        }

        public frmCreateCCAccount(int prKey)
            : this()
        {
            foreach (tbl_Partner pim in cbPartner.Items)
            {
                if (pim.PR_KEY == prKey)
                {
                    cbPartner.SelectedItem = pim;
                    break;
                }
            }
        }
        #endregion

        #region Обработка событий
        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbYear.SelectedIndex < 0)
            {
                cbPartner.Enabled = false;
                return;
            }

            var qHPRKeys = from xH in PLDC.LCC_Histories
                           where
                               xH.LCH_TypeSend == 2
                               && xH.LCH_Date.Year == (int)cbYear.SelectedItem
                           group xH by xH.LCH_PRKey into xPGroup
                           orderby xPGroup.Key
                           select xPGroup.Key;

            var q = from xP in PLDC.tbl_Partners
                    from xH in qHPRKeys
                    where xP.PR_KEY == xH
                    orderby xP.PR_NAME
                    select xP;

            cbPartner.Items.Clear();
            foreach (tbl_Partner PatnerValue in q)
            {
                cbPartner.Items.Add(PatnerValue);
            }
            if (cbPartner.Items.Count > 0)
                cbPartner.SelectedIndex = 0;
        }

        private void cbPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPartner.SelectedIndex < 0)
            {
                cbMonth.Enabled = false;
                return;
            }
            var q = from xH in PLDC.LCC_Histories
                    where xH.LCH_PRKey == CurrentPartnerKey
                        && xH.LCH_Date.Year == CurrentYear
                        && xH.LCH_TypeSend == 2
                    group xH by xH.LCH_Date.Month into xHGroup
                    orderby xHGroup.Key
                    select xHGroup.Key;

            StringInt[] MonthArray = new StringInt[]{
                new StringInt("Январь", 1),
                new StringInt("Февраль", 2),
                new StringInt("Март", 3),
                new StringInt("Апрель", 4),
                new StringInt("Май", 5),
                new StringInt("Июнь", 6),
                new StringInt("Июль", 7),
                new StringInt("Август", 8),
                new StringInt("Сентябрь", 9),
                new StringInt("Октябрь", 10),
                new StringInt("Ноябрь", 11),
                new StringInt("Декабрь", 12)};
            
            cbMonth.Items.Clear();
            foreach (int montKey in q.OrderBy(x => x))
            {
                cbMonth.Items.Add(MonthArray[montKey - 1]);
            }
            cbMonth.SelectedIndex = -1;
            cbMonth.SelectedItem = MonthArray[DateTime.Now.Date.AddMonths(-2).Month - 1];
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            wbInfo.Visible = true;
            if (cbMonth.SelectedIndex < 0)
            {
                wbInfo.Visible = false;
                return;
            }

            string Result = "<head><style>body{font-size:10pt}</style></head><body>";
            Result += "<hr><b>Звонков за выбранный месяц: </b>" + CountCallsInCurrentMonth + "<hr>";

            var LCCPartnerInfo =
                from xP in PLDC.LCC_Partners
                where xP.LCP_PRKey == CurrentPartnerKey
                select xP.LCP_IsFreeService;

            if (LCCPartnerInfo.First())
                Result += "<p><font color='#0C0CF6'>На текущий момент числится на бесплатной основе</font></p>";

            Result += "<p>" + (AccountInCurrentMonth != null
                ? "<font color='#06B303'>Есть счет № </font>"
                    + AccountInCurrentMonth.AC_Number + "<font color='#06B303'> на сумму </font>"
                    + AccountInCurrentMonth.AC_TotalPrice.ToString() + " " + AccountInCurrentMonth.AC_Rate
                : "<b><font color='#B30303'>НЕТ СЧЕТА ЗА ОПЛАТУ УСЛУГ</font></b>"
            ) + "</p>";

            tsBtnAccountViewer.Enabled = !(tsBtnCreateAccount.Enabled = (AccountInCurrentMonth == null));

            wbInfo.DocumentText = Result;
        }

        #region _EnabledChanged
        private void cbPartner_EnabledChanged(object sender, EventArgs e)
        {
            cbMonth.Enabled = cbYear.Enabled;
            cbPartner.Items.Clear();
        }

        private void cbYear_EnabledChanged(object sender, EventArgs e)
        {
            
        }

        private void cbMonth_EnabledChanged(object sender, EventArgs e)
        {
            tsBtnCreateAccount.Enabled = wbInfo.Visible = cbMonth.Enabled;
            if (!cbMonth.Enabled)
                tsBtnCreateAccount.Enabled = false;
            cbMonth.Items.Clear();
        }
        #endregion

        private void tsBtnCreateAccount_Click(object sender, EventArgs e)
        {
            if (CountCallsInCurrentMonth == 0)
            {
                MessageBox.Show("У выбранного партнера нет звонков за этот перриод");
                return;
            }
            ltp_v2.AccountCreator.AccountCreator AC = new ltp_v2.AccountCreator.AccountCreator();
            AC.ClearAndSetDafault();
            AC.UseAccount.Buyer = AC.GetPartnerByKey(CurrentPartnerKey);
            AC.UseAccount.LTA_AccountType = AC.GetAccountType(1);
            AC.UseAccount.AC_Param1 = (CurrentMonth < 10 ? "0" : "") + CurrentMonth.ToString() + "." + cbYear.SelectedItem.ToString();
            foreach (ltp_v2.AccountCreator.ObjectModel.dict_AccountDefaultService adsItem in AC.GetDefaultServices(AC.UseAccount.LTA_AccountType))
            {
                ltp_v2.AccountCreator.ObjectModel.LTA_AccountService asItem = new ltp_v2.AccountCreator.ObjectModel.LTA_AccountService();
                asItem.AS_Count = CountCallsInCurrentMonth;
                asItem.AS_CountType = "шт";
                asItem.AS_Price = adsItem.ADS_Price;
                asItem.AS_Name = adsItem.ADS_Name + " " + ((StringInt)cbMonth.SelectedItem).Text;
                AC.UseAccount.LTA_AccountServices.Add(asItem);
            }
            AC.OnCreate += new EventHandler(AC_OnCreate);
            AC.ViewAccount(AC.UseAccount.Buyer.PR_EMAIL,
                global::ltp_v2.Framework.ApplicationConf.CompanyName + " Счет: " + AC.UseAccount.LTA_AccountType.AT_Name,
                global::ltp_v2.Framework.ApplicationConf.Logo + "<br> Счет находится в прикрепленном файле");
        }

        void AC_OnCreate(object sender, EventArgs e)
        {
            cbMonth_SelectedIndexChanged(null, null);
            if (AfterCreateAccount != null)
                AfterCreateAccount(this, null);
        }

        private void tsBtnAccountViewer_Click(object sender, EventArgs e)
        {
            ltp_v2.AccountCreator.AccountCreator AC = new ltp_v2.AccountCreator.AccountCreator(SqlConnection.ConnectionUserName, SqlConnection.ConnectionPassword);
            AC.ViewAccount(AccountInCurrentMonth.AC_ID);
        }
        #endregion
    }
}
