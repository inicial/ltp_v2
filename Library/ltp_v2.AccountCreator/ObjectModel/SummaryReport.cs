using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltp_v2.AccountCreator.ObjectModel
{
    public class SummaryReport
    {
        #region Свойства
        public DateTime AccCreateDate { get; private set; }
        public string PartnerName { get; private set; }
        public string AccNumber { get; private set; }
        public double Summ { get; private set; }
        public double Payed { get; private set; }
        public int AccType { get; private set; }
        #endregion

        #region Конструктор
        public SummaryReport(ltp_v2.AccountCreator.ObjectModel.LTA_Account account)
        {
            this.AccCreateDate = account.AC_CRDate;
            this.PartnerName = (account.Buyer != null ? account.Buyer.PR_Name + " " + account.Buyer.PR_COD : "");
            this.AccNumber = account.AC_Number;
            this.Summ = account.AC_TotalPrice;
            this.Payed = account.GetPayed();
            this.AccType = account.AC_ATID;
        }
        #endregion
    }
}
