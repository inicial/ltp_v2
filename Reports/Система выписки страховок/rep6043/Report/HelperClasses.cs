using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep6043.Report
{
    public class InsHeader
    {
        public int Id { get; private set; }
        public string Number { get; private set; }
        public string InsuredFio { get; private set; }

        public DateTime DateBeg { get; private set; }
        public DateTime DateEnd { get; private set; }
        public int Duration { get; private set; }
        public DateTime DateCreate { get; private set; }

        public decimal PrimiumTotal { get; private set; }
        public string PrimiumRate { get; private set; }
        public decimal RealCourseToRub { get; private set; }

        public InsHeader(INS_INSURANCE value, sqlDataContext sqlDC)
        {
            this.Id = value.IN_KEY;
            this.Number = value.IN_NUMBER;
            this.InsuredFio = value.IN_INSURED;
            this.DateBeg = value.IN_DATESTART;
            this.DateEnd = value.IN_DATEEND;
            this.Duration = value.IN_DURATION;
            this.DateCreate = value.IN_DATE;
            this.PrimiumTotal = value.IN_PREMIUMTOTAL;
            this.PrimiumRate = value.IN_PREMIUMTOTALRATE;


            var RealCoursesToRub = sqlDC.RealCourses.Where(X =>
                X.RC_RCOD1.ToLower() == "рб"
                && X.RC_RCOD2.ToLower() == (this.PrimiumRate.ToLower() == "$" ? "$" : "ec")
                && X.RC_DATEBEG.Value.Date >= this.DateCreate.Date
                && X.RC_DATEEND.Value.Date <= this.DateCreate.Date);
            if (RealCoursesToRub.Count() > 0)
                RealCourseToRub = RealCoursesToRub.First().RC_COURSE.GetValueOrDefault(1);
            RealCourseToRub = 1;
        }
    }

    public class InsConditions
    {
        public string Name { get; set; }
        public decimal Premium { get; set; }
        public double Franchise { get; set; }
        public string PremiumRate { get; private set; }

        public InsConditions(INS_CONDITION value)
        {
            this.Name = value.INS_RISK.RS_NAME;
            this.Premium = value.CO_INSUREDSUM;
            this.Franchise = value.CO_FRANCHISE;
            this.PremiumRate = value.CO_INSUREDRATE;
        }
    }
}