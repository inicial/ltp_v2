using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace rep25991.Report
{
    public class HelperReport
    {
        public string CountryName { get; set; }
        public string PartnerLine1 { get; set; }
        public string PartnerLine2 { get; set; }
        public string PartnerLine3 { get; set; }

        public int PersonsCount { get; set; }
        public string PersonLine1 { get; set; }
        public string PersonLine2 { get; set; }
        public string PersonLine3 { get; set; }
        public string PersonLine4 { get; set; }

        public string ContactPerson { get; set; }

        public string TravelDates { get; set; }
        public string TourName { get; set; }
        public string ServiceLine1 { get; set; }
        public string ServiceLine2 { get; set; }
        public string ServiceLine3 { get; set; }
        public string ServiceLine4 { get; set; }
        public string ServiceLine5 { get; set; }

        public string VoucherNum { get; set; }
        public string DogovorNum { get; set; }
        public byte[] Logotip { get; set; }
    }
}
