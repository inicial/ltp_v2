using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;
using ltp_v2.Controls.Forms;
using AgencyManager.FormsForAccounts;
using AgencyManager.FormsForDogovor;
using AgencyManager.FormsForAccess;
using ltp_v2.Controls;
using ltp_v2.Framework;
using System.Data.Linq;

namespace AgencyManager.FormsForPartners
{
    public partial class frmEditPartner : Form
    {
        #region Свойства
        PartnersListDataContext CurrentUsePLDC;
        CallCenter.CallCenterDataContext CallCenterDC;
        tbl_Partners CurrentEditPIM;
        frmLantaOnLine formLantaOnLine;
        frmPartnerTypes formPartnerTypes;
        frmDogovorsList formDogovorsList;
        frmAviaOnLine formAviaOnLine;
        List<frmAccountInformation> ListUseAccountInformationForm = new List<frmAccountInformation>();
        StreamForms streamControls;
        Control PresentError;
        bool PresentIsEditCtrl = false;
        int? CurrentPartnerKey;
        #endregion

        #region Методы
        private void ClosingMDIForms()
        {
            if (formPartnerTypes != null)
                formPartnerTypes.Close();
            if (formLantaOnLine != null)
                formLantaOnLine.Close();
            if (formAviaOnLine != null)
                formAviaOnLine.Close();
            if (formDogovorsList != null)
                formDogovorsList.Close();

            foreach (frmAccountInformation AIItem in ListUseAccountInformationForm)
                AIItem.Close();
        }
       
        private void RefreshBindingData()
        {
            var lwWaitScreen = new ltp_v2.Controls.Forms.lwWaitScreen();
            lwWaitScreen.Show();

            CurrentUsePLDC = new PartnersListDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            CallCenterDC = new CallCenter.CallCenterDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            DataLoadOptions DLO = new DataLoadOptions();
            DLO.LoadWith<tbl_Partners>(x => x.PrtTypesToPartners);
            DLO.LoadWith<tbl_Partners>(x => x.LTP_PrtDogs);
            CurrentUsePLDC.LoadOptions = DLO;

            if (this.CurrentPartnerKey != null)
            {
                CurrentEditPIM = CurrentUsePLDC.tbl_Partners.Where(x => x.PR_KEY == CurrentPartnerKey.Value).First();
            }

            lwWaitScreen.Close();

            PresentIsEditCtrl = false;
            if (CurrentPartnerKey == null)
            {
                CurrentEditPIM = new tbl_Partners();
                CurrentUsePLDC.tbl_Partners.InsertOnSubmit(CurrentEditPIM);
            }
            
            this.Text = "Изменение информации о партнере:" + CurrentEditPIM.NameForForms;
 
            ClosingMDIForms();

            mt_CountryDictionary.DataSource = CurrentUsePLDC.tbl_Countries.Where(x => x.CN_NAME != "").OrderBy(x => x.CN_NAME);
            mt_CountryDictionary.DisplayMember = "CN_Name";
            mt_CountryDictionary.ValueMember = "CN_Key";
            mt_CountryDictionary.DefaultValue = 460;

            mt_OWNER.DataSource = CurrentUsePLDC.dict_UserLists.OrderBy(x => x.US_FullName);
            mt_OWNER.DisplayMember = "US_FullName";
            mt_OWNER.ValueMember = "US_Key";
            mt_OWNER.DefaultValue = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_KEY;

            PR_PGKey.DataSource = CurrentUsePLDC.dict_PrtGroups.OrderBy(x => x.PG_Name);
            PR_PGKey.DisplayMember = "PG_Name";
            PR_PGKey.ValueMember = "PG_Key";

            mt_MetroID.SetDefaultMetroStation_Required(CurrentUsePLDC);
            if (CurrentEditPIM.LCC_Partner != null)
                mt_MetroID.DefaultValue = CurrentEditPIM.LCC_Partner.LCP_MSID;
            else
                mt_MetroID.SelectedIndex = 0;

            this.mt_Fax.DefaultText = CurrentEditPIM.PR_FAX;
            this.mt_ADDITIONALINFO.DefaultText = CurrentEditPIM.PR_ADDITIONALINFO;
            this.mt_Address.DefaultText = CurrentEditPIM.PR_ADRESS;
            this.mt_BossType.DefaultText = CurrentEditPIM.PR_BOSS;
            this.mt_BossName.DefaultText = CurrentEditPIM.BossName;
            this.mt_BossFName.DefaultText = CurrentEditPIM.BossFName;
            this.mt_BossSName.DefaultText = CurrentEditPIM.BossSName;

            this.mt_Cod.DefaultText = CurrentEditPIM.PR_COD;
            this.mt_CODEOKONH.DefaultText = CurrentEditPIM.PR_CODEOKONH;
            this.mt_CODEOKPO.DefaultText = CurrentEditPIM.PR_CODEOKPO;
            this.mt_EMAIL.DefaultText = CurrentEditPIM.PR_EMAIL;
            this.mt_FullName.DefaultText = CurrentEditPIM.PR_FULLNAME;
            this.mt_Http.DefaultText = CurrentEditPIM.PR_Http;
            this.mt_INN.DefaultText = CurrentEditPIM.PR_INN;
            this.mt_KPP.DefaultText = CurrentEditPIM.PR_KPP;
            this.mt_LEGALADDRESS.DefaultText = CurrentEditPIM.PR_LEGALADDRESS;
            this.mt_LEGALPOSTINDEX.DefaultText = CurrentEditPIM.PR_LEGALPOSTINDEX;
            this.mt_LICENSENUMBER.DefaultText = CurrentEditPIM.PR_LICENSENUMBER;
            this.mt_NAME.DefaultText = CurrentEditPIM.PR_NAME;
            this.mt_NameEng.DefaultText = CurrentEditPIM.PR_NAMEENG;
            this.mt_OWNER.DefaultValue = CurrentEditPIM.PR_OWNER;
            this.PR_PGKey.DefaultValue = CurrentEditPIM.PR_PGKEY;
            this.mt_PHONES.DefaultText = CurrentEditPIM.PR_PHONES;
            this.mt_PostIndex.DefaultText = CurrentEditPIM.PR_POSTINDEX;
            this.PR_RegisterNumber.DefaultText = CurrentEditPIM.PR_RegisterNumber;
            this.mt_RegisterSeries.DefaultText = CurrentEditPIM.PR_RegisterSeries;

            if (CurrentEditPIM.CityDictionary != null)
            {
                this.mt_CountryDictionary.DefaultValue = CurrentEditPIM.CityDictionary.CT_CNKEY;
                this.mt_CityDictionary.DefaultValue = CurrentEditPIM.PR_CTKEY;
            }

            if (CurrentEditPIM.LTP_PartnerAddsValue == null)
                CurrentEditPIM.LTP_PartnerAddsValue = new LTP_PartnerAddsValue();

            this.mt_BossWorkWith.DefaultText = CurrentEditPIM.LTP_PartnerAddsValue.PRL_BossWorkWith;
            this.PRL_BossMobilePhone.DefaultText = CurrentEditPIM.LTP_PartnerAddsValue.PRL_BossMobilePhone;
            this.PRL_UnicalBossCode.DefaultText = CurrentEditPIM.LTP_PartnerAddsValue.PRL_UnicalBossCode;
            if (PRL_UnicalBossCode.Text.Trim() != "")
            {
                btnCreateUBC.Enabled = false;
                btnCreateUBC.Text = "УКР Имеется";
                btnCreateUBC.BackColor = Color.Green;
            }
            else
            {
                btnCreateUBC.Enabled = true;
                btnCreateUBC.Text = "Создать УКР";
            }

            this.PRL_StartWorkAgency.DefaultValue = CurrentEditPIM.LTP_PartnerAddsValue.PRL_StartWorkAgency;
            this.mt_CodeOGRN.DefaultText = CurrentEditPIM.LTP_PartnerAddsValue.PRL_CodeOGRN;
            this.mt_CodeOKATO.DefaultText = CurrentEditPIM.LTP_PartnerAddsValue.PRL_CodeOKATO;
            this.mt_CodeOKVED.DefaultText = CurrentEditPIM.LTP_PartnerAddsValue.PRL_CodeOKVED;
            
            this.mt_EMailBuh.DefaultText = CurrentEditPIM.LTP_PartnerAddsValue.PRL_EMailBuh;
            this.mt_EmailSpam.DefaultText = CurrentEditPIM.LTP_PartnerAddsValue.PRL_EmailSpam;
            this.mt_EmailBoss.DefaultText = CurrentEditPIM.LTP_PartnerAddsValue.PRL_EMailBoss;

            this.mt_MobilePhone.DefaultText = CurrentEditPIM.LTP_PartnerAddsValue.PRL_MobilePhone;

            if (CurrentEditPIM.LCC_Partner == null)
                CurrentEditPIM.LCC_Partner = new LCC_Partner();

            foreach (PrtAccount PAItem in CurrentEditPIM.PrtAccounts)
            {
                frmAccountInformation fPrtAccount = new frmAccountInformation(CurrentUsePLDC, PAItem);
                fPrtAccount.TopLevel = false;
                fPrtAccount.Dock = DockStyle.Top;
                fPrtAccount.FormBorderStyle = FormBorderStyle.None;
                pnlAccounts.Controls.Add(fPrtAccount);
                fPrtAccount.Show();
                ListUseAccountInformationForm.Add(fPrtAccount);
            }

            formPartnerTypes = new frmPartnerTypes(CurrentUsePLDC, this.CurrentEditPIM);
            formPartnerTypes.FormBorderStyle = FormBorderStyle.None;
            formPartnerTypes.TopLevel = false;
            formPartnerTypes.Dock = DockStyle.Fill;
            pnlListTypesPartner.Controls.Add(formPartnerTypes);
            formPartnerTypes.Show();

            if (gcPassword.Enabled)
            {
                formLantaOnLine = new frmLantaOnLine(CurrentUsePLDC, this.CurrentEditPIM);
                formLantaOnLine.FormBorderStyle = FormBorderStyle.None;
                formLantaOnLine.TopLevel = false;
                formLantaOnLine.Dock = DockStyle.Fill;
                tabOnLine.Controls.Add(formLantaOnLine);
                formLantaOnLine.Show();

                formAviaOnLine = new frmAviaOnLine(CurrentUsePLDC, this.CurrentEditPIM);
                formAviaOnLine.FormBorderStyle = FormBorderStyle.None;
                formAviaOnLine.TopLevel = false;
                formAviaOnLine.Dock = DockStyle.Fill;
                tabAvia.Controls.Add(formAviaOnLine);
                formAviaOnLine.Show();
            }

            if (gcDogovors.Enabled)
            {
                formDogovorsList = new frmDogovorsList(CurrentUsePLDC, CurrentEditPIM);
                formDogovorsList.FormBorderStyle = FormBorderStyle.None;
                formDogovorsList.TopLevel = false;
                formDogovorsList.Dock = DockStyle.Fill;
                gcDogovors.PnlContainer.Controls.Add(formDogovorsList);
                formDogovorsList.Show();
            }

            SubAgencyDGV.AutoGenerateColumns = false;
            SubAgencyDGV.Columns.Clear();

            if (CurrentEditPIM.PR_INN != null)
            {
                string errorMsg = "";
                var q = CurrentUsePLDC.GetTheOfficesOnSuchAnINN(CurrentEditPIM, out errorMsg);
                if (q == null)
                {
                    MessageBox.Show(errorMsg);
                    SubAgencyDGV.DataSource = null;
                }
                else
                {
                    SubAgencyDGV.DataSource = q;
                }
            }
            else
            {
                SubAgencyDGV.DataSource = null;
            }

            SubAgencyDGV.Columns.Clear();
            SubAgencyDGV.Columns.AddColumns("PR_Cod", "Код агенства");
            SubAgencyDGV.Columns["PR_Cod"].Width = 200;
            SubAgencyDGV.Columns.AddColumns("PR_NAME", "Краткое название");
            SubAgencyDGV.Columns.AddColumns("PR_Phones", "Телефон");
        }

        /// <summary>
        /// Проверка на правильность заполнения данных
        /// </summary>
        private bool VerifyErrors()
        {
            this.PresentError = null;
            this.streamControls.Start(this);
            if (this.PresentError != null)
            {
                string ParametrName = ((Control)PresentError).Name.Replace("move_", "").Replace("mt_", "").Replace("tmp_", "");
                Control.ControlCollection CC = ((Control)PresentError).Parent.Controls;
                int LabelId = CC.IndexOfKey("lbl_" + ParametrName);
                Label tmpLBL = CC[LabelId] as Label;
                MessageBox.Show(
                    "Внимание присутствуют ошибки в данных, проверьте данные " + tmpLBL.Text,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                ((Control)PresentError).Focus();
                return true;
            }
            return false;
        }
        #endregion

        #region Конструктор
        public frmEditPartner()
            : this(null)
        {
        }

        public frmEditPartner(int? PartnerKey)
        {
            this.CurrentPartnerKey = PartnerKey;
            InitializeComponent();
            if (CurrentPartnerKey == null)
                tsBtnCallCenter.Enabled = false;
            this.streamControls = new StreamForms();
            this.streamControls.FindControl += new EventHandler(streamControls_FindControl);
        }
        #endregion

        #region Обработка событий
        private void frmEditPartner_Load(object sender, EventArgs e)
        {
            PR_PGKey.Enabled
                = pnlListTypesPartner.Enabled
                = tsBtnCallCenter.Visible
                = tsBtnSave.Visible
                = tsBtnSendMail.Visible
                = tsBtnHistory.Visible
                = tsBtnCancel.Visible
                = tsBtnAKA.Visible
                = gcSubAgency.Visible = gcSubAgency.Enabled
                = gcAccount.Visible = gcAccount.Enabled
                = gcPassword.Visible = gcPassword.Enabled
                = gcDogovors.Visible = gcDogovors.Enabled
                = Permission.Get.LTP_AC_ModifyPartner;

            if (Permission.Get.LTP_AC_ModifyPartner)
            {
                tsBtnSendMail.Enabled
                    = tsBtnHistory.Enabled
                    = tsBtnCancel.Enabled
                    = gcDogovors.Enabled
                    = gcPassword.Enabled = (CurrentPartnerKey != 0);
            }
            RefreshBindingData();
        }

        public void streamControls_FindControl(object sender, EventArgs e)
        {
            if (((Control)sender).Parent != null && !((Control)sender).Parent.Visible)
                return;

            if ((sender.GetType() == typeof(lwDateTimePicker)) && ((lwDateTimePicker)sender).IsEdit)
            {
                PresentIsEditCtrl = true;
            }
            if (sender.GetType() == typeof(lwTextBox))
            {
                if (((lwTextBox)sender).isErrorText)
                {
                    this.PresentError = (Control)sender;
                }
                if (((lwTextBox)sender).isEdit)
                {
                    PresentIsEditCtrl = true;
                }
            }
            if (sender.GetType() == typeof(lwComboBox))
            {
                if (((lwComboBox)sender).isErrorText)
                {
                    this.PresentError = (Control)sender;
                }
                if (((lwComboBox)sender).isEdit)
                {
                    PresentIsEditCtrl = true;
                }
            }
        }

        private void mt_CNKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mt_CityDictionary.DataSource != null)
                ((List<CityDictionary>)mt_CityDictionary.DataSource).Clear();

            mt_CityDictionary.DataSource = ((tbl_Country)mt_CountryDictionary.SelectedItem)
                .CityDictionaries
                .Where(x => x.CT_NAME != "")
                .OrderBy(x => x.CT_NAME).ToList();

            mt_CityDictionary.DisplayMember = "CT_Name";
            mt_CityDictionary.ValueMember = "CT_Key";
            if (((tbl_Country)mt_CountryDictionary.SelectedItem).CN_KEY == 460)
                mt_CityDictionary.DefaultValue = 1;
            else
                mt_CityDictionary.SelectedIndex = 0;
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            streamControls.Start(this);
            if (CurrentUsePLDC.GetChangeSet().Inserts.Count() != 0
                || CurrentUsePLDC.GetChangeSet().Updates.Count() != 0
                || CurrentUsePLDC.GetChangeSet().Deletes.Count() != 0
                || PresentIsEditCtrl)
            {
                if (MessageBox.Show("Есть изменения, Вы хотите продолжить отмену изменений?", "Отмена изменений", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            RefreshBindingData();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if ((mt_BossName.Text.Trim() + " " + mt_BossFName.Text.Trim() + " " + mt_BossSName.Text.Trim()).Length > 40)
            {
                MessageBox.Show("ФИО Руководителя не должно быть более 40 символов у вас " + (mt_BossName.Text.Trim() + " " + mt_BossFName.Text.Trim() + " " + mt_BossSName.Text.Trim()).Length.ToString());
                return;
            }
            if (VerifyErrors()) return;

            if (CurrentEditPIM.PR_CTKEY != (int)mt_CityDictionary.SelectedValue)
                CurrentEditPIM.CityDictionary = (CityDictionary)mt_CityDictionary.SelectedItem;
            if (CurrentEditPIM.PR_CITY != ((CityDictionary)mt_CityDictionary.SelectedItem).CT_NAME)
                CurrentEditPIM.PR_CITY = ((CityDictionary)mt_CityDictionary.SelectedItem).CT_NAME;

            if (CurrentEditPIM.PR_OWNER != (int)mt_OWNER.SelectedValue)
                CurrentEditPIM.dict_UserList = (dict_UserList)mt_OWNER.SelectedItem;

            if (CurrentEditPIM.PR_PGKEY != (int)PR_PGKey.SelectedValue)
                CurrentEditPIM.dict_PrtGroup = (dict_PrtGroup)PR_PGKey.SelectedItem;

            CurrentEditPIM.LCC_Partner.LCC_MetroStation = (LCC_MetroStation)mt_MetroID.SelectedItem;
            CurrentEditPIM.PR_FAX = this.mt_Fax.Text;
            CurrentEditPIM.PR_ADDITIONALINFO = this.mt_ADDITIONALINFO.Text;
            CurrentEditPIM.PR_ADRESS = this.mt_Address.Text;
            CurrentEditPIM.PR_BOSS = this.mt_BossType.Text;
            CurrentEditPIM.PR_BOSSNAME = mt_BossName.Text.Trim() + " " + mt_BossFName.Text.Trim() + " " + mt_BossSName.Text.Trim();
            CurrentEditPIM.PR_COD = this.mt_Cod.Text;
            CurrentEditPIM.PR_CODEOKONH = this.mt_CODEOKONH.Text;
            CurrentEditPIM.PR_CODEOKPO = this.mt_CODEOKPO.Text;
            CurrentEditPIM.PR_EMAIL = this.mt_EMAIL.Text;
            CurrentEditPIM.PR_FULLNAME = this.mt_FullName.Text;
            CurrentEditPIM.PR_Http = this.mt_Http.Text;
            CurrentEditPIM.PR_INN = this.mt_INN.Text;
            CurrentEditPIM.PR_KPP = this.mt_KPP.Text;
            CurrentEditPIM.PR_LEGALADDRESS = this.mt_LEGALADDRESS.Text;
            CurrentEditPIM.PR_LEGALPOSTINDEX = this.mt_LEGALPOSTINDEX.Text;
            CurrentEditPIM.PR_LICENSENUMBER = this.mt_LICENSENUMBER.Text;
            CurrentEditPIM.PR_NAME = this.mt_NAME.Text;
            CurrentEditPIM.PR_NAMEENG = this.mt_NameEng.Text;
            CurrentEditPIM.PR_PHONES = this.mt_PHONES.Text;
            CurrentEditPIM.PR_POSTINDEX = this.mt_PostIndex.Text;
            CurrentEditPIM.PR_RegisterNumber = this.PR_RegisterNumber.Text;
            CurrentEditPIM.PR_RegisterSeries = this.mt_RegisterSeries.Text;

            CurrentEditPIM.LTP_PartnerAddsValue.PRL_StartWorkAgency = this.PRL_StartWorkAgency.Value;
            CurrentEditPIM.LTP_PartnerAddsValue.PRL_BossWorkWith = this.mt_BossWorkWith.Text;
            CurrentEditPIM.LTP_PartnerAddsValue.PRL_UnicalBossCode = this.PRL_UnicalBossCode.Text;
            CurrentEditPIM.LTP_PartnerAddsValue.PRL_BossMobilePhone = this.PRL_BossMobilePhone.Text;
            CurrentEditPIM.LTP_PartnerAddsValue.PRL_CodeOGRN = this.mt_CodeOGRN.Text;
            CurrentEditPIM.LTP_PartnerAddsValue.PRL_CodeOKATO = this.mt_CodeOKATO.Text;
            CurrentEditPIM.LTP_PartnerAddsValue.PRL_CodeOKVED = this.mt_CodeOKVED.Text;
            CurrentEditPIM.LTP_PartnerAddsValue.PRL_EMailBuh = this.mt_EMailBuh.Text;
            CurrentEditPIM.LTP_PartnerAddsValue.PRL_EmailSpam = this.mt_EmailSpam.Text;
            CurrentEditPIM.LTP_PartnerAddsValue.PRL_EMailBoss = this.mt_EmailBoss.Text;

            CurrentEditPIM.LTP_PartnerAddsValue.PRL_MobilePhone = this.mt_MobilePhone.Text;

            CurrentUsePLDC.SubmitChanges();
            CallCenterDC.SubmitChanges();
            this.CurrentPartnerKey = CurrentEditPIM.PR_KEY;
            RefreshBindingData();
        }

        private void tsBtnSendMail_Click(object sender, EventArgs e)
        {
            PresentIsEditCtrl = false;
            streamControls.Start(this);
            if (CurrentUsePLDC.GetChangeSet().Inserts.Count() != 0
                || CurrentUsePLDC.GetChangeSet().Updates.Count() != 0
                || CurrentUsePLDC.GetChangeSet().Deletes.Count() != 0
                || PresentIsEditCtrl)
            {
                MessageBox.Show(@"Есть измененные данные, для продолжения операции необходимо их сохранить");
                return;
            }
            new frmSendMail(CurrentEditPIM.PR_KEY).ShowDialog();
        }

        private void tsBtnAKA_Click(object sender, EventArgs e)
        {
            AccreditationCards.ltsDataContext ltsAKA = new AccreditationCards.ltsDataContext(SqlConnection.ConnectionData);
            new AccreditationCards.frmMain(this.CurrentEditPIM.PR_KEY).ShowDialog();
        }

        private void tsBtnHistory_Click(object sender, EventArgs e)
        {
            if (CurrentPartnerKey == null)
            {
                MessageBox.Show("Партнер еще не создан");
                return;
            }
            new frmHistory(CurrentPartnerKey.Value).ShowDialog();
        }

        private void tsBtnAddAccount_Click(object sender, EventArgs e)
        {
            frmAccountInformation newFormAI = new frmAccountInformation(CurrentUsePLDC, CurrentEditPIM);
            if (newFormAI.ShowDialog() == DialogResult.Yes)
            {
                frmAccountInformation fPrtAccount = new frmAccountInformation(CurrentUsePLDC, newFormAI.currentPA);
                fPrtAccount.TopLevel = false;
                fPrtAccount.Dock = DockStyle.Top;
                fPrtAccount.FormBorderStyle = FormBorderStyle.None;
                pnlAccounts.Controls.Add(fPrtAccount);
                fPrtAccount.Show();
                ListUseAccountInformationForm.Add(fPrtAccount);
            }
        }


        private void frmEditPartner_FormClosing(object sender, FormClosingEventArgs e)
        {
            streamControls.Start(this);
            if (CurrentUsePLDC.GetChangeSet().Inserts.Count() != 0
                || CurrentUsePLDC.GetChangeSet().Updates.Count() != 0
                || CurrentUsePLDC.GetChangeSet().Deletes.Count() != 0
                || PresentIsEditCtrl)
            {
                if (MessageBox.Show("Есть изменения, Вы хотите продолжить отмену изменений?", "Отмена изменений", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

            }

            if (formDogovorsList != null)
                formDogovorsList.Close();

            if (mt_CityDictionary.DataSource != null)
                ((List<CityDictionary>)mt_CityDictionary.DataSource).Clear();
        }

        private void tsBtnCallCenter_Click(object sender, EventArgs e)
        {
            new CallCenter.frmCallCenter(CallCenterDC, CurrentEditPIM.PR_KEY).ShowDialog();
            if (CurrentEditPIM.LCC_Partner.LCC_MetroStation == null)
                mt_MetroID.SelectedIndex = 0;
            else
                mt_MetroID.SelectedValue = CurrentEditPIM.LCC_Partner.LCP_MSID;
        }

        private void btnCreateUBC_Click(object sender, EventArgs e)
        {
            this.PRL_UnicalBossCode.Text = UnicalCodeBoss.Generate;
        }
        #endregion
    }
}