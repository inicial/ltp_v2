using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ltp_v2.Controls;
using ltp_v2.Framework;
using System.Text.RegularExpressions;
using ltp_v2.Controls.Forms;
using rep6043.ExtendedClasses;
using System.Linq.Expressions;

namespace rep6043
{
    public partial class frmMain : Form
    {
        #region Свойства
        private sqlDataContext SqlDC;
        private System.Data.SqlClient.SqlConnection sqlConnection;
        private System.Data.SqlClient.SqlTransaction sqlTransaction;
        helperDGVOutItem[] listDataSource;
        #endregion

        [FlagsAttribute]
        public enum ErrorFlags
        {
            esNone = 0x0,
            /// <summary>
            /// Услугой пользуются не все туристы на услуге
            /// </summary>
            esErrorServiceNotFullUse = 0x1,
            /// <summary>
            /// Неуказанны dlDay, dlNDays на SVKey = 6
            /// </summary>
            esErrorDatesService = 0x2,
            /// <summary>
            /// несоответствие dlDay у D и AB
            /// </summary>
            esWroungUseBegDayNotTripRisk = 0x4,
            /// <summary>
            /// Пересечение дат страхования
            /// </summary>
            esErrorCrossDateService = 0x8,
            /// <summary>
            /// У туриста в МТ нехватает данных
            /// </summary>
            esErrorPersonValue = 0x10,
            /// <summary>
            /// Были изменены данные туриста и они отличаются от полиса
            /// </summary>
            esPersonValueNeedUpdate = 0x20, // esInsuranceCreate
            /// <summary>
            /// Неправильное использование мед условий по коэф.
            /// </summary>
            esErrorPersonUseAgeCoef = 0x40,
            /// <summary>
            /// До блокировки менее 5 дней
            /// </summary>
            esCountDayBeforeStart5 = 0x80,
            /// <summary>
            /// До блокировки 1 день
            /// </summary>
            esCountDayBeforeStart1 = 0x100,
            /// <summary>
            /// Блокировка на создание по дням
            /// </summary>
            esOutOfDaysForCreate = 0x200,
            /// <summary>
            /// Несоответствие условий страхования МТ и Полиса
            /// </summary>
            esChangingConditions = 0x400, // esInsuranceCreate
            /// <summary>
            /// Созданный полис
            /// </summary>
            esInsuranceCreate = 0x800,
            /// <summary>
            /// Распечатан
            /// </summary>
            esInsurancePrinted = 0x1000, // esInsuranceCreate
            /// <summary>
            /// Страховой полис потерян по фильтру
            /// </summary>
            esInsuranceLost = 0x2000,

            esNoInsuranceErrors = 
                esErrorServiceNotFullUse | 
                esErrorDatesService |
                esWroungUseBegDayNotTripRisk |
                esErrorCrossDateService |
                esErrorPersonValue |
                esOutOfDaysForCreate |
                esErrorPersonUseAgeCoef,

            /// <summary>
            /// Группа флагов запрещающих создание полиса
            /// </summary>
            IsLockForCreate =
                esNeedReCreate |
                esErrorServiceNotFullUse |
                esErrorDatesService |
                esWroungUseBegDayNotTripRisk |
                esErrorCrossDateService |
                esErrorPersonValue |
                esErrorPersonUseAgeCoef |
                esOutOfDaysForCreate |
                esInsuranceCreate |
                esInsurancePrinted,

            /// <summary>
            /// Группа флагов определяющих фильтр обязательного вывода услуги
            /// </summary>
            esEntryForOutput = esNeedReCreate |
                esCountDayBeforeStart5 | 
                esOutOfDaysForCreate,

            /// <summary>
            /// Группа флагов определяющий обязательное пересоздание страховки
            /// </summary>
            esNeedReCreate = esInsuranceLost |
                esChangingConditions |
                esPersonValueNeedUpdate
        }

        #region Вспомогательные классы и свойства
        public class helperDGVOutItem
        {
            public int OrderCode
            {
                get {
                    if ((this.ErrorCode & ErrorFlags.esOutOfDaysForCreate) != 0)
                        return -1;
                    if ((this.ErrorCode & ErrorFlags.esCountDayBeforeStart1) != 0)
                        return 0;
                    if ((this.ErrorCode & ErrorFlags.esCountDayBeforeStart5) != 0)
                        return 1;
                    if ((this.ErrorCode & ErrorFlags.esInsuranceLost) != 0)
                        return 2;
                    if ((this.ErrorCode & ErrorFlags.esNeedReCreate) != 0)
                        return 3;
                    if ((this.ErrorCode & ErrorFlags.esNoInsuranceErrors) != 0)
                        return 4;
                    if ((this.ErrorCode & ErrorFlags.esInsurancePrinted) != 0)
                        return 6;
                    if ((this.ErrorCode & ErrorFlags.esInsuranceCreate) != 0)
                        return 5;
                    
                    return (int)ErrorCode; 
                }
            }

            public string ErrorMessage = "";

            public ErrorFlags ErrorCode;
            [DisplayName("№ Страхования (условия)")]
            [DefaultWidth(200)]
            public string Insurance { get; private set; }
            [DisplayName("Даты страхования")]
            [DefaultWidth(200)]
            public string InsuranceDate { get; private set; }
            [DisplayName("Фам.Имя Туриста")]
            public string FIPerson { get; private set; }
            [DisplayName("№ Брони/дата заезда")]
            [DefaultWidth(100)]
            public string BronNumber { get; private set; }

            public string[] RSCodes;
            public int DGKey;
            public DateTime TurDate;
            public string DGCode;
            public int INKey;
            public int PersonAge;
            public int DLDay;
            public int DLNDays;
            public int TUKey;

            /// <summary>
            /// Услуги из МТ только мед
            /// </summary>
            public helperDGVOutItem(sqlDataContext sqlDC, int tuKey, short dlDay, short? dlNDays, int dgKey)
            {

                this.TUKey = tuKey;
                this.DLDay = dlDay;
                this.DLNDays = dlNDays.GetValueOrDefault(0);

                ErrorCode = ErrorFlags.esNone;
                
                tbl_Dogovor currentDogovor;
                currentDogovor = sqlDC.tbl_Dogovors.Where(x => x.DG_Key == dgKey).FirstOrDefault();
                if (tuKey == -1)
                {
                    this.DGCode = currentDogovor.DG_CODE;
                    this.DGKey = currentDogovor.DG_Key;
                    this.TurDate = currentDogovor.DG_TURDATE.Date;
                    this.BronNumber = currentDogovor.DG_CODE;
                    this.ErrorCode |= ErrorFlags.esErrorServiceNotFullUse;
                    ErrorMessage += ErrorMessages.ErrDLNMens(currentDogovor.DG_CODE);
                    return;
                }
   
                #region Проверка на привязанность всех туристов к услуге страхования
                if ((from xTU in sqlDC.tbl_Turists.Where(x => x.TU_KEY == tuKey)
                     from xDL in sqlDC.tbl_DogovorLists.Where(x => x.DL_DGKEY == xTU.TU_DGKEY && x.DL_SVKEY == 6)
                     where xDL.DL_NMEN != xDL.TuristServices.Count()
                     select xDL).Count() > 0)
                {
                    ErrorCode |= ErrorFlags.esErrorServiceNotFullUse;
                    ErrorMessage += ErrorMessages.ErrDLNMens(currentDogovor.DG_CODE);
                }
                #endregion
                
                // Данные о текущем туристе из мт.
                var currentPerson = 
                    (from xTU in sqlDC.tbl_Turists
                    where xTU.TU_KEY == tuKey
                    select xTU).FirstOrDefault();
                
                // Текущая бронь
                this.DGCode = currentDogovor.DG_CODE;
                this.DGKey = currentDogovor.DG_Key;
                this.TurDate = currentDogovor.DG_TURDATE.Date;

                // Получение всех услуг страхования по туру для туриста
                var tblServices =
                    (from xTS in sqlDC.TuristServices
                     from xDL in sqlDC.tbl_DogovorLists
                     from xSR in sqlDC.INS_SL_REFs
                     where xTS.TU_TUKEY == tuKey
                            && xDL.DL_KEY == xTS.TU_DLKEY
                            && xSR.SLR_SLKEY == xDL.DL_CODE
                            && xSR.SLR_SUBCODE1 == xDL.DL_SUBCODE1
                            && xSR.SLR_SUBCODE2 == xDL.DL_SUBCODE2
                            && xDL.DL_SVKEY == 6
                     select new { xDL.DL_KEY, xDL.DL_DAY, xDL.DL_NDAYS, xSR.INS_RISK.RS_CODE, xSR.INS_RISK.RS_KEY }).Distinct().ToArray();
                
                var currentInsurance =
                    (from xIN in sqlDC.INS_INSURANCEs
                     from xIP in xIN.INS_PERSONs
                     where xIP.IP_TUKEY == tuKey
                            && xIN.IN_ANNULDATE == null
                            && xIN.IN_DATESTART.Date == currentDogovor.DG_TURDATE.AddDays(dlDay - 1).Date
                            && xIN.IN_DATEEND.Date == currentDogovor.DG_TURDATE.AddDays(dlDay - 1).AddDays(dlNDays.GetValueOrDefault(1) - 1).Date
                            && xIN.IN_ParentINKey == 0
                     select xIN).FirstOrDefault();
                
                INS_INSURANCE chieldInsurance = null;
                if (currentInsurance != null && currentInsurance.InsurancesChield.Count() > 0)
                {
                    chieldInsurance = currentInsurance.InsurancesChield.Where(x => x.INS_PERSONs.Any(xIP => xIP.IP_TUKEY == tuKey)).FirstOrDefault();
                }

                #region Проверка на указание dlDay, dlNDays
                if (tblServices.Any(x => x.DL_DAY == null || x.RS_CODE != 'D' && (x.DL_NDAYS == null || x.DL_NDAYS <= 0)))
                {
                    ErrorCode |= ErrorFlags.esErrorDatesService;
                    ErrorMessage += ErrorMessages.ErrDLDay(currentDogovor.DG_CODE);
                }
                #endregion

                #region Проверка на пересечение дат однотипных типов условий страхования
                foreach (var xKey in tblServices.Where(x => x.RS_CODE != 'B').GroupBy(x => x.RS_CODE))
                {
                    foreach (var xDay in xKey.Select(x => x))
                    {
                        var xAnyDay = tblServices
                            .Where(x => x.RS_CODE == xKey.Key)
                            .Where(x => x.DL_DAY != xDay.DL_DAY || x.DL_NDAYS != xDay.DL_NDAYS).ToArray();

                        xAnyDay = xAnyDay
                            .Where(x => x.DL_DAY >= xDay.DL_DAY && x.DL_DAY <= xDay.DL_NDAYS + xDay.DL_DAY - 1
                                || x.DL_NDAYS + x.DL_DAY - 1 >= xDay.DL_DAY && x.DL_NDAYS + x.DL_DAY - 1 <= xDay.DL_NDAYS + xDay.DL_DAY - 1).ToArray();

                        if (xAnyDay.Count() > 0)
                        {
                            ErrorCode |= ErrorFlags.esErrorCrossDateService;
                            ErrorMessage += ErrorMessages.ErrPresentCrossMedService(currentDogovor.DG_CODE);
                        }
                    }
                }
                #endregion

                #region Проверка на правильность указания даты начала страхования от невыезда
                var xPresentNormalUseRiskD = tblServices.Any(x =>
                    x.RS_CODE == 'D'
                    && tblServices
                        .Where(xRS => xRS.RS_CODE == 'A')
                        .Any(xRS => xRS.DL_DAY == x.DL_DAY));

                if (!xPresentNormalUseRiskD && tblServices.Any(x => x.RS_CODE == 'D'))
                {
                    ErrorCode |= ErrorFlags.esWroungUseBegDayNotTripRisk;
                    ErrorMessage += ErrorMessages.ErrNoMedIfUseTrip(currentDogovor.DG_CODE);
                }
                #endregion

                this.BronNumber = currentDogovor.DG_CODE + " / " + currentDogovor.DG_TURDATE.ToString("dd.MM.yyyy");

                if (currentInsurance == null)
                {
                    DateTime begDate = currentDogovor.DG_TURDATE.AddDays(dlDay - 1);
                    DateTime endDate = begDate.AddDays(dlNDays.GetValueOrDefault(1) - 1);
                    this.InsuranceDate = begDate.ToString("dd.MM.yyyy") + " по " + endDate.ToString("dd.MM.yyyy");
                    this.FIPerson = (currentPerson.TU_NAMELAT.Trim() + " " + currentPerson.TU_FNAMELAT.Trim()).ToUpper();
                    #region проверка актуальности по дням
                    int minAddsDay = (int)tblServices.Min(x => x.DL_DAY.GetValueOrDefault(1));
                    int countDaysBeforeStart = (int)(currentDogovor.DG_TURDATE.Date.AddDays(minAddsDay - 1).Date - ltp_v2.Framework.SqlConnection.ServerDateTime.Date).TotalDays;
                    bool useRistNotTripInDogovor = tblServices.Any(x => x.RS_CODE == 'D' && x.DL_DAY == dlDay);
                    if (countDaysBeforeStart == 5 && useRistNotTripInDogovor || countDaysBeforeStart == 1)
                        ErrorCode |= ErrorFlags.esCountDayBeforeStart1;
                    if (countDaysBeforeStart < 5 && useRistNotTripInDogovor || countDaysBeforeStart < 1)
                    {
                        ErrorCode |= ErrorFlags.esOutOfDaysForCreate;
                        ErrorMessage += ErrorMessages.ErrOutDayBeforeCreate(currentDogovor.DG_CODE, countDaysBeforeStart);
                    }
                    else if (countDaysBeforeStart < 10 && useRistNotTripInDogovor || countDaysBeforeStart < 5)
                        ErrorCode |= ErrorFlags.esCountDayBeforeStart5;
                    #endregion

                    #region Проверка данных туриста ФИО / Д.Р.
                    var currentPersonError = currentPerson.CheckOnError();
                    if ((currentPersonError & (tbl_Turist.ErrorCode.Name | tbl_Turist.ErrorCode.NameIsNull)) != 0)
                    {
                        ErrorCode |= ErrorFlags.esErrorPersonValue;
                        ErrorMessage += ErrorMessages.ErrPersName(currentPerson.ToString());
                    }
                    else if ((currentPersonError  & (tbl_Turist.ErrorCode.FName | tbl_Turist.ErrorCode.FNameIsNull)) != 0)
                    {
                        ErrorCode |= ErrorFlags.esErrorPersonValue;
                        ErrorMessage += ErrorMessages.ErrPersFName(currentPerson.ToString());
                    }
                    else if ((currentPersonError & (tbl_Turist.ErrorCode.Birthday | tbl_Turist.ErrorCode.BirthdayIsNull)) != 0)
                    {
                        ErrorCode |= ErrorFlags.esErrorPersonValue;
                        ErrorMessage += ErrorMessages.ErrPersBirthday(currentPerson.ToString());
                    }
                    #endregion
                    else
                    {
                        #region Проверка на правильность возраста и повышающего коэфициента
                        var useCoef = tblServices.Where(x => x.RS_CODE == 'A' && x.DL_DAY == dlDay);
                        PersonAge = currentPerson.TU_BIRTHDAY.Value.TotalYearsOfTheDate(currentDogovor.DG_TURDATE);
                        var insRowCoef = sqlDC.INS_AgeCoefs.FirstOrDefault(x => x.AC_AgeFrom <= PersonAge && x.AC_AgeTo >= PersonAge);

                        int insCoef = 1;
                        if (insRowCoef != null)
                            insCoef = (int)(insRowCoef.AC_Coef < 1 ? 1 : insRowCoef.AC_Coef);
                        if (insCoef != useCoef.Count())
                        {
                            ErrorCode |= ErrorFlags.esErrorPersonUseAgeCoef;
                            ErrorMessage += ErrorMessages.ErrCountMedUse(currentPerson.ToString(), dlDay, useCoef.Count(), insCoef);
                        }
                        #endregion

                        FIPerson += "(" + PersonAge + ")";
                    }
                }
                else // (rowInsurance != null)
                {

                    this.INKey = currentInsurance.IN_KEY;
                    ErrorCode |= ErrorFlags.esInsuranceCreate;

                    this.InsuranceDate = currentInsurance.IN_DATESTART.ToString("dd.MM.yyyy") + " по " + currentInsurance.IN_DATEEND.ToString("dd.MM.yyyy");
                    var rowPerson = currentInsurance.INS_PERSONs.Where(x => x.IP_TUKEY == tuKey).FirstOrDefault();

                    this.Insurance = currentInsurance.IN_NUMBER;

                    #region проверка на совпадение имени и д.р. застрахованного и МТ
                    if (currentPerson.TU_NAMELAT.Trim().ToUpper() == rowPerson.IP_NAME.Trim().ToUpper()
                        && currentPerson.TU_FNAMELAT.Trim().ToUpper() == rowPerson.IP_FNAME.Trim().ToUpper()
                        && currentPerson.TU_BIRTHDAY.HasValue
                        && currentPerson.TU_BIRTHDAY.Value.Date == rowPerson.IP_BIRTHDAY.Date)
                    {
                        this.FIPerson = rowPerson.IP_NAME + " " + rowPerson.IP_FNAME;
                    }
                    else
                    {
                        ErrorCode |= ErrorFlags.esPersonValueNeedUpdate;
                        ErrorMessage += "В полисе " + currentInsurance.IN_NUMBER + " данные по туристу отличаются от мастер-тура";
                    }
                    #endregion
                    
                    if (chieldInsurance != null)
                    {
                        Insurance += "/MN/";
                    }

                    var tblConditions = currentInsurance.INS_CONDITIONs.Select(x => x);
                    if (chieldInsurance != null)
                    {
                        tblConditions = tblConditions.Union(chieldInsurance.INS_CONDITIONs.Select(x => x));
                    }

                    var rsKeysInInsurance = tblConditions.Select(x=>x.INS_RISK.RS_KEY).Distinct().ToArray();
                    var rsKeysInDogovor = (from x in tblServices
                                where x.DL_DAY == dlDay
                                    // && x.DL_NDAYS == dlNDays // - Выкидывает невыезд
                                select x.RS_KEY).Distinct().ToArray();

                    #region Проверка на изменение условий страхования
                    if (rsKeysInDogovor.Except(rsKeysInInsurance).Count() > 0 || rsKeysInInsurance.Except(rsKeysInDogovor).Count() > 0)
                    {
                        ErrorCode |= ErrorFlags.esChangingConditions;
                        ErrorMessage += "В полисе " + currentInsurance.IN_NUMBER + " условий страхования отличаются от мастер-тура";
                    }
                    #endregion

                    #region Проверка на изменение премиальной части за невыезд
                    else if (tblConditions.Any(x => x.INS_RISK.RS_CODE == 'D'))
                    {
                        var insuredSumInInsurance = tblConditions
                            .Where(x => x.INS_RISK.RS_CODE == 'D')
                            .Select(x => x.CO_INSUREDSUM)
                            .FirstOrDefault();

                        var insuredSumInDogovor = (
                            from xDL in currentDogovor.tbl_DogovorLists
                            from xSV in tblServices.Where(x => x.RS_CODE == 'D')
                            from xSL in sqlDC.INS_SL_REFs
                            where xDL.DL_KEY == xSV.DL_KEY
                                    && xSL.SLR_SLKEY == xDL.DL_CODE
                                    && xSL.SLR_SUBCODE1 == xDL.DL_SUBCODE1
                                    && xSL.SLR_SUBCODE2 == xDL.DL_SUBCODE2
                            select xSL.SLR_INSUREDSUM).FirstOrDefault();

                        if (insuredSumInInsurance != insuredSumInDogovor)
                        {
                            ErrorCode |= ErrorFlags.esChangingConditions;
                            ErrorMessage += "В полисе " + currentInsurance.IN_NUMBER + " условий страхования отличаются от мастер-тура";
                        }
                    }
                    #endregion
                }
                RSCodes = tblServices.Where(x => x.DL_DAY == dlDay).Select(x => x.RS_CODE).OrderBy(x=>x).Distinct().Select(x => x.ToString()).ToArray();
                this.Insurance += "(" + string.Join("", RSCodes) + ")";
            }

            public helperDGVOutItem(sqlDataContext sqlDC, int inKey)
            {
                ErrorCode |= ErrorFlags.esInsuranceLost | ErrorFlags.esInsuranceCreate;
                
                var currentInsurance = sqlDC.INS_INSURANCEs.Where(x => x.IN_KEY == inKey).FirstOrDefault();
                ErrorMessage += "Полис № " + currentInsurance.IN_NUMBER + " несоответствует данным мастер-тура";
                this.DGCode = currentInsurance.IN_UseDGCode;
                this.INKey = currentInsurance.IN_KEY;
                this.BronNumber = currentInsurance.IN_UseDGCode;
                this.FIPerson = currentInsurance.IN_INSURED;
                this.Insurance = currentInsurance.IN_NUMBER + (currentInsurance.InsurancesChield.Count() > 0 ? "/MN/" : "");
                this.InsuranceDate = currentInsurance.IN_DATESTART.ToString("dd.MM.yyyy") + " по " + currentInsurance.IN_DATEEND.ToString("dd.MM.yyyy");
            }
        }
        #endregion

        #region Методы
        private void RefreshData()
        {
            if (edtFltCountry.Enabled && edtFltCountry.SelectedValue == null
                || !edtFltCountry.Enabled && edtFltBronNumber.Text.Trim() == "")
            {
                MessageBox.Show("Выберите параметр для фильтрации данных");
                return;
            }

            var timer = DateTime.Now;

            lwWaitScreen fWS = new lwWaitScreen();
            fWS.Show();

            var listFilteredDogovors =
                (from xDG in SqlDC.tbl_Dogovors
                 select xDG);

            if (edtFltBronNumber.Text != "")
            {
                if (Regex.IsMatch(edtFltBronNumber.Text, @"^TA[0-9]{1,4}-.*"))
                {
                    var currInsurances = SqlDC.INS_INSURANCEs.Where(x => x.IN_NUMBER == edtFltBronNumber.Text).FirstOrDefault();
                    if (currInsurances == null)
                        return;

                    edtFltBronNumber.Text = currInsurances.IN_UseDGCode;
                }
               
                var currentDogovor = SqlDC.tbl_Dogovors.Where(x => x.DG_CODE == edtFltBronNumber.Text).FirstOrDefault();
                if (currentDogovor == null)
                    return;

                edtFltCountry.SelectedItem = edtFltCountry.Items.OfType<COUNTRY>().FirstOrDefault(x => x.CN_KEY == currentDogovor.DG_CNKEY);
                edtFltDate.Value = currentDogovor.DG_TURDATE.Date;
            }

            listFilteredDogovors = listFilteredDogovors
                       .Where(xFS =>
                            (xFS.DG_TURDATE.Date == edtFltDate.Value.Date
                            || xFS.DG_TURDATE.Date == ltp_v2.Framework.SqlConnection.ServerDateTime.Date
                            || xFS.DG_TURDATE.Date == ltp_v2.Framework.SqlConnection.ServerDateTime.Date.AddDays(1)
                            || xFS.DG_TURDATE.Date == ltp_v2.Framework.SqlConnection.ServerDateTime.Date.AddDays(5)
                            || xFS.DG_TURDATE.Date == ltp_v2.Framework.SqlConnection.ServerDateTime.Date.AddDays(6)
                            || xFS.DG_TURDATE.Date == ltp_v2.Framework.SqlConnection.ServerDateTime.Date.AddDays(7))
                            && xFS.DG_CNKEY == (int)edtFltCountry.SelectedValue);
           
            var listFilteredServices = listFilteredDogovors.Select(x => x.DG_Key).Distinct();

            #region Получение списка туристов по услувию
            var listTuristAndSevice =
                (from xFS in listFilteredServices
                 from xDL in SqlDC.tbl_DogovorLists.Where(x => x.DL_SVKEY == 6 && x.DL_DGKEY == xFS)
                 join qTS in SqlDC.TuristServices on xDL.DL_KEY equals qTS.TU_DLKEY into joinTS
                 from xTS in joinTS.DefaultIfEmpty()
                 from xSR in SqlDC.INS_SL_REFs
                 where xSR.SLR_SLKEY == xDL.DL_CODE
                        && xSR.SLR_SUBCODE1 == xDL.DL_SUBCODE1
                        && xSR.SLR_SUBCODE2 == xDL.DL_SUBCODE2
                        && xSR.INS_RISK.RS_CODE == 'A'
                 select new
                 {
                     TUKey = (xTS == null ? -1 : xTS.TU_TUKEY),
                     DLDay = xDL.DL_DAY,
                     DLNDays = xDL.DL_NDAYS,
                     DGKey = xDL.DL_DGKEY,
                     RSCode = xSR.INS_RISK.RS_CODE
                 }).Distinct();
            #endregion

            if (ResultListDGV.DataSource != null)
                ResultListDGV.DataSource = null;

            var listNormalData = listTuristAndSevice.Select(x => new helperDGVOutItem(SqlDC, x.TUKey, x.DLDay.GetValueOrDefault(1), x.DLNDays, x.DGKey.Value)).ToList();

            var lostInsurances = (
                    from xDG in listFilteredDogovors
                    from xIN in SqlDC.INS_INSURANCEs.Where(x => x.IN_ANNULDATE == null && x.IN_ParentINKey == 0)
                    where xIN.IN_UseDGCode == xDG.DG_CODE
                    select new { xDG.DG_Key, xIN.IN_KEY })
                        .ToArray()
                        .Where(x => !listNormalData.Any(xLi => xLi.DGKey == x.DG_Key && xLi.INKey == x.IN_KEY))
                        .Select(x => new helperDGVOutItem(SqlDC, x.IN_KEY));

            listNormalData.AddRange(lostInsurances.ToArray());

            if (edtFltBronNumber.Text.Trim() != "")
            {
                listDataSource = listNormalData.Where(x => (x.ErrorCode & ErrorFlags.esEntryForOutput) != 0 || x.DGCode.ToUpper() == edtFltBronNumber.Text.ToUpper()).ToArray();
            }
            else
            {
                listDataSource = listNormalData.Where(x => (x.ErrorCode & ErrorFlags.esEntryForOutput) != 0 || x.TurDate == edtFltDate.Value).ToArray();
            }

            ResultListDGV.DataSource = listDataSource.OrderBy(x => x.OrderCode).ToArray();
            ResultListDGV.Columns["OrderCode"].Visible = false;

            tsLblCountRows.Text = (listDataSource.Count()).ToString();
            var timerTotal = (DateTime.Now - timer).TotalMilliseconds;
            tsLblCountTime.Text = (Math.Truncate(timerTotal / 1000) + "сек. " + Math.Round(timerTotal - Math.Truncate(timerTotal / 1000) * 1000).ToString() + "мсек.").ToString();
            fWS.Close();
        }

        private void RefreshList()
        {
            if (SqlDC != null)
                SqlDC.Dispose();
            if (sqlConnection != null)
                sqlConnection.Dispose();
            if (sqlTransaction != null)
                sqlTransaction.Dispose();

            sqlConnection = new System.Data.SqlClient.SqlConnection(ltp_v2.Framework.SqlConnection.ConnectionData);
            sqlConnection.Open();
            sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
            SqlDC = new sqlDataContext(sqlConnection);
            SqlDC.Transaction = sqlTransaction;

            SqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            
            if (Regex.IsMatch(edtFltBronNumber.Text, @"^TA[0-9]{1,4}-.*"))
            {
                var fInsur = SqlDC.INS_INSURANCEs.Where(x=>x.IN_NUMBER == edtFltBronNumber.Text.Trim()).FirstOrDefault();
                if (fInsur != null)
                    edtFltBronNumber.Text = fInsur.IN_UseDGCode;
                else
                {
                    MessageBox.Show("По вашему запросу страховка не найдена");
                    return;
                }
            }
            RefreshData(); 


            //tsBtnCreateInsurances.Enabled = false;
            if (ResultListDGV.Rows.Count > 0)
                ResultListDGV_CellEnter(null, null);
        }
        #endregion

        #region Конструктор
        public frmMain(string DGCode)
        {
            InitializeComponent();
            using (sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
            {
                tsBtnExport.Visible = sqlDC.IsRootManager;

                edtFltCountry.DataSource = sqlDC.COUNTRies.OrderBy(x => x.CN_NAME);
                edtFltCountry.DisplayMember = "CN_Name";
                edtFltCountry.ValueMember = "CN_Key";

                edtFltDate.Value = DateTime.Now.Date;
            }

            edtFltBronNumber.Text = DGCode;
        }
        #endregion

        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            edtFltBronNumber.Text = edtFltBronNumber.Text.Trim();
            RefreshList();
        }

        private void edtFltBronNumber_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(edtFltBronNumber.Text, @"^TA[0-9]{1,4}-.*"))
                lblTypFilter.Text = "№ Страх.";
            else
                lblTypFilter.Text = "№ Брони";

            edtFltCountry.Enabled = edtFltDate.Enabled = edtFltBronNumber.Text.Trim() == "";
        }

        private void ResultListDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in ResultListDGV.Rows)
            {
                if (dgvr.DataBoundItem is helperDGVOutItem)
                {
                    Label lblLegend = lblLegendNormal;
                    helperDGVOutItem itemHDGV = (helperDGVOutItem)dgvr.DataBoundItem;
                    if ((itemHDGV.ErrorCode & ErrorFlags.esNeedReCreate) != 0)
                        lblLegend = lblLegendLostService;
                    else if ((itemHDGV.ErrorCode & ErrorFlags.esInsurancePrinted) != 0)
                        lblLegend = lblLegendPrinted;
                    else if ((((itemHDGV.ErrorCode | ErrorFlags.esInsuranceCreate | ErrorFlags.esInsurancePrinted)
                            ^ ErrorFlags.esInsurancePrinted ^ ErrorFlags.esInsuranceCreate) & ErrorFlags.IsLockForCreate) != 0)
                        lblLegend = lblLegendAnyError;
                    else if ((itemHDGV.ErrorCode & ErrorFlags.esCountDayBeforeStart1) != 0)
                        lblLegend = lblLegend1Days;
                    else if ((itemHDGV.ErrorCode & ErrorFlags.esCountDayBeforeStart5) != 0)
                        lblLegend = lblLegend5Days;
                    else if ((itemHDGV.ErrorCode & ErrorFlags.esOutOfDaysForCreate) != 0)
                        lblLegend = lblLegend0Days;

                    dgvr.DefaultCellStyle.Font = lblLegend.Font;
                    dgvr.DefaultCellStyle.ForeColor = lblLegend.ForeColor;
                    dgvr.DefaultCellStyle.BackColor = lblLegend.BackColor;
                }
            }
        }

        private void ResultListDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            tsBtnCreateInsurances.Enabled = true;
            tsBtnShowWarning.Enabled = true;

            bool OnlyCreate = true;
            string lastDGCode = "";
            foreach (DataGridViewRow dgvr in ResultListDGV.SelectedRows)
            {
                if (dgvr.DataBoundItem is helperDGVOutItem)
                {
                    helperDGVOutItem hro = (helperDGVOutItem)dgvr.DataBoundItem;
                    if ((hro.ErrorCode & ErrorFlags.esInsuranceCreate) == 0)
                        OnlyCreate = false;
                    //else if ((hro.ErrorCode & ErrorFlags.) != 0)
                    //    tsBtnShowWarning.Enabled = true;
                    lastDGCode = hro.DGCode;
                }
            }
            tsBtnPrint.Enabled = tsBtnAnulate.Enabled = OnlyCreate;
            tsBtnOpenEdit.Enabled = (OnlyCreate && ResultListDGV.SelectedRows.Count == 1);
        }

        private void tsBtnCreateInsurances_Click(object sender, EventArgs e)
        {
            if (ResultListDGV.SelectedRows.Count == 0)
                return;

            List<helperDGVOutItem> forCreateArray = new List<helperDGVOutItem>();
            List<helperDGVOutItem> skipArray = new List<helperDGVOutItem>();

            foreach (DataGridViewRow selRows in ResultListDGV.SelectedRows)
            {
                var hro = ((helperDGVOutItem)selRows.DataBoundItem);
                if ((hro.ErrorCode & ErrorFlags.esInsuranceCreate) == 0)
                {
                    if (listDataSource
                        .Where(x => x.DGKey == hro.DGKey)
                        .Any(x => (
                            (((x.ErrorCode | ErrorFlags.esInsuranceCreate | ErrorFlags.esInsurancePrinted) 
                                ^ ErrorFlags.esInsurancePrinted) 
                                    ^ ErrorFlags.esInsuranceCreate) & ErrorFlags.IsLockForCreate) != 0))
                    {
                        skipArray.Add(hro);
                    }else {
                        forCreateArray.Add(hro);
                    }
                }
            }

            if (skipArray.Count() > 0)
            {
                if (MessageBox.Show("Имеются ошибки по выбранным броням, вывести первую бронь?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    edtFltBronNumber.Text = skipArray[0].DGCode;
                    return;
                }
                else if (SqlDC.IsRootManager)
                {
                    int rootCreate = 0;
                    int rootSkip = 0;
                    foreach (var itemHro in skipArray.Where(x => (x.ErrorCode & ErrorFlags.esNoInsuranceErrors) != 0))
                    {
                        if (new frmListAnnuledInsurances(itemHro.DGCode, itemHro.DLDay, itemHro.TUKey, itemHro.DLNDays).ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            rootCreate++;
                        else
                            rootSkip++;
                    }
                    return;
                }
            }

            int SkeepCreate = skipArray.Count();
            int Create = 0;
            int ManualSkeep = 0;
            int NeedCreate = 0;

            foreach (var q in forCreateArray.OrderByDescending(x=>x.PersonAge))
            {
                if (q.PersonAge < 2)
                {
                    var createdChldIns = new frmListInsurancesForInfant(q.TUKey, q.DLDay, q.DLNDays);
                    if (createdChldIns.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Create++;
                    }
                    else
                    {
                        ManualSkeep++;
                    }
                }else {
                    frmCreateInsurances createInsurances = new frmCreateInsurances(q.DGCode, q.DLDay, q.DLNDays, q.TUKey);
                    if (createInsurances.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        Create++;
                    }
                    else
                    {
                        ManualSkeep++;
                    }
                }
            }

            string Messages =
                (SkeepCreate > 0 ? "Пропущенно по ошибкам страховок: " + SkeepCreate + "\r\n" : "") +
                "Созданно страховых полисов: " + Create + "\r\n" +
                (ManualSkeep > 0 ? "Пропущенно по Вашуму желанию: " + ManualSkeep + "\r\n" : "") +
                "Должно было быть созданно страховых полисов: " + NeedCreate;
            MessageBox.Show(Messages, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshList();
        }

        private void tsBtnAnulate_Click(object sender, EventArgs e)
        {
            if (ResultListDGV.SelectedRows.Count == 0)
                return;

            foreach (DataGridViewRow dgvr in ResultListDGV.SelectedRows)
            {
                var hDGV = ((helperDGVOutItem)dgvr.DataBoundItem);
                if ((hDGV.ErrorCode & ErrorFlags.esInsuranceCreate) != 0)
                {
                    var currentInsurance = SqlDC.INS_INSURANCEs.FirstOrDefault(x => x.IN_KEY == hDGV.INKey);
                    if (currentInsurance != null)
                    {
                        string errorMessage = "";
                        if (MessageBox.Show("Вы точно хотите анулировать сл. полис №" + currentInsurance.IN_NUMBER, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (!currentInsurance.Anulate(false, out errorMessage))
                            {
                                MessageBox.Show(errorMessage, "Ошибка при аннуляции полиса", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            SqlDC.SubmitChanges();
            RefreshList();
        }

        private void tsBtnPrint_Click(object sender, EventArgs e)
        {
            if (ResultListDGV.SelectedRows.Count == 0)
                return;

            if (!SqlDC.IsRootManager)
            {
                #region Проверка на потерянные записи
                foreach (DataGridViewRow dgvr in ResultListDGV.SelectedRows)
                {
                    helperDGVOutItem hro = (helperDGVOutItem)dgvr.DataBoundItem;
                    var errorsInsurances = listDataSource.Where(x =>
                            x.DGCode == hro.DGCode &&
                            ((((x.ErrorCode | ErrorFlags.esInsuranceCreate | ErrorFlags.esInsurancePrinted)
                                    ^ ErrorFlags.esInsurancePrinted)
                                        ^ ErrorFlags.esInsuranceCreate) & ErrorFlags.IsLockForCreate) != 0);

                    if (errorsInsurances.Count() > 0)
                    {
                        MessageBox.Show("Есть ошибки в выбранных полисах, после нажатия ОК, выведутся эти брони");
                        edtFltBronNumber.Text = errorsInsurances.First().DGCode;
                        this.RefreshList();
                        return;
                    }
                }
                #endregion
            }
            List<int> inKeys = new List<int>();
            foreach (DataGridViewRow dgvr in ResultListDGV.SelectedRows)
            {
                helperDGVOutItem hro = (helperDGVOutItem)dgvr.DataBoundItem;
                if ((hro.ErrorCode & ErrorFlags.esInsuranceCreate) != 0)
                    inKeys.Add(hro.INKey);
            }

            if (inKeys.Count > 0)
                new Report.ReportViewer(inKeys).ShowDialog();
        }

        private void tsBtnOpenEdit_Click(object sender, EventArgs e)
        {
            if (ResultListDGV.SelectedRows.Count != 1)
                return;

            var q = (helperDGVOutItem)ResultListDGV.SelectedRows[0].DataBoundItem;

            if ((q.ErrorCode & ErrorFlags.esInsuranceCreate) != 0)
                new frmCreateInsurances(q.INKey).ShowDialog();
        }

        private void tsBtnExport_Click(object sender, EventArgs e)
        {
            new frmExport().ShowDialog();
        }

        private void ResultListDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (listDataSource != null)
            {
                var param = Expression.Parameter(typeof(helperDGVOutItem), "person");
                var mySortExpression = Expression.Lambda<Func<helperDGVOutItem, object>>(Expression.Property(param, ResultListDGV.Columns[e.ColumnIndex].Name), param);
                ResultListDGV.DataSource = listDataSource.AsQueryable().OrderByDescending(mySortExpression).ToArray();
                ResultListDGV.Columns["OrderCode"].Visible = false;
            }
        }

        private void tsBtnShowWarning_Click(object sender, EventArgs e)
        {
            if (ResultListDGV.SelectedRows.Count != 1)
                return;

            helperDGVOutItem hro = (helperDGVOutItem)ResultListDGV.SelectedRows[0].DataBoundItem;
            if (hro.ErrorMessage.Trim() == "")
                return;

            MessageBox.Show(hro.ErrorMessage);
        }
    }
}