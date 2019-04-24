using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rep22341
{
    public partial class frmMain : Form
    {
        #region Свойства
        public sqlDataContext sqlDC;
        #endregion

        #region Методы
        /// <summary>
        /// Загрузка дат туров
        /// </summary>
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

        /// <summary>
        /// Рейсов на дату
        /// </summary>
        public void InitializeCharters()
        {
            if (fltDateStartAir.SelectedItem != null && !(fltDateStartAir.SelectedItem is DateTimeItem))
                return;

            DateTimeItem selectedFltDate = (DateTimeItem)fltDateStartAir.SelectedItem;
            var chartes = sqlDC.tbl_DogovorLists
                .Where(x =>
                    x.DL_TURDATE.GetValueOrDefault(x.tbl_Dogovor.DG_TURDATE).AddDays(x.DL_DAY.GetValueOrDefault(0) - 1) == selectedFltDate.Value &&
                    x.DL_SVKEY == 1 &&
                    x.TuristServices.Count() > 0)
                .Select(x => x.Charter)
                .Distinct()
                .OrderBy(x => x.CH_AIRLINECODE)
                .ThenBy(x => x.CH_FLIGHT)
                .Select(x => new CharterItem(x));

            fltChartes.DataSource = chartes.ToList();
            fltChartes.Columns["CharterKey"].Visible = false;
            fltChartes.Columns["SelectedItem"].HeaderText = "";
            fltChartes.Columns["CharterName"].HeaderText = "Рейс";
            fltChartes.Columns["CityRoute"].HeaderText = "Маршрут";
        }

        public void InitializeAirServices()
        {
            if (fltDateStartAir.SelectedItem == null || !(fltDateStartAir.SelectedItem is DateTimeItem))
                return;

            DateTimeItem selectedFltDate = (DateTimeItem)fltDateStartAir.SelectedItem;

            List<int> chekedItems = new List<int>();
            fltChartes.EndEdit();

            foreach (DataGridViewRow rowItem in fltChartes.Rows)
            {
                var item = (CharterItem)rowItem.DataBoundItem;
                if (item.SelectedItem)
                {
                    chekedItems.Add(item.CharterKey);
                }
            }

            if (chekedItems.Count() > 0)
            {
                var airServices = sqlDC.tbl_DogovorLists
                    .Where(x =>
                        x.DL_TURDATE.GetValueOrDefault(x.tbl_Dogovor.DG_TURDATE).AddDays(x.DL_DAY.GetValueOrDefault(0) - 1) == selectedFltDate.Value &&
                        x.DL_SVKEY == 1 &&
                        x.TuristServices.Count() > 0 &&
                        chekedItems.Contains(x.Charter.CH_KEY))
                    .Select(x => x.AirService)
                    .Distinct()
                    .OrderBy(x => x.AS_NAMERUS)
                    .Select(x => new AirServiceItem(x));

                fltAirService.DataSource = airServices.ToList();
                fltAirService.Columns["AirServiceKey"].Visible = false;
                fltAirService.Columns["SelectedItem"].HeaderText = "";
                fltAirService.Columns["Code"].HeaderText = "Класс";
                fltAirService.Columns["Text"].HeaderText = "Название";
            }
            chekedItems.Clear();
            chekedItems = null;

        }
        #endregion

        #region Конструктор
        public frmMain()
        {
            InitializeComponent();
            sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            InitializeFlyDate();
        }
        #endregion

        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            InitializeAirServices();
        }

        private void fltDateStartAir_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            InitializeCharters();
        }

        private void tsBtnPrint_Click(object sender, EventArgs e)
        {
            if (fltDateStartAir.SelectedItem != null && !(fltDateStartAir.SelectedItem is DateTimeItem))
                return;

            fltChartes.EndEdit();
            fltAirService.EndEdit();
            List<int> chekedCharterItems = new List<int>();
            foreach (DataGridViewRow rowItem in fltChartes.Rows)
            {
                var item = (CharterItem)rowItem.DataBoundItem;
                if (item.SelectedItem)
                {
                    chekedCharterItems.Add(item.CharterKey);
                }
            }

            List<int> chekedAirServicesItems = new List<int>();
            foreach (DataGridViewRow rowItem in fltAirService.Rows)
            {
                var item = (AirServiceItem)rowItem.DataBoundItem;
                if (item.SelectedItem)
                {
                    chekedAirServicesItems.Add(item.AirServiceKey);
                }
            }

            new frmPrint(
                sqlDC,
                ((DateTimeItem)fltDateStartAir.SelectedItem).Value,
                chekedCharterItems.ToArray(),
                chekedAirServicesItems.ToArray()).ShowDialog();

            chekedCharterItems.Clear();
            chekedCharterItems = null;

            chekedAirServicesItems.Clear();
            chekedAirServicesItems = null;
        }

        private void tsBtnOneReis_Click(object sender, EventArgs e)
        {
            new frmListRistOneBilet().ShowDialog();
        }
    }
}
