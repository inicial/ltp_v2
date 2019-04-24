using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep763
{
    public class rptHelperDogovor
    {
        public string DGCode { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal FullPrice 
        {
            get { return (Price > 0 ? Price + Discount : 0); }
        }
        public decimal Payed { get; set; }
        public decimal Profit { get; set; }
        public decimal Overpay
        {
            get { return Payed - Price; }
        }
        public string PartnerName { get; set; }
        public string PartnerINN { get; set; }
        public string DGRate { get; set; }

        public rptHelperDogovor(tbl_Dogovor value)
        {
            PartnerName = value.tbl_Partner.PR_FULLNAME;
            PartnerINN = value.tbl_Partner.PR_INN;
            DGRate = value.DG_RATE;
            DGCode = value.DG_CODE;
            //cast(convert(MONEY, round((DG_DISCOUNTSUM + DG_PRICE),2)) as varchar) + DG_Rate as DG_FULLSUM
            Discount = value.DG_DISCOUNTSUM;
            Price = value.DG_PRICE;
            Payed = (value.DG_PAYED.HasValue ? value.DG_PAYED.Value : 0);
            Profit = (Price > 0 
                ? Price 
                    - value.tbl_DogovorLists
                        .Where(x => x.DL_PAYED.GetValueOrDefault(0) == 0)
                        .Sum(x => x.DL_COST.GetValueOrDefault(0))
                    +value.tbl_DogovorLists
                        .Where(x => x.DL_PAYED.HasValue)
                        .Sum(x => x.DL_PAYED.GetValueOrDefault(0))
                : 0);
        }
    }
}
