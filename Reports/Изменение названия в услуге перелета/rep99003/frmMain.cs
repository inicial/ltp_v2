using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rep99003
{
    public partial class frmMain : Form
    {
        #region Вспомогательные классы и структуры
        private class OutDataST
        {
            private bool _Checked = false;
            [DisplayName("Выбрать для обновления")]
            public bool Checked { get { return _Checked; } set { _Checked = value; } }
            [DisplayName("Код авиа компании")]
            public string CompanyCode { get; set; }
            [DisplayName("Рейс")]
            public string Reis { get; set; }
            [DisplayName("Аэропорт вылета")]
            public string AeroportFrom { get; set; }
            [DisplayName("Аэропорт прилета")]
            public string AeroportTo { get; set; }
            [DisplayName("Тип самолета")]
            public string FlyType { get; set; }
            [DisplayName("Действие с....")]
            public DateTime? FlyFrom { get; set; }
            [DisplayName("Действие по...")]
            public DateTime? FlyTo { get; set; }
            [DisplayName("Дни недели")]
            public string FlyWeekDay { get; set; }
            [DisplayName("Время вылета")]
            public DateTime? FlyTimeFrom { get; set; }
            [DisplayName("Время прилета")]
            public DateTime? FlyTimeTo { get; set; }
            public int ASId = 0;
        }
        #endregion

        #region Свойства
        sqlDataContext sqlDC;
        #endregion

        #region Конструктор
        public frmMain()
        {
            sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            InitializeComponent();

            // Загрузка стран вылета
            edtFltCountryFrom.DataSource = sqlDC.tbl_Countries.Where(x =>
                x.CN_NAME.Trim() != ""
                && x.CityDictionaries.Any(xCT =>
                    xCT.ChartersFrom.Any(xCH =>
                        xCH.AirSeasons.Any(xAS => 
                            xAS.AS_DATETO.GetValueOrDefault(DateTime.MaxValue) >= DateTime.Now.Date
                        )))).OrderBy(x => x.CN_NAME);
        }
        #endregion

        #region Обработка событий
        private void edtFlt_TextChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text == "")
            {
                ((ComboBox)sender).SelectedIndex = -1;
            }
        }

        private void edtFltCountryFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            edtFltCityFrom.Enabled = !(edtFltCountryFrom.SelectedIndex < 0);
            if (!edtFltCityFrom.Enabled)
            {
                edtFltCityFrom.SelectedIndex = -1;
                edtFltCityFrom.DataSource = null;
                return;
            }

            // Загрузка городов по стране вылета
            edtFltCityFrom.DataSource = sqlDC.CityDictionaries.Where(x =>
                x.CT_NAME.Trim() != ""
                && x.CT_CNKEY == ((tbl_Country)edtFltCountryFrom.SelectedItem).CN_KEY
                && x.ChartersFrom.Any(xCH =>
                    xCH.AirSeasons.Any(xAS =>
                        xAS.AS_DATETO.GetValueOrDefault(DateTime.MaxValue) >= DateTime.Now.Date
                    ))).OrderBy(x => x.CT_NAME);
        }

        private void edtFltCityFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            edtFltCountryTo.Enabled = !(edtFltCityFrom.SelectedIndex < 0);
            if (!edtFltCountryTo.Enabled)
            {
                edtFltCountryTo.SelectedIndex = -1;
                edtFltCountryTo.DataSource = null;
                return;
            }

            // Загрузка стран прилета по городу вылета
            edtFltCountryTo.DataSource = sqlDC.tbl_Countries.Where(x =>
                x.CN_NAME.Trim() != ""
                && x.CityDictionaries.Any(xCT =>
                    xCT.ChartersTo.Any(xCH =>
                        xCH.CH_CITYKEYFROM == ((CityDictionary)edtFltCityFrom.SelectedItem).CT_KEY
                        && xCH.AirSeasons.Any(xAS => 
                            xAS.AS_DATETO.GetValueOrDefault(DateTime.MaxValue) >= DateTime.Now.Date
                        )))).OrderBy(x => x.CN_NAME);
        }

        private void edtFltCountryTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            edtFltCityTo.Enabled = !(edtFltCountryTo.SelectedIndex < 0);
            if (!edtFltCityTo.Enabled)
            {
                edtFltCityTo.SelectedIndex = -1;
                edtFltCityTo.DataSource = null;
                return;
            }
            // Загрузка городов прилета по городу вылета и стране прилета
            edtFltCityTo.DataSource = sqlDC.CityDictionaries.Where(x=>
                x.CT_CNKEY == ((tbl_Country)edtFltCountryTo.SelectedItem).CN_KEY
                && x.CT_NAME.Trim() != ""
                && x.ChartersTo.Any(xCH =>
                    xCH.CH_CITYKEYFROM == ((CityDictionary)edtFltCityFrom.SelectedItem).CT_KEY
                    && xCH.AirSeasons.Any(
                        xAS => xAS.AS_DATETO.GetValueOrDefault(DateTime.MaxValue) >= DateTime.Now.Date
                    ))).OrderBy(x => x.CT_NAME);
        }

        private void edtFltCityTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = !(edtFltCityTo.SelectedIndex < 0);
            if (!btnApply.Enabled)
            {
                OutListDGV.DataSource = null;
                return;
            }
            if (OutListDGV.DataSource != null)
                OutListDGV.DataSource = null;
            OutListDGV.DataSource = sqlDC.AirSeasons.Where(xAS =>
                xAS.Charter.CH_CITYKEYFROM == ((CityDictionary)edtFltCityFrom.SelectedItem).CT_KEY
                && xAS.Charter.CH_CITYKEYTO == ((CityDictionary)edtFltCityTo.SelectedItem).CT_KEY)
                .Select(x => new OutDataST()
                {
                    CompanyCode = x.Charter.CH_AIRLINECODE,
                    Reis = x.Charter.CH_FLIGHT,
                    AeroportFrom = x.Charter.CH_PORTCODEFROM,
                    AeroportTo = x.Charter.CH_PORTCODETO,
                    FlyType = x.Charter.CH_AIRCRAFT,
                    FlyFrom = x.AS_DATEFROM,
                    FlyTo = x.AS_DATETO,
                    FlyWeekDay = (x.AS_WEEK == null || x.AS_WEEK == "" ? "......." : x.AS_WEEK),
                    FlyTimeFrom = x.AS_TIMEFROM,
                    FlyTimeTo = x.AS_TIMETO,
                    ASId = x.AS_ID
                })
                .OrderBy(x => x.CompanyCode)
                .ThenBy(x => x.Reis)
                .ThenBy(x => x.FlyFrom)
                .ThenBy(x => x.FlyTo).ToList();

            foreach (DataGridViewColumn col in OutListDGV.Columns)
                col.ReadOnly = true;

            OutListDGV.Columns["Checked"].ReadOnly = false;
            OutListDGV.Columns["FlyFrom"].DefaultCellStyle.Format = "dd.MM.yyyy";
            OutListDGV.Columns["FlyTo"].DefaultCellStyle.Format = "dd.MM.yyyy";
            OutListDGV.Columns["FlyTimeFrom"].DefaultCellStyle.Format = "HH:mm";
            OutListDGV.Columns["FlyTimeTo"].DefaultCellStyle.Format = "HH:mm";
        }
        #endregion

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (OutListDGV.DataSource == null)
            {
                MessageBox.Show("Выберите параметры вылет и прилет");
                return;
            }
            var tmpOu = ((List<OutDataST>)OutListDGV.DataSource);

            if (!tmpOu.Any(x => x.Checked))
            {
                MessageBox.Show("Выберите рейс для обновления");
                return;
            }

            var outL =
                from xDL in sqlDC.tbl_DogovorLists
                from xAS in sqlDC.AirSeasons.Where(x => x.AS_DATEFROM.HasValue && x.AS_DATETO.HasValue)
                where
                    xDL.DL_TURDATE.HasValue
                    && xAS.AS_CHKEY == xDL.Charter.CH_KEY
                    && xDL.DL_TURDATE.Value.AddDays(xDL.DL_DAY.GetValueOrDefault(1) - 1).Date >= DateTime.Now.Date
                    && xDL.DL_TURDATE.Value.AddDays(xDL.DL_DAY.GetValueOrDefault(1) - 1).Date >= xAS.AS_DATEFROM.Value.Date
                    && xDL.DL_TURDATE.Value.AddDays(xDL.DL_DAY.GetValueOrDefault(1) - 1).Date <= xAS.AS_DATETO.Value.Date
                    && xAS.AS_WEEK[
                        (xDL.DL_TURDATE.Value.AddDays(xDL.DL_DAY.GetValueOrDefault(1) - 1).DayOfWeek == 0
                            ? 7
                            : (int)xDL.DL_TURDATE.Value.AddDays(xDL.DL_DAY.GetValueOrDefault(1) - 1).DayOfWeek) - 1] != '.'
                select new { DL = xDL, CH = xDL.Charter, SR = xDL.AirService, AS = xAS };


            var ListSelectedReis = tmpOu.Where(x => x.Checked).Select(x => x.ASId).ToList();
            var q = outL.ToArray()
                .Where(xOL => ListSelectedReis.Any(x=> x == xOL.AS.AS_ID))
                .Select(x => new
            {
                TextRus = "А_П::"
                    + x.CH.CityFrom.CT_NAME + "/"
                    + x.CH.CityTo.CT_NAME + "/"
                    + x.CH.CH_AIRLINECODE
                    + x.CH.CH_FLIGHT + ","
                    + x.CH.CH_PORTCODEFROM + "-"
                    + x.CH.CH_PORTCODETO + ","
                    + (x.AS.AS_TIMEFROM.HasValue ? x.AS.AS_TIMEFROM.Value.ToString("HH.mm") : "") + "-"
                    + (x.AS.AS_TIMETO.HasValue ? x.AS.AS_TIMETO.Value.ToString("HH:mm") : "") + "/"
                    + x.SR.AS_CODE + " "
                    + x.SR.AS_NAMERUS,
                TextLat = "Flight::"
                    + x.CH.CityFrom.CT_NameLat + "/"
                    + x.CH.CityTo.CT_NameLat + "/"
                    + x.CH.CH_AIRLINECODE
                    + x.CH.CH_FLIGHT + ","
                    + x.CH.CH_PORTCODEFROM + "-"
                    + x.CH.CH_PORTCODETO + ","
                    + (x.AS.AS_TIMEFROM.HasValue ? x.AS.AS_TIMEFROM.Value.ToString("HH.mm") : "") + "-"
                    + (x.AS.AS_TIMETO.HasValue ? x.AS.AS_TIMETO.Value.ToString("HH:mm") : "") + "/"
                    + x.SR.AS_CODE + " "
                    + x.SR.AS_NAMELAT,
                DLKey = x.DL.DL_KEY,
                Dogovor = x.DL.tbl_Dogovor,
                x.AS.AS_WEEK,
                x.DL.DL_TURDATE,
                x.DL.DL_DAY,
                x.DL
            }).ToList();


            #region Создание сообщения в рассылку
            foreach (var partnerItem in q
                .Where(x => x.Dogovor.tbl_Partner.PR_EMAIL != "")
                .Select(x => new { x.Dogovor.tbl_Partner.PR_EMAIL, x.Dogovor.tbl_Partner.PR_KEY })
                .Distinct()
            )
            {
                string MessageOut = "Уважаемые коллеги, В следующих турах произошли изменения перелета<br><br><ul>";
                foreach (var changeItem in q
                    .Where(x => x.Dogovor.DG_PARTNERKEY == partnerItem.PR_KEY).Distinct())
                {
                    MessageOut += "<li>" + changeItem.Dogovor.DG_CODE + " дата начала тура " + changeItem.Dogovor.DG_TURDATE.ToString("dd.MM.yyyy") + " рейс: " + changeItem.TextRus + "</li>";
                    changeItem.DL.DL_NAME = changeItem.TextRus;
                    changeItem.DL.DL_NameLat = changeItem.TextLat;
                }
                

                LTS_SpamServer ss = new LTS_SpamServer()
                {
                    LSS_ServiceSend = "AirNewText",
                    LSS_Subject = "Ланта-тур вояж: система оповещения о изменениях перелета",
                    LSS_Body = "%head%" + MessageOut + "%bottom%",
                    LSS_DTEndPeriod = DateTime.Now,
                    LSS_MailFrom = "info@lantatur.ru",
                    LSS_MailTo = partnerItem.PR_EMAIL,
                    LSS_PRKey = partnerItem.PR_KEY
                };
                sqlDC.LTS_SpamServers.InsertOnSubmit(ss);
            }
            int CountUpdates = sqlDC.GetChangeSet().Updates.Count;
            sqlDC.SubmitChanges();

            MessageBox.Show("Итого данных обнавлено: " + CountUpdates.ToString());
            #endregion
        }
    }
}
