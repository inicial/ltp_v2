using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rep259916.ObjectModel;

namespace rep259916.Report
{
    public class ReportStruct
    {
        public string DGCode { get; set; }
        public string ParnterName { get; set; }
        public string PartnerPhones { get; set; }
        public decimal DG_PRICE { get; set; }
        public decimal DG_PAYED { get; set; }
        public int Procent { get; set; }
        public DateTime DG_TURDATE { get; set; }
        public string CN_NAME { get; set; }
        public int CN_KEY { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Lucky { get; set; }
    }
}
