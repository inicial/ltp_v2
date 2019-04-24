using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;
using ltp_v2.Framework;
using ltp_v2.Controls;
using ltp_v2.Controls.Forms;
using AgencyManager.FormsForAccounts;
using AgencyManager.FormsForDogovor;
using System.Text.RegularExpressions;

namespace AgencyManager.FormsForPartners
{
    public partial class frmMoveValues : Form
    {
        #region Свойства
        PartnersListDataContext CurrentUsePLDC;
        private StreamForms streamControls;
        private object PresentError = null;
        private tbl_Partners CurrentUsePIM;
        private LTP_TempPartner CurrentUsePIR;
        #endregion

        #region Методы
        private void SetValuePIRItem(LTP_TempPartner partnerRegistration)
        {
            CurrentUsePIR = CurrentUsePLDC.LTP_TempPartners.First(x => x.LTP_ID == partnerRegistration.LTP_ID);
            CurrentUsePIR.LTP_UseDateTime = DateTime.Now;
            CurrentUsePLDC.SubmitChanges();

            tsLblAccreditationCard.Text = (CurrentUsePIR.LTP_TempAccreditationCards.Count() > 0 ? "Оформление АКК" : "");

            this.tmp_Name.Text = CurrentUsePIR.LTP_Name;
            this.tmp_NameLat.Text = CurrentUsePIR.LTP_NameLat;
            this.tmp_FullName.Text = CurrentUsePIR.LTP_FullName;
            this.tmp_Phone.Text = CurrentUsePIR.LTP_Phone;

            this.tmp_License.Text = CurrentUsePIR.LTP_LicenseNumber;
            this.tmp_AdditionalInfo.Text = CurrentUsePIR.LTP_AdditionalInfo;

            this.tmp_MobilePhone.Text = CurrentUsePIR.LTP_MobilePhone;
            this.tmp_Fax1.Text = CurrentUsePIR.LTP_Fax1;
            this.tmp_Fax2.Text = CurrentUsePIR.LTP_Fax2;
            
            this.tmp_EMailBuh.Text = CurrentUsePIR.LTP_EmailBuh;
            this.tmp_EmailRasilka.Text = CurrentUsePIR.LTP_EmailRasilka;
            this.tmp_EmailSpam.Text = CurrentUsePIR.LTP_EmailSpam;
            this.tmp_EmailBoss.Text = CurrentUsePIR.LTP_EMailBoss;

            this.tmp_PostIndex.Text = CurrentUsePIR.LTP_PostIndex;
            this.tmp_Adress.Text = CurrentUsePIR.LTP_Adress;
            this.tmp_LegalAdress.Text = CurrentUsePIR.LTP_LegalAdress;
            this.tmp_LegalPostIndex.Text = CurrentUsePIR.LTP_LegalPostIndex;
            this.tmp_BankName.Text = CurrentUsePIR.LTP_BankName;
            this.tmp_BIK.Text = CurrentUsePIR.LTP_BIK;
            this.tmp_INN.Text = CurrentUsePIR.LTP_INN;
            this.tmp_KPP.Text = CurrentUsePIR.LTP_KPP;
            this.tmp_KS.Text = CurrentUsePIR.LTP_KS;
            this.tmp_RS.Text = CurrentUsePIR.LTP_RS;
            this.tmp_CodeOGRN.Text = CurrentUsePIR.LTP_CodeOGRN;
            this.tmp_CodeOKPO.Text = CurrentUsePIR.LTP_CodeOKPO;
            this.tmp_CodeOKONH.Text = CurrentUsePIR.LTP_CodeOKONH;
            this.tmp_CodeOKATO.Text = CurrentUsePIR.LTP_CodeOKATO;
            this.tmp_CodeOKVED.Text = CurrentUsePIR.LTP_CodeOKVED;
            this.tmp_BossWorkWith.Text = CurrentUsePIR.LTP_BossWorkWith;
            this.tmp_UnicalBossCode.Checked = CurrentUsePIR.LTP_UnicalBossCode;
            this.tmp_BossMobilePhone.Text = CurrentUsePIR.LTP_BossMobilePhone;

            clbNeedPasswords.Items.Clear();
            if (CurrentUsePIR.LTP_TempUsers != null)
            {
                var BossUser = CurrentUsePIR.LTP_TempUsers.Where(x => x.LTU_IsBoss);
                if (BossUser.Count() != 0)
                {
                    this.tmp_BossName.Text = BossUser.First().LTU_Name;
                    this.tmp_BossFName.Text = BossUser.First().LTU_FName;
                    this.tmp_BossSName.Text = BossUser.First().LTU_SName;
                    this.tmp_Boss.Text = BossUser.First().LTU_JobName;
                }
                clbNeedPasswords.Items.AddRange(CurrentUsePIR.LTP_TempUsers
                    .OrderByDescending(x=>x.LTU_IsBoss)
                    .ThenBy(x=>x.LTU_Name)
                    .ToArray());

                for (int i = 0; i < clbNeedPasswords.Items.Count; i++)
                {
                    var currUser = (LTP_TempUser)clbNeedPasswords.Items[i];
                    clbNeedPasswords.SetItemChecked(i,
                        CurrentUsePIM == null || (CurrentUsePIM.DUP_USERs
                        .Count(x => x.US_FULLNAME == 
                            currUser.LTU_Name 
                            + " " + currUser.LTU_FName 
                            + " " + currUser.LTU_SName) == 0));
                }
            }

            if (CurrentUsePIR.LTP_CTKey != null)
            {
                tmp_Country.SelectedValue = CurrentUsePIR.CityDictionary.CT_CNKEY;
                tmp_City.SelectedValue = CurrentUsePIR.LTP_CTKey.Value;
            }
            else
            {
                // Флаг невозможности найти город в адресе
                bool NotCanFindCityName = true;
                int tmpCityID = 460;
                string RegexStrFindCity = @"г.\s*(?<City>[A-Za-zА-Яа-я-]*)[^A-Za-zА-Яа-я-]";
                if (Regex.IsMatch(tmp_Adress.Text, RegexStrFindCity, RegexOptions.IgnoreCase))
                {
                    foreach (Match MX in Regex.Matches(tmp_Adress.Text, RegexStrFindCity, RegexOptions.IgnoreCase))
                    {
                        string mcResult = MX.Groups["City"].Value;
                        var FindingCD = CurrentUsePLDC.CityDictionaries.Where(x => x.CT_NAME == mcResult);
                        if (FindingCD.Count() == 1)
                        {
                            tmp_Country.SelectedValue = FindingCD.First().CT_CNKEY;
                            tmp_City.SelectedValue = FindingCD.First().CT_KEY;
                            NotCanFindCityName = false;
                            break;
                        }
                    }
                }
                if (NotCanFindCityName && CurrentUsePIM != null && Int32.TryParse(mt_CityKey.Text, out tmpCityID))
                {
                    var q = CurrentUsePLDC.CityDictionaries.Where(x => x.CT_KEY == tmpCityID).First().CT_CNKEY;
                    this.tmp_Country.SelectedValue = q;
                    this.tmp_City.SelectedValue = tmpCityID;
                }
                else if (NotCanFindCityName)
                {
                    this.tmp_Country.SelectedValue = 460;
                }
            }

            #region Проставление выбора договора
            cbGroupDogovorType.SelectedIndex = 0;
            #endregion

            if (CurrentUsePIM == null || CurrentUsePIM.PR_KEY == 0)
                CurrentUsePIM = new tbl_Partners();

            this.AutoCheckedCheckBox(base.Controls);
        }

        private void SetValuePIMItem(tbl_Partners partnerInMaster)
        {
            if (partnerInMaster == null || partnerInMaster.PR_KEY == 0)
                return;
            
            CurrentUsePIM = CurrentUsePLDC.tbl_Partners.Where(x => x.PR_KEY == partnerInMaster.PR_KEY).First();

            if (CurrentUsePIM.LCC_Partner != null)
                tmp_Metro.DefaultValue = CurrentUsePIM.LCC_Partner.LCP_MSID;

            this.mt_Name.DefaultText = CurrentUsePIM.PR_NAME;
            this.mt_NameLat.DefaultText = CurrentUsePIM.PR_NAMEENG;
            this.mt_FullName.DefaultText = CurrentUsePIM.PR_FULLNAME;
            this.mt_Phone.DefaultText = CurrentUsePIM.PR_PHONES;
            
            this.mt_License.DefaultText = CurrentUsePIM.PR_LICENSENUMBER;
            this.mt_AdditionalInfo.Text = CurrentUsePIM.PR_ADDITIONALINFO;

            this.mt_Fax1.DefaultText = CurrentUsePIM.PR_FAX;
            this.mt_Fax2.DefaultText = CurrentUsePIM.PR_FAX1;
            this.mt_EmailRasilka.DefaultText = CurrentUsePIM.PR_EMAIL;

            this.mt_PostIndex.DefaultText = CurrentUsePIM.PR_POSTINDEX;
            this.mt_Adress.DefaultText = CurrentUsePIM.PR_ADRESS;
            this.mt_LegalAdress.DefaultText = CurrentUsePIM.PR_LEGALADDRESS;
            this.mt_LegalPostIndex.DefaultText = CurrentUsePIM.PR_LEGALPOSTINDEX;
            this.mt_INN.DefaultText = CurrentUsePIM.PR_INN;
            this.mt_KPP.DefaultText = CurrentUsePIM.PR_KPP;

            this.mt_CodeOKPO.DefaultText = CurrentUsePIM.PR_CODEOKPO;
            this.mt_CodeOKONH.DefaultText = CurrentUsePIM.PR_CODEOKONH;
            
            this.mt_BossName.DefaultText = CurrentUsePIM.BossName;
            this.mt_BossFName.DefaultText = CurrentUsePIM.BossFName;
            this.mt_BossSName.DefaultText = CurrentUsePIM.BossSName;

            this.mt_Boss.DefaultText = CurrentUsePIM.PR_BOSS;

            if (CurrentUsePIM.LTP_PartnerAddsValue != null)
            {
                this.mt_CodeOGRN.DefaultText = CurrentUsePIM.LTP_PartnerAddsValue.PRL_CodeOGRN;
                this.mt_CodeOKATO.DefaultText = CurrentUsePIM.LTP_PartnerAddsValue.PRL_CodeOKATO;
                this.mt_CodeOKVED.DefaultText = CurrentUsePIM.LTP_PartnerAddsValue.PRL_CodeOKVED;
                
                this.mt_EMailBuh.DefaultText = CurrentUsePIM.LTP_PartnerAddsValue.PRL_EMailBuh;
                this.mt_EmailSpam.DefaultText = CurrentUsePIM.LTP_PartnerAddsValue.PRL_EmailSpam;
                this.mt_EmailBoss.DefaultText = CurrentUsePIM.LTP_PartnerAddsValue.PRL_EMailBoss;
                
                this.mt_MobilePhone.DefaultText = CurrentUsePIM.LTP_PartnerAddsValue.PRL_MobilePhone;
                this.mt_BossWorkWith.DefaultText = CurrentUsePIM.LTP_PartnerAddsValue.PRL_BossWorkWith;
                this.mt_UnicalBossCode.DefaultText = CurrentUsePIM.LTP_PartnerAddsValue.PRL_UnicalBossCode;
                if (this.mt_UnicalBossCode.Text != "")
                {
                    tmp_UnicalBossCode.Enabled = false;
                    tmp_UnicalBossCode.Text = "УКР Имеется";
                }
                else
                {
                    tmp_UnicalBossCode.Enabled = false;
                    tmp_UnicalBossCode.Text = "Создать УКР";
                }
                this.mt_BossMobilePhone.DefaultText = CurrentUsePIM.LTP_PartnerAddsValue.PRL_BossMobilePhone;

            }
            if (CurrentUsePIM.CityDictionary != null)
            {
                this.mt_City.DefaultText = CurrentUsePIM.CityDictionary.CT_NAME;
                this.mt_CityKey.Text = CurrentUsePIM.CityDictionary.CT_KEY.ToString();
                this.mt_Country.DefaultText = CurrentUsePIM.CityDictionary.tbl_Country.CN_NAME;
            }
            if (CurrentUsePIM.LCC_Partner != null && CurrentUsePIM.LCC_Partner.LCC_MetroStation != null)
            {
                this.mt_Metro.DefaultText = CurrentUsePIM.LCC_Partner.LCC_MetroStation.MS_StationName;
                this.mt_MetroKey.Text = CurrentUsePIM.LCC_Partner.LCC_MetroStation.MS_ID.ToString();
            }
            if (this.mt_Metro.Text == "")
            {
                this.mt_Metro.DefaultText = "Нет станции";
                this.mt_MetroKey.Text = "0";
            }


            foreach (PrtAccount tmpPrtAccountItem in CurrentUsePIM.PrtAccounts)
            {
                gbPresentsAccount.Text = "Счетов доступно : " + CurrentUsePIM.PrtAccounts.Count().ToString() + "шт.";
                frmAccountInformation frmAccountInformation = new frmAccountInformation(CurrentUsePLDC, tmpPrtAccountItem);
                frmAccountInformation.TopLevel = false;
                frmAccountInformation.Dock = DockStyle.Top;
                frmAccountInformation.FormBorderStyle = FormBorderStyle.None;
                pnlAccounts.Controls.Add(frmAccountInformation);
                frmAccountInformation.Show();
            }

            this.AutoCheckedCheckBox(base.Controls);
        }

        /// <summary>
        /// Автоматическое расставление CheckBox
        /// </summary>
        private void AutoCheckedCheckBox(Control.ControlCollection lCollect)
        {
            for (int i = 0; i < lCollect.Count; i++)
            {
                if (lCollect[i].GetType() == typeof(lwGroupContainer)
                    || lCollect[i].GetType() == typeof(Panel)
                    || lCollect[i].GetType() == typeof(TableLayoutPanel))
                {
                    this.AutoCheckedCheckBox(lCollect[i].Controls);
                }
                else if ((lCollect[i].GetType() == typeof(CheckBox)) && (((CheckBox)lCollect[i]).Name.IndexOf("move") >= 0))
                {
                    string ParametrName = ((CheckBox)lCollect[i]).Name.Replace("move", "");
                    int CheckBoxID = lCollect.IndexOfKey("move" + ParametrName);
                    int EdtTempID = lCollect.IndexOfKey("tmp" + ParametrName);
                    int EdtMTID = lCollect.IndexOfKey("mt" + ParametrName);
                    int EdtMTKeyID = lCollect.IndexOfKey("mt" + ParametrName + "Key");

                    if (
                            CheckBoxID >= 0
                            && EdtTempID >= 0
                            && EdtMTID >= 0
                            //&& ((CheckBox)lCollect[CheckBoxID]).Name != this.move_Metro.Name
                            //&& ((CheckBox)lCollect[CheckBoxID]).Name != this.move_City.Name
                            && (
                                lCollect[EdtMTID].GetType() == typeof(TextBox) 
                                || lCollect[EdtMTID].GetType() == typeof(lwTextBox)
                            )
                        )
                    {
                        CheckBox CurrentCheckBox = (CheckBox)lCollect[CheckBoxID];
                        CurrentCheckBox.Checked = true;

                        if (lCollect[EdtTempID].GetType() == typeof(TextBox) 
                            || lCollect[EdtTempID].GetType() == typeof(lwTextBox))
                        {
                            TextBox MTTb = ((TextBox)lCollect[EdtMTID]);
                            TextBox TMPTb = ((TextBox)lCollect[EdtTempID]);

                            TMPTb.Text = TMPTb.Text.Trim();

                            if (TMPTb.Text == "")
                            {
                                CurrentCheckBox.Checked = false;
                            }
                            else
                            {
                                CurrentCheckBox.Checked = !(MTTb.Text.CheckEntryValue(TMPTb.Text)
                                    && !TMPTb.Text.IsNullOrEmptyOrSpace());
                            }
                        }
                        else if ((lCollect[EdtTempID].GetType() == typeof(ComboBox) ||
                            lCollect[EdtTempID].GetType() == typeof(lwComboBox) 
                            )&& EdtMTKeyID >= 0)
                        {
                            ComboBox currentCB = (ComboBox)lCollect[EdtTempID];
                            TextBox currenMtKey = (TextBox)lCollect[EdtMTKeyID];
                            if (currentCB.SelectedValue != null
                                && currenMtKey.Text == currentCB.SelectedValue.ToString())
                            {
                                CurrentCheckBox.Checked = false;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Перенос данных из временных полей в основные
        /// </summary>
        private void MoveDataFromTemp2MT(Control.ControlCollection lCollect)
        {
            for (int i = 0; i < lCollect.Count; i++)
            {
                if (lCollect[i].GetType() == typeof(lwGroupContainer)
                    || lCollect[i].GetType() == typeof(Panel)
                    || lCollect[i].GetType() == typeof(TableLayoutPanel))
                {
                    this.MoveDataFromTemp2MT(lCollect[i].Controls);
                }
                else if ((lCollect[i].GetType() == typeof(CheckBox)) && (((CheckBox)lCollect[i]).Name.IndexOf("move") >= 0))
                {
                    string str = ((CheckBox)lCollect[i]).Name.Replace("move", "");
                    if (((CheckBox)lCollect[i]).Checked)
                    {
                        ((CheckBox)lCollect[i]).Checked = false;
                        int num2 = lCollect.IndexOfKey("tmp" + str);
                        int num3 = lCollect.IndexOfKey("mt" + str);
                        int num4 = lCollect.IndexOfKey("mt" + str + "Key");
                        if (((num2 >= 0) && (num3 >= 0)) && ((lCollect[num3].GetType() == typeof(TextBox)) || (lCollect[num3].GetType() == typeof(lwTextBox))))
                        {
                            if (lCollect[num2].GetType() == typeof(TextBox)
                                || lCollect[num2].GetType() == typeof(lwTextBox))
                            {
                                ((TextBox)lCollect[num3]).Text = ((TextBox)lCollect[num2]).Text;
                            }
                            else if (
                                (
                                    lCollect[num2].GetType() == typeof(ComboBox)
                                    || lCollect[num2].GetType() == typeof(lwComboBox)
                                ) && num4 >= 0)
                            {
                                string text = ((ComboBox)lCollect[num2]).Text;
                                if (((ComboBox)lCollect[num2]).SelectedValue == null)
                                {
                                    ((TextBox)lCollect[num3]).Text = "";
                                    ((TextBox)lCollect[num4]).Text = "";
                                }
                                else
                                {
                                    ComboBox UsedCombobox = ((ComboBox)lCollect[num2]);
                                    if (UsedCombobox == tmp_City)
                                        mt_Country.Text = ((CityDictionary)UsedCombobox.SelectedItem).tbl_Country.CN_NAME;
                                    int selectedValue = (int)UsedCombobox.SelectedValue;
                                    ((TextBox)lCollect[num3]).Text = text;
                                    ((TextBox)lCollect[num4]).Text = selectedValue.ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Получения кол-ва выбранных checkbox
        /// </summary>
        private int GetCountSelectedCheckBox(Control.ControlCollection inCollectControl)
        {
            int result = 0;

            foreach (Control tmpCtrl in inCollectControl)
            {
                if (tmpCtrl.GetType() == typeof(lwGroupContainer)
                    || tmpCtrl.GetType() == typeof(Panel)
                    || tmpCtrl.GetType() == typeof(TableLayoutPanel))
                {
                    result += this.GetCountSelectedCheckBox(tmpCtrl.Controls);
                }

                else if ((tmpCtrl.GetType() == typeof(CheckBox)) && (((CheckBox)tmpCtrl).Name.IndexOf("move_") >= 0))
                {
                    if (((CheckBox)tmpCtrl).Checked)
                        result++;
                }
            }
            return result;
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
        public frmMoveValues()
        {
            InitializeComponent();
            CurrentUsePLDC = new PartnersListDataContext(SqlConnection.ConnectionData);
            
            mt_Phone.SetDefaultPhones_Required();
            tmp_Metro.SetDefaultMetroStation_Required(CurrentUsePLDC);

            tmp_Country.DataSource = CurrentUsePLDC.tbl_Countries.Where(x => x.CN_NAME != "").OrderBy(x => x.CN_NAME);
            tmp_Country.DisplayMember = "CN_Name";
            tmp_Country.ValueMember = "CN_Key";
            tmp_Country.SelectedValue = 460;

            streamControls = new StreamForms();
            streamControls.FindControl += new EventHandler(streamControls_FindControl);

            this.gbBuhgalteria.AutoSize = true;
            this.gbContact.AutoSize = true;
            this.gbContactValue.AutoSize = true;
            this.gbRegistration.AutoSize = true;

            cbGroupDogovorType.Items.AddRange(new string[] { "Запрашиваемые агентством", "Основной тип", "ИП тип" });
        }
        
        public frmMoveValues(LTP_TempPartner partnerRegistration)
            : this()
        {
            SetValuePIRItem(partnerRegistration);
        }

        public frmMoveValues(LTP_TempPartner partnerRegistration, tbl_Partners partnerInMaster)
            : this()
        {
            SetValuePIMItem(partnerInMaster);
            SetValuePIRItem(partnerRegistration);
        }
        #endregion

        #region Обработка событий
        private void move_Checked(object sender, EventArgs e)
        {
            CheckBox cbSender = ((CheckBox)sender);
            string ParametrName = cbSender.Name.Replace("move", "");
            int EdtTempID = cbSender.Parent.Controls.IndexOfKey("tmp" + ParametrName);

            if (EdtTempID >= 0)
                cbSender.Parent.Controls[EdtTempID].Enabled = cbSender.Checked;
        }

        private void tmp_Country_SelectedValueChanged(object sender, EventArgs e)
        {
            tmp_City.DataSource = ((tbl_Country)tmp_Country.SelectedItem)
                .CityDictionaries
                .Where(x => x.CT_NAME != "")
                .OrderBy(x => x.CT_NAME).ToList();
            tmp_City.DisplayMember = "CT_Name";
            tmp_City.ValueMember = "CT_Key";
            if (((tbl_Country)tmp_Country.SelectedItem).CN_KEY == 460)
                tmp_City.SelectedValue = 1;
            else
                tmp_City.SelectedIndex = 0;
        }

        private void streamControls_FindControl(object sender, EventArgs e)
        {
            if ((sender.GetType() == typeof(lwTextBox)) && (((lwTextBox)sender).isErrorText && (this.PresentError == null)))
            {
                this.PresentError = sender;
            }
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (move_BossMobilePhone.Checked)
                if (MessageBox.Show("Смена № телефона руководителя, вы хотите продолжить?", "Внимение !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;

            int CountSelectedMoved = GetCountSelectedCheckBox(this.Controls);
            if (CountSelectedMoved != 0
                && MessageBox.Show("Для переноса из временной БД выбранно " + CountSelectedMoved.ToString() + " данных(ое), \r\n перенести данные?", "Перенос данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MoveDataFromTemp2MT(this.Controls);
                //AutoCheckedCheckBox(this.Controls);
            }
            
            if ((mt_BossName.Text.Trim() + " " + mt_BossFName.Text.Trim() + " " + mt_BossSName.Text.Trim()).Length > 40)
            {
                MessageBox.Show("ФИО Руководителя не должно быть более 40 символов у вас " + (mt_BossName.Text.Trim() + " " + mt_BossFName.Text.Trim() + " " + mt_BossSName.Text.Trim()).Length.ToString());
                return;
            }

            if (tmp_UnicalBossCode.Checked && mt_UnicalBossCode.Text.Trim() == "")
            {
                tmp_UnicalBossCode.Text = AgencyManager.FormsForPartners.UnicalCodeBoss.Generate;
                if (mt_BossMobilePhone.Text.Trim() == "")
                    MessageBox.Show("Нет номера моб.тел. руководителя компании!");
            }

            if (VerifyErrors()) return;

            if (MessageBox.Show("Вы хотите продолжить проверку данных?", "Перенос данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return;

            #region Перенос основных данных
            if (CurrentUsePIM.PR_KEY == 0)
            {
                CurrentUsePLDC.tbl_Partners.InsertOnSubmit(CurrentUsePIM);
            }

            CurrentUsePIM.PR_NAMEENG = this.mt_NameLat.Text;
            CurrentUsePIM.PR_NAME = this.mt_Name.Text;
            CurrentUsePIM.PR_FULLNAME = this.mt_FullName.Text;
            CurrentUsePIM.PR_POSTINDEX = this.mt_PostIndex.Text;
            CurrentUsePIM.PR_ADRESS = this.mt_Adress.Text;
            CurrentUsePIM.PR_LEGALPOSTINDEX = this.mt_LegalPostIndex.Text;
            CurrentUsePIM.PR_LEGALADDRESS = this.mt_LegalAdress.Text;
            CurrentUsePIM.PR_PHONES = this.mt_Phone.Text;
            CurrentUsePIM.PR_LICENSENUMBER = this.mt_License.Text;
            CurrentUsePIM.PR_ADDITIONALINFO = this.mt_AdditionalInfo.Text;
            CurrentUsePIM.PR_FAX = this.mt_Fax1.Text;
            CurrentUsePIM.PR_FAX1 = this.mt_Fax2.Text;
            CurrentUsePIM.PR_EMAIL = this.mt_EmailRasilka.Text;
            CurrentUsePIM.PR_INN = this.mt_INN.Text;
            CurrentUsePIM.PR_KPP = this.mt_KPP.Text;
            CurrentUsePIM.PR_CODEOKONH = this.mt_CodeOKONH.Text;
            CurrentUsePIM.PR_CODEOKPO = this.mt_CodeOKPO.Text;
            CurrentUsePIM.PR_BOSSNAME = this.mt_BossName.Text + " " + this.mt_BossFName.Text + " " + this.mt_BossSName.Text;
            CurrentUsePIM.PR_BOSS = this.mt_Boss.Text;
            
            List<CityDictionary> iCityDictionary = (mt_CityKey.Text.TryConvertToInt() ? 
                CurrentUsePLDC
                .CityDictionaries
                .Where(x => x.CT_KEY == mt_CityKey.Text.ConvertToInt()) : null)
                .ToList();
            if (iCityDictionary.Count() > 0)
            {
                CurrentUsePIM.CityDictionary = iCityDictionary.First();
                CurrentUsePIM.PR_CITY = CurrentUsePIM.CityDictionary.CT_NAME;
            }
            #endregion

            #region Перенос дополнительных данных
            if (CurrentUsePIM.LTP_PartnerAddsValue == null)
                CurrentUsePIM.LTP_PartnerAddsValue = new LTP_PartnerAddsValue();

            CurrentUsePIM.LTP_PartnerAddsValue.PRL_EMailBuh = this.mt_EMailBuh.Text;
            CurrentUsePIM.LTP_PartnerAddsValue.PRL_EmailSpam = this.mt_EmailSpam.Text;
            CurrentUsePIM.LTP_PartnerAddsValue.PRL_EMailBoss = this.mt_EmailBoss.Text;

            CurrentUsePIM.LTP_PartnerAddsValue.PRL_CodeOGRN = this.mt_CodeOGRN.Text;
            CurrentUsePIM.LTP_PartnerAddsValue.PRL_CodeOKATO = this.mt_CodeOKATO.Text;
            CurrentUsePIM.LTP_PartnerAddsValue.PRL_CodeOKVED = this.mt_CodeOKVED.Text;
            CurrentUsePIM.LTP_PartnerAddsValue.PRL_MobilePhone = this.mt_MobilePhone.Text;
            CurrentUsePIM.LTP_PartnerAddsValue.PRL_BossWorkWith = this.mt_BossWorkWith.Text;
            CurrentUsePIM.LTP_PartnerAddsValue.PRL_UnicalBossCode = this.mt_UnicalBossCode.Text;
            CurrentUsePIM.LTP_PartnerAddsValue.PRL_BossMobilePhone = this.mt_BossMobilePhone.Text;
            #endregion

            #region Перенос данных для CallCenter
            
            List<LCC_MetroStation> iMetroStation = 
                (mt_MetroKey.Text.TryConvertToInt() 
                    ? CurrentUsePLDC.LCC_MetroStations
                        .Where(x => x.MS_ID == mt_MetroKey.Text.ConvertToInt())
                    : null).ToList();
            if (iMetroStation != null && iMetroStation.Count() > 0)
            {
                if (CurrentUsePIM.LCC_Partner == null)
                    CurrentUsePIM.LCC_Partner = new LCC_Partner();

                CurrentUsePIM.LCC_Partner.LCC_MetroStation = iMetroStation.First();
            }
            #endregion

            CurrentUsePLDC.SubmitChanges();
            // Обновляем значения у регистрируемоего партнера
            CurrentUsePIR.MakeDateTime = DateTime.Now;
            // Обновляем данные у всех подобных по ИНН записях
            if (CurrentUsePIR.LTP_INN.Length > 5)
            {
                foreach (var item in CurrentUsePLDC.LTP_TempPartners.Where(x =>
                    !x.LTP_UseDateTime.HasValue
                    && !x.MakeDateTime.HasValue
                    && x.LTP_INN == CurrentUsePIR.LTP_INN))
                {
                    item.LTP_UseDateTime = DateTime.Now;
                    item.MakeDateTime = DateTime.Now;
                    item.LTP_WhoMake = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FullName;
                }
            }
            CurrentUsePLDC.SubmitChanges();

            #region Создание договоров
            foreach (PrtDogTypes TOD in clbNeedDogovors.CheckedItems)
            {
                frmCreateDogovor fcd = new frmCreateDogovor(CurrentUsePLDC, CurrentUsePIM, TOD);
                fcd.ShowDialog();
                fcd.ClearFormFromMemory();
            }
            #endregion

            #region Создание Логинов и подключение их к бонусной программе
            foreach (LTP_TempUser TTU in clbNeedPasswords.CheckedItems)
            {
                FormsForAccess.frmLantaOnLine fol = new FormsForAccess.frmLantaOnLine(CurrentUsePLDC, CurrentUsePIM, TTU);
                fol.ShowDialog();
                DUP_USER CreatedDU = fol.LastCreatedLoginPass;
                if (CreatedDU != null && TTU.LTU_LBAMPID != null)
                {
                    Lanta_BonusAgencyManagerInPeriod LBMIP = new Lanta_BonusAgencyManagerInPeriod();
                    LBMIP.lbamip_LBAMPID = TTU.LTU_LBAMPID.Value;
                    CreatedDU.Lanta_BonusAgencyManagerInPeriods.Add(LBMIP);
                }
                fol.ClearFormFromMemory();
            }
            #endregion

            CurrentUsePLDC.SubmitChanges();

            #region Создание АКА
            if (this.CurrentUsePIR.LTP_TempAccreditationCards != null)
            {
                List<int> resulted = new List<int>();
                if (this.CurrentUsePIR.LTP_TempAccreditationCards.Count() > 0)
                {
                    var tmpACC = this.CurrentUsePIR.LTP_TempAccreditationCards.First();
                    //SUMMARY: Упростить
                    if (tmpACC.LTPA_0) resulted.Add(0);
                    if (tmpACC.LTPA_1) resulted.Add(1);
                    if (tmpACC.LTPA_2) resulted.Add(2);

                    AccreditationCards.CardsAccountControl.AccountCreateCards(
                        this.CurrentUsePIM.PR_KEY,
                        resulted.ToArray(),
                        tmpACC.LTPA_LTPDKey,
                        tmpACC.LTPA_UnicalKey.Value,
                        tmpACC.LTPA_SendCardToOffice);
                }
            }
            #endregion

            this.Hide();

            frmEditPartner FormEditPartner = new frmEditPartner(CurrentUsePIM.PR_KEY);
            FormEditPartner.ShowDialog();
            FormEditPartner.ClearFormFromMemory();
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Abort;
            base.Close();
        }

        private void tsNewAccount_Click(object sender, EventArgs e)
        {
            Bank FindBank = new Bank();
            FindBank.BN_Name = tmp_BankName.Text;
            FindBank.BN_BIK = tmp_BIK.Text;
            FindBank.BN_CorAccount = tmp_KS.Text;

            PrtAccount NewPA = new PrtAccount();
            NewPA.PA_Account = this.tmp_RS.Text;

            frmAccountInformation newFormAI = new frmAccountInformation(CurrentUsePLDC, CurrentUsePIM, FindBank, NewPA);
            if (newFormAI.ShowDialog() == DialogResult.Yes)
            {
                frmAccountInformation fPrtAccount = new frmAccountInformation(CurrentUsePLDC, newFormAI.currentPA);
                fPrtAccount.TopLevel = false;
                fPrtAccount.Dock = DockStyle.Top;
                fPrtAccount.FormBorderStyle = FormBorderStyle.None;
                pnlAccounts.Controls.Add(fPrtAccount);
                fPrtAccount.Show();
                pnlNewAccountInformation.Visible = false;
            }
            newFormAI.ClearFormFromMemory();
        }

        private void frmMoveValues_Resize(object sender, EventArgs e)
        {
            pnlNeedPasswords.Width = this.Width / 2;
        }

        private void tmp_UnicalBossCode_CheckedChanged(object sender, EventArgs e)
        {
            tmp_UnicalBossCode.ForeColor = (tmp_UnicalBossCode.Checked) ? Color.Red : SystemColors.ControlText;
        }

        private void cbGroupDogovorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dogTypeList = CurrentUsePLDC.PrtDogTypes.SetPermissionFilter().OrderByDescending(x => x.LTP_DogType.LDT_IsRoot).ThenBy(x => x.LTP_DogType.LDT_Key);
            clbNeedDogovors.Items.Clear();
            if (cbGroupDogovorType.SelectedIndex == 0 && CurrentUsePIR != null && CurrentUsePIR.LTP_PrtDogLinks != null)
            {
                clbNeedDogovors.Items.AddRange(dogTypeList.Where(x => CurrentUsePIR.LTP_PrtDogLinks.Select(xl => xl.LTD_LDTID).Contains(x.PDT_ID)).ToArray());
                foreach (PrtDogTypes tmpItem in CurrentUsePIR.LTP_PrtDogLinks.Select(x => x.PrtDogTypes))
                {
                    if (tmpItem != null)
                        if (clbNeedDogovors.Items.IndexOf(tmpItem) >= 0)
                            clbNeedDogovors.SetItemChecked(clbNeedDogovors.Items.IndexOf(tmpItem), true);
                }
            }
            else if (cbGroupDogovorType.SelectedIndex == 1)
            {
                clbNeedDogovors.Items.AddRange(dogTypeList.Where(x=>x.LTP_DogType.LDT_GroupID == 1).ToArray());
            }
            else if (cbGroupDogovorType.SelectedIndex == 2)
            {
                clbNeedDogovors.Items.AddRange(dogTypeList.Where(x => x.LTP_DogType.LDT_GroupID == 2).ToArray());
            }
        }
        #endregion
    }
}
