using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ltp_v2.AccountCreator
{
    public partial class frmAccountControl : Form
    {
        #region Свпомогательные классы и методы
        private class MonthYearFilterItem
        {
            public int Month;
            public int Year;
            public override string ToString()
            {
                return (Month < 10 ? "0" : "") + Month.ToString() + "." + Year.ToString();
            }
        }
        #endregion
        #region Свойства
        ObjectModel.AccountDataContext Adc;
        #endregion

        #region Методы
        private void BindingDataFilter(int accountTypeId)
        {
            var q = Adc.LTA_AccountTypes.OrderBy(x => x.AT_Name).Where(x=>x.AT_Name != "");
            if (accountTypeId > 0)
            {
                q = q.Where(x => x.AT_ID == accountTypeId);
            }
            fltAccountType.Items.AddRange(q.ToArray());
            if (q.Count() > 0)
                fltAccountType.SelectedIndex = 0;

            var itemsMY = Adc.LTA_Accounts
                .Select(x => new MonthYearFilterItem() { Month = x.AC_CRDate.Month, Year = x.AC_CRDate.Year })
                .Distinct()
                .OrderByDescending(x => x.Year)
                .ThenByDescending(x => x.Month);

            fltYear.Sorted = false;
            fltYear.Items.AddRange(itemsMY.ToArray());
            fltYear.SelectedIndex = 0;

            fltCacheType.Items.AddRange(new object[] { "Все", "Оплаченные", "Не оплаченные" });
            fltCacheType.SelectedIndex = 0;
        }

        public frmAccountControl() : this(0)
        {
        }

        public frmAccountControl(int accountTypeId)
        {
            Adc = new ObjectModel.AccountDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            InitializeComponent();
            BindingDataFilter(accountTypeId);
        }
        #endregion

        #region Обработка событий
        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            var filterMonthDate = ((MonthYearFilterItem)fltYear.SelectedItem);

            var q = Adc.LTA_Accounts
                .Where(x => !x.AC_IsAnull.HasValue)
                .AsEnumerable()
                .Select(x => new ObjectModel.SummaryReport(x))
                .Where(x => x.AccType == ((ObjectModel.LTA_AccountType)fltAccountType.SelectedItem).AT_ID
                        && x.AccCreateDate.Month == filterMonthDate.Month
                        && x.AccCreateDate.Year == filterMonthDate.Year
                        && (fltCacheType.SelectedIndex == 0
                            || fltCacheType.SelectedIndex == 1 && x.Summ - x.Payed <= 0
                            || fltCacheType.SelectedIndex == 2 && x.Summ - x.Payed > 0))
                .OrderBy(x => x.PartnerName)
                .ToList();

            BindingSource bsAccount = new BindingSource();
            bsAccount.DataSource = q;
            ReportDataSource rdsAccount = new ReportDataSource();
            rdsAccount.Name = "SummaryReport";
            rdsAccount.Value = bsAccount;

            this.reportViewer.Reset();
            this.reportViewer.LocalReport.DataSources.Add(rdsAccount);

            this.reportViewer.LocalReport.ReportEmbeddedResource = "ltp_v2.AccountCreator.AccountControlRep.rdlc";
            this.reportViewer.RefreshReport();
            this.reportViewer.SetDisplayMode(DisplayMode.Normal);
            this.reportViewer.ZoomMode = ZoomMode.Percent;
            this.reportViewer.ZoomPercent = 75;
            this.reportViewer.RefreshReport();
        }
        #endregion

        private void reportViewer_BookmarkNavigation(object sender, BookmarkNavigationEventArgs e)
        {
            if (e.BookmarkId.Trim() != "")
            {
                var q = Adc.LTA_Accounts.Where(x => x.AC_Number == e.BookmarkId);
                if (q.Count() > 0)
                {
                    var partnerValue = q.First().Buyer;
                    new AccountCreator().ViewAccount(q.First().AC_ID, 
                        partnerValue.PR_EMAIL, 
                        global::ltp_v2.Framework.ApplicationConf.CompanyName + " Счет: " + q.First().LTA_AccountType.AT_Name,
                        "<br> Счет находится в прикрепленном файле");
                }
            }
        }
    }
}
