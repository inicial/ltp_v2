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
using System.Data.Linq;

namespace rep259916
{
    public partial class frmMain : Form
    {
        ObjectModel.ReportingDataContext RDC = new ObjectModel.ReportingDataContext(SqlConnection.ConnectionData);

        public frmMain()
        {
            InitializeComponent();
        }

        private class ccItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tsEdtCountryName.Items.Clear();
            tsEdtCountryName.Items.Add(new ccItem { ID = -1, Name = "Все страны" });
            tsEdtCountryName.Items.AddRange(
                RDC.COUNTRies
                    .Where(x => x.CN_NAME != "" && x.CN_NAME != null)
                    .OrderBy(x => x.CN_NAME)
                    .Select(x => new ccItem { ID = x.CN_KEY, Name = x.CN_NAME }).ToArray()
            );
            tsEdtCountryName.SelectedIndex = 0;
        }

        private IQueryable<Report.ReportStruct> LoadList(bool IsCruise)
        {
            return LoadList(IsCruise, false);
        }
        private IQueryable<Report.ReportStruct> LoadList(bool IsCruise, bool ShowNotNormalPercent)
        {
            int ShiftCountDaysForOut = 50;
            decimal UECoef = 3;
            decimal RURCoef = 1;
           
            var FilteredListDG = from dg in RDC.tbl_Dogovors
                                 from dl in RDC.tbl_DogovorLists
                                 where dg.DG_TURDATE.Date > DateTime.Now.Date
                                     && dl.DL_DGCOD == dg.DG_CODE
                                 select new { dg, dl };

            if (IsCruise)
            {
                FilteredListDG =
                    from xFLD in FilteredListDG.Where(x => x.dl.DL_SVKEY == 3143 || x.dl.DL_SVKEY == 7 || x.dl.DL_SVKEY == 3)
                    from xHD in RDC.HotelDictionaries
                    where xFLD.dl.DL_SVKEY != 3
                            || xFLD.dl.DL_SVKEY == 3 && xHD.HD_KEY == xFLD.dl.DL_CODE && xHD.HD_IsCruise == 1
                    select xFLD;

                FilteredListDG = FilteredListDG.Distinct();
            }
            if (ShowNotNormalPercent)
            {
                FilteredListDG = FilteredListDG.Where(x => x.dg.DG_PROCENT.GetValueOrDefault(0) == 1 && x.dg.DG_RazmerP.GetValueOrDefault(0) > 100); 
            }

            var q1 = from dg in RDC.tbl_Dogovors
                     from filteredDG in FilteredListDG.Select(x=>x.dg.DG_CODE).Distinct()
                     where dg.DG_CODE == filteredDG
                     select new
                     {
                         dg.DG_CODE,
                         dg.DG_PPAYMENTDATE,
                         dg.DG_PAYMENTDATE,
                         dg.DG_PRICE,
                         dg.DG_PAYED,
                         dg.DG_RATE,
                         DGCode = dg.DG_CODE,
                         RazmerPProcent = (dg.DG_PROCENT.Value == 0
                            ? (dg.DG_RazmerP.GetValueOrDefault(0) / (dg.DG_PRICE == 0 ? 1 : dg.DG_PRICE))
                            : (dg.DG_RazmerP.GetValueOrDefault(0) / 100))
                     } into dg
                     where
                         dg.DG_PRICE != 0
                     select new { DGCode = dg.DG_CODE,
                                  PP = (
                                    // Фильтрация по предоплате
                                    dg.DG_PPAYMENTDATE != null
                                    && dg.DG_PPAYMENTDATE.Value.Date <= DateTime.Now.Date.AddDays(ShiftCountDaysForOut)
                                    && dg.DG_PRICE * dg.RazmerPProcent - dg.DG_PAYED > (dg.DG_RATE.ToUpper() != "РБ" ? UECoef : RURCoef)
                                    ? 1 
                                    :
                                        // Фильтрация по полной оплате
                                        dg.DG_PAYMENTDATE != null
                                        && dg.DG_PAYMENTDATE.Value.Date <= DateTime.Now.Date.AddDays(ShiftCountDaysForOut)
                                        && dg.DG_PRICE - dg.DG_PAYED > (dg.DG_RATE.ToUpper() != "РБ" ? UECoef : RURCoef)
                                        ? 2 
                                        : 0)
                     } into filteredDG
                     from dg in RDC.tbl_Dogovors
                     //join nnt in RDC.Lanta_NNT_Names on dg.DG_TRKEY equals nnt.IDTR_Key
                     where dg.DG_CODE == filteredDG.DGCode
                        && filteredDG.PP != 0
                        && !dg.tbl_Partner.PR_NAME.Contains("Экспресс-вояж (Пр-во Ланта-тур вояж в Киеве)")
                        && !dg.tbl_Partner.PR_NAME.Contains("Индивидуально")
                        && !dg.tbl_Partner.PR_NAME.Contains("Test")
                        && !dg.tbl_Partner.PR_NAME.Contains("Ланта-тур вояж")
                     select new Report.ReportStruct {
                        DGCode = dg.DG_CODE,// + (nnt.LuckyBaseIDTR_Key != null ? " (LUCKY)" : ""),
                        ParnterName = dg.tbl_Partner.PR_NAME + " (" + dg.tbl_Partner.PR_CITY + ")",
                        PartnerPhones = dg.tbl_Partner.PR_PHONES,
                        DG_PRICE = dg.DG_PRICE,
                        DG_PAYED = dg.DG_PAYED.Value,
                        Procent = (int)(dg.DG_PAYED * 100 / dg.DG_PRICE),
                        DG_TURDATE = dg.DG_TURDATE,
                        CN_NAME = dg.COUNTRY.CN_NAME,
                        CN_KEY = dg.COUNTRY.CN_KEY,
                        PaymentDate = (filteredDG.PP == 1
                            ? dg.DG_PPAYMENTDATE.Value 
                            : dg.DG_PAYMENTDATE.Value).Date,
                        Lucky = (dg.tbl_TurList.TipTur.TP_NAME.ToLower().Contains("раннее бронирование") ? "раннее бронирование": "")
                     };
            ccItem SelectedItem = (ccItem)tsEdtCountryName.SelectedItem;
            var Result = (SelectedItem.ID <= 0 ? q1 : q1.Where(x => x.CN_KEY == SelectedItem.ID))
                .Distinct()
                .OrderByDescending(x => x.Lucky)
                .ThenBy(x => x.PaymentDate)
                .ThenBy(x => x.ParnterName)
                .ThenBy(x => x.DGCode);


            BindingSource bsReportStruct = new BindingSource();
            bsReportStruct.DataSource = Result;
            ReportDataSource rdsReportStruct = new ReportDataSource();
            rdsReportStruct.Name = "ReportStruct";
            rdsReportStruct.Value = bsReportStruct;

            this.reportViewer.Reset();

            this.reportViewer.LocalReport.DataSources.Add(rdsReportStruct);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "rep259916.Report.resultOut.rdlc";
            this.reportViewer.SetDisplayMode(DisplayMode.Normal);
            this.reportViewer.ZoomMode = ZoomMode.Percent;
            this.reportViewer.ZoomPercent = 75;
            this.reportViewer.RefreshReport();

            return Result;
        }

        private void tsBtnOnlyBron_Click(object sender, EventArgs e)
        {
            LoadList(false);
        }

        private void tsBtnOnlyCruise_Click(object sender, EventArgs e)
        {
            LoadList(true);
        }

        private void reportViewer_BookmarkNavigation(object sender, BookmarkNavigationEventArgs e)
        {
            Clipboard.SetText(e.BookmarkId);
            MessageBox.Show("Данные добавленны в буфер обмена, перейдите в нужное поле и нажмите ctrl+v или вставить");
        }

        private void tsBtnOnlyNotNormalPercent_Click(object sender, EventArgs e)
        {
            LoadList(false, true);
        }
    }
}
