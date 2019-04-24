namespace CallCenter
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using ltp_v2.Framework;

    partial class tbl_Partner
    {
        public String NameForForms
        {
            get
            {
                if (PR_NAME == "")
                    return "Новый";
                else
                    return this.PR_NAME + " " + PR_CITY + " [" + PR_COD + "]";
            }
        }

        public override string ToString()
        {
            return this.PR_NAME + " [" + this.PR_COD + "]";
        }
    }

    partial class LCC_Partner
    {
        #region Свойства
        public bool? UsedCallCenter_OnLoad;
        public string[] GetPhonesByType(LCC_TypeCallCenter ccType)
        {
            List<string> result = new List<string>();
            var PhonesByType = this.LCC_Phones.Where(x => x.LCC_TypeCallCenter == ccType);
            foreach (LCC_Phones itemCCPhones in PhonesByType)
            {
                result.AddRange(itemCCPhones.LPT_Phones.Split(new char[] { ',', ';', ' ' }));
            }
            return result.ToArray();
        }

        public void SetPhonesByType(LCC_TypeCallCenter ccType, List<String> Phones)
        {
            var UsedCCPhonesByType = this.LCC_Phones.Where(x => x.LCC_TypeCallCenter == ccType);
            var UsedCCPhoneByType = (UsedCCPhonesByType.Count() > 0 ? UsedCCPhonesByType.First() : new LCC_Phones());
            UsedCCPhoneByType.LCC_TypeCallCenter = ccType;
            UsedCCPhoneByType.LPT_Phones = String.Join(";", Phones.Where(x => x.Trim() != "").ToArray());
            if (UsedCCPhoneByType.LCC_Partner == null)
            {
                this.LCC_Phones.Add(UsedCCPhoneByType);
            }
        }

        #endregion

        #region Методы
        partial void OnCreated()
        {
            this.LCP_Rait = 0;
            this.LCP_UsedCallCenter = false;
            this.LCP_CRDate = DateTime.Now;
            this.LCP_IsFreeService = false;
            this.LCP_LastUSKey = SqlConnection.ConnectionUserInformation.US_KEY;
            this.UsedCallCenter_OnLoad = false;
        }

        partial void OnLoaded()
        {
            this.UsedCallCenter_OnLoad = this.LCP_UsedCallCenter;
        }
        #endregion

        #region Методы сменяющие LCP_LastUSKey
        partial void OnLCP_IsFreeServiceChanging(bool value)
        {
            if (this._LCP_IsFreeService != value)
                this.LCP_LastUSKey = SqlConnection.ConnectionUserInformation.US_KEY;
        }

        partial void OnLCP_UsedCallCenterChanging(bool value)
        {
            if (this._LCP_UsedCallCenter != value)
                this.LCP_LastUSKey = SqlConnection.ConnectionUserInformation.US_KEY;
        }

        partial void OnLCP_MSIDChanging(int value)
        {
            if (this._LCP_MSID != value)
                this.LCP_LastUSKey = SqlConnection.ConnectionUserInformation.US_KEY;
        }
        #endregion
    }

    partial class tbl_Country
    {
        public override string ToString()
        {
            return this.CN_NAME;
        }
    }
}
