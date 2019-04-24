using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Rep22341
{
    public partial class frmListRistOneBilet : Form
    {
        #region Свойства
        private sqlDataContext sqlDC;
        #endregion

        #region Методы
        public void InitializeFlyDate()
        {
            var turDates = sqlDC.tbl_DogovorLists
                .Where(x => x.DL_SVKEY == 1)
                .Select(x => new { DateService = x.DL_TURDATE.GetValueOrDefault(x.tbl_Dogovor.DG_TURDATE).Date.AddDays(x.DL_DAY.GetValueOrDefault(0) - 1).Date })
                .Distinct()
                .OrderByDescending(x => x.DateService)
                .Select(x => new DateTimeItem(x.DateService))
                .ToArray();
            fltDateStartAir.Items.Clear();
            fltDateStartAir.Items.AddRange(turDates);

            double LastMIS = 9999;
            DateTimeItem selectedFltDate = new DateTimeItem(DateTime.MinValue);

            foreach (var q in turDates)
            {
                if (Math.Abs((q.Value - DateTime.Now.Date).TotalDays) < LastMIS)
                {
                    LastMIS = Math.Abs((q.Value - DateTime.Now.Date).TotalDays);
                    selectedFltDate = q;
                }
            }

            if (selectedFltDate.Value != DateTime.MinValue)
            {
                fltDateStartAir.SelectedItem = selectedFltDate;
            }
        }
        #endregion

        #region Конструктор
        public frmListRistOneBilet()
        {
            sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            InitializeComponent();
            InitializeFlyDate();
        }
        #endregion

        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            DateTimeItem selectedDate = (DateTimeItem)fltDateStartAir.SelectedItem;
            var res =
                //from xDLPresentReis in sqlDC.tbl_DogovorLists
                from xDLOut in sqlDC.tbl_DogovorLists
                where //xDLPresentReis.DL_DGCOD == xDLOut.DL_DGCOD
                        //&& xDLPresentReis.DL_SVKEY == 1
                        xDLOut.DL_SVKEY == 1
                select xDLOut;

            res = res.Distinct();

            // Более одно партнера на перевозку
            var query1 = res.Select(x => new { x.DL_PARTNERKEY, x.DL_DGCOD })
                .GroupBy(x => x.DL_DGCOD)
                .Where(x => x.Distinct().Count() > 1)
                .Select(x => x.Key);
            // Только одна услуга авиа перевозки
            var query2 = res.Select(x => new { x.DL_DGCOD, x.DL_KEY })
               .GroupBy(x => x.DL_DGCOD)
               .Where(x => x.Count() == 1)
               .Select(x => x.Key);
            // Одновременно есть трех и четырех значные номера рейсов
            var query3 = res.Select(x => new { x.DL_DGCOD, len = x.Charter.CH_FLIGHT.Length })
                .GroupBy(x => x.DL_DGCOD)
                .Where(x => x.Distinct().Count() > 1)
                .Select(x => x.Key);

            var result =
                from xQueries in query1.Concat(query2).Concat(query3)
                from xDL in sqlDC.tbl_DogovorLists
                where xDL.DL_SVKEY == 1 &&
                        xDL.DL_DGCOD == xQueries
                        && xDL.tbl_Dogovor.DG_TURDATE.AddDays(xDL.DL_DAY.GetValueOrDefault(1) - 1).Date == selectedDate.Value.Date
                select new Extended.OneBiletItem()
                {
                    DGCode = xDL.DL_DGCOD,
                    ReisName = xDL.DL_NAME,
                    BronDate = xDL.tbl_Dogovor.DG_TURDATE.Date,
                    ReisDate = xDL.tbl_Dogovor.DG_TURDATE.AddDays(xDL.DL_DAY.GetValueOrDefault(1) - 1).Date
                };


            reportViewer1.LocalReport.ReportEmbeddedResource = "Rep22341.repListRistOneBilet.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsItems", result));
            reportViewer1.RefreshReport();
        }
    }
}
