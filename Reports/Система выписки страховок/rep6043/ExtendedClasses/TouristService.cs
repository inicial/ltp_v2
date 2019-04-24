using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep6043.ExtendedClasses
{
    public class TouristService
    {
        public int TUKey { get; set; }
        public int DLSVKey { get; set; }
        public int DLCode { get; set; }
        public int? DLCode1 { get; set; }
        public int? DLCode2 { get; set; }
        public short DLDAY { get; set; }
        public string DGCode { get; set; }
        public DateTime DogDateBeg;
        public DateTime DogDateEnd;
        public DateTime TurDate;
    }

    public class helperItem
    {
        public byte LostInsurances { get; set; }
        public int TUKey { get; set; }
        public int INKey { get; set; }
        public int DLDay { get; set; }
        public string DGCode { get; set; }
        public DateTime TurDate { get; set; }
    }
}
