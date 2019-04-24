using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Data.Linq;
using System.Windows.Forms;
using ltp_v2.Framework;
using Microsoft.Reporting.WinForms;

namespace rep763
{
    public partial class frmMain : Form
    {
        #region Свойства
        private lSqlDataContext lSqlFilter;
        private lSqlDataContext lSqlReport;
        private int SelectedCNKey
        {
            get
            {
                if (cbCountryList.SelectedIndex < 0)
                    return -1;
                else 
                    return ((COUNTRY)cbCountryList.SelectedItem).CN_KEY;
            }
        }

        private int SelectedPRKey
        {
            get
            {
                if (cbCountryList.SelectedIndex < 0)
                    return -1;
                else
                    return ((tbl_Partner)cbPartnerList.SelectedItem).PR_KEY;
            }
        }
        #endregion

        #region Конструктор
        public frmMain(string dgCode)
        {
            InitializeComponent();
            lbUsedDGCode.Items.Clear();
            if (!String.IsNullOrEmpty(dgCode))
            {
                string[] dgCodes = dgCode.Split(',');
                lbUsedDGCode.Items.AddRange(dgCodes);
            }
        }
        #endregion

        #region Методы
        private void ReloadDogovorsList()
        {
            if (cbPartnerList.SelectedValue != null && cbCountryList.SelectedValue != null)
            {
                var dogovors = ((tbl_Partner)cbPartnerList.SelectedItem).tbl_Dogovors
                    .Where(x =>
                        x.DG_TURDATE.Date >= dtBegin.Value.Date
                        && x.DG_TURDATE.Date <= dtEnd.Value.Date
                        && x.DG_CNKEY == ((COUNTRY)cbCountryList.SelectedValue).CN_KEY)
                    .OrderBy(x => x.DG_TURDATE)
                    .ThenBy(x => x.DG_CODE)
                    .ToList();
                BindingSource bs_tbl_Dogovor = new BindingSource();
                bs_tbl_Dogovor.DataSource = dogovors;
                ReportDataSource rds_tbl_Dogovor = new ReportDataSource();
                rds_tbl_Dogovor.Name = "tbl_Dogovor";
                rds_tbl_Dogovor.Value = bs_tbl_Dogovor;

                this.repViewer.Reset();
                this.repViewer.LocalReport.DataSources.Add(rds_tbl_Dogovor);
                this.repViewer.LocalReport.ReportEmbeddedResource = "rep763.Report.rptDogovorsList.rdlc";
                this.repViewer.RefreshReport();
                this.repViewer.SetDisplayMode(DisplayMode.Normal);
                this.repViewer.ZoomMode = ZoomMode.Percent;
                this.repViewer.ZoomPercent = 75;
                this.repViewer.RefreshReport();
            }
        }

        private void ReloadPartnerList()
        {
            if (cbCountryList.SelectedValue != null)
            {
                var partners = lSqlFilter.tbl_Dogovors
                    .Where(x =>
                        x.DG_TURDATE.Date >= dtBegin.Value.Date
                        && x.DG_TURDATE.Date <= dtEnd.Value.Date
                        && x.DG_CNKEY == SelectedCNKey)
                    .Select(x => x.tbl_Partner)
                    .OrderBy(x => x.PR_NAME)
                    .Distinct()
                    .ToList();
                if (partners.Count() > 0)
                {
                    cbPartnerList.DataSource = partners;
                    cbPartnerList.DisplayMember = "PR_FullName";
                    cbPartnerList.Enabled = true;
                }
                else
                {
                    cbPartnerList.DataSource = null;
                    cbPartnerList.Enabled = false;
                }
            }
        }
        #endregion

        #region Обработка событий
        private void frmMain_Load(object sender, EventArgs e)
        {
            ltp_v2.Framework.ReferencesModelDataContext RMDC = new ltp_v2.Framework.ReferencesModelDataContext(SqlConnection.Connection);
            lSqlFilter = new lSqlDataContext(SqlConnection.Connection);

            cbCountryList.DataSource = RMDC.COUNTRies.OrderBy(x => x.CN_NAME).ToList();
            cbCountryList.DisplayMember = "CN_Name";

            dtBegin.Value = DateTime.Now.Date;
            dtEnd.Value = DateTime.Now.Date;

            cbPartnerList.Enabled = false;

            this.repViewer.RefreshReport();
        }

        private void dtBegin_ValueChanged(object sender, EventArgs e)
        {
            if (dtBegin.Value > dtEnd.Value)
                dtBegin.Value = dtEnd.Value;
            ReloadPartnerList();
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtBegin.Value > dtEnd.Value)
                dtEnd.Value = dtBegin.Value;
            ReloadPartnerList();
        }

        private void cbCountryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadPartnerList();
        }

        private void cbPartnerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadDogovorsList();
        }

        private void tsBtnPrint_Click(object sender, EventArgs e)
        {
            if (lbUsedDGCode.Items.Count == 0)
                return;

            List<string> filter = new List<string>();
            foreach(string item in lbUsedDGCode.Items)
                filter.Add(item);

            if (lSqlReport != null)
                lSqlReport.Dispose();

            lSqlReport = new lSqlDataContext(SqlConnection.ConnectionData);
            var dogovors = lSqlReport.tbl_Dogovors
                    .Where(x =>
                        filter.Contains(x.DG_CODE))
                    .OrderBy(x => x.DG_TURDATE)
                    .ThenBy(x => x.DG_CODE)
                    .Select(x => new rptHelperDogovor(x))
                    .ToList();

            BindingSource bs_rptHelperDogovor = new BindingSource();
            bs_rptHelperDogovor.DataSource = dogovors;
            ReportDataSource rds_rptHelperDogovor = new ReportDataSource();
            rds_rptHelperDogovor.Name = "rptHelperDogovor";
            rds_rptHelperDogovor.Value = bs_rptHelperDogovor;

            this.repViewer.Reset();
            this.repViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            this.repViewer.LocalReport.DataSources.Add(rds_rptHelperDogovor);
            this.repViewer.LocalReport.ReportEmbeddedResource = "rep763.Report.rptExitData.rdlc";
            this.repViewer.RefreshReport();
            this.repViewer.SetDisplayMode(DisplayMode.Normal);
            this.repViewer.ZoomMode = ZoomMode.Percent;
            this.repViewer.ZoomPercent = 75;
            this.repViewer.RefreshReport();
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (e.DataSourceNames.Contains("rep763_tbl_Turist"))
            {
                e.DataSources.Add(new ReportDataSource("rep763_tbl_Turist", 
                    lSqlReport.tbl_Turists
                        .Where(x => x.TU_DGCOD == e.Parameters[0].Values[0])
                        .Distinct()
                        .ToList()));
            }
            if (e.DataSourceNames.Contains("rep763_rptHelperTransaction"))
            {
                var q1 = from xFT in lSqlReport.FIN_TRANSACTIONs
                         where
                                xFT.TR_FAPKEY == 0
                                && xFT.TR_TURSUM.GetValueOrDefault(0) != 0
                                && new int[] { 87, 88, 89, 90, 1000 }.Contains(xFT.TR_CREDIT)
                                && xFT.TR_CR_DGCODE == e.Parameters[0].Values[0]
                         select new rptHelperTransaction()
                         {
                             DGCode = xFT.TR_CR_DGCODE,
                             Summ_Transaction = xFT.TR_SUM,
                             Summ_DogovorRate = xFT.TR_TURSUM.Value,
                             Summ_National = xFT.TR_SUM_NATIONAL,
                             Date_Course = xFT.TR_DATE_PROCESS,
                             Date_Transaction = xFT.TR_DATE,
                             Rate_Transaction = (xFT.TR_RACODE.ToUpper() == "EU" && xFT.tbl_Dogovor.DG_RATE == "$" ? "EE" : xFT.TR_RACODE),
                             Rate_Dogovor = xFT.TR_TURRATE,
                             WhoPayments = xFT.tbl_Partner.PR_FULLNAME,
                             PaymentsType = lSqlReport.LANTA_FIN_GET_PAYMENTTYPE_BY_DOGOVOR(xFT.TR_CR_DGCODE, xFT.TR_KEY)
                         };
                var q2 = from xFT in lSqlReport.FIN_TRANSACTIONs
                         where
                                xFT.TR_FAPKEY == 0
                                && xFT.TR_TURSUM.GetValueOrDefault(0) != 0
                                && new int[] { 87, 88, 89, 90, 1000 }.Contains(xFT.TR_DEBT)
                                && xFT.TR_DT_DGCODE == e.Parameters[0].Values[0]
                         select new rptHelperTransaction()
                         {
                             DGCode = xFT.TR_CR_DGCODE,
                             Summ_Transaction = -xFT.TR_SUM,
                             Summ_DogovorRate = -xFT.TR_TURSUM.Value,
                             Summ_National = -xFT.TR_SUM_NATIONAL,
                             Date_Course = xFT.TR_DATE_PROCESS,
                             Date_Transaction = xFT.TR_DATE,
                             Rate_Transaction = (xFT.TR_RACODE.ToUpper() == "EU" && xFT.tbl_Dogovor.DG_RATE == "$" ? "EE" : xFT.TR_RACODE),
                             Rate_Dogovor = xFT.TR_TURRATE,
                             WhoPayments = xFT.tbl_Partner.PR_FULLNAME,
                             PaymentsType = lSqlReport.LANTA_FIN_GET_PAYMENTTYPE_BY_DOGOVOR(xFT.TR_CR_DGCODE, xFT.TR_KEY)
                         };

                var q3 = from xPD in lSqlReport.PaymentDetails
                         where xPD.tbl_Dogovor.DG_CODE == e.Parameters[0].Values[0]
                         select new rptHelperTransaction()
                         {
                             DGCode = xPD.tbl_Dogovor.DG_CODE,
                             Summ_Transaction = (double)xPD.PD_Sum,
                             Summ_DogovorRate = (double)xPD.PD_SumInDogovorRate.GetValueOrDefault(0),
                             Summ_National = (double)xPD.PD_SumNational,
                             Date_Course = xPD.PD_Date,
                             Date_Transaction = xPD.Payment.PM_Date,
                             Rate_Transaction = xPD.Payment.Rate.RA_CODE,
                             Rate_Dogovor = xPD.tbl_Dogovor.DG_RATE,
                             WhoPayments = xPD.Payment.PM_RepresentName,
                             PaymentsType = xPD.Payment.PaymentOperation.tbl_PaymentType.PT_CODE
                         };

                var qEXT = q1.Concat(q2).Concat(q3).OrderBy(x => x.Date_Transaction);
                e.DataSources.Add(new ReportDataSource("rep763_rptHelperTransaction", qEXT.ToList()));
                
            }
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            List<object> selItems = new List<object>();
            foreach (var selItem in lbUsedDGCode.SelectedItems)
            {
                selItems.Add(selItem);
            }
            foreach (var selItem in selItems)
            {
                lbUsedDGCode.Items.Remove(selItem);
            }
            selItems.Clear();
            selItems = null;
        }

        private void edtManualDGCodeEnter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && edtManualDGCodeEnter.Text.Trim() != "")
            {
                lbUsedDGCode.Items.Add(edtManualDGCodeEnter.Text);
                edtManualDGCodeEnter.Text = "";
            }
        }

        private void repViewer_BookmarkNavigation(object sender, BookmarkNavigationEventArgs e)
        {
            lbUsedDGCode.Items.Add(e.BookmarkId);
        }
        #endregion
    }
}
