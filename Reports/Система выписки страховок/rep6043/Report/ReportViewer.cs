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

namespace rep6043.Report
{
    public partial class ReportViewer : Form
    {
        #region Свойства
        List<int> INKeys;
        sqlDataContext SqlDC;
        List<InsHeader> IHList;
        #endregion

        private void InsertToIHList(InsHeader header)
        {
            IHList.Add(header);
            IHList.Add(header);
            IHList.Add(header);
        }

        #region Конструктор
        public ReportViewer(List<int> ValuesINKey)
        {
            InitializeComponent();
            this.INKeys = ValuesINKey;
        }
        #endregion

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            SqlDC = new sqlDataContext(SqlConnection.ConnectionData);

            IHList = new List<InsHeader>();

            // Добовление связанных страховок
            foreach (int tmpINKey in INKeys)
            {
                var CurrentINSur = SqlDC.INS_INSURANCEs.Where(X => X.IN_KEY == tmpINKey).First();
                InsertToIHList(new InsHeader(CurrentINSur, SqlDC));
                if (CurrentINSur.InsurancesParent != null && INKeys.IndexOf(CurrentINSur.InsurancesParent.IN_KEY) < 0)
                    InsertToIHList(new InsHeader(CurrentINSur.InsurancesParent, SqlDC));
                if (CurrentINSur.InsurancesChield.Count() > 0)
                {
                    foreach (var chieldItem in CurrentINSur.InsurancesChield)
                    {
                        if (INKeys.IndexOf(chieldItem.IN_KEY) < 0)
                            InsertToIHList(new InsHeader(chieldItem, SqlDC));
                    }
                }
            }

            Ins_HeaderBindingSource.DataSource = IHList;
            ReportDataSource rdsInsHeader = new ReportDataSource();
            rdsInsHeader.Name = "InsHeader";
            rdsInsHeader.Value = Ins_HeaderBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(rdsInsHeader);

            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            this.reportViewer1.Print += new ReportPrintEventHandler(reportViewer1_Print);
            
            /*
             * Параметр PrintInsuredSumm необходим для отмены или вывода суммы страхования
             * , в связи с тем что в Екб. посольство чехии нуждается в данной информации
             * , по умолчанию для других выводится AS AGREED
             */
            ReportParameter rpSISumm = new ReportParameter("PrintInsuredSumm", "false");
            if (SqlConnection.ConnectionUserInformation.US_PRKEY == 13293 || SqlDC.IsRootManager)
            {
                this.reportViewer1.ShowExportButton = true;
                if (MessageBox.Show("Вывести страховую сумму?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rpSISumm = new ReportParameter("PrintInsuredSumm", "true");
                }
            }

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rpSISumm });

            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }

        void reportViewer1_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
            using (sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
            {
                foreach (int tmpIHItem in this.IHList.Select(x=>x.Id).Distinct())
                {
                    var Insur = sqlDC.INS_INSURANCEs.Where(x => x.IN_KEY == tmpIHItem).FirstOrDefault();
                    if (Insur != null)
                        Insur.IN_LastPrintDate = ltp_v2.Framework.SqlConnection.ServerDateTime;
                }
                sqlDC.SubmitChanges();
            }
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (e.DataSourceNames.Contains("INS_Conditions"))
                e.DataSources.Add(new ReportDataSource("INS_Conditions",
                    SqlDC.INS_CONDITIONs.Where(X => int.Parse(e.Parameters[0].Values[0]) == X.CO_INKEY)
                        .OrderBy(x => x.INS_RISK.RS_CODE)
                        .Select(x => new InsConditions(x))
                        .ToList()));
            else if (e.DataSourceNames.Contains("INS_Persons"))
                e.DataSources.Add(new ReportDataSource("INS_Persons", SqlDC.INS_PERSONs
                    .Where(X => int.Parse(e.Parameters[0].Values[0]) == X.IP_INKEY)
                    .OrderBy(X => X.IP_BIRTHDAY)
                    .ToList()));
            else if (e.DataSourceNames.Contains("INS_COUNTRIES_ING"))
                e.DataSources.Add(new ReportDataSource("INS_COUNTRIES_ING", 
                    SqlDC.INS_TERRITORies
                        .Where(X => int.Parse(e.Parameters[0].Values[0]) == X.IT_INKEY)
                        .Select(x => x.INS_COUNTRIES_ING)
                        .OrderBy(x => x.CI_NAME)
                        .ToList()));
        }
    }
}
