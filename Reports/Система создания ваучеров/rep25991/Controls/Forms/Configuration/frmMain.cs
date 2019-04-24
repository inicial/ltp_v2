using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rep25991.ExtendedMethods.Convertation;
using rep25991.ExtendedMethods;
using ltp_v2.Controls.Forms;

namespace rep25991.Controls.Forms.Configuration
{
    public partial class frmMain : Form
    {
        #region Вспомогательные классы
        public class IndexedService
        {
            public int Index;
            public int SVKey;

            public IndexedService(int index, int svKey)
            {
                this.Index = index;
                this.SVKey = svKey;
            }
        }
        
        private class helperShablonService
        {
            public LT_V_ShablonService ShablonService;
            public List<IndexedService> UsedServices;

            public helperShablonService(LT_V_ShablonService value)
            {
                UsedServices = new List<IndexedService>();
                ShablonService = value;
            }

            public override string ToString()
            {
                return ShablonService.LT_V_ShablonFormatService.Service.SV_NAME + " - (" + UsedServices.Count() + "/" + (ShablonService.SHS_IsMultiVariant ? "X" : "1") + ")";
            }
        }

        delegate void CheckStateEventHandler(helperResultOut sender, bool Check);
        private class helperResultOut
        {
            public event CheckStateEventHandler OnCheckedChange;
            private bool _Checked;
            public int Index;
            public int SVKey;
            public int? PRKey;
            public int? SHId = null;

            [DisplayName("исп.")]
            public bool Checked
            {
                get { return _Checked; }
                set
                {
                    _Checked = value;
                    if (OnCheckedChange != null)
                        OnCheckedChange(this, value);
                }
            }

            [ReadOnlyAttribute(true)]
            [DisplayName("День")]
            public short? Day { get; set; }

            [ReadOnlyAttribute(true)]
            [DisplayName("Продолжительность")]
            public short? NDays { get; set; }

            [ReadOnlyAttribute(true)]
            [DisplayName("Услуги тура")]
            public string ServiceName { get; set; }

            [ReadOnlyAttribute(true)]
            [DisplayName("Пример названия услуги")]
            public string ExampleName { get; set; }

            [ReadOnlyAttribute(true)]
            [DisplayName("Используется шаблон ваучера")]
            public string ShablonName { get; set; }

            public helperResultOut(sqlDataContext sqlDC, TurService value)
            {
                var IndexedTurService = new structIndexedService(value);
                PRKey = value.TS_PARTNERKEY;
                Index = IndexedTurService.Index;
                SVKey = IndexedTurService.SVKey;
                Day = value.TS_DAY;
                NDays = value.TS_NDAYS;
                ServiceName = value.Service.SV_NAME + " - " + IndexedTurService.Index;
                ExampleName = value.TS_NAME;

                var q = sqlDC.LT_V_MappingTurServices.Where(x =>
                    x.LT_V_MappingTurList.VT_TLKey == value.TS_TRKEY
                    && x.VS_Index == IndexedTurService.Index
                    && x.VS_SVKey == value.TS_SVKEY).FirstOrDefault();

                if (q != null)
                {
                    ShablonName = q.LT_V_ShablonService.LT_V_Shablon.SH_Name + " (" + q.LT_V_MappingTurList.VT_Name + ")";
                    SHId = q.LT_V_ShablonService.LT_V_Shablon.SH_Id;
                }
            }
        }

        private class helperResultTurList
        {
            public int TLKey;
            public int CountCreatedShablon;

            [DisplayName("Тур")]
            public string TLName { get; set; }

            [DisplayName("Кол-во используюемых шаблонов")]
            public string CountShablon
            {
                get
                {
                    return (CountCreatedShablon > 0 ? CountCreatedShablon.ToString() : "");
                }
            }

            [DisplayName("Кол-во услуг вне шаблона")]
            public int CountServiceNotInShablon { get; set; }

            public helperResultTurList(IGrouping<tbl_TurList, TurService> value, sqlDataContext sqlDC)
            {
                TLKey = value.Key.TL_KEY;
                TLName = value.Key.TL_NAME;

                var mtl = sqlDC.LT_V_MappingTurLists.Where(x => x.VT_TLKey == TLKey);

                CountCreatedShablon = mtl.Count();
                var userServices =
                    from xMtl in mtl
                    from xMts in sqlDC.LT_V_MappingTurServices.Where(x => x.VS_VTId == xMtl.VT_Id)
                    select new { index = xMts.VS_Index, svKey = xMts.VS_SVKey };
                var indexedService = value.Key.GetIndexedTurService().Select(x => new { index = x.Index, svKey = x.SVKey });

                CountServiceNotInShablon = value.Select(x => x.TS_Key).Count() - userServices.Count();
            }
        }

        private class helperResultCityList
        {
            [DisplayName("Город/курорт")]
            public string Name { get; private set; }
            [DisplayName("Кол-во туров")]
            public int CountTour { get; private set; }
            [DisplayName("Кол-во используюемых 100% по всем услугам")]
            public int CountFullUseTour { get; private set; }
            [DisplayName("Кол-во туров у которых не размеченно 1 или более услуга")]
            public int CountNotFullUseTour { get; private set; }
            public int CTKey;
            public helperResultCityList(sqlDataContext sqlDC, CityDictionary value)
            {
                CTKey = value.CT_KEY;
                var turServices = (from xTL in sqlDC.GetTurList(value.CT_CNKEY)
                         .Where(x => x.TurServices.Any(xTS => xTS.TS_CTKEY == value.CT_KEY))
                     from xTS in sqlDC.TurServices.Where(x =>
                         (x.TS_ATTRIBUTE.GetValueOrDefault(0) & 64) == 0
                         && x.Service.LT_V_ServiceNotUse == null)
                     where xTS.TS_TRKEY == xTL.TL_KEY
                     select xTS);

                var turLists = turServices.Select(x => x.tbl_TurList).Distinct();

                var created =
                    (from xTL in turLists.ToArray()
                    from xTS in xTL.GetIndexedTurService()
                     select new { xTL.TL_KEY, xTS.Index, xTS.SVKey }).ToArray();

                var used =
                    (from xMTL in sqlDC.LT_V_MappingTurLists.Where(x => turLists.Any(xTL => xTL.TL_KEY == x.VT_TLKey))
                    from xMTS in xMTL.LT_V_MappingTurServices
                    select new { xMTL.VT_TLKey, xMTS.VS_Index, xMTS.VS_SVKey }).ToArray();

                CountNotFullUseTour = CountFullUseTour = 0;
                foreach (var tlCreated in created.GroupBy(x => x.TL_KEY))
                {
                    var usedInTL = used.Where(x => x.VT_TLKey == tlCreated.Key).Select(x => new { Index = x.VS_Index, SVKey = x.VS_SVKey });
                    var itemInGR = tlCreated.Select(x => new { x.Index, x.SVKey });
                    var unionItem = itemInGR.Except(usedInTL);
                    if (unionItem.Count() == 0)
                    {
                        CountFullUseTour++;
                    }
                    else
                    {
                        CountNotFullUseTour++;
                    }
                }

                Name = value.CT_NAME;
                CountTour = turLists.Count();
                //CountFullUseTour = fullUsed.Count();
            }
        }
        #endregion

        #region Свойства
        private bool skeepReloadDataSource = false;
        private bool localChackedSet = false;
        private bool presentChecked = false;
        private WordReport.TurTemplateLink _frmLink;
        private int TLKey;
        private sqlDataContext _SqlDC;
        private sqlDataContext SqlDC
        {
            get { return _SqlDC; }
            set
            {
                _SelectedFltShablon = null;
                _SqlDC = value;
            }
        }
        private COUNTRY SelectedFltCountry
        {
            get
            {
                if (fltCountry.SelectedItem == null || fltCountry.SelectedItem.GetType() != typeof(COUNTRY))
                {
                    fltCity.Enabled = false;
                    fltTour.Enabled = false;
                    return null;
                }
                fltCity.Enabled = true;
                fltTour.Enabled = true;
                return (COUNTRY)fltCountry.SelectedItem;
            }
        }
        private CityDictionary SelectedFltCity
        {
            get
            {
                if (fltCity.SelectedItem == null || fltCity.SelectedItem.GetType() != typeof(CityDictionary))
                {
                    fltTour.Enabled = false;
                    return null;
                }
                var selItem = (CityDictionary)fltCity.SelectedItem;
                fltTour.Enabled = selItem.CT_KEY != -1;
                return selItem;
            }
        }
        /// <summary>
        /// Выбранное значение fltTour
        /// </summary>
        private tbl_TurList SelectedFltTurList
        {
            get
            {
                if (fltTour.SelectedItem == null || fltTour.SelectedItem.GetType() != typeof(tbl_TurList))
                {
                    return null;
                }
                return (tbl_TurList)fltTour.SelectedItem;
            }
        }
        private LT_V_Shablon _SelectedFltShablon;
        private LT_V_Shablon SelectedFltShablon
        {
            get
            {
                if (_SelectedFltShablon == null)
                {
                    if (fltShablon.SelectedItem == null || fltShablon.SelectedItem.GetType() != typeof(LT_V_Shablon))
                    {
                        return null;
                    }
                    _SelectedFltShablon = SqlDC.LT_V_Shablons.First(x => x.SH_Id == ((LT_V_Shablon)fltShablon.SelectedItem).SH_Id);
                }
                return _SelectedFltShablon;
            }
        }
        #endregion

        #region Методы
        private IQueryable<CityDictionary> GetUsedCity()
        {
            return SqlDC.CityDictionaries.Where(x => x.CT_CNKEY == SelectedFltCountry.CN_KEY)
                    .Where(x => (
                        from xTL in SqlDC.tbl_TurLists.Where(xTL => xTL.TL_CNKEY == SelectedFltCountry.CN_KEY)
                        from xTS in SqlDC.TurServices.Where(xTS =>
                            (xTS.TS_ATTRIBUTE.GetValueOrDefault(0) & 64) == 0
                            && xTS.Service.LT_V_ServiceNotUse == null
                            && xTS.TS_TRKEY == xTL.TL_KEY
                            && xTS.TS_CTKEY == x.CT_KEY)
                        where xTL.TurDates.Any(xTD => xTD.TD_DATE.Date >= ltp_v2.Framework.SqlConnection.ServerDateTime.Date)
                        select xTL).Count() > 0)
                    .Select(x => x).Distinct().OrderBy(x => x.CT_NAME);
        }

        private void SetEventAndCheck()
        {
            if (SelectedFltShablon == null)
                return;
            
            foreach (var itemDS in ((helperResultOut[])ResultListDGV.DataSource))
            {
                itemDS.OnCheckedChange += new CheckStateEventHandler(itemDS_OnCheckedChange);
                itemDS.Checked = SqlDC.LT_V_MappingTurServices.Any(x =>
                    x.VS_SVKey == itemDS.SVKey
                    && x.VS_Index == itemDS.Index
                    && x.LT_V_MappingTurList.VT_TLKey == SelectedFltTurList.TL_KEY);
            }
        }

        private void SetListServiceVariant()
        {
            listPresentShablonService.DataSource = null;

            if (SelectedFltShablon == null)
                return;
            listPresentShablonService.DataSource = SelectedFltShablon.LT_V_ShablonServices
                .OrderBy(x => x.SHS_LineOut)
                .Select(x => new helperShablonService(x))
                .ToArray();
        }

        private void ReloadDataSource()
        {
            if (skeepReloadDataSource)
                return;

            lwWaitScreen wait = new lwWaitScreen();
            wait.Show();

            SqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            ResultListDGV.DataSource = null;
            pnlTourName.Visible = false;
            tsBtnShowExample.Visible = tsBtnApply.Visible = false;

            if (SelectedFltCity == null)
            {
            }
            else if (SelectedFltCity.CT_KEY == -1)
            {
                ResultListDGV.DataSource = GetUsedCity().Select(x => new helperResultCityList(SqlDC, x));
            }
            else if (fltTour.SelectedItem == null || SelectedFltTurList == null && fltTour.SelectedItem.GetType() != typeof(string) || fltTour.SelectedIndex < 0)
            {
            }
            else if (fltTour.SelectedItem.GetType() == typeof(string))
            {
                var q =
                    (from xTL in SqlDC.GetTurList(SelectedFltCountry.CN_KEY)
                         .Where(x => x.TurServices.Any(xTS => xTS.TS_CTKEY == SelectedFltCity.CT_KEY))
                     from xTS in SqlDC.TurServices.Where(x =>
                         (x.TS_ATTRIBUTE.GetValueOrDefault(0) & 64) == 0
                         && x.Service.LT_V_ServiceNotUse == null)
                     where xTS.TS_TRKEY == xTL.TL_KEY
                     select xTS).GroupBy(x => x.tbl_TurList)
                        .Where(x => x.Count() > 0)
                        .Select(x => new helperResultTurList(x, SqlDC));
                ResultListDGV.DataSource = q;
            }
            else
            {
                var dsResult = (
                   from xITS in SelectedFltTurList.GetIndexedTurService()
                   from xTS in SelectedFltTurList.TurServices
                   where xTS.TS_Key == xITS.Key
                   select new { xTS, xITS.Index }
                   ).OrderBy(x => x.xTS.TS_DAY)
                   .ThenBy(x => x.xTS.TS_Key)
                   .Select(x => new helperResultOut(SqlDC, x.xTS));

                if (SelectedFltShablon != null)
                {
                    int[] SVKeys = SelectedFltShablon.LT_V_ShablonServices.Select(xSS => xSS.LT_V_ShablonFormatService.SHFS_SVKey).ToArray();
                    dsResult = dsResult
                        .Where(x => SVKeys.Any(xSV => xSV == x.SVKey))
                        .Where(x => !x.SHId.HasValue || x.SHId == SelectedFltShablon.SH_Id);
                    pnlTourName.Visible = true;
                    tsBtnApply.Visible = true;
                }

                ResultListDGV.DataSource = dsResult.ToArray();
                SetListServiceVariant();
                SetEventAndCheck();

                ResultListDGV.Columns["Checked"].Visible = (SelectedFltShablon != null);
                ResultListDGV.Columns["day"].Width = 30;
                ResultListDGV.Columns["ndays"].Width = 30;
                ResultListDGV.Columns["Checked"].Width = 40;
            }

            wait.Close();
            presentChecked = false;
        }
        #endregion

        #region Конструктор
        public frmMain(int tlKey)
        {
            InitializeComponent();
            TLKey = tlKey;
        }
        #endregion

        #region Обработка событий
        private void frmMain_Load(object sender, EventArgs e)
        {
            skeepReloadDataSource = true;
            SqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            fltCountry.DataSource = SqlDC.COUNTRies
                .Where(x=>SqlDC.LT_V_ShablonTourNames.Any(xCN=>xCN.SHTN_CNKey == x.CN_KEY))
                .OrderBy(x => x.CN_NAME);
            skeepReloadDataSource = false;

            if (TLKey > 0)
            {
                var filteredTurList = SqlDC.tbl_TurLists.Where(x => x.TL_KEY == TLKey);
                if (filteredTurList.Count() > 0)
                {
                    var filteredCNKey = filteredTurList.First().TL_CNKEY;
                    var filteredCTKey = SqlDC.TurServices.Where(x => (x.TS_SVKEY == 3 || x.TS_SVKEY == 3149) && x.TS_CNKEY == filteredCNKey && x.TS_TRKEY == TLKey).First().TS_CTKEY;

                    fltCountry.SelectedItem = fltCountry.Items.OfType<COUNTRY>().FirstOrDefault(x => x.CN_KEY == filteredCNKey);
                    fltCity.SelectedItem = fltCity.Items.OfType<CityDictionary>().FirstOrDefault(x => x.CT_KEY == filteredCTKey);
                    if (SqlDC.LT_GroupToBaseTours.Any(x => x.GT_ParentTLKey == TLKey))
                    {
                        fltTour.SelectedItem = fltTour.Items.OfType<tbl_TurList>().FirstOrDefault(x => x.TL_KEY == SqlDC.LT_GroupToBaseTours.FirstOrDefault(xGBT => xGBT.GT_ParentTLKey == TLKey).GT_RootTLKey);
                    }
                    else
                    {
                        fltTour.SelectedItem = fltTour.Items.OfType<tbl_TurList>().FirstOrDefault(x => x.TL_KEY == TLKey);
                    }
                }
            }
            else
            {
                fltCountry.SelectedIndex = 0;
            }
        }

        #region Обработка событий фильтра
        private void fltCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            fltShablon.Items.Clear();
            if (skeepReloadDataSource)
                return;

            if (SelectedFltCountry != null && (fltCity.SelectedItem == null || ((CityDictionary)fltCity.SelectedItem).CT_CNKEY != ((COUNTRY)fltCountry.SelectedItem).CN_KEY))
            {
                fltCity.Items.Clear();
                fltCity.Items.AddRange(GetUsedCity().ToArray());
                fltCity.Items.Insert(0, new CityDictionary() { CT_NAME = "Все города", CT_KEY = -1, CT_CNKEY =  ((COUNTRY)fltCountry.SelectedItem).CN_KEY});
                fltCity.SelectedIndex = 0;
                fltBaseTour.DataSource = SqlDC.LT_V_ShablonTourNames.Where(x => x.SHTN_CNKey == SelectedFltCountry.CN_KEY).OrderBy(x => x.SHTN_Name);
            }
        }

        private void fltCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            fltTour.Items.Clear();
            fltTour.Enabled = fltShablon.Enabled = fltBaseTour.Enabled = false;

            if (SelectedFltCity == null)
                return;
            
            if (SelectedFltCity.CT_KEY != -1)
            {
                fltTour.Enabled = true;
                fltTour.Items.AddRange(SqlDC
                        .GetTurList(SelectedFltCountry.CN_KEY)
                        .Where(x => x.TurServices.Any(xTS =>
                            xTS.TS_CTKEY == SelectedFltCity.CT_KEY
                            && (xTS.TS_ATTRIBUTE.GetValueOrDefault(0) & 64) == 0
                            && xTS.Service.LT_V_ServiceNotUse == null))
                        .Where(x => !SqlDC.LT_GroupToBaseTours.Any(xG => xG.GT_ParentTLKey == x.TL_KEY))
                        .OrderBy(x => x.TL_NAME).ToArray());
                fltTour.Items.Insert(0, "Все туры");
            }
            else
            {
                ReloadDataSource();
            }
        }

        private void fltTour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fltTour.SelectedIndex <= 0 || _frmLink != null)
            {
                panel2.Controls.Clear();
                panel2.Visible = false;
                if (_frmLink != null)
                    _frmLink.Dispose();
                _frmLink = null;
                tsBtnApply.Visible = false;
            }
            ReloadDataSource();
            if (tsBtnShowExample.Visible = fltBaseTour.Enabled = fltShablon.Enabled = (fltTour.SelectedIndex > 0))
            {
                panel2.Visible = true;
                fltBaseTour.SelectedItem =
                    (from xSTN in fltBaseTour.Items.OfType<LT_V_ShablonTourNames>()
                     from xMTL in SqlDC.LT_V_MappingTurLists.Where(x => x.VT_TLKey == SelectedFltTurList.TL_KEY)
                     from xSH in SqlDC.LT_V_MappingTurServices.Where(x => x.VS_VTId == xMTL.VT_Id).Select(x => x.LT_V_ShablonService.LT_V_Shablon)
                     from xSTG in SqlDC.LT_V_ShablonTourGroups.Where(x => x.SHTR_SHId == xSH.SH_Id).Select(x => x.LT_V_ShablonTourNames)
                     where xSTN.SHTN_Id == xSTG.SHTN_Id
                     select xSTN).FirstOrDefault();

                _frmLink = new WordReport.TurTemplateLink(ltp_v2.Framework.SqlConnection.ConnectionData, SelectedFltTurList.TL_KEY);
                _frmLink.TopLevel = false;
                panel2.Controls.Add(_frmLink);
                _frmLink.Show();
                _frmLink.Dock = DockStyle.Fill;
                _frmLink.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                tsBtnApply.Visible = true;
            }
        }

        private void fltBaseTour_SelectedIndexChanged(object sender, EventArgs e)
        {
            fltShablon.Items.Clear();
            if (!(fltShablon.Enabled = !(fltBaseTour.SelectedItem == null)))
                return;

            fltShablon.Items.AddRange(
                (from xSTG in SqlDC.LT_V_ShablonTourGroups
                 from xSH in SqlDC.LT_V_Shablons
                 where xSTG.SHTR_SHId == xSH.SH_Id
                        && xSTG.SHTR_SHTNId == ((LT_V_ShablonTourNames)fltBaseTour.SelectedItem).SHTN_Id
                 select xSH).Distinct().OrderBy(x => x.SH_Name).ToArray());
            edtTourName.Text = ((LT_V_ShablonTourNames)fltBaseTour.SelectedItem).SHTN_Name;
            edtTourName.Enabled = false;

            fltShablon.Items.Insert(0, "Все шаблоны");
            fltShablon.SelectedIndex = 0;
        }

        private void fltShablon_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SelectedFltShablon = null;
            ReloadDataSource();
        }
        #endregion

        private void ResultListDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (ResultListDGV.Rows.Count == 0)
                return;

            tsBtnTourShow.Visible = false;
            tsBtnAllTours.Visible = false;
            tsBtnShowCity.Visible = false;

            if (ResultListDGV.Rows[0].DataBoundItem.GetType() == typeof(helperResultCityList))
            {
                tsBtnShowCity.Visible = true;
            }

            if (ResultListDGV.Rows[0].DataBoundItem.GetType() == typeof(helperResultTurList))
            {
                tsBtnTourShow.Visible = true;
            }

            if (ResultListDGV.Rows[0].DataBoundItem.GetType() == typeof(helperResultOut))
            {
                tsBtnAllTours.Visible = true;
            }

            foreach (DataGridViewRow dgvr in ResultListDGV.Rows)
            {
                if (dgvr.DataBoundItem == null)
                    continue;

                if (dgvr.DataBoundItem.GetType() == typeof(helperResultTurList))
                {
                    if (((helperResultTurList)dgvr.DataBoundItem).CountCreatedShablon > 0)
                    {
                        dgvr.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        dgvr.DefaultCellStyle.ForeColor = Color.Black;
                        dgvr.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    }
                }

                if (dgvr.DataBoundItem.GetType() == typeof(helperResultOut))
                {
                    if (((helperResultOut)dgvr.DataBoundItem).SHId.HasValue)
                    {
                        dgvr.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        dgvr.DefaultCellStyle.ForeColor = Color.Black;
                        dgvr.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void itemDS_OnCheckedChange(helperResultOut sender, bool Check)
        {
            if (localChackedSet)
                return;

            presentChecked = true;

            localChackedSet = true;

            var listPSS = listPresentShablonService.Items.OfType<helperShablonService>();

            if (Check)
            {
                bool itemIsFull = true;
                // Подбор позиции для добавляемой услуги
                foreach (var itemPSS in listPSS.Where(x => x.ShablonService.LT_V_ShablonFormatService.SHFS_SVKey == sender.SVKey))
                {
                    if (itemPSS.ShablonService.SHS_IsMultiVariant
                        || !itemPSS.ShablonService.SHS_IsMultiVariant
                        && itemPSS.UsedServices.Count() == 0)
                    {
                        itemIsFull = false;
                        itemPSS.UsedServices.Add(new IndexedService(sender.Index, sender.SVKey));
                        break;
                    }
                }

                if (itemIsFull)
                {
                    sender.Checked = false;
                }
            }
            else
            {
                foreach (var item in listPSS.Where(x => x.ShablonService.LT_V_ShablonFormatService.SHFS_SVKey == sender.SVKey))
                {
                    IndexedService valueDel = item.UsedServices.FirstOrDefault(x => x.Index == sender.Index && x.SVKey == sender.SVKey);
                    if (valueDel != null)
                    {
                        item.UsedServices.Remove(valueDel);
                    }
                }
            }

            // Блокировка / разблокировка кнопок
            tsBtnShowExample.Enabled = !listPSS.Any(x => x.UsedServices.Count() == 0) || listPSS.All(x => x.UsedServices.Count() == 0);

            var Lsx = listPresentShablonService.DataSource;
            listPresentShablonService.DataSource = null;
            listPresentShablonService.DataSource = Lsx;

            localChackedSet = false;
        }

        private void ResultListDGV_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            ResultListDGV.EndEdit();
        }

        private void ResultListDGV_KeyUp(object sender, KeyEventArgs e)
        {
            ResultListDGV.EndEdit();
        }

        private void tsBtnApply_Click(object sender, EventArgs e)
        {
            if (_frmLink != null)
                _frmLink.Submit();

            if (!presentChecked)
                return;

            var listPSS = listPresentShablonService.Items.OfType<helperShablonService>();
            
            // Внесение одного названия для всех вариантов
            foreach (var itemMapTL in SqlDC.LT_V_MappingTurLists.Where(x => x.VT_TLKey == SelectedFltTurList.TL_KEY))
            {
                itemMapTL.VT_Name = edtTourName.Text.RemoveSpace();
            }

            // Получение текущего используемого шаблона
            var currentMapTL =
                (from xMTL in SqlDC.LT_V_MappingTurLists
                 from xMTS in SqlDC.LT_V_MappingTurServices.Where(x => x.VS_VTId == xMTL.VT_Id)
                 from xSS in SqlDC.LT_V_ShablonServices.Where(x => x.SHS_SHId == SelectedFltShablon.SH_Id)
                 where xSS.SHS_Id == xMTS.VS_SHSId
                     && xMTL.VT_TLKey == SelectedFltTurList.TL_KEY
                 select xMTL).Distinct().FirstOrDefault();

            if (currentMapTL == null)
            {
                currentMapTL = new LT_V_MappingTurList();
                SqlDC.LT_V_MappingTurLists.InsertOnSubmit(currentMapTL);
                currentMapTL.VT_Name = edtTourName.Text.RemoveSpace();
                currentMapTL.VT_TLKey = SelectedFltTurList.TL_KEY;
            }
            else
            {
                foreach (var itemDel in currentMapTL.LT_V_MappingTurServices.ToArray())
                {
                    currentMapTL.LT_V_MappingTurServices.Remove(itemDel);
                    SqlDC.LT_V_MappingTurServices.DeleteOnSubmit(itemDel);
                }
            }

            foreach (var item in listPSS)
            {
                foreach (var itemIns in item.UsedServices)
                {
                    currentMapTL.LT_V_MappingTurServices.Add(
                        new LT_V_MappingTurService()
                    {
                        VS_Index = itemIns.Index,
                        VS_SHSId = item.ShablonService.SHS_Id,
                        VS_SVKey = itemIns.SVKey
                    });
                }
            }

            if (currentMapTL.LT_V_MappingTurServices.Count() == 0)
                SqlDC.LT_V_MappingTurLists.DeleteOnSubmit(currentMapTL);

            SqlDC.SubmitChanges();
            foreach (var itemParent in SqlDC.LT_GroupToBaseTours.Where(x => x.GT_RootTLKey == currentMapTL.VT_TLKey))
            {
                SqlDC.CopyMapppingTurList(currentMapTL.VT_TLKey, itemParent.GT_ParentTLKey);
            }
            SqlDC.SubmitChanges();
            fltShablon.SelectedIndex = 0;
        }

        private void tsBtnEditPartners_Click(object sender, EventArgs e)
        {
            new frmPartnerList(SelectedFltCountry.CN_KEY).ShowDialog();
        }

        private void tsBtnShowExample_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пример создается без учета партнеров, и туристов");

            sqlDataContext sqlDCTest = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            List<LT_V_Voucher> resultTestVouchers = new List<LT_V_Voucher>();
            var usedTour = sqlDCTest.tbl_TurLists.FirstOrDefault(x=>x.TL_KEY == SelectedFltTurList.TL_KEY);
            var indexedService = usedTour.GetIndexedTurService();
            var prKey = usedTour.TurServices.FirstOrDefault(x => x.TS_PARTNERKEY.HasValue).TS_PARTNERKEY;
            var testTurist = sqlDCTest.tbl_Turists.Where(x =>
                    x.TU_NAMELAT != ""
                    && x.TU_FNAMELAT != ""
                    && x.TU_PASPORTNUM != ""
                    && x.TU_PASPORTTYPE != ""
                    && x.TU_BIRTHDAY.HasValue).First();

            foreach (var tmpShablonItem in usedTour.LT_V_MappingTurLists)
            {
                var newTestVoucher = sqlDCTest.CreateVoucher(prKey, SelectedFltCountry.CN_KEY, -1);
                newTestVoucher.SetPersonToVoucher(sqlDCTest, new tbl_Turist[] { testTurist });
                newTestVoucher.V_DateBeg = DateTime.MaxValue;
                resultTestVouchers.Add(newTestVoucher);
                var shablonItem = sqlDCTest.LT_V_MappingTurLists.FirstOrDefault(x => x.VT_Id == tmpShablonItem.VT_Id);
                foreach (var shServiceItem in shablonItem.LT_V_MappingTurServices.OrderBy(x=>x.VS_Index))
                {
                    var currentService = indexedService.FirstOrDefault(x =>
                        x.Index == shServiceItem.VS_Index
                        && x.SVKey == shServiceItem.VS_SVKey);

                    if (currentService == null)
                        continue;

                    var qItem = sqlDCTest.TurServices.FirstOrDefault(x => x.TS_Key == currentService.Key);

                    if (tmpShablonItem.LT_V_MappingTurServices.Count() == 1 &&
                        tmpShablonItem.LT_V_MappingTurServices.Any(x => !x.LT_V_ShablonService.SHS_IsGroupToOneVoucher) &&
                        newTestVoucher.LT_V_Services.Count() > 0)
                    {
                        newTestVoucher = sqlDCTest.CreateVoucher(prKey, SelectedFltCountry.CN_KEY, -1);
                        newTestVoucher.V_DateBeg = DateTime.MaxValue;
                        newTestVoucher.SetPersonToVoucher(sqlDCTest, new tbl_Turist[] { testTurist });
                        resultTestVouchers.Add(newTestVoucher);
                    }

                    newTestVoucher.tbl_Partner = qItem.tbl_Partner;

                    newTestVoucher.V_TourName = tmpShablonItem.VT_Name;
                    var newDateBeg = DateTime.Now.AddDays(qItem.TS_DAY.GetValueOrDefault(1) - 1);
                    var newDateEnd = newDateBeg.AddDays(qItem.TS_NDAYS.GetValueOrDefault(1) - ((qItem.TS_SVKEY == 3 || qItem.TS_SVKEY == 3149) ? 0 : 1));
                    if (newTestVoucher.V_DateBeg.Date > newDateBeg.Date)
                        newTestVoucher.V_DateBeg = newDateBeg;
                    if (newTestVoucher.V_DateEnd.Date < newDateEnd.Date)
                        newTestVoucher.V_DateEnd = newDateEnd;

                    newTestVoucher.LT_V_Services.Add(new LT_V_Service()
                    {
                        VS_PrintLine = shServiceItem.LT_V_ShablonService.SHS_LineOut,
                        VS_Name = qItem.Convert(
                            shServiceItem.LT_V_ShablonService.LT_V_ShablonFormatService.SHFS_FormatOut,
                            qItem.tbl_Partner.LT_V_MappingPartner.VMP_DateFormat)
                    });
                }
            }

            new Report.ReportGenerator(sqlDCTest, resultTestVouchers.ToArray(), true, false, false).ShowDialog();
            sqlDCTest.Dispose();
            sqlDCTest = null;
            resultTestVouchers.Clear();
            resultTestVouchers = null;
        }

        private void tsBtnAllTours_Click(object sender, EventArgs e)
        {
            fltTour.SelectedIndex = 0;
        }

        private void tsBtnTourShow_Click(object sender, EventArgs e)
        {
            var q = (helperResultTurList)ResultListDGV.SelectedRows[0].DataBoundItem;
            TLKey = q.TLKey;
            if (SqlDC.LT_GroupToBaseTours.Any(x => x.GT_ParentTLKey == TLKey))
            {
                fltTour.SelectedItem = fltTour.Items.OfType<tbl_TurList>().FirstOrDefault(x => x.TL_KEY == SqlDC.LT_GroupToBaseTours.FirstOrDefault(xGBT => xGBT.GT_ParentTLKey == TLKey).GT_RootTLKey);
            }
            else
            {
                fltTour.SelectedItem = fltTour.Items.OfType<tbl_TurList>().FirstOrDefault(x => x.TL_KEY == TLKey);
            }
        }

        private void tsBtnShowCity_Click(object sender, EventArgs e)
        {
            var selectedHRCItem = (helperResultCityList)ResultListDGV.SelectedRows[0].DataBoundItem;
            fltCity.SelectedItem = fltCity.Items.OfType<CityDictionary>().FirstOrDefault(x => x.CT_KEY == selectedHRCItem.CTKey);
            fltTour.SelectedIndex = 0;
        }

        private void tsSetBaseTour_Click(object sender, EventArgs e)
        {
            new GroupTours.frmGroupTour(SelectedFltCountry.CN_KEY, SelectedFltTurList == null ? 0 : SelectedFltTurList.TL_KEY).ShowDialog();
        }
        #endregion
    }
}