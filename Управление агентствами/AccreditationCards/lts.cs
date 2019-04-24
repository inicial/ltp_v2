namespace AccreditationCards
{
    using System;
    using System.Linq;
    using System.Data.Linq;
    using System.Collections.Generic;
    using ltp_v2.AccountCreator.ObjectModel;

    partial class LTP_AccreditationCard
    {
        #region Свойства
        private DateTime? _EndCardUsed;
        private DateTime? _BegCardUsed;
        private DateTime? _DogDateStart;
        private DateTime? _DogDateEnd;

        public string _DogovorNum;

        public string CardType
        {
            get
            {
                return (
                    !this.LTPA_CardType.HasValue 
                        ? ""
                        : this.LTPA_CardType == 0
                            ? "Основная"
                            : "Дубликат № " + LTPA_CardType.GetValueOrDefault(0));
            }
        }

        /// <summary>
        /// Сумма для оптлаты по счетам
        /// </summary>
        public double AccountSumm
        {
            get
            {
                double Result = 0;
                var accountCreator = new ltp_v2.AccountCreator.AccountCreator();
                var insAccount = accountCreator.GetAccount(this.LTPA_ACId);
                if (insAccount.AC_IsAnull == null)
                {
                    Result += insAccount.AC_TotalPrice;
                }

                var delAccounts = accountCreator.GetAccounts(this.LTPA_PRKey, 3)
                    .Where(x => 
                        !x.AC_IsAnull.HasValue
                        && x.AC_Param1 == this.LTPA_CardNum);

                foreach (var delAccount in delAccounts)
                {
                    Result += delAccount.AC_TotalPrice;
                }
                return Result;
            }
        }

        /// <summary>
        /// Сумма проплаты по счетам
        /// </summary>
        public double AccountsPayed
        {
            get
            {
                double Result = 0;
                var accountCreator = new ltp_v2.AccountCreator.AccountCreator();
                var insAccount = accountCreator.GetAccount(this.LTPA_ACId);
                if (!insAccount.AC_IsAnull.HasValue && insAccount.AC_DCKey.HasValue)
                {
                    Result += insAccount.GetPayed();
                }

                var delAccounts = accountCreator.GetAccounts(this.LTPA_PRKey, 3)
                    .Where(x =>
                        !x.AC_IsAnull.HasValue
                        && x.AC_DCKey.HasValue
                        && x.AC_Param1 == this.LTPA_CardNum);

                foreach (var delAccount in delAccounts)
                {
                    Result += delAccount.GetPayed();
                }
                return Result; //Summary: Псевдо оплата
            }
        }

        public ltp_v2.AccountCreator.ObjectModel.LTA_Account AccountForPay
        {
            get
            {
                var accountCreator = new ltp_v2.AccountCreator.AccountCreator();
                return accountCreator.GetAccount(this.LTPA_ACId);
            }
        }

        /// <summary>
        /// Дата начала действия договора к которому привязана карта
        /// </summary>
        public DateTime? CardDateStart
        {
            get
            {
                if (!_LTPA_ActivationDate.HasValue)
                    return null;

                if (_BegCardUsed.HasValue)
                    return _BegCardUsed;

                if (DogDateStart.HasValue)
                {
                    if (_LTPA_ActivationDate.Value.Date < this.DogDateStart.Value.Date)
                        return _BegCardUsed = this.DogDateStart.Value.Date;
                    else
                        return _BegCardUsed = this._LTPA_ActivationDate.Value.Date;

                }
                return null;
            }
        }

        /// <summary>
        /// Дата завершения действия договора к которому привязана карта
        /// </summary>
        public DateTime? CardDateEnd
        {
            get
            {
                if (_EndCardUsed.HasValue)
                    return _EndCardUsed;

                if (LTPA_BlockDate.HasValue && LTPA_LTPDKey.HasValue)
                    return (LTPA_BlockDate.Value.Date < this.LTP_PrtDog.LTPD_DateEnd.Value.Date 
                        ? LTPA_BlockDate.Value.Date 
                        : this.LTP_PrtDog.LTPD_DateEnd.Value.Date);

                if (LTPA_BlockDate.HasValue)
                    return _EndCardUsed = this.LTPA_BlockDate.Value.Date;

                if (LTPA_LTPDKey != null)
                    return _EndCardUsed = this.LTP_PrtDog.LTPD_DateEnd.Value.Date;
                
                return null;
            }
        }

        /// <summary>
        /// Дата начла действия договора
        /// </summary>
        public DateTime? DogDateStart
        {
            get
            {
                if (_DogDateStart.HasValue)
                    return _DogDateStart;

                if (LTPA_LTPDKey != null)
                {
                    return _DogDateStart = this.LTP_PrtDog.LTPD_DateStart.Value.Date;
                }
                return null;
            }
        }

        /// <summary>
        /// Дата завершения действия договора
        /// </summary>
        public DateTime? DogDateEnd
        {
            get
            {
                if (_DogDateEnd.HasValue)
                    return _DogDateEnd;

                if (LTPA_LTPDKey != null)
                {
                    return _DogDateEnd = this.LTP_PrtDog.LTPD_DateEnd.Value.Date;
                }
                return null;
            }
        }

        public string Partner_UsingCard
        {
            get
            {
                return this.tbl_Partner_UsingCard.PR_NAME;
            }
        }

        public string ActivationUserName
        {
            get
            {
                return (this.LTPA_ActivationUsKey != null ? this.UserList_Activation.US_FullName : "");
            }
        }

        public string PartnerName_SendCardTo
        {
            get
            {
                return this.tbl_Partner_SendToOffice != null ? this.tbl_Partner_SendToOffice.PR_NAME : "";
            }
        }

        public string PrintedUserName
        {
            get
            {
                return (this.LTPA_PrintedUSKey != null ? this.UserList_Printed.US_FullName : "");
            }
        }

        #endregion

        #region Методы
        partial void OnLoaded()
        {
            if (!this.LTPA_LTPDKey.HasValue)
            {
                var dogovor = this.tbl_Partner_UsingCard.GetDogovor(this.LTPA_CRDate);
                if (dogovor != null)
                {
                    this.LTP_PrtDog = dogovor;
                }
            }
        }
        partial void OnCreated()
        {
            this._LTPA_CRDate = DateTime.Now;
        }
        /// <summary>
        /// Деактивация карты
        /// </summary>
        public void DeactivateCard()
        {
            if (!this.LTPA_BlockDate.HasValue
                && this.LTPA_ActivationDate.HasValue)
            {
                this.LTPA_BlockDate = DateTime.Now;
            }
        }
        /// <summary>
        /// Активация карты
        /// </summary>
        public void ActiveCard()
        {
            if (!this.LTPA_BlockDate.HasValue
                && !this.LTPA_ActivationDate.HasValue
                && this.LTPA_PrintedDate.HasValue)
            {
                this.LTPA_ActivationDate = DateTime.Now;
                this.LTPA_ActivationUsKey = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_KEY;
            }
        }

        /// <summary>
        /// Стаиус печати карты
        /// </summary>
        public void PrintCard()
        {
            if (!this.LTPA_BlockDate.HasValue
                && !this.LTPA_ActivationDate.HasValue
                && !this.LTPA_PrintedDate.HasValue)
            {
                this.LTPA_PrintedDate = DateTime.Now;
                this.LTPA_PrintedUSKey = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_KEY;
            }
        }

        public override string ToString()
        {
            return this.LTPA_CardNum;
        }
        #endregion
    }

    partial class tbl_Partner
    {
        public LTP_PrtDog GetDogovor(DateTime datetime)
        {
            var dogRootList = this.LTP_PrtDogs.Where(x =>
                x.LTP_DogType.LDT_IsRoot);
            // получение текущего договора
            var q = dogRootList.Where(x =>
                x.LTPD_DateStart.Value.Date <= datetime
                && x.LTPD_DateEnd.Value.Date.AddMonths(-1) >= datetime
                ).OrderBy(x => x.LTPD_Key);

            // Если текущий договор не найден
            if (q.Count() == 0)
            {
                // получение следующего активного, основного договора
                q = dogRootList.Where(x =>
                x.LTPD_DateStart.Value.Date >= datetime
                && x.LTP_DogType.LDT_IsRoot).OrderBy(x => x.LTPD_Key);
            }

            return (q.Count() != 0 ? q.First() : null);
        }
    }
}
