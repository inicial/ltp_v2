using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ltp_v2.Controls;

//TTT10711A1
namespace rep6043
{
    public partial class frmCreateInsurances : Form
    {
        #region Свойства
        private INS_INSURANCE CurrentInsurances;
        private sqlDataContext SqlDC;
        private decimal TotalServicePriceInDogovor = 0;
        #endregion

        #region Методы
        private void SetError(string errorMessage)
        {
            lblError.Text = errorMessage;
            lblError.Visible = true;
            tsBtnCreate.Enabled = false;
            tsBtnPrint.Enabled = false;
            tsBtnRefreshData.Enabled = false;
        }

        private bool PresentErrors()
        {
            tsBtnCreate.Enabled = true;
            if (lblError.Visible)
                return true;

            var PresentRS_D = CurrentInsurances.INS_CONDITIONs.Any(x => x.INS_RISK.RS_CODE == 'D');

            #region Проверка туристов на правильность
            if (CurrentInsurances.INS_PERSONs.Count() == 0)
            {
                SetError(ErrorMessages.ErrNoTurist);
                return true;
            }
            // =================== проверка правильности заполнения даты рождения ===================
            if (CurrentInsurances.INS_PERSONs.Any(x => x.IP_BIRTHDAY.Date > ltp_v2.Framework.SqlConnection.ServerDateTime.Date))
            {
                SetError(ErrorMessages.ErrPersBirthday(""));
                return true;
            }

            // ==================== Проверка на правильность заполнения Фамилии ====================
            var turistNameHaveAnyChar = CurrentInsurances.INS_PERSONs.ToArray().Where(x => x.IP_NAME.Trim() == "" || Regex.IsMatch(x.IP_NAME, @".*[^A-Za-z-\s'`\.].*"));
            if (turistNameHaveAnyChar.Count() > 0)
            {
                SetError(ErrorMessages.ErrPersName(turistNameHaveAnyChar.FirstOrDefault().ToString()));
                return true;
            }

            // ==================== Проверка на правильность заполнения Имени ====================
            var turistFNameHaveAnyChar = CurrentInsurances.INS_PERSONs.ToArray().Where(x => x.IP_FNAME.Trim() == "" || Regex.IsMatch(x.IP_FNAME, @".*[^A-Za-z-\s'`\.].*"));
            if (turistFNameHaveAnyChar.Count() > 0)
            {
                SetError(ErrorMessages.ErrPersFName(turistFNameHaveAnyChar.FirstOrDefault().ToString()));
                return true;
            }
            
            #endregion

            #region Проверка территорий
            // ================= Проверка на наличие территорий =============
            if (CurrentInsurances.INS_TERRITORies.Count() == 0)
            {
                SetError(ErrorMessages.ErrNoTerretories);
                return true;
            }
            // ================= Проверка на существование территории которая не может быть в группе =================
            var listTerretoryUseNotGroup = CurrentInsurances.INS_TERRITORies.Where(x => x.INS_COUNTRIES_ING.CI_NotUseInGroup);
            if (CurrentInsurances.INS_TERRITORies.Count() > 1 && listTerretoryUseNotGroup.Count() > 0)
            {
                SetError(ErrorMessages.ErrTerretoryUse(listTerretoryUseNotGroup.First().INS_COUNTRIES_ING.CI_NAME));
                return true;
            }
            #endregion

            #region Проверка шапки страхового полиса
            if (!SqlDC.INS_SL_REFs.Any(x => x.SLR_INSUREDRATE == CurrentInsurances.IN_PREMIUMTOTALRATE))
            {
                SetError(ErrorMessages.ErrRateUse);
                return true;
            }
            // ================ Проверка минимально допустимой даты для выписки ================
            var CountDaysBeforeUse = (CurrentInsurances.IN_DATESTART.Date - CurrentInsurances.IN_DATE.Date).TotalDays;
            if (PresentRS_D && CountDaysBeforeUse < 5
                || !PresentRS_D && CountDaysBeforeUse < 0)
            {
                SetError(ErrorMessages.ErrOutDayBeforeCreate(CurrentInsurances.IN_UseDGCode, (int)CountDaysBeforeUse));
                return true;
            }
            
            // ================= Проверка на мин продолжительность страхования =================
            if (CurrentInsurances.IN_DURATION < 1)
            {
                SetError("Выписать страховку на продолжительность менее 1 дня??? хммм");
                return true;
            }

            // ================= Проверка на макс. продолжительность страхования =================
            if (CurrentInsurances.IN_DURATION > SqlDC.INS_TARIFFs.Where(x => x.INS_RISK.RS_CODE == 'A').Select(x => x.TR_DAY2).Max())
            {
                SetError(ErrorMessages.ErrNotTariffForDuration);
                return true;
            }

            // ================= Проверка даты завершения страхования за пределы действия тура =============
            var currDG = SqlDC.tbl_Dogovors.Where(x => x.DG_CODE == CurrentInsurances.IN_UseDGCode).First();
            if (CurrentInsurances.IN_DATEEND.Date > currDG.DG_TURDATE.AddDays(currDG.DG_NDAY - 1).Date)
            {
                SetError("Дата завершения страхования более чем дата завершения тура");
                return true;
            }
            #endregion

            #region Проверка условий страхования
            if (CurrentInsurances.INS_CONDITIONs.Count() == 0)
            {
                SetError(ErrorMessages.ErrNoConditions);
                return true;
            }
            if (CurrentInsurances.INS_CONDITIONs.Where(x => x.INS_RISK.RS_CODE == 'A').Count() > 1)
            {
                SetError(ErrorMessages.AnyErrorCountMedUse);
                return true;
            }
            if (CurrentInsurances.INS_CONDITIONs.Where(x => x.INS_RISK.RS_CODE == 'A').Count() == 0)
            {
                SetError(ErrorMessages.AnyErrorNotMedUse);
                return true;
            }
            if (CurrentInsurances.INS_CONDITIONs.Where(x => x.INS_RISK.RS_CODE == 'B').Count() > 1)
            {
                SetError(ErrorMessages.AnyErrorCountBServUse);
                return true;
            }
            if (CurrentInsurances.INS_CONDITIONs.Where(x => x.INS_RISK.RS_CODE == 'B').Count() == 0)
            {
                SetError(ErrorMessages.AnyErrorNotBServUse);
                return true;
            }
            if (CurrentInsurances.INS_CONDITIONs.Where(x => x.INS_RISK.RS_CODE == 'D').Count() > 1)
            {
                SetError(ErrorMessages.AnyErrorCountDServUse);
                return true;
            }
            // ================= Проверка на минимальную сумму мед. страхования для выбранных территорий
            var minimumInsurance = CurrentInsurances.INS_TERRITORies.Max(x => x.INS_COUNTRIES_ING.CI_MinimumRS1);
            if (CurrentInsurances.INS_CONDITIONs.Where(x => x.INS_RISK.RS_CODE == 'A').Min(x => x.CO_INSUREDSUM) < minimumInsurance)
            {
                SetError(ErrorMessages.ErrMinContitions(minimumInsurance));
                return true;
            }
            // ================ Проверка на наличие специальных тарифов =======================
            var qPresentSpecialTariff =
                (from xTR in SqlDC.INS_TARIFFs.ToArray()
                 from xIT in CurrentInsurances.INS_TERRITORies.Select(x => x.IT_CIKEY).Distinct()
                 where xTR.TR_CIKey.HasValue
                     && xTR.TR_CIKey == xIT
                 select new { xTR.TR_RSCodeKEY, xTR.TR_INSURSUM, xTR.TR_RATE })
                 .Distinct();

            if (CurrentInsurances.INS_CONDITIONs.Any(xIC =>
                        qPresentSpecialTariff.Any(xST =>
                            xIC.INS_RISK.RS_CodeKey == xST.TR_RSCodeKEY)))
            {
                // Для актуального тарифа есть специальные тарифы
                if (CurrentInsurances.INS_CONDITIONs.Any(xIC =>
                        !qPresentSpecialTariff.Any(xST =>
                            xIC.INS_RISK.RS_CodeKey == xST.TR_RSCodeKEY
                            && xIC.CO_INSUREDRATE == xST.TR_RATE
                            && xIC.CO_INSUREDSUM == xST.TR_INSURSUM)))
                {
                    SetError(ErrorMessages.ErrNotUseSpecialTarriff);
                    return true;
                }
            }

            if (CurrentInsurances.IN_PREMIUMTOTAL == 0)
            {
                SetError(ErrorMessages.ErrIsNullInsuredSumm);
                return true;
            }
            #endregion

            return lblError.Visible;
        }

        /// <summary>
        /// Пересчет стоимости страховки
        /// </summary>
        private void RecalculateTotalPrice()
        {
            CurrentInsurances.RecalculatePremiumTotal();
        }

        /// <summary>
        /// Загрузка тарифов на услуги
        /// </summary>
        private void RefreshTarrifs()
        {
            string NumberCode = "";

            CurrentInsurances.ClearPremiumInConditions();

            foreach (var itemCond in CurrentInsurances.INS_CONDITIONs)
            {
                IEnumerable<INS_TARIFF> actualTarrifs;
                actualTarrifs = SqlDC.INS_TARIFFs.Where(x =>
                    x.TR_FRANCHISE == itemCond.CO_FRANCHISE
                    && x.TR_RSCodeKEY == itemCond.INS_RISK.RS_CodeKey);

                if (itemCond.INS_RISK.RS_CODE != 'D')
                {
                    actualTarrifs = actualTarrifs.Where(x =>
                        x.TR_DAY1 <= CurrentInsurances.IN_DURATION
                        && x.TR_DAY2 >= CurrentInsurances.IN_DURATION
                        && x.TR_INSURSUM == itemCond.CO_INSUREDSUM
                        && x.TR_RATE == itemCond.CO_INSUREDRATE
                        && (x.TR_CIKey == null
                            || CurrentInsurances.INS_TERRITORies.Any(xUTR => xUTR.IT_CIKEY == x.TR_CIKey)));
                }

                if (actualTarrifs.Count() > 1 && actualTarrifs.Any(x => CurrentInsurances.INS_TERRITORies.Any(xCI => xCI.IT_CIKEY == x.TR_CIKey)))
                {
                    actualTarrifs = actualTarrifs.Where(x => CurrentInsurances.INS_TERRITORies.Any(xCI => xCI.IT_CIKEY == x.TR_CIKey));
                }

                if (actualTarrifs.Count() > 1)
                {
                    SetError(ErrorMessages.ErrAutomaticGetMoreTarrif);
                    CurrentInsurances.ClearPremiumInConditions();
                    return;
                }
                else if (actualTarrifs.Count() == 0)
                {
                    SetError(ErrorMessages.ErrNotAutomaticGetTarrif);
                    CurrentInsurances.ClearPremiumInConditions();
                    return;
                }

                 var actualTariff = actualTarrifs.First();
                if (actualTariff.TR_SUM != 0)
                    itemCond.CO_PREMIUMSUM = actualTariff.TR_SUM;
                else
                    itemCond.CO_PREMIUMSUM = actualTariff.TR_PERCENT;

                if (actualTariff.TR_NumCode != null)
                {
                    if (NumberCode == "")
                        NumberCode = actualTariff.TR_NumCode;
                    else if (NumberCode != actualTariff.TR_NumCode)
                    {
                        SetError(ErrorMessages.ErrNotAutomaticGetNumber);
                    }
                }
            }

            if (String.IsNullOrEmpty(CurrentInsurances.IN_NUMBER))
                CurrentInsurances.IN_NUMBER = NumberCode;

            RecalculateTotalPrice();
        }

        private void LoadDefaultConditions()
        {
            if (CurrentInsurances.IN_NUMBERKEY == 0)
                CurrentInsurances.IN_NUMBER = "";
            edt_Conditions.DataSource = null;
            while (CurrentInsurances.INS_CONDITIONs.Count() > 0)
            {
                var delItem = CurrentInsurances.INS_CONDITIONs.First();
                delItem.INS_INSURANCE = null;
                delItem.INS_RISK = null;
                CurrentInsurances.INS_CONDITIONs.Remove(delItem);
            }

            if (CurrentInsurances.INS_TERRITORies.Count() == 0 || CurrentInsurances.INS_PERSONs.Count() == 0)
            {
                return;
            }
            var currentDogovor = SqlDC.tbl_Dogovors.Where(x => x.DG_CODE == CurrentInsurances.IN_UseDGCode).First();
            var UsedInsurService = (
                from xDL in SqlDC.tbl_DogovorLists
                    .Where(x => 
                        x.DL_DGCOD == CurrentInsurances.IN_UseDGCode
                        && x.DL_DAY == (CurrentInsurances.IN_DATESTART.Date - currentDogovor.DG_TURDATE.Date).TotalDays + 1
                        && x.DL_SVKEY == 6)
                from xDG in SqlDC.tbl_Dogovors
                    .Where(x => x.DG_CODE == CurrentInsurances.IN_UseDGCode)
                from xTS in SqlDC.TuristServices
                    .Where(x => x.TU_TUKEY == CurrentInsurances.INS_PERSONs.First().IP_TUKEY)
                from xSL in SqlDC.INS_SL_REFs
                where xDL.DL_KEY == xTS.TU_DLKEY
                    && xDL.DL_CODE == xSL.SLR_SLKEY
                    && xDL.DL_SUBCODE1 == xSL.SLR_SUBCODE1
                    && xDL.DL_SUBCODE2 == xSL.SLR_SUBCODE2
                    && xSL.SLR_INSUREDRATE == CurrentInsurances.IN_PREMIUMTOTALRATE
                select new
                {
                    xSL.SLR_COEF,
                    xSL.SLR_FRANCHISE,
                    xSL.SLR_INSUREDRATE,
                    xSL.SLR_INSUREDSUM,
                    xSL.INS_RISK,
                    xDL.DL_COST,
                    xDL.DL_NMEN,
                    xDL.DL_KEY
                }).ToArray()
                .Where(x =>
                    x.INS_RISK.RS_CODE != 'A'
                    || x.INS_RISK.RS_CODE == 'A'
                    && x.SLR_INSUREDSUM >= CurrentInsurances.INS_TERRITORies.Select(xCI => xCI.INS_COUNTRIES_ING.CI_MinimumRS1).Max());

            TotalServicePriceInDogovor = UsedInsurService
                .Select(x => new { x.DL_COST, x.DL_NMEN, x.DL_KEY })
                .Distinct()
                .Select(x => x.DL_COST.GetValueOrDefault(0) / (decimal)x.DL_NMEN)
                .Sum();

            foreach (var itemConditions in UsedInsurService)
            {
                if (!CurrentInsurances.INS_CONDITIONs.Any(x => x.INS_RISK.RS_CODE == itemConditions.INS_RISK.RS_CODE))
                {
                    CurrentInsurances.INS_CONDITIONs.Add(new INS_CONDITION()
                    {
                        CO_COEF = (float)itemConditions.SLR_COEF,
                        CO_FRANCHISE = (float)itemConditions.SLR_FRANCHISE,
                        CO_INSUREDRATE = itemConditions.SLR_INSUREDRATE,
                        CO_INSUREDSUM = itemConditions.SLR_INSUREDSUM,
                        INS_RISK = itemConditions.INS_RISK
                    });
                };
            }
            RefreshTarrifs();
            edt_Conditions.DataSource = CurrentInsurances.INS_CONDITIONs.OrderBy(x => x.INS_RISK.RS_CodeKey).ToArray();
        }
        /// <summary>
        /// Загрузка значений по умолчанию
        /// </summary>
        private void LoadDataDefault(string dgCode, int tuKey, int dlDay, int dlNDays)
        {
            var currentDogovor = SqlDC.tbl_Dogovors.Where(x=>x.DG_CODE == dgCode).FirstOrDefault();
            if (CurrentInsurances == null)
            {
                CurrentInsurances = new INS_INSURANCE();
                SqlDC.INS_INSURANCEs.InsertOnSubmit(CurrentInsurances);
            }

            CurrentInsurances.PropertyChanged += new PropertyChangedEventHandler(CurrentInsurances_PropertyChanged);
            CurrentInsurances.IN_UseDGCode = currentDogovor.DG_CODE;
            CurrentInsurances.IN_DATESTART = currentDogovor.DG_TURDATE.AddDays(dlDay - 1).Date;
            CurrentInsurances.IN_DATEEND = currentDogovor.DG_TURDATE.AddDays(dlDay + dlNDays - 2).Date;
            CurrentInsurances.IN_PREMIUMTOTALRATE = currentDogovor.DG_RateNormalize;

            #region Загрузка возможных территорий
            foreach (var itemTerretory in
                (from xDL in SqlDC.tbl_DogovorLists
                 from xCN in SqlDC.tbl_DogovorLists.Where(x => x.DL_DGCOD == dgCode).Select(x => x.COUNTRY)
                 from xTR in SqlDC.INS_COUNTRY_REFs
                 from xTS in SqlDC.TuristServices.Where(x => x.TU_TUKEY == tuKey)
                 where
                    (
                        xDL.DL_SVKEY == 3
                        || xDL.DL_SVKEY == 8
                        || xDL.DL_SVKEY == 4
                        || xDL.DL_SVKEY == 7
                        || xDL.DL_SVKEY == 9
                        || xDL.DL_SVKEY == 5
                    ) && xCN.CN_KEY == xDL.DL_CNKEY
                    && xTR.CR_CNKEY == xCN.CN_KEY
                    && xTS.TU_DLKEY == xDL.DL_KEY
                 select xTR.INS_COUNTRIES_ING).Distinct())
            {
                if (!CurrentInsurances.INS_TERRITORies.Any(x => x.IT_CIKEY == itemTerretory.CI_KEY))
                    CurrentInsurances.INS_TERRITORies.Add(new INS_TERRITORy() { INS_COUNTRIES_ING = itemTerretory });
            }

            foreach (var itemTerretoryByDogovor in SqlDC.INS_COUNTRY_REFs.Where(x => x.CR_CNKEY == currentDogovor.DG_CNKEY))
            {
                if (itemTerretoryByDogovor != null)
                {
                    if (!CurrentInsurances.INS_TERRITORies.Any(x => x.IT_CIKEY == itemTerretoryByDogovor.INS_COUNTRIES_ING.CI_KEY))
                        CurrentInsurances.INS_TERRITORies.Add(new INS_TERRITORy() { INS_COUNTRIES_ING = itemTerretoryByDogovor.INS_COUNTRIES_ING });
                }
            }
            edt_Terretory.DataSource = CurrentInsurances.INS_TERRITORies.ToArray();
            #endregion

            #region Загрузка списка туристов
            foreach (var itemPerson in (SqlDC.tbl_Turists.Where(x => x.TU_KEY == tuKey).Distinct()))
            {
                CurrentInsurances.INS_PERSONs.Add(new INS_PERSON() { tbl_Turist = itemPerson });
            }
            edt_Persons.DataSource = CurrentInsurances.INS_PERSONs;
            var firstPersonMaxBD = CurrentInsurances.INS_PERSONs.OrderByDescending(x => x.IP_BIRTHDAY).FirstOrDefault();
            CurrentInsurances.IN_INSURED = firstPersonMaxBD.IP_NAME + " " + firstPersonMaxBD.IP_FNAME;
            #endregion

            LoadDefaultConditions();
        }
        #endregion

        #region Конструктор
        public frmCreateInsurances()
        {
            InitializeComponent();
            SqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            lblError.Visible = false;
            tsBtnCreate.Visible = false;
            tsBtnPrint.Visible = false;
            tsBtnRefreshData.Visible = false;
            pnlEdit_Terretory.Visible = false;
            cb_Terretory.DataSource = SqlDC.INS_COUNTRIES_INGs.Where(x => x.CI_NAME.Trim() != "").OrderBy(x => x.CI_NAME);
        }

        public frmCreateInsurances(int INKey) : this()
        {
            CurrentInsurances = SqlDC.INS_INSURANCEs.Where(x => x.IN_KEY == INKey).FirstOrDefault();
            if (CurrentInsurances != null)
            {
                tsBtnPrint.Visible = true;
                tsBtnRefreshData.Visible = true;

                edt_Terretory.DataSource = CurrentInsurances.INS_TERRITORies.ToArray();
                edt_Persons.DataSource = CurrentInsurances.INS_PERSONs.ToArray();
                edt_Conditions.DataSource = CurrentInsurances.INS_CONDITIONs.ToArray();
                CurrentInsurances_PropertyChanged(CurrentInsurances, null);
            }

        }

        public frmCreateInsurances(int INKey, string dgCode, int dlDay, int dlNDays, int tuKEy)
            : this()
        {
            CurrentInsurances = SqlDC.INS_INSURANCEs.Where(x => x.IN_KEY == INKey).FirstOrDefault();
            CurrentInsurances.IN_UseDGCode = "";
            CurrentInsurances.IN_PREMIUMTOTALRATE = "";
            CurrentInsurances.IN_INSURED = "";
            CurrentInsurances.IN_DATESTART = DateTime.MinValue;
            CurrentInsurances.IN_DATEEND = DateTime.MinValue;
            CurrentInsurances.IN_ANNULDATE = null;
            CurrentInsurances.IN_IsExport = false;
            CurrentInsurances.IN_IsPrintedByWeb = false;
            CurrentInsurances.IN_LastPrintDate = null;

            foreach (var q in CurrentInsurances.INS_PERSONs.ToArray())
            {
                SqlDC.INS_PERSONs.DeleteOnSubmit(q);
            }
            CurrentInsurances.INS_PERSONs.Clear();
            foreach (var q in CurrentInsurances.INS_TERRITORies.ToArray())
            {
                SqlDC.INS_TERRITORies.DeleteOnSubmit(q);
            }
            CurrentInsurances.INS_TERRITORies.Clear();
            foreach (var q in CurrentInsurances.INS_CONDITIONs.ToArray())
            {
                SqlDC.INS_CONDITIONs.DeleteOnSubmit(q);
            }
            CurrentInsurances.INS_CONDITIONs.Clear();

            pnlEdit_Terretory.Visible = true;
            tsBtnCreate.Visible = true;
            LoadDataDefault(dgCode, tuKEy, dlDay, dlNDays);
            RefreshTarrifs();
            PresentErrors();
        }

        public frmCreateInsurances(string dgCode, int dlDay, int dlNDays, int tuKEy)
            : this()
        {
            pnlEdit_Terretory.Visible = true;
            tsBtnCreate.Visible = true;
            LoadDataDefault(dgCode, tuKEy, dlDay, dlNDays);
            RefreshTarrifs();
            if (PresentErrors())
            {
                this.ShowDialog();
            }
            else
            {
                SqlDC.SubmitChanges();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        #endregion

        private void CurrentInsurances_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.edt_DateBeg.Text = CurrentInsurances.IN_DATESTART.ToString("dd.MM.yyyy");
            this.edt_DateEnd.Text = CurrentInsurances.IN_DATEEND.ToString("dd.MM.yyyy");
            this.edt_Duration.Text = CurrentInsurances.IN_DURATION.ToString();

            this.edt_Number.Text = CurrentInsurances.IN_NUMBER;
            this.edt_Persons.Text = CurrentInsurances.IN_INSURED;
            this.edt_InsuranceFIO.Text = CurrentInsurances.IN_INSURED;
            this.edt_TotalSumm.Text = CurrentInsurances.IN_PREMIUMTOTAL.ToString(".##");
            this.edt_Rate.Text = CurrentInsurances.IN_PREMIUMTOTALRATE;

            var currentDogovor = SqlDC.tbl_Dogovors.Where(x => x.DG_CODE == CurrentInsurances.IN_UseDGCode).FirstOrDefault();
            if (currentDogovor != null
                && CurrentInsurances.INS_PERSONs.Any(x=>x.Coef(currentDogovor.DG_TURDATE.Date) > 1)
                && currentDogovor.DG_RateNormalize == currentDogovor.DG_RATE
                && TotalServicePriceInDogovor != 0 
                && CurrentInsurances.IN_PREMIUMTOTAL != 0 
                && Math.Abs(CurrentInsurances.IN_PREMIUMTOTAL - TotalServicePriceInDogovor) > 3)
            {
                SetError("Разница сумм страховки и соимости их в МТ превышает 3ед");
            }
            this.edt_Date.Text = CurrentInsurances.IN_DATE.ToString("dd.MM.yyyy");
            
        }

        private void btn_TerretoryDelete_Click(object sender, EventArgs e)
        {
            if (edt_Terretory.SelectedItems != null)
            {
                foreach (INS_TERRITORy item in edt_Terretory.SelectedItems)
                {
                    var deletedTerretory = CurrentInsurances.INS_TERRITORies.First(x => x.IT_CIKEY == item.IT_CIKEY);
                    deletedTerretory.INS_COUNTRIES_ING = null;
                    deletedTerretory.INS_INSURANCE = null;
                    CurrentInsurances.INS_TERRITORies.Remove(deletedTerretory);
                }
                edt_Terretory.DataSource = CurrentInsurances.INS_TERRITORies.ToArray();
            }

            lblError.Visible = false;
            LoadDefaultConditions();
            PresentErrors();
        }

        private void btn_TerretoryAdd_Click(object sender, EventArgs e)
        {
            if (cb_Terretory.SelectedItem != null)
            {
                if (!CurrentInsurances.INS_TERRITORies.Any(x => x.IT_CIKEY == ((INS_COUNTRIES_ING)cb_Terretory.SelectedItem).CI_KEY))
                {
                    CurrentInsurances.INS_TERRITORies.Add(new INS_TERRITORy() { INS_COUNTRIES_ING = (INS_COUNTRIES_ING)cb_Terretory.SelectedItem });
                }
                edt_Terretory.DataSource = CurrentInsurances.INS_TERRITORies.ToArray();
                
                lblError.Visible = false;
                LoadDefaultConditions();
                PresentErrors();
            }
        }

        private void tsBtnCreate_Click(object sender, EventArgs e)
        {
            if (!lblError.Visible)
            {
                SqlDC.SubmitChanges();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void lblError_VisibleChanged(object sender, EventArgs e)
        {
            if (lblError.Visible)
                tsBtnCreate.Enabled = false;
            else
                tsBtnCreate.Enabled = true;
        }

        private void tsBtnPrint_Click(object sender, EventArgs e)
        {
            new Report.ReportViewer(new List<int>() { CurrentInsurances.IN_KEY }).ShowDialog();
        }

        public void tsBtnRefreshData_Click(object sender, EventArgs e)
        {
            var error = CurrentInsurances.UpdatePersonsName(SqlDC);
            if (error != "")
            {
                SetError(error);
                return;
            }

            SqlDC.SubmitChanges();
            MessageBox.Show(ErrorMessages.DataUpdatedSuccessfully);
            this.Close();
        }
    }
}
