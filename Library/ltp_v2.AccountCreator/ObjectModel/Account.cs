namespace ltp_v2.AccountCreator.ObjectModel
{
    using System;
    using System.Data.Linq;
    using System.Linq;
       
    partial class LTA_Account
    {
        #region Ìועמהû
        public void GenerateAndOpenDocuments()
        {
            foreach (var adItem in this.LTA_AccountDocuments)
            {
                string pathFs = ltp_v2.Framework.MasterValue.PathToOutDoc + "\\ACD-" + adItem.LTA_Account.AC_ID + "-" + adItem.ACF_Id + "." + adItem.ACF_Extension;
                try
                {
                    System.IO.File.Delete(pathFs);
                }
                catch { }

                System.IO.FileStream fs = new System.IO.FileStream(pathFs, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);
                fs.Write(adItem.ACF_Source.ToArray(), 0, adItem.ACF_Source.Length);
                fs.Close();
                System.Diagnostics.Process.Start(pathFs);
                using (AccountDataContext adc = new AccountDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
                {
                    var q = adc.LTA_AccountDocuments.First(x => x.ACF_Id == adItem.ACF_Id);
                    q.ACF_PrintDate = DateTime.Now;
                    adc.SubmitChanges();
                }
            }
        }

        public double GetPayed()
        {
            return (this.FIN_DOCUMENT == null ? 0 : this.FIN_DOCUMENT.FIN_BILL_OUT == null ? 0 :
                this.FIN_DOCUMENT.FIN_BILL_OUT.Where(x => x.BI_ANNULDATE == null).Sum(x => x.BI_PAYED.GetValueOrDefault(0)));
        }

        partial void OnCreated()
        {
            this._AC_CRDate = DateTime.Now;
            this._AC_USID = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_KEY;
        }

        partial void OnLoaded()
        {
            this.TotalPriceString = ltp_v2.Framework.Money.dec2string(this.AC_TotalPrice, 1, ".", this.AC_Rate);
        }

        public void ReCalculateTotalPrice()
        {
            if (this.AC_ID != 0)
                return;

            double TotalPrice = 0;
            foreach (LTA_AccountService asItem in this.LTA_AccountServices)
            {
                TotalPrice += asItem.AS_TotalPrice;
            }
            this.AC_TotalPrice = TotalPrice;
        }

        partial void OnAC_TotalPriceChanged()
        {
            this.TotalPriceString = ltp_v2.Framework.Money.dec2string(this.AC_TotalPrice, 1, ".", this.AC_Rate);
        }
        #endregion
    }

    partial class LTA_AccountService
    {
        partial void OnAS_CountChanged()
        {
            this._AS_TotalPrice = AS_Count * AS_Price;
        }

        partial void OnAS_PriceChanged()
        {
            this._AS_TotalPrice = AS_Count * AS_Price;
        }
    }

    partial class LTA_AccountType
    {
        #region Ìועמהû
        public override string ToString()
        {
            return this.AT_Name;
        }
        #endregion
    }
}
