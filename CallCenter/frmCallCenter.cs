using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ltp_v2.Framework;
using ltp_v2.Controls;
using ltp_v2.Controls.Forms;

namespace CallCenter
{
    public partial class frmCallCenter : Form
    {
        #region Свойства
        CallCenterDataContext CurrentUsePLDC;
        tbl_Partner CurrentUsePIM;
        List<tbl_Country> CheckedCountryList
        {
            get
            {
                List<tbl_Country> result = new List<tbl_Country>();
                foreach (object CheckItem in edt_CountryList.CheckedItems)
                {
                    result.Add((tbl_Country)CheckItem);
                }
                return result;
            }
            set
            {
                if (value == null)
                    return;
                for (int i = 0; i < edt_CountryList.Items.Count; i++)
                {
                    edt_CountryList.SetItemChecked(i, (value.Where(x => x.CN_KEY == ((tbl_Country)edt_CountryList.Items[i]).CN_KEY).Count() > 0));
                }
            }
        }
        LCC_TypeCallCenter SelectedItemType
        {
            get
            {
                if (edt_TypeCallCenter.SelectedItem == null)
                    return null;
                else
                    return ((LCC_TypeCallCenter)edt_TypeCallCenter.SelectedItem);
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Перенос списка телефонов в БД
        /// </summary>
        private void SetPhonesToDB()
        {
            List<string> phones = new List<string>();
            foreach (string itemPhone in this.edt_Phones.Items)
            {
                if (!itemPhone.IsNullOrEmptyOrSpace())
                    phones.Add(itemPhone);
            }
            if (phones.Count > 0)
            CurrentUsePIM.LCC_Partner.SetPhonesByType(SelectedItemType, phones);
        }

        public void SetDefaultMetroStation_Required(lwComboBox sender, CallCenterDataContext PLDC)
        {
            sender.ChangeBackGroundColor = Color.FromArgb(192, 255, 255);
            sender.ErrorBackGroundColor = Color.Red;
            sender.IsNotNullValue = true;
            sender.MessageInformationError = "Это поле является обязательным"; ;

            LCC_MetroStation FreeLMS = new LCC_MetroStation();
            FreeLMS.MS_ID = 0;
            FreeLMS.MS_StationName = "Нет станции";
            List<LCC_MetroStation> MSList = new List<LCC_MetroStation>();
            MSList.Add(FreeLMS);
            MSList.AddRange(PLDC.LCC_MetroStations.OrderBy(x => x.MS_StationName));
            
            sender.DataSource = MSList;
            sender.DisplayMember = "MS_StationName";
            sender.ValueMember = "MS_ID";
            sender.DefaultValue = 0;
        }
        #endregion

        #region Конструктор
        public frmCallCenter(CallCenterDataContext currentUsePLDC, int PRKey)
        {
            InitializeComponent();
            this.CurrentUsePLDC = currentUsePLDC;
            this.CurrentUsePIM = CurrentUsePLDC.tbl_Partners.First(x => x.PR_KEY == PRKey);
            this.DialogResult = DialogResult.Cancel;
            this.Text += CurrentUsePIM.NameForForms;

            if (CurrentUsePIM.LCC_Partner == null)
                CurrentUsePIM.LCC_Partner = new LCC_Partner();

            edt_TypeCallCenter.DataSource = currentUsePLDC.LCC_TypeCallCenters;
            edt_TypeCallCenter.DisplayMember = "LCPT_Name";
            edt_TypeCallCenter.ValueMember = "LCPT_ID";
            edt_TypeCallCenter.SelectedIndex = 0;

            SetDefaultMetroStation_Required(edt_MetroList, CurrentUsePLDC);
            if (CurrentUsePIM.LCC_Partner.LCC_MetroStation == null)
                edt_MetroList.SelectedIndex = 0;
            else
                edt_MetroList.SelectedValue = CurrentUsePIM.LCC_Partner.LCP_MSID;

            edt_CountryList.Items.Clear();
            edt_CountryList.Items.AddRange(currentUsePLDC.tbl_Countries.Where(x=>x.CN_NAME.Trim() != "").OrderBy(x => x.CN_NAME).ToArray());
            CheckedCountryList = CurrentUsePIM.LCC_Partner.LCC_PartnerCountries.Select(x => x.tbl_Country).ToList();
            edt_CountryList.ItemCheck += new ItemCheckEventHandler(edt_CountryList_ItemCheck);

            edt_AgencyName.Text = CurrentUsePIM.NameForForms;
            edt_IsUsedCallCenter.Checked = CurrentUsePIM.LCC_Partner.LCP_UsedCallCenter;
            edt_Rait.Value = CurrentUsePIM.LCC_Partner.LCP_Rait;
            edt_CRDate.Value = (CurrentUsePIM.LCC_Partner.LCP_CRDate < edt_CRDate.MinDate ? edt_CRDate.MinDate : CurrentUsePIM.LCC_Partner.LCP_CRDate);
            edt_IsFreeService.Checked = CurrentUsePIM.LCC_Partner.LCP_IsFreeService;
        }
        #endregion

        #region Обработка событий
        private void edt_CountryList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            tbl_Country currentChecked = (tbl_Country)this.edt_CountryList.Items[e.Index];
            List<LCC_PartnerCountry> lpc = CurrentUsePIM.LCC_Partner.LCC_PartnerCountries.Where(x => x.LCPC_CNKey == currentChecked.CN_KEY).ToList();

            if (lpc.Count() > 0 && e.NewValue == CheckState.Unchecked)
            {
                CurrentUsePIM.LCC_Partner.LCC_PartnerCountries.Remove(lpc.First());
                CurrentUsePLDC.LCC_PartnerCountries.DeleteOnSubmit(lpc.First());
            }
            else if (lpc.Count() > 0 && CurrentUsePLDC.GetChangeSet().Deletes.IndexOf(lpc.First()) >= 0)
            {
                CurrentUsePLDC.LCC_PartnerCountries.InsertOnSubmit(lpc.First());
                CurrentUsePIM.LCC_Partner.LCC_PartnerCountries.Add(lpc.First());
            }
            else
            {
                LCC_PartnerCountry newPttp = new LCC_PartnerCountry();
                newPttp.tbl_Country = currentChecked;
                CurrentUsePLDC.LCC_PartnerCountries.InsertOnSubmit(newPttp);
                CurrentUsePIM.LCC_Partner.LCC_PartnerCountries.Add(newPttp);
            }
        }

        private void edt_TypeCallCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPhonesToDB();

            gbCountrryList.Enabled = (SelectedItemType.LCPT_ID == -1);

            edt_Phones.Items.Clear();
            edt_Phones.Items.AddRange(CurrentUsePIM.LCC_Partner.GetPhonesByType(SelectedItemType));

            #region Собираем все записи по данному типу в одну
            var PnonesByType = CurrentUsePIM.LCC_Partner.LCC_Phones.Where(x => x.LCC_TypeCallCenter == SelectedItemType);
            var FirstPhoneByTypeForSave = (PnonesByType.Count() > 0 ? PnonesByType.First() : null);
            var PhonesByTypeForDelete = CurrentUsePIM.LCC_Partner.LCC_Phones.Where(x => x.LCC_TypeCallCenter == SelectedItemType && x != FirstPhoneByTypeForSave);
            while (PhonesByTypeForDelete.Count() > 0)
            {
                var PhoneByTypeForDelete = PhonesByTypeForDelete.First();
                CurrentUsePLDC.LCC_Phones.DeleteOnSubmit(PhoneByTypeForDelete);
                CurrentUsePIM.LCC_Partner.LCC_Phones.Remove(PhoneByTypeForDelete);
            }
            #endregion
        }

        private void tsBtnOk_Click(object sender, EventArgs e)
        {
            SetPhonesToDB();

            if (edt_MetroList.isErrorText
                || CurrentUsePIM.LCC_Partner.LCC_PartnerCountries.Count() == 0
                || CurrentUsePIM.LCC_Partner.LCC_Phones.Count() == 0)
            {
                MessageBox.Show("Поправьте данные");
                return;
            }

            //CurrentUsePIM.LCC_Partner.LCC_MetroStation = (LCC_MetroStation)edt_MetroList.SelectedItem;
            CurrentUsePIM.LCC_Partner.LCP_MSID = ((LCC_MetroStation)edt_MetroList.SelectedItem).MS_ID;
            CurrentUsePIM.LCC_Partner.LCP_CRDate = edt_CRDate.Value;
            CurrentUsePIM.LCC_Partner.LCP_IsFreeService = edt_IsFreeService.Checked;
            CurrentUsePIM.LCC_Partner.LCP_Rait = Convert.ToInt32(edt_Rait.Value);
            CurrentUsePIM.LCC_Partner.LCP_UsedCallCenter = edt_IsUsedCallCenter.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDelSelectPhone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.edt_Phones.SelectedItems.Count; i++)
            {
                this.edt_Phones.Items.Remove(this.edt_Phones.SelectedItems[i]);
            }
        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            this.edt_Phones.Items.Add(this.edtPhone.Text);
            
        }

        private void btn_SelectAllCountry_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.edt_CountryList.Items.Count; i++)
            {
                this.edt_CountryList.SetItemChecked(i, true);
            }
        }
        #endregion

        private void edt_IsUsedCallCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (edt_IsUsedCallCenter.Checked)
            {
                edt_IsUsedCallCenter.Text = "Активный";
                edt_IsUsedCallCenter.Image = global::CallCenter.Properties.Resources.Check;
            }
            else
            {
                edt_IsUsedCallCenter.Text = "Неактивный";
                edt_IsUsedCallCenter.Image = global::CallCenter.Properties.Resources.UnCheck;
            }
        }

        private void edt_IsFreeService_CheckedChanged(object sender, EventArgs e)
        {
            if (edt_IsFreeService.Checked)
            {
                edt_IsFreeService.Text = "На бесплатной основе";
                edt_IsFreeService.Image = global::CallCenter.Properties.Resources.Check;
            }
            else
            {
                edt_IsFreeService.Text = "На платной основе";
                edt_IsFreeService.Image = global::CallCenter.Properties.Resources.UnCheck;
            }
        }
    }
}
