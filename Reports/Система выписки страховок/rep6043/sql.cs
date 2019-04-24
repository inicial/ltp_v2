namespace rep6043
{
    using System;
    using System.Linq;
    using ltp_v2.Controls;
    using System.Collections.Generic;
    using rep6043.ExtendedClasses;
    using System.Text.RegularExpressions;

    partial class sqlDataContext
    {
        public IEnumerable<TouristService> GetTouristServicesList(IEnumerable<tbl_DogovorList> value)
        {
            return from xFS in value
                   join qTS in this.TuristServices on xFS.DL_KEY equals qTS.TU_DLKEY into joinTS
                   from xTS in joinTS.DefaultIfEmpty()
                   select new TouristService()
                   {
                       TUKey = (xTS.tbl_Turist == null ? -1 : xTS.tbl_Turist.TU_KEY),
                       DLSVKey = xFS.DL_SVKEY,
                       DLCode = xFS.DL_CODE,
                       DLCode1 = xFS.DL_SUBCODE1,
                       DLCode2 = xFS.DL_SUBCODE2,
                       DLDAY = xFS.DL_DAY.GetValueOrDefault(0),
                       DGCode = xFS.DL_DGCOD,
                       DogDateBeg = xFS.tbl_Dogovor.DG_TURDATE.AddDays(xTS.tbl_DogovorList.DL_DAY.GetValueOrDefault(1) - 1),
                       DogDateEnd = xFS.tbl_Dogovor.DG_TURDATE.AddDays(xTS.tbl_DogovorList.DL_DAY.GetValueOrDefault(1) + xTS.tbl_DogovorList.DL_NDAYS.GetValueOrDefault(1) - 2)
                   };
        }

        public IEnumerable<helperItem> GetListNormalInsurances(IEnumerable<TouristService> value)
        {
            return
                 from xLP in value.Where(x => x.DLSVKey == 6)
                 from xTU in this.tbl_Turists.Where(x => x.TU_KEY == xLP.TUKey)
                 from xIP in this.INS_PERSONs.Where(x => x.IP_TUKEY == xLP.TUKey && !x.INS_INSURANCE.IN_ANNULDATE.HasValue)
                 from xSLR in
                     (
                         from xSL in this.INS_SL_REFs.Where(x =>
                             x.SLR_SLKEY == xLP.DLCode
                             && x.SLR_SUBCODE1 == xLP.DLCode1
                             && x.SLR_SUBCODE2 == xLP.DLCode2)
                         from xCO in this.INS_CONDITIONs.Where(x => x.CO_INKEY == xIP.IP_INKEY)
                         where
                             xSL.SLR_COEF == xCO.CO_COEF
                             && xSL.SLR_INSUREDSUM == xCO.CO_INSUREDSUM
                             && xSL.SLR_INSUREDRATE == xCO.CO_INSUREDRATE
                         select xCO.CO_INKEY)
                 where
                     xIP.IP_NAME.ToUpper().Trim() == xTU.TU_NAMELAT.ToUpper().Trim()
                     && xIP.IP_FNAME.ToUpper().Trim() == xTU.TU_FNAMELAT.ToUpper().Trim()
                     && xTU.TU_BIRTHDAY.HasValue && xIP.IP_BIRTHDAY.Date == xTU.TU_BIRTHDAY.Value.Date
                     && xIP.INS_INSURANCE.IN_DATESTART.Date == xLP.DogDateBeg.Date
                     && (
                         xIP.INS_INSURANCE.IN_NUMBER.LastIndexOf('N') < 0
                         && xIP.INS_INSURANCE.IN_DATEEND.Date == xLP.DogDateEnd.Date
                         || xIP.INS_INSURANCE.IN_NUMBER.LastIndexOf('N') > 0)
                 select new helperItem
                 {
                     LostInsurances = 0,
                     TUKey = xIP.IP_TUKEY,
                     INKey = xIP.INS_INSURANCE.IN_KEY,
                     DLDay = xLP.DLDAY,
                     DGCode = xLP.DGCode
                 };
        }

        public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
        {
            foreach (var itemInsertInsurance in
                this.GetChangeSet().Inserts
                .Where(x => x.GetType() == typeof(INS_INSURANCE))
                .Select(x => (INS_INSURANCE)x)
                .Where(x => x.IN_NUMBERKEY == 0)
                .ToArray())
            {
                using (sqlDataContext tmpSqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
                {
                    //Проверка на существование полиса для этой услуги
                    var checkPresent =
                        from xIN in tmpSqlDC.INS_INSURANCEs.Where(x => x.IN_ANNULDATE == null)
                        from xIP in xIN.INS_PERSONs
                        from xCO in xIN.INS_CONDITIONs
                        where itemInsertInsurance.INS_PERSONs.Select(x=>x.IP_TUKEY).Contains(xIP.IP_TUKEY)
                                && xIN.IN_DATESTART.Date == itemInsertInsurance.IN_DATESTART.Date
                                && xIN.IN_DATEEND.Date == itemInsertInsurance.IN_DATEEND.Date
                        select xCO.CO_RSKEY;

                    if (checkPresent.ToArray().Intersect(itemInsertInsurance.INS_CONDITIONs.Select(x => x.CO_RSKEY).ToArray()).Count() > 0)
                    {
                        foreach (var itemDel in itemInsertInsurance.INS_CONDITIONs.ToArray())
                        {
                            itemInsertInsurance.INS_CONDITIONs.Remove(itemDel);
                            this.INS_CONDITIONs.DeleteOnSubmit(itemDel);
                        }
                        foreach (var itemDel in itemInsertInsurance.INS_TERRITORies.ToArray())
                        {
                            itemInsertInsurance.INS_TERRITORies.Remove(itemDel);
                            this.INS_TERRITORies.DeleteOnSubmit(itemDel);
                        }
                        foreach (var itemDel in itemInsertInsurance.INS_PERSONs.ToArray())
                        {
                            itemInsertInsurance.INS_PERSONs.Remove(itemDel);
                            this.INS_PERSONs.DeleteOnSubmit(itemDel);
                        }

                        this.INS_INSURANCEs.DeleteOnSubmit(itemInsertInsurance);
                    }
                }
            }

            foreach (var insINS_INSURANCE in this.GetChangeSet().Inserts
                .Where(x => x.GetType() == typeof(INS_INSURANCE))
                .Select(x => (INS_INSURANCE)x)
                .Where(x => x.IN_NUMBERKEY == 0))
            {
                int newNumKey = 0;
                using (sqlDataContext tmpSqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
                {
                    newNumKey = tmpSqlDC.INS_INSURANCEs
                        .Where(x => x.IN_NUMBER.IndexOf(insINS_INSURANCE.IN_NUMBER) == 0)
                        .Select(x => (int?)x.IN_NUMBERKEY).Max().GetValueOrDefault(0) + 1;
                }
                insINS_INSURANCE.IN_NUMBERKEY = newNumKey;
                string newNum = insINS_INSURANCE.IN_NUMBERKEY.ToString();
                while (newNum.Length < 6)
                    newNum = "0" + newNum;
                insINS_INSURANCE.IN_NUMBER += "-" + newNum + "M";
            }
            base.SubmitChanges(failureMode);
        }

        private bool? _IsRootManager = null;
        public bool IsRootManager
        {
            get
            {
                if (_IsRootManager.HasValue)
                    return _IsRootManager.Value;
                
                var q= this.ExecuteQuery<bool>("SELECT cast(case when PERMISSIONS(OBJECT_ID('INS_AgeCoef'))&8 = 8 then 1 else 0 end as bit)");
                
                _IsRootManager = (q.First());

                return _IsRootManager.Value;
            }
        }
    }

    partial class COUNTRY
    {
        public override string ToString()
        {
            return this.CN_NAME;
        }
    }

    partial class tbl_Turist
    {
        public override string ToString()
        {
            return (this.TU_NAMELAT == null ? "" : this.TU_NAMELAT.ToUpper().Trim())
                + " " + (this.TU_FNAMELAT == null ? "" : this.TU_FNAMELAT.ToUpper().Trim());
        }

        public enum ErrorCode
        {
            noError = 0,
            FNameIsNull = 2,
            NameIsNull = 4,
            BirthdayIsNull = 8,
            Birthday = 16,
            FName = 32,
            Name = 64
        }

        /// <summary>
        /// Проверка туриста на ошибки
        /// </summary>
        /// <returns></returns>
        public ErrorCode CheckOnError()
        {
            ErrorCode result = ErrorCode.noError;
            if (this.TU_NAMELAT == null || this.TU_NAMELAT.Trim() == "")
            {
                result |= ErrorCode.NameIsNull;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(this.TU_NAMELAT, @".*[^A-Za-z-\s'`\.].*"))
            {
                result |= ErrorCode.Name;
            }

            if (this.TU_FNAMELAT == null || this.TU_FNAMELAT.Trim() == "")
            {
                result |= ErrorCode.FNameIsNull;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(this.TU_FNAMELAT, @".*[^A-Za-z-\s'`\.].*"))
            {
                result |= ErrorCode.FName;
            }

            if (this.TU_BIRTHDAY == null)
            {
                result |= ErrorCode.BirthdayIsNull;
            }
            else if (this.TU_BIRTHDAY.Value > ltp_v2.Framework.SqlConnection.ServerDateTime)
            {
                result |= ErrorCode.Birthday;
            }
            return result;
        }
    }

    partial class INS_INSURANCE
    {
        partial void OnCreated()
        {
            this.IN_IsPrintedByWeb = false;
            this._IN_DATE = ltp_v2.Framework.SqlConnection.ServerDateTime;
            this.IN_IsExport = false;
            this._IN_PRODUCT = "TourTrip";
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(INS_INSURANCE_PropertyChanged);
        }

        void INS_INSURANCE_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (this.InsurancesParent != null && e.PropertyName == "InsurancesParent" && string.IsNullOrEmpty(this.IN_NUMBER))
            {
                this._IN_UseDGCode = this.InsurancesParent.IN_UseDGCode;
                this.IN_NUMBER = this.InsurancesParent.IN_NUMBER + "N";
                this.IN_NUMBERKEY = this.InsurancesParent.IN_NUMBERKEY;
                this._IN_DATE = this.InsurancesParent.IN_DATE;
                this.IN_DATESTART = this.InsurancesParent.IN_DATESTART;
                this.IN_DATEEND = this.InsurancesParent.IN_DATEEND;
                this._IN_DURATION = this.InsurancesParent.IN_DURATION;
                this.IN_INSURED = this.InsurancesParent.IN_INSURED;
                this.IN_PREMIUMTOTALRATE = this.InsurancesParent.IN_PREMIUMTOTALRATE;
                RecalculatePremiumTotal();
            }
        }

        public void ClearPremiumInConditions()
        {
            foreach (var itemCondition in this.INS_CONDITIONs)
            {
                itemCondition.CO_PREMIUMSUM = 0;
            }
            RecalculatePremiumTotal();
        }

        public void RecalculatePremiumTotal()
        {
            decimal totalPrice = 0;
            using (sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
            {
                foreach (var itemConditions in this.INS_CONDITIONs)
                {
                    decimal amountOfService = 0;
                    amountOfService = itemConditions.CO_PREMIUMSUM * (decimal)itemConditions.CO_COEF;
                    if (itemConditions.INS_RISK.RS_CalcOfDay)
                    {
                        amountOfService = itemConditions.INS_INSURANCE.IN_DURATION * amountOfService;
                    }
                    else if (itemConditions.INS_RISK.RS_CalcOfPremuim)
                    {
                        amountOfService = itemConditions.CO_PREMIUMSUM / 100 * itemConditions.CO_INSUREDSUM * (decimal)itemConditions.CO_COEF;
                    }
                    if (itemConditions.INS_RISK.RS_UseAgeCoef)
                    {
                        var currentDogovor = sqlDC.tbl_Dogovors.Where(x=>x.DG_CODE == this.IN_UseDGCode).FirstOrDefault();
                        foreach (var itemPersons in this.INS_PERSONs)
                        {
                            var AgeCoef = sqlDC.INS_AgeCoefs.Where(x => x.AC_AgeFrom <= itemPersons.Age(currentDogovor.DG_TURDATE) && x.AC_AgeTo >= itemPersons.Age(currentDogovor.DG_TURDATE)).Max(x => x.AC_Coef);
                            totalPrice += amountOfService * (decimal)AgeCoef;
                        }
                    }
                    else
                    {
                        totalPrice += amountOfService;
                    }
                }
            }

            this._IN_PREMIUMTOTAL = totalPrice;
            this.OnIN_PREMIUMTOTALRATEChanged();
            SendPropertyChanged("IN_PREMIUMTOTAL");
        }

        partial void OnIN_DATESTARTChanged()
        {
            this._IN_DURATION = (int)(this.IN_DATEEND - this.IN_DATESTART).TotalDays + 1;
        }

        partial void OnIN_DATEENDChanged()
        {
            this._IN_DURATION = (int)(this.IN_DATEEND - this.IN_DATESTART).TotalDays + 1;
        }

        /// <summary>
        /// Анулирование страховки и всех взаимосвязанных с ней
        /// </summary>
        public bool Anulate(bool ByAnnulTour, out string ErrorMessage)
        {
            ErrorMessage = "";
            if (this.IN_DATESTART.Date < DateTime.Now.Date)
            {
                ErrorMessage = "Вы не можете анулировать после заезда";
                return false;
            }

            if (!ByAnnulTour)
            {
                if (this.INS_CONDITIONs.Any(x => x.INS_RISK.RS_CODE == 'D') && (this.IN_DATESTART.Date - DateTime.Now.Date).TotalDays < 5)
                {
                    ErrorMessage = "Вы могли анулировать за 5 дней до заезда";
                    return false;
                }
            }
            DateTime annulDate = ltp_v2.Framework.SqlConnection.ServerDateTime; 
            if (annulDate.Date > this._IN_DATESTART)
                annulDate = this._IN_DATESTART;
            if (annulDate.Month != ltp_v2.Framework.SqlConnection.ServerDateTime.Month)
            {
                ErrorMessage = "Вы могли анулировать только в прошлом месяце";
                return false;
            }

            this.IN_ANNULDATE = annulDate;

            if (this.InsurancesParent != null)
            {
                this.InsurancesParent.IN_ANNULDATE = this.IN_ANNULDATE;
            }
            if (this.InsurancesChield.Count() > 0)
            {
                foreach (var anullChieldIns in this.InsurancesChield)
                {
                    anullChieldIns.IN_ANNULDATE = this.IN_ANNULDATE;
                }
            }
            return true;
        }

        /// <summary>
        /// Обновление данных по туристу
        /// </summary>
        /// <returns>Статус ошибки</returns>
        public string UpdatePersonsName(sqlDataContext sqlDC)
        {
            if (this.IN_DATESTART.Date < ltp_v2.Framework.SqlConnection.ServerDateTime.Date
                    || this.IN_DATE.Month != ltp_v2.Framework.SqlConnection.ServerDateTime.Month)
            {
                return ErrorMessages.ErrUpdatePersonInfoByLostDate;
            }

            if (this.INS_PERSONs.Any(x => x.tbl_Turist == null))
            {
                return ErrorMessages.ErrCrossTuristData;
            }
            if (this.INS_PERSONs.Select(x => x.tbl_Turist).Any(x => !x.TU_BIRTHDAY.HasValue || x.TU_BIRTHDAY.Value.Date > ltp_v2.Framework.SqlConnection.ServerDateTime.Date))
            {
                return ErrorMessages.ErrPersBirthday("");
            }
            var turistNameHaveAnyChar = this.INS_PERSONs.Select(x => x.tbl_Turist).ToArray().Where(x => x.TU_NAMELAT.Trim() == "" || Regex.IsMatch(x.TU_NAMELAT, @".*[^A-Za-z-\s'`\.].*"));
            if (turistNameHaveAnyChar.Count() > 0)
            {
                return ErrorMessages.ErrPersName(turistNameHaveAnyChar.FirstOrDefault().ToString());
            }
            var turistFNameHaveAnyChar = this.INS_PERSONs.Select(x => x.tbl_Turist).ToArray().Where(x => x.TU_FNAMELAT.Trim() == "" || Regex.IsMatch(x.TU_FNAMELAT, @".*[^A-Za-z-\s'`\.].*"));
            if (turistFNameHaveAnyChar.Count() > 0)
            {
                return ErrorMessages.ErrPersFName(turistFNameHaveAnyChar.FirstOrDefault().ToString());
            }

            var ListNeedUpdate = this.INS_PERSONs
                .Where(x =>
                    x.IP_FNAME != x.tbl_Turist.TU_FNAMELAT
                    || x.IP_NAME != x.tbl_Turist.TU_NAMELAT
                    || x.IP_BIRTHDAY.Date != x.tbl_Turist.TU_BIRTHDAY);
            if (ListNeedUpdate.Count() == 0)
            {
                return ErrorMessages.UpdatePersonInformationNotRequired;
            }
            var currentDogovor = sqlDC.tbl_Dogovors.Where(x => x.DG_CODE == this.IN_UseDGCode).FirstOrDefault();
            foreach (var persons in ListNeedUpdate)
            {
                int insur_TuristAge = persons.Age(currentDogovor.DG_TURDATE);
                int dogov_TuristAge = persons.tbl_Turist.TU_BIRTHDAY.Value.TotalYearsOfTheDate(persons.INS_INSURANCE.IN_DATESTART.Date);
                var currentCoef = sqlDC.INS_AgeCoefs.Where(x => x.AC_AgeFrom <= insur_TuristAge && x.AC_AgeTo >= insur_TuristAge).FirstOrDefault().AC_Coef;
                var newCoef = sqlDC.INS_AgeCoefs.Where(x => x.AC_AgeFrom <= dogov_TuristAge && x.AC_AgeTo >= dogov_TuristAge).FirstOrDefault().AC_Coef;

                if (currentCoef != newCoef)
                {
                    return ErrorMessages.ErrUpdatePersonInfoDifferentAges;
                }
                var newValueTblPersons = sqlDC.tbl_Turists.First(x => x.TU_KEY == persons.tbl_Turist.TU_KEY);

                persons.tbl_Turist = null;
                persons.tbl_Turist = newValueTblPersons;
            }
            var firstPersonMaxBD = this.INS_PERSONs.OrderByDescending(x => x.IP_BIRTHDAY).FirstOrDefault();
            this.IN_INSURED = firstPersonMaxBD.IP_NAME + " " + firstPersonMaxBD.IP_FNAME;
            return "";
        }
    }

    partial class INS_TERRITORy
    {
        public override string ToString()
        {
            if (this.INS_COUNTRIES_ING != null)
                return this.INS_COUNTRIES_ING.CI_NAME;
            return "";
        }
    }

    partial class INS_COUNTRIES_ING
    {
        public override string ToString()
        {
            return this.CI_NAME;
        }
    }

    partial class INS_CONDITION
    {
        public override string ToString()
        {
            if (this.INS_RISK !=null)
                return "(" + this.INS_RISK.RS_CODE + ") " + this.INS_RISK.RS_NAME + " " + (int)this.CO_INSUREDSUM + this.CO_INSUREDRATE + " (" + this.CO_PREMIUMSUM + this.CO_INSUREDRATE + " * " + this.CO_COEF + ")";
            return "";
        }
    }

    partial class INS_PERSON
    {
        partial void OnCreated()
        {
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(INS_PERSON_PropertyChanged);
        }

        private void INS_PERSON_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (this.tbl_Turist == null)
                return;

            if (e.PropertyName == this.tbl_Turist.GetType().Name)
            {
                this._IP_NAME = this.tbl_Turist.TU_NAMELAT.ToUpper().Trim();
                this._IP_FNAME = this.tbl_Turist.TU_FNAMELAT.ToUpper().Trim();
                this._IP_BIRTHDAY = this.tbl_Turist.TU_BIRTHDAY.Value.Date;

                if (this.INS_INSURANCE != null)
                {
                    if (this.INS_INSURANCE.InsurancesParent != null
                        && this.INS_INSURANCE.InsurancesParent.INS_PERSONs
                            .Any(x => x.IP_TUKEY == this.tbl_Turist.TU_KEY
                                &&
                                    (
                                        x.IP_NAME != this.tbl_Turist.TU_NAMELAT.ToUpper().Trim()
                                        || x.IP_FNAME != this.tbl_Turist.TU_FNAMELAT.ToUpper().Trim()
                                        || x.IP_BIRTHDAY.Date != this.tbl_Turist.TU_BIRTHDAY.Value.Date
                                    )
                                )
                        )
                    {
                        foreach (var upd in this.INS_INSURANCE.InsurancesParent.INS_PERSONs.Where(x => x.IP_TUKEY == this.tbl_Turist.TU_KEY))
                        {
                            upd.tbl_Turist = null;
                            upd.tbl_Turist = this.tbl_Turist;
                        }
                    }


                    if (this.INS_INSURANCE.InsurancesChield.Count() > 0
                            && this.INS_INSURANCE.InsurancesChield.Any(x => x.INS_PERSONs
                                .Any(xIP => xIP.IP_TUKEY == this.tbl_Turist.TU_KEY
                                    &&
                                        (
                                            xIP.IP_NAME != this.tbl_Turist.TU_NAMELAT.ToUpper().Trim()
                                            || xIP.IP_FNAME != this.tbl_Turist.TU_FNAMELAT.ToUpper().Trim()
                                            || xIP.IP_BIRTHDAY.Date != this.tbl_Turist.TU_BIRTHDAY.Value.Date
                                        )
                                    )
                            )
                        )
                    {
                        foreach (var chld in this.INS_INSURANCE.InsurancesChield)
                        {
                            foreach (var upd in chld.INS_PERSONs.Where(x => x.IP_TUKEY == this.tbl_Turist.TU_KEY))
                            {
                                upd.tbl_Turist = null;
                                upd.tbl_Turist = this.tbl_Turist;
                            }
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return this.IP_NAME.ToString().ToUpper().Trim() + " " + this.IP_FNAME.ToString().ToUpper().Trim() + " " + this.IP_BIRTHDAY.ToString("dd.MM.yyyy");
        }

        public int Age(DateTime TurDate)
        {
            return this.IP_BIRTHDAY.Date.TotalYearsOfTheDate(TurDate.Date);
        }

        private double? _Coef = null;
        public double Coef(DateTime TurDate)
        {
            if (_Coef.HasValue)
                return _Coef.Value;

            using (sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
            {
                _Coef = sqlDC.INS_AgeCoefs.First(x => x.AC_AgeFrom <= Age(TurDate) && x.AC_AgeTo >= Age(TurDate)).AC_Coef;
            }
            return _Coef.Value;
        }
    }

    partial class tbl_Dogovor
    {
        public string DG_RateNormalize
        {
            get {
                if (this.DG_RATE.ToLower() == "рб" && this.DG_CNKEY == 460) // Россия
                    return "$";
                else if (this.DG_RATE.ToLower() == "рб" && this.DG_CNKEY == 5) // Украина
                    return "EU";
                else if (this.DG_RATE.ToLower() == "рб" && this.DG_CNKEY == 17) // Беларусь
                    return "EU";
                else if (this.DG_RATE.ToLower() == "gb" && this.DG_CNKEY == 1111146) // ?????
                    return "EU";
                else
                    return this.DG_RATE; // др. страны
            }
        }

        public enum ErrorCode
        {
            NoError = 0,
            ToBlock5Days = 2,
            LockOnDays = 4,
            ErrorOnDay = 8,
            CrossDateService = 16,
            ErrorDatesUseNotTripService = 32
        }
    }
}
