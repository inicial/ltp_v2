using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq.SqlClient;

using AgencyManager.ObjectModel;

using ltp_v2.Controls;
using ltp_v2.Framework;

namespace AgencyManager
{
    public partial class frmMasterPartners : Form
    {
        enum FormOpenedState
        {
            IsFidningDoublicate,
            IsFindingAgency,
            IsPartnerList
        }

        #region Свойства

        private FormOpenedState FrmOpenedState = FormOpenedState.IsPartnerList;

        public tbl_Partners SelectedPartnerInMaster
        {
            get
            {
                if (PartnersDGV.SelectedRows.Count == 0)
                    return null;
                return ((tbl_Partners)PartnersDGV.SelectedRows[0].DataBoundItem);
            }
        }
        bool IsNeedAutoRefresh;
        PartnersListDataContext PLDC;

        List<PrtDogTypes> FilterListDogovorTypes;
        List<PrtType> FilterListPrtTypes;
        IQueryable<int> FilterByPRKey;
        public LTP_TempPartner FilerByPIR;
        IQueryable<tbl_Partners> _UsedQueryable;
        IQueryable<tbl_Partners> UsedQueryable
        {
            set
            {
                _UsedQueryable = value;
                var lwWaitScreen = new ltp_v2.Controls.Forms.lwWaitScreen();
                lwWaitScreen.Show();
                PartnersDGV.DataSource = value.OrderBy(x => x.PR_NAME).ToList();
                lwWaitScreen.Close();
            }
            get { return _UsedQueryable; }
        }
        #endregion

        #region Конструктор
        public frmMasterPartners()
        {
            IsNeedAutoRefresh = false;
            InitializeComponent();
            label5.Text = "";
            PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);
            FilterListDogovorTypes = new List<PrtDogTypes>();
            FilterListPrtTypes = new List<PrtType>();

            edt_filter_Code.Text = "";
            edt_filter_Name.Text = "";
            edt_filter_Phone.Text = "";
            edt_filter_Fax.Text = "";
            edt_filter_EMail.Text = "";
            
            IsNeedAutoRefresh = true;
            FrmOpenedState = FormOpenedState.IsPartnerList;
        }

        public frmMasterPartners(IQueryable<int> filterByPRKey, PartnersListDataContext pldc)
            :this()
        {
            this.PLDC = pldc;
            this.FilterByPRKey = filterByPRKey;
            BindingDataFilter();
        }

        public frmMasterPartners(LTP_TempPartner PRItem)
            : this()
        {
            IsNeedAutoRefresh = false;
            this.DialogResult = DialogResult.Cancel;
            FilerByPIR = PRItem;
            IsNeedAutoRefresh = true;

            FrmOpenedState = FormOpenedState.IsFidningDoublicate;
        }

        /// <summary>
        /// Открытие формы для поиска агентства
        /// </summary>
        public frmMasterPartners(int emptyArgument) : this()
        {
            IsNeedAutoRefresh = false;
            this.DialogResult = DialogResult.Cancel;
            IsNeedAutoRefresh = true;
            FrmOpenedState = FormOpenedState.IsFindingAgency;
        }
        #endregion

        #region Методы
        private void SetEnabledByPermission()
        {
            tsBtnMoveToMaster.Enabled =
                tsBtnEdit.Enabled =
                tsBtnSendMail.Enabled =
                tsBtnHistory.Enabled = PartnersDGV.SelectedRows.Count > 0;

            tsBtnMoveToMaster.Visible = (FrmOpenedState != FormOpenedState.IsPartnerList);

            tsBtnSendMail.Visible = tsBtnCreateNew.Visible = (FrmOpenedState != FormOpenedState.IsFindingAgency);

            tsBtnEdit.Visible 
                = tsBtnHistory.Visible
                = (FrmOpenedState == FormOpenedState.IsPartnerList);
        }

        public void BindingDataFilter()
        {
            SetEnabledByPermission();
            if (FilterByPRKey != null)
            {
                UsedQueryable =
                    (from prt in PLDC.tbl_Partners_By_Permission
                     from flt in FilterByPRKey.GroupBy(x => x).Select(x => x.Key)
                     where flt == prt.PR_KEY
                     orderby prt.PR_NAME
                     select prt);
            }
            else if (FilerByPIR != null)
            {
                UsedQueryable = BindingFilterByPIR(FilerByPIR).OrderBy(x => x.PR_NAME);
            }
            else
            {
                UsedQueryable =
                    (from prt in PLDC.tbl_Partners
                     orderby prt.PR_NAME
                     select prt);
            }

            IsNeedAutoRefresh = false;
            if (FilerByPIR != null || FilterByPRKey != null)
            {
                label5.Text = "Использован спец.фильтр";
                FilerByPIR = null;
                FilterByPRKey = null;
            }
            else
                label5.Text = "";

            IsNeedAutoRefresh = true;
        }

        public IQueryable<tbl_Partners> BindingFilterByPIR(LTP_TempPartner PRItem)
        {
            var tmpQueryable = PLDC.tbl_Partners_By_Permission.Where(x => x.PR_INN.Contains(PRItem.LTP_INN));
            #region Поиск совпадений в мастер-тур
            if (PRItem.LTP_PRKey.HasValue)
            {
                tmpQueryable = PLDC.tbl_Partners_By_Permission.Where(x => x.PR_KEY == PRItem.LTP_PRKey);
            }
            // Сопадение по ИНН
            else if (tmpQueryable.Count() > 0)
            {
                edt_filter_Inn.Text = PRItem.LTP_INN;
            }
            // Полное совпадение данных не cчитая ИНН
            else if ((tmpQueryable =
                PLDC.tbl_Partners_By_Permission.Where(x =>
                    (
                        x.PR_NAME.Contains(PRItem.LTP_Name)
                        || x.PR_NAME.Contains(PRItem.LTP_NameLat)
                        || x.PR_NAME.Contains(PRItem.LTP_FullName)
                        || x.PR_NAMEENG.Contains(PRItem.LTP_Name)
                        || x.PR_NAMEENG.Contains(PRItem.LTP_NameLat)
                        || x.PR_NAMEENG.Contains(PRItem.LTP_FullName)
                        || x.PR_FULLNAME.Contains(PRItem.LTP_Name)
                        || x.PR_FULLNAME.Contains(PRItem.LTP_NameLat)
                        || x.PR_FULLNAME.Contains(PRItem.LTP_FullName)
                    ) && (
                        x.PR_PHONES.Contains(PRItem.LTP_Phone)
                    ) && (
                        x.PR_FAX.Contains(PRItem.LTP_Fax1)
                    ) && (
                        x.PR_EMAIL.Contains(PRItem.LTP_EmailBuh)
                        || x.PR_EMAIL.Contains(PRItem.LTP_EmailRasilka)
                        || x.PR_EMAIL.Contains(PRItem.LTP_EmailSpam)
                    )
                )).Count() > 0)
            {
                edt_filter_Name.Text = PRItem.LTP_Name;
                edt_filter_Phone.Text = PRItem.LTP_Phone;
                edt_filter_Fax.Text = PRItem.LTP_Fax1;
                edt_filter_EMail.Text = PRItem.LTP_EmailSpam;
            }
            // Совпадения только по наванию
            else if ((tmpQueryable = PLDC.tbl_Partners_By_Permission.Where(x =>
                    (
                        PRItem.LTP_Name != "" && (
                            x.PR_NAME.Contains(PRItem.LTP_Name)
                            || x.PR_NAMEENG.Contains(PRItem.LTP_Name)
                            || x.PR_FULLNAME.Contains(PRItem.LTP_Name)
                        ) ||
                        PRItem.LTP_FullName != "" && (
                            x.PR_NAME.Contains(PRItem.LTP_FullName)
                            || x.PR_NAMEENG.Contains(PRItem.LTP_FullName)
                            || x.PR_FULLNAME.Contains(PRItem.LTP_FullName)
                        ) ||
                        PRItem.LTP_NameLat != "" && (
                            x.PR_NAME.Contains(PRItem.LTP_NameLat)
                            || x.PR_NAMEENG.Contains(PRItem.LTP_NameLat)
                            || x.PR_FULLNAME.Contains(PRItem.LTP_NameLat)
                        )
                    ))).Count() > 0)
            {
                edt_filter_Name.Text = PRItem.LTP_Name;
            }
            // Совпадения только по телефону
            else if ((tmpQueryable = PLDC.tbl_Partners_By_Permission.Where(x => x.PR_PHONES.Contains(PRItem.LTP_Phone))).Count() > 0)
            {
                edt_filter_Phone.Text = PRItem.LTP_Phone;
            }
            // Совпадения только по эл.почте
            else if ((tmpQueryable = PLDC.tbl_Partners_By_Permission.Where(x => x.PR_EMAIL.Contains(PRItem.LTP_EmailBuh)
                                 || x.PR_EMAIL.Contains(PRItem.LTP_EmailRasilka)
                                 || x.PR_EMAIL.Contains(PRItem.LTP_EmailSpam))).Count() > 0)
            {
                edt_filter_EMail.Text = PRItem.LTP_EmailSpam;
            }
            else
            {
                MessageBox.Show("Схожих записей в основной базе Мастера не найдено, попробуйте найти самостоятельно");
            }
            #endregion
            
            // Определение более подходящего названия
            if (edt_filter_Name.Text != "")
            {
                int Count_Name = tmpQueryable.Where(x =>
                        x.PR_NAME.Contains(PRItem.LTP_Name)
                        || x.PR_NAMEENG.Contains(PRItem.LTP_Name)
                        || x.PR_FULLNAME.Contains(PRItem.LTP_Name)
                    ).Count();
                int Count_NameLat = (PRItem.LTP_NameLat != ""
                       ? tmpQueryable.Where(x =>
                        x.PR_NAME.Contains(PRItem.LTP_NameLat)
                        || x.PR_NAMEENG.Contains(PRItem.LTP_NameLat)
                        || x.PR_FULLNAME.Contains(PRItem.LTP_NameLat)
                        ).Count() : 0);

                int Count_FullName = (PRItem.LTP_FullName != ""
                        ? tmpQueryable.Where(x =>
                        x.PR_NAME.Contains(PRItem.LTP_FullName)
                        || x.PR_NAMEENG.Contains(PRItem.LTP_FullName)
                        || x.PR_FULLNAME.Contains(PRItem.LTP_FullName)
                        ).Count() : 0);

                if (Count_Name > Count_NameLat && Count_Name > Count_FullName)
                    edt_filter_Name.Text = PRItem.LTP_Name;
                else if (Count_FullName > Count_NameLat)
                    edt_filter_Name.Text = PRItem.LTP_FullName;
                else
                    edt_filter_Name.Text = PRItem.LTP_NameLat;
            }

            // Определение более подходящего E-Mail
            if (edt_filter_EMail.Text != "")
            {
                int Count_Buh = tmpQueryable.Where(x => x.PR_EMAIL.Contains(PRItem.LTP_EmailBuh)).Count();
                int Count_Rasilka = tmpQueryable.Where(x => x.PR_EMAIL.Contains(PRItem.LTP_EmailRasilka)).Count();
                int Count_Spam = tmpQueryable.Where(x => x.PR_EMAIL.Contains(PRItem.LTP_EmailSpam)).Count();

                if (Count_Buh > Count_Rasilka && Count_Buh > Count_Spam)
                    edt_filter_EMail.Text = PRItem.LTP_EmailBuh;
                else if (Count_Rasilka > Count_Spam)
                    edt_filter_EMail.Text = PRItem.LTP_EmailRasilka;
                else
                    edt_filter_EMail.Text = PRItem.LTP_EmailSpam;
            }
            return tmpQueryable;
        }

        /// <summary>
        /// Вывод всех данных
        /// </summary>
        public void SetBaseFilters()
        {
            if (!IsNeedAutoRefresh)
                return;

            try
            {
                var tmpQueryable = PLDC.tbl_Partners_By_Permission;
                
                if (FilterListDogovorTypes.Count > 0)
                {
                    tmpQueryable =
                        from q in tmpQueryable
                        from dr in PLDC.LTP_PrtDogs
                        where q.PR_KEY == dr.LTPD_PRKey
                            && FilterListDogovorTypes.Select(x => x.PDT_ID).Contains(dr.LTPD_DogovorTypeID)
                            && dr.LTPD_DateEnd.Date >= DateTime.Now.Date
                            && dr.LTPD_DateStart.Date <= DateTime.Now.Date
                        select q;
                }

                if (!string.IsNullOrEmpty(edt_filter_DogovorNum.Text.Trim()))
                {
                    tmpQueryable = tmpQueryable.Where(x => x.LTP_PrtDogs.First(x2 => x2.LTPD_DogNum.Contains(edt_filter_DogovorNum.Text)) != null);
                }

                if (FilterListPrtTypes.Count > 0)
                {
                    tmpQueryable =
                        from q in tmpQueryable
                        from ptp in
                            (
                                from ptp in PLDC.PrtTypesToPartners
                                where FilterListPrtTypes.Select(x => x.PT_Id).Contains(ptp.PTP_PTId)
                                group ptp by ptp.PTP_PRKey into g
                                select g.Key
                                )
                        where q.PR_KEY == ptp
                        select q;
                }

                // Установка фильтра по коду агентства
                if (!string.IsNullOrEmpty(edt_filter_Code.Text.Trim()))
                    tmpQueryable = tmpQueryable.Where(x => x.PR_COD == edt_filter_Code.Text);

                // Установка фильтра по названию
                if (!string.IsNullOrEmpty(edt_filter_Name.Text.Trim()))
                    tmpQueryable = tmpQueryable.Where(x => x.PR_NAME.Contains(edt_filter_Name.Text)
                                || x.PR_NAMEENG.Contains(edt_filter_Name.Text)
                                || x.PR_FULLNAME.Contains(edt_filter_Name.Text));

                // Установка фильтра по телефону
                if (!string.IsNullOrEmpty(edt_filter_Phone.Text.Trim()))
                    tmpQueryable = tmpQueryable.Where(x => x.PR_PHONES.Contains(edt_filter_Phone.Text));

                // Установка фильтра по факсу
                if (!string.IsNullOrEmpty(edt_filter_Fax.Text.Trim()))
                    tmpQueryable = tmpQueryable.Where(x => x.PR_FAX.Contains(edt_filter_Fax.Text));

                // Установка фильтра по EMail
                if (!string.IsNullOrEmpty(edt_filter_EMail.Text.Trim()))
                    tmpQueryable = tmpQueryable.Where(x => x.PR_EMAIL.Contains(edt_filter_EMail.Text));

                // Установка фильтра по INN
                if (!string.IsNullOrEmpty(edt_filter_Inn.Text.Trim()))
                    tmpQueryable = tmpQueryable.Where(x => x.PR_INN.Contains(edt_filter_Inn.Text));

                if (edt_filter_Login.Text.Trim().Length > 3)
                {
                    var duPrKeyList = (from dU in PLDC.DUP_USERs
                                       where dU.US_ID.Contains(edt_filter_Login.Text)
                                            && dU.US_PRKEY != null
                                       select dU.US_PRKEY).ToList();
                    tmpQueryable = tmpQueryable.Where(x => duPrKeyList.Contains(x.PR_KEY));
                }

                UsedQueryable = tmpQueryable;
            }
            catch
            {

            }
        }
        #endregion

        #region Обработка событий
        private void PartnersDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PartnersDGV.AutoGenerateColumns = false;
            PartnersDGV.Columns.Clear();
            PartnersDGV.Columns.AddColumns("PR_Cod", "Код агенства");
            try
            {
                PartnersDGV.Columns["PR_Cod"].Width = 100;
            }
            catch { }
            PartnersDGV.Columns.AddColumns("PR_NAME", "Краткое название");
            PartnersDGV.Columns.AddColumns("PR_Phones", "Телефон");
            PartnersDGV.Columns.AddColumns("PR_Fax1", "Факс");
            PartnersDGV.Columns.AddColumns("PR_EMail", "E-Mail для рассылки");
            PartnersDGV.Columns.AddColumns("PR_Inn", "ИНН");
            PartnersDGV.Columns.AddColumns("PR_City", "Город");
            PartnersDGV.Columns.AddColumns("ActiveDogovors", "Активные договора");
            PartnersDGV.Columns.AddColumns("NotActiveDogovors", "Неактивные договора текущего и будущих периодов");
            PartnersDGV.Columns.AddColumns("ActiveTempDogovors", "Активированных по копии");
            tssCountRows.Text = "Итого записей: " + PartnersDGV.Rows.Count;
        }

        private void PartnersDGV_SelectionChanged(object sender, EventArgs e)
        {
            tsBtnMoveToMaster.Enabled = (PartnersDGV.SelectedRows.Count == 1);
            tsBtnSendMail.Enabled = (PartnersDGV.SelectedRows.Count == 1);
            tsBtnHistory.Enabled = tsBtnEdit.Enabled = (PartnersDGV.SelectedRows.Count == 1);
        }

        private void edtFilterTextChange(object sender, EventArgs e)
        {
            if (((ltp_v2.Controls.Forms.lwFilterTextBox)sender).IsChangeText)
                SetBaseFilters();
        }

        private void edt_Filter_DogovorType_Click(object sender, EventArgs e)
        {
            FormsForPartners.frmSetDogovorTypes frmSetDogovorTypes = new FormsForPartners.frmSetDogovorTypes();
            frmSetDogovorTypes.CheckedList = FilterListDogovorTypes;
            if (frmSetDogovorTypes.ShowDialog() == DialogResult.OK)
            {
                FilterListDogovorTypes = frmSetDogovorTypes.CheckedList;
                edt_Filter_DogovorType.Text = "";
                foreach (PrtDogTypes dtmItem in FilterListDogovorTypes)
                {
                    edt_Filter_DogovorType.Text += (edt_Filter_DogovorType.Text != "" ? "," : "") + dtmItem.LTP_DogType.LDT_Key;
                }
                SetBaseFilters();
            }
            frmSetDogovorTypes.ClearFormFromMemory();
        }

        private void edt_Filter_PartnerType_Click(object sender, EventArgs e)
        {
            FormsForPartners.frmPartnerTypes frmPartnerTypes = new AgencyManager.FormsForPartners.frmPartnerTypes(PLDC);
            frmPartnerTypes.CheckedList = FilterListPrtTypes;
            if (frmPartnerTypes.ShowDialog() == DialogResult.OK)
            {
                FilterListPrtTypes = frmPartnerTypes.CheckedList;
                edt_Filter_PartnerType.Text = "";
                if (FilterListPrtTypes.Count > 0)
                {
                    edt_Filter_PartnerType.Text = "Имеется фильтр";
                }
                SetBaseFilters();
            }
            frmPartnerTypes.ClearFormFromMemory();
        }

        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            SetBaseFilters();
        }

        private void tsBtnMoveToMaster_Click(object sender, EventArgs e)
        {
            if (SelectedPartnerInMaster == null)
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tsBtnCreateNew_Click(object sender, EventArgs e)
        {
            var frmEdtPartner = new FormsForPartners.frmEditPartner();
            frmEdtPartner.ShowDialog();
            frmEdtPartner.ClearFormFromMemory();
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            var frmEdtPartner = new FormsForPartners.frmEditPartner(SelectedPartnerInMaster.PR_KEY);
            frmEdtPartner.ShowDialog();
            frmEdtPartner.ClearFormFromMemory();
        }

        private void tsBtnSendMail_Click(object sender, EventArgs e)
        {
            var frmEdtPartner = new FormsForPartners.frmSendMail(SelectedPartnerInMaster.PR_KEY);
            frmEdtPartner.ShowDialog();
            frmEdtPartner.ClearFormFromMemory();
            SetBaseFilters();
        }

        private void PartnersDGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetEnabledByPermission();
            string resultInfoText = "";
            tbl_Partners SelectedPIM = (tbl_Partners)PartnersDGV.Rows[e.RowIndex].DataBoundItem;

            resultInfoText = "<head><style>body{font-size:10pt}</style></head><body>"
                + "<b>Полное название: </b>" + SelectedPIM.PR_FULLNAME + "<br>"
                + "<b>Англ. название: </b>" + SelectedPIM.PR_NAMEENG + "<br>";

            string errorMsg = "";
            var officesOnSuchINN = PLDC.GetTheOfficesOnSuchAnINN(SelectedPIM, out errorMsg);
            if (officesOnSuchINN == null)
            {
                resultInfoText += "<b>Суб. агентств</b><font color=#FF0000> : " + errorMsg + "</font><br>";
            }
            else
            {
                int CountSubAgancy = officesOnSuchINN.Count();
                if (CountSubAgancy > 1)
                {
                    resultInfoText += "<b>Суб. агентств</b> : " + CountSubAgancy.ToString()
                        + " <b>код осн.офиса:</b>"
                        + PLDC.GetTheMainOfficePartner(SelectedPIM, out errorMsg).Select(x=>x.PR_COD).First()
                        + "<br>";
                }
            }
           
            foreach (LTP_PrtDog dcItem in SelectedPIM.LTP_PrtDogs
                .OrderByDescending(x => x.LTPD_DogNum)
                .ThenByDescending(x => x.LTPD_DateEnd)
                .ThenBy(x => x.LTPD_DogovorTypeID))
            {
                int TypeActiveState = dcItem.IsActiveState == DogovorActiveState.Active
                        ? dcItem.LTPD_DateStart.Date <= DateTime.Now.Date && dcItem.LTPD_DateEnd.Date >= DateTime.Now.Date
                            ? 1
                            : dcItem.LTPD_DateEnd.Date >= DateTime.Now.Date
                                    ? 2
                                    : 3
                        : dcItem.IsActiveState == DogovorActiveState.TmpActive
                                        ? 4
                                        : 0;
                resultInfoText += "<font color='" 
                    + (
                        TypeActiveState == 0 ? "#000"
                            : TypeActiveState == 1 ? "#55FF55"
                                : TypeActiveState == 2 ? "#DD99DD"
                                    : TypeActiveState == 3 ? "#004400"
                                        : "#FF0000")
                    +"'>"
                    +"&emsp;<b>" + dcItem.LTPD_DogNum + "</b>"
                    + " с " + dcItem.LTPD_DateStart.ToString("dd.MM.yyyy")
                    + " по " + dcItem.LTPD_DateEnd.ToString("dd.MM.yyyy")
                    + " - " + (
                        TypeActiveState == 0 ? "<b>Неактивирован<b>"
                            : TypeActiveState == 1 ? "<b>Активен - текущий</b>"
                                : TypeActiveState == 2 ? "<b>Активен - будущих пер.</b>"
                                    : TypeActiveState == 3 ?"<b>Активен - старый</b>"
                                        : "<b>Активирован по копии</b>, действителен до" + dcItem.LTPD_DateStart.AddDays(dcItem.LTPD_TempActiveCountDayUse).ToString("dd.MM.yyyy"))
                    + "<br></font>"
                    + ((dcItem.Parent_LTPD_Key == null) ? "<br>" : "");
            }
            wbPrtInfo.DocumentText = resultInfoText;
        }

        private void frmMasterPartners_Load(object sender, EventArgs e)
        {
            SetEnabledByPermission();
        }
        
        private void tsBtnHistory_Click(object sender, EventArgs e)
        {
            var frmHistory = new FormsForPartners.frmHistory(SelectedPartnerInMaster.PR_KEY);
            frmHistory.ShowDialog();
            frmHistory.ClearFormFromMemory();
        }
        #endregion
    }
}