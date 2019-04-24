using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ltp_v2.Framework;
using Microsoft.Reporting.WinForms;

namespace CallCenter
{
    public partial class frmSummaryReport : Form
    {
        enum eReportTypes
        {
            Суммарный_отчет = 0,
            Суммарный_отчет_по_странам = 1,
            Подробный_отчет_по_агентству = 2,
            Детальный_отчет = 3,
            Суммарный_отчет_для_бухгалтерии = 4,
        }

        #region Свойства
        ReportParameter PerriodStart
        {
            get { return new ReportParameter("PerriodStart", edtDTBeg.Value.Date.ToString("dd.MM.yyyy")); }
        }
        ReportParameter PerriodEnd
        {
            get { return new ReportParameter("PerriodEnd", edtDTEnd.Value.Date.ToString("dd.MM.yyyy")); }
        }

        IQueryable<Report.SummaryReport> LCCHistoryFiltered(DateTime fltDateBeg, DateTime fltDateEnd)
        {
            return from lcH in pldc.LCC_Histories
                   from dictC in pldc.tbl_Countries
                   where lcH.LCH_Date.Date >= fltDateBeg.Date
                         && lcH.LCH_Date.Date <= fltDateEnd.Date
                         && lcH.LCH_LCPTID == -1
                         && dictC.CN_KEY == lcH.LCH_CNKey
                   select new Report.SummaryReport
                   {
                       PartnerKey = lcH.LCH_PRKey,
                       CountryKey = lcH.LCH_CNKey,
                       cntNotCall = (lcH.LCH_TypeSend == 1 ? 1 : 0),
                       cntAnswer = (lcH.LCH_TypeSend == 2 ? 1 : 0),
                       cntNotAnswer = (lcH.LCH_TypeSend == 3 ? 1 : 0)
                   } into list
                   group list by new { list.PartnerKey, list.CountryKey } into g

                   from Partner in pldc.tbl_Partners
                   from CCPartner in pldc.LCC_Partners
                   from CCMetro in pldc.LCC_MetroStations
                   where g.Key.PartnerKey == Partner.PR_KEY
                          && CCPartner.LCP_PRKey == Partner.PR_KEY
                          && CCMetro.MS_ID == CCPartner.LCP_MSID
                   select new Report.SummaryReport
                   {
                       PartnerKey = g.Key.PartnerKey,
                       CountryKey = g.Key.CountryKey,
                       CountryName = pldc.tbl_Countries.First(xCN => xCN.CN_KEY == g.Key.CountryKey).CN_NAME,
                       cntNotCall = g.Sum(x => x.cntNotCall),
                       cntAnswer = g.Sum(x => x.cntAnswer),
                       cntNotAnswer = g.Sum(x => x.cntNotAnswer),
                       PartnerCode = Partner.PR_COD,
                       PartnerName = Partner.PR_NAME,
                       PartnerFullName = Partner.PR_FULLNAME,
                       MetroStationName = CCMetro.MS_StationName,
                       ConnectionDate = CCPartner.LCP_CRDate,
                       BronByCountry = pldc.tbl_Dogovors.Where(x =>
                           x.DG_CNKEY == g.Key.CountryKey
                           && x.DG_TURDATE >= new DateTime(1995, 1, 1)
                           && x.DG_CRDATE.Date >= fltDateBeg.Date
                           && x.DG_CRDATE.Date <= fltDateEnd.Date
                           && (
                                Partner.PR_Filial == 0 && x.DG_PARTNERKEY == g.Key.PartnerKey
                                || Partner.PR_Filial != 0 && x.DG_PARTNERKEY == 0 && pldc.UserLists.Where(xUL => xUL.US_KEY == x.DG_CREATOR && xUL.US_PRKEY == g.Key.PartnerKey).Count() > 0)
                           ).Count()
                   };
        }

        CallCenterDataContext pldc = new CallCenterDataContext(SqlConnection.ConnectionData);
        #endregion

        #region Методы
        /// <summary>
        /// Суммарный отчет
        /// </summary>
        private void ViewSummaryReport()
        {
            var qHist = from lcH in LCCHistoryFiltered(edtDTBeg.Value, edtDTEnd.Value)
                        group lcH by new { lcH.PartnerKey, lcH.PartnerCode, lcH.PartnerName, lcH.MetroStationName, lcH.ConnectionDate } into g
                        select new Report.SummaryReport
                        {
                            PartnerCode = g.Key.PartnerCode,
                            PartnerName = g.Key.PartnerName,
                            MetroStationName = g.Key.MetroStationName,
                            ConnectionDate = g.Key.ConnectionDate,
                            cntNotAnswer = g.Sum(x => x.cntNotAnswer),
                            cntAnswer = g.Sum(x=>x.cntAnswer),
                            cntNotCall = g.Sum(x=>x.cntNotCall),
                            BronCount = g.Sum(x=>x.BronByCountry)
                        };

            BindingSource bsSummaryReport = new BindingSource();
            bsSummaryReport.DataSource = qHist.Distinct().OrderBy(x => x.PartnerName).ThenBy(x => x.PartnerCode);
            ReportDataSource rdsSummaryReport = new ReportDataSource();
            rdsSummaryReport.Name = "SummaryReport";
            rdsSummaryReport.Value = bsSummaryReport;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CallCenter.Report.SummaryReport.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(rdsSummaryReport);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { PerriodStart, PerriodEnd });
        }

        private void ViewSummaryReportBuh()
        {
            DateTime newFilter = new DateTime(edtDTBeg.Value.Year, edtDTBeg.Value.Month, 1);

            var qHist = from lcH in LCCHistoryFiltered(newFilter, newFilter.AddMonths(1).AddDays(-1))
                        group lcH by new { lcH.PartnerKey, lcH.PartnerCode, lcH.PartnerFullName, lcH.MetroStationName, lcH.ConnectionDate } into g
                        select new Report.SummaryReport
                        {
                            PartnerCode = g.Key.PartnerCode,
                            PartnerFullName = g.Key.PartnerFullName,
                            MetroStationName = g.Key.MetroStationName,
                            cntAnswer = g.Sum(x => x.cntAnswer),
                            AccountNumber = (pldc.LTA_Accounts
                                .Where(x =>
                                    x.AC_PRKey == g.Key.PartnerKey
                                    && x.AC_Param1 == edtDTBeg.Value.ToString("MM.yyyy")
                                    && !x.AC_IsAnull.HasValue).Count() > 0 ? pldc.LTA_Accounts
                                .Where(x =>
                                    x.AC_PRKey == g.Key.PartnerKey
                                    && x.AC_Param1 == edtDTBeg.Value.ToString("MM.yyyy")
                                    && !x.AC_IsAnull.HasValue).Select(x => x.AC_Number).First()
                                    : "")
                        };

            BindingSource bsSummaryReport = new BindingSource();
            bsSummaryReport.DataSource = qHist.Distinct().OrderBy(x => x.PartnerFullName).ThenBy(x => x.PartnerCode);
            ReportDataSource rdsSummaryReport = new ReportDataSource();
            rdsSummaryReport.Name = "SummaryReport";
            rdsSummaryReport.Value = bsSummaryReport;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CallCenter.Report.SummaryReportForBuh.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(rdsSummaryReport);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { PerriodStart, PerriodEnd });
        }
        /// <summary>
        /// Суммарный отчет по странам
        /// </summary>
        private void ViewSummaryReportByCountry()
        {
            var qHist = from lcH in LCCHistoryFiltered(edtDTBeg.Value, edtDTEnd.Value)
                        select new Report.SummaryReport
                        {
                            PartnerCode = lcH.PartnerCode,
                            PartnerName = lcH.PartnerName,
                            MetroStationName = lcH.MetroStationName,
                            ConnectionDate = lcH.ConnectionDate,
                            cntNotAnswer = lcH.cntNotAnswer,
                            cntAnswer = lcH.cntAnswer,
                            cntNotCall = lcH.cntNotCall,
                            CountryName = lcH.CountryName,
                            BronCount = lcH.BronByCountry
                        };

            BindingSource bsSummaryReport = new BindingSource();
            bsSummaryReport.DataSource = qHist.Distinct().OrderBy(x => x.PartnerName).ThenBy(x => x.PartnerCode).ThenBy(x => x.CountryName);
            ReportDataSource rdsSummaryReport = new ReportDataSource();
            rdsSummaryReport.Name = "SummaryReport";
            rdsSummaryReport.Value = bsSummaryReport;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CallCenter.Report.SummaryReportFilterCountry.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(rdsSummaryReport);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { PerriodStart, PerriodEnd });
        }

        /// <summary>
        /// Подробный отчет по агентству
        /// </summary>
        private void ViewSummaryReportByPartner()
        {
            int SelectedPartnerKey = (int)edtAgency.SelectedValue;
            var ccHeader = from ccH in LCCHistoryFiltered(edtDTBeg.Value, edtDTEnd.Value)
                           where ccH.PartnerKey == SelectedPartnerKey
                           group ccH by new { ccH.PartnerKey, ccH.PartnerCode, ccH.PartnerName, ccH.MetroStationName, ccH.ConnectionDate } into g
                           select new Report.SummaryReport
                           {
                               PartnerCode = g.Key.PartnerCode,
                               PartnerName = g.Key.PartnerName,
                               MetroStationName = g.Key.MetroStationName,
                               ConnectionDate = g.Key.ConnectionDate,
                               cntNotAnswer = g.Sum(x => x.cntNotAnswer),
                               cntAnswer = g.Sum(x => x.cntAnswer),
                               cntNotCall = g.Sum(x => x.cntNotCall),
                               BronByCountry = g.Sum(x=>x.BronByCountry),
                               BronCount = g.Sum(x=>x.BronByCountry)
                           };
            var ccList = from ccH in pldc.LCC_Histories
                         from dictC in pldc.tbl_Countries
                         where dictC.CN_KEY == ccH.LCH_CNKey
                               && ccH.LCH_PRKey == SelectedPartnerKey
                               && ccH.LCH_Date.Date >= edtDTBeg.Value.Date
                               && ccH.LCH_Date.Date <= edtDTEnd.Value.Date
                         select new Report.HistoryDetail
                         {
                             CallTypeSend = ccH.LCC_TypesSend.LCT_Name,
                             CountryName = dictC.CN_NAME,
                             HistoryDate = ccH.LCH_Date,
                             ManagerName = ccH.LCH_ManagerName,
                             PhoneNumber = ccH.LCH_Phone
                         };

            BindingSource bsHeader = new BindingSource();
            bsHeader.DataSource = ccHeader.Distinct();
            ReportDataSource rdsHeader = new ReportDataSource();
            rdsHeader.Name = "Header";
            rdsHeader.Value = bsHeader;

            BindingSource bsSummaryReport = new BindingSource();
            bsSummaryReport.DataSource = ccList.Distinct().OrderBy(x => x.HistoryDate);
            ReportDataSource rdsSummaryReport = new ReportDataSource();
            rdsSummaryReport.Name = "SummaryReport";
            rdsSummaryReport.Value = bsSummaryReport;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CallCenter.Report.ViewSummaryReportByPartner.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(rdsHeader);
            this.reportViewer1.LocalReport.DataSources.Add(rdsSummaryReport);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { PerriodStart, PerriodEnd });
        }

        private void ViewDetailReport()
        {
            var ccList = from ccH in pldc.LCC_Histories
                         from dictC in pldc.tbl_Countries
                         from ccP in pldc.LCC_Partners
                         from prt in pldc.tbl_Partners
                         from dictM in pldc.LCC_MetroStations
                         from adc in pldc.Advertises
                         where prt.PR_KEY == ccH.LCH_PRKey
                               && ccP.LCP_PRKey == ccH.LCH_PRKey
                               && dictM.MS_ID == ccP.LCP_MSID
                               && dictC.CN_KEY == ccH.LCH_CNKey
                               && adc.AD_KEY == ccH.LCH_ADKey
                               && ccH.LCH_Date.Date >= edtDTBeg.Value.Date
                               && ccH.LCH_Date.Date <= edtDTEnd.Value.Date
                         select new Report.HistoryDetail
                         {
                             CallTypeSend = ccH.LCC_TypesSend.LCT_Name,
                             CountryName = dictC.CN_NAME,
                             HistoryDate = ccH.LCH_Date,
                             ManagerName = ccH.LCH_ManagerName,
                             PhoneNumber = ccH.LCH_Phone,
                             AgencyName = prt.PR_NAME,
                             MetroStationName = dictM.MS_StationName, 
                             ReclameSource = adc.AD_NAME,
                             NotCall = (ccH.LCH_TypeSend == 1 ? 1 : 0),
                             Answer = (ccH.LCH_TypeSend == 2 ? 1 : 0),
                             NotAnswer = (ccH.LCH_TypeSend == 3 ? 1 : 0)
                         };

            BindingSource bsSummaryReport = new BindingSource();
            bsSummaryReport.DataSource = ccList.Distinct().OrderBy(x => x.AgencyName).ThenBy(x => x.HistoryDate);
            ReportDataSource rdsSummaryReport = new ReportDataSource();
            rdsSummaryReport.Name = "SummaryReport";
            rdsSummaryReport.Value = bsSummaryReport;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CallCenter.Report.ViewDetailReport.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(rdsSummaryReport);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { PerriodStart, PerriodEnd });
        }

        private void UpdateAgencyList()
        {
            var q = from prt in pldc.tbl_Partners
                    from ccH in LCCHistoryFiltered(edtDTBeg.Value, edtDTEnd.Value)
                    where ccH.PartnerKey == prt.PR_KEY
                    select new { PartnerKey = prt.PR_KEY, PartnerName = prt.PR_NAME };
            edtAgency.DataSource = q.Distinct().OrderBy(x => x.PartnerName);
            edtAgency.ValueMember = "PartnerKey";
            edtAgency.DisplayMember = "PartnerName";
            if (edtAgency.Items.Count > 0)
                edtAgency.SelectedIndex = 0;
        }
        #endregion

        #region Конструктор
        public frmSummaryReport()
        {
            InitializeComponent();
            edtReportType.Items.Clear();
            foreach (var item in (eReportTypes[])Enum.GetValues(typeof(eReportTypes)))
            {
                edtReportType.Items.Add(item);
            }
            edtReportType.SelectedItem = eReportTypes.Суммарный_отчет;

            edtDTBeg.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            edtDTEnd.Value = DateTime.Now;
        }
        #endregion

        #region Обработка событий
        private void fltDTBeg_ValueChanged(object sender, EventArgs e)
        {
            if (edtDTBeg.Value > edtDTEnd.Value)
                edtDTEnd.Value = edtDTBeg.Value;
            UpdateAgencyList();
        }

        private void fltDTEnd_ValueChanged(object sender, EventArgs e)
        {
            if (edtDTBeg.Value > edtDTEnd.Value)
                edtDTBeg.Value = edtDTEnd.Value;
            UpdateAgencyList();
        }

        private void frmSummaryReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.reportViewer1.Reset();

            switch ((eReportTypes)edtReportType.SelectedItem)
            {
                case eReportTypes.Суммарный_отчет:
                    ViewSummaryReport();
                    break;
                case eReportTypes.Суммарный_отчет_по_странам:
                    ViewSummaryReportByCountry();
                    break;
                case eReportTypes.Подробный_отчет_по_агентству:
                    ViewSummaryReportByPartner();
                    break;
                case eReportTypes.Детальный_отчет:
                    ViewDetailReport();
                    break;
                case eReportTypes.Суммарный_отчет_для_бухгалтерии:
                    ViewSummaryReportBuh();
                    break;
            }                       

            this.reportViewer1.SetDisplayMode(DisplayMode.Normal);
            this.reportViewer1.ZoomMode = ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 75;
            this.reportViewer1.RefreshReport();
        }

        private void edtReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            edtAgency.Enabled = (eReportTypes)edtReportType.SelectedItem == eReportTypes.Подробный_отчет_по_агентству;
            edtDTEnd.Enabled = (eReportTypes)edtReportType.SelectedItem != eReportTypes.Суммарный_отчет_для_бухгалтерии;
            UpdateAgencyList();
        }
        #endregion
    }
}
