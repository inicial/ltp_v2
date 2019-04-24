using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using AgencyManager.ObjectModel;
using ltp_v2.Controls;
using ltp_v2.Framework;

namespace AgencyManager
{
    public partial class frmNewRegistration : Form
    {
        #region Свойства
        private frmMasterPartners _frmMasterPartners;
        private PartnersListDataContext _PLDC;
        private PartnersListDataContext PLDC
        {
            get
            {
                return _PLDC;
            }
            set
            {
                if (_PLDC != null)
                    _PLDC.Dispose();
                _PLDC = value;
            }
        }
        private bool IsNeedAutoRefresh;
        private List<PrtDogTypes> FilterListDogovorTypes;
        IQueryable<LTP_TempPartner> _UsedQueryable;
        IQueryable<LTP_TempPartner> UsedQueryable
        {
            set 
            {
                var lwWaitScreen = new ltp_v2.Controls.Forms.lwWaitScreen();
                lwWaitScreen.Show();

                _UsedQueryable = value;
                NewPartnersDGV.DataSource = value.OrderByDescending(x => x.LTP_PRKey).ThenBy(x => x.LTP_Name);

                lwWaitScreen.Close();
            }
            get { return _UsedQueryable; }
        }
        #endregion

        #region Конструктор
        public frmNewRegistration()
        {
            IsNeedAutoRefresh = false;
            InitializeComponent();
            
            PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);
            FilterListDogovorTypes = new List<PrtDogTypes>();

            IsNeedAutoRefresh = true;

            tsBtnDelete.Visible = tsBtnMoveToMaster.Visible = Permission.Get.LTP_AC_NewRegistration;
        }
        #endregion

        #region Методы
        public void SetBaseFilters()
        {
            PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);

            if (!IsNeedAutoRefresh)
                return;

            var result = PLDC.LTP_TempPartners_By_Permission.Where(x => x.LTP_Name != "");

            List<int> LdtIdArray = new List<int>();
            if (FilterListDogovorTypes.Count > 0)
            {
                var drLinks =   from res in result
                                from drLink in PLDC.LTP_PrtDogLinks
                                where res == drLink.LTP_TempPartner
                                    && FilterListDogovorTypes.Select(x => x.PDT_ID).Contains(drLink.LTD_LDTID)
                                select drLink;

                result = result.Where(x => drLinks.Single(x2 => x2.LTD_LTPID == x.LTP_ID) != null);
            }

            if (tsBtnGetUsed.Checked)
            {
                result = result.Where(x => x.MakeDateTime != null);
            }
            else if (tsBtnGetNew.Checked)
            {
                result = result.Where(x => x.MakeDateTime == null);
            }
            if (!string.IsNullOrEmpty(edt_filter_Name.Text.Trim()))
            {
                result = result.Where(x =>
                        x.LTP_Name.Contains(edt_filter_Name.Text) ||
                        x.LTP_FullName.Contains(edt_filter_Name.Text) ||
                        x.LTP_NameLat.Contains(edt_filter_Name.Text));
            }
            if (!string.IsNullOrEmpty(edt_filter_Phone.Text.Trim()))
            {
                result = result.Where(x =>
                    x.LTP_Phone.Contains(edt_filter_Phone.Text));
            }
            if (!string.IsNullOrEmpty(edt_filter_EMail.Text.Trim()))
            {
                result = result.Where(x =>
                        x.LTP_EmailSpam.Contains(edt_filter_EMail.Text) ||
                        x.LTP_EmailBuh.Contains(edt_filter_EMail.Text) ||
                        x.LTP_EmailRasilka.Contains(edt_filter_EMail.Text));
            }
            if (!string.IsNullOrEmpty(edt_filter_Fax.Text.Trim()))
            {
                result = result.Where(x =>
                    x.LTP_Fax1.Contains(edt_filter_Fax.Text));
            }
            if (!string.IsNullOrEmpty(edt_filter_Inn.Text.Trim()))
            {
                result = result.Where(x =>
                    x.LTP_INN.Contains(edt_filter_Inn.Text));
            }

            if (!string.IsNullOrEmpty(edt_filter_Address.Text.Trim()))
            {
                result = result.Where(x=>x.LTP_Adress.ToUpper().Contains(edt_filter_Address.Text.ToUpper()));
            }

            UsedQueryable = result.OrderByDescending(x => x.InsertedDateTime.Date).ThenBy(x => x.LTP_Name);
            //result.Clear();
        }
        #endregion

        #region Обработка событий
        private void frmNewRegistration_Load(object sender, EventArgs e)
        {
            SetBaseFilters();
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);
            SetBaseFilters();
        }

        private void NewPartnersDGV_DataSourceChanged(object sender, EventArgs e)
        {
            NewPartnersDGV.AutoGenerateColumns = false;
            NewPartnersDGV.Columns.Clear();
            NewPartnersDGV.Columns.AddColumns("LTP_Name", "Название агентства");
            NewPartnersDGV.Columns["LTP_Name"].SortMode = DataGridViewColumnSortMode.Programmatic;
            NewPartnersDGV.Columns.AddColumns("LTP_Adress", "Адрес");
            NewPartnersDGV.Columns.AddColumns("LTP_Phone", "Телефон");
            NewPartnersDGV.Columns.AddColumns("LTP_INN", "ИНН");
            NewPartnersDGV.Columns.AddColumns("LTP_EmailSpam", "E-Mail");
            NewPartnersDGV.Columns.AddColumns("InsertedDateTime", "Дата регистрации", "dd.MM.yyyy HH:mm");
            if (UsedQueryable.Where(x => x.MakeDateTime != null).Count() > 0)
                NewPartnersDGV.Columns.AddColumns("MakeDateTime", "Дата обработки", "dd.MM.yyyy HH:mm");
            NewPartnersDGV.Columns.AddColumns("NeedDogovors", "Необходимость договоров");
            tssCountRows.Text = "Записей на экране: " + UsedQueryable.Count().ToString();
        }

        private void edtFilterTextChange(object sender, EventArgs e)
        {
            if (((ltp_v2.Controls.Forms.lwFilterTextBox)sender).IsChangeText)
                SetBaseFilters();
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите скрыть " + this.NewPartnersDGV.SelectedRows.Count + " регистраций"
                , "Скрытие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            PartnersListDataContext PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);
            foreach (DataGridViewRow dgvrSelectedItem in this.NewPartnersDGV.SelectedRows)
            {
                LTP_TempPartner dgBI = ((LTP_TempPartner)dgvrSelectedItem.DataBoundItem);
                LTP_TempPartner tmpPRT = PLDC.LTP_TempPartners.Where(x => x.LTP_ID == dgBI.LTP_ID).First();
                dgBI.MakeDateTime = DateTime.Now;
                tmpPRT.MakeDateTime = DateTime.Now;
                tmpPRT.LTP_WhoMake = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FullName;
            }

            if (PLDC.GetChangeSet().Updates.Count != 0)
            {
                PLDC.SubmitChanges();
                SetBaseFilters();
            }
        }

        private void tsBtnMoveToMaster_Click(object sender, EventArgs e)
        {
            LTP_TempPartner UsedPartnerRegistration = (LTP_TempPartner)this.NewPartnersDGV.SelectedRows[0].DataBoundItem;

            if (UsedPartnerRegistration.LTP_PRKey.HasValue)
            {
                FormsForPartners.frmMoveValues frmMoveValues = new FormsForPartners.frmMoveValues(UsedPartnerRegistration, UsedPartnerRegistration.tbl_Partners);
                frmMoveValues.ShowDialog();
                return;
            }

            if (_frmMasterPartners == null)
                _frmMasterPartners = new frmMasterPartners(UsedPartnerRegistration);
            else
                _frmMasterPartners.FilerByPIR = UsedPartnerRegistration;
            
            _frmMasterPartners.BindingDataFilter();


            if (_frmMasterPartners.ShowDialog() == DialogResult.OK)
            {
                tbl_Partners UsedPartnerInMaster = _frmMasterPartners.SelectedPartnerInMaster;
                FormsForPartners.frmMoveValues frmMoveValues = new FormsForPartners.frmMoveValues(UsedPartnerRegistration, UsedPartnerInMaster);
                frmMoveValues.ShowDialog();
            }
            else if (MessageBox.Show("Вы хотите создать нового?", "Перенос данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormsForPartners.frmMoveValues frmMoveValues = new FormsForPartners.frmMoveValues(UsedPartnerRegistration);
                frmMoveValues.ShowDialog();
            }
        }

        private void tsBtnGetUsed_CheckedChanged(object sender, EventArgs e)
        {
            if (!tsBtnGetUsed.Checked && !tsBtnGetNew.Checked)
                tsBtnGetNew.Checked = true;
            if (tsBtnGetUsed.Checked)
            {
                tsBtnGetUsed.Image = global::AgencyManager.Properties.Resources.Check;
                tsBtnGetNew.Checked = false;
                SetBaseFilters();
            }
            else
            {
                tsBtnGetUsed.Image = global::AgencyManager.Properties.Resources.UnCheck;
            }
        }

        private void tsBtnGetNew_CheckedChanged(object sender, EventArgs e)
        {
            if (!tsBtnGetUsed.Checked && !tsBtnGetNew.Checked)
                tsBtnGetUsed.Checked = true;
            if (tsBtnGetNew.Checked)
            {
                tsBtnGetNew.Image = global::AgencyManager.Properties.Resources.Check;
                tsBtnGetUsed.Checked = false;
                SetBaseFilters();
            }
            else
            {
                tsBtnGetNew.Image = global::AgencyManager.Properties.Resources.UnCheck;
            }
        }

        private void NewPartnersDGV_SelectionChanged(object sender, EventArgs e)
        {
            tsBtnDelete.Enabled = NewPartnersDGV.SelectedRows.Count > 0;
            tsBtnMoveToMaster.Enabled = NewPartnersDGV.SelectedRows.Count == 1;
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
        }
        #endregion

        private void frmNewRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PLDC != null)
                PLDC.Dispose();
            
            if (_frmMasterPartners != null && !_frmMasterPartners.IsDisposed)
                _frmMasterPartners.Dispose();
            if (FilterListDogovorTypes != null)
                FilterListDogovorTypes.Clear();

            _frmMasterPartners = null;
            FilterListDogovorTypes = null;
            PLDC = null;
        }

        private void NewPartnersDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in NewPartnersDGV.Rows)
            {
                LTP_TempPartner partReg = (LTP_TempPartner)dgvr.DataBoundItem;
                if (partReg.LTP_PRKey.HasValue)
                    dgvr.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
            }
        }
    }
}