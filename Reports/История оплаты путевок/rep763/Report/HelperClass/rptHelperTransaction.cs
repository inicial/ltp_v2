using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ltp_v2.Framework;

namespace rep763
{
    public class rptHelperTransaction
    {
        private double _Course = double.NaN;
        public string DGCode { get; set; }
        public double Summ_Transaction { get; set; }
        public double Summ_DogovorRate { get; set; }
        public double Summ_National { get; set; }
        public DateTime Date_Course { get; set; }
        public DateTime Date_Transaction { get; set; }
        public string Rate_Transaction { get; set; }
        public string Rate_Dogovor { get; set; }
        public string WhoPayments { get; set; }
        public string PaymentsType { get; set; }
        
        public double Course
        {
            get
            {
                if (!double.IsNaN(_Course))
                    return _Course;
                lSqlDataContext lSql = new lSqlDataContext(SqlConnection.Connection);
                var rc1 = lSql.RealCourses.Where(xRC =>
                                   Date_Course.Date >= xRC.RC_DATEBEG.Value.Date
                                   && Date_Course.Date <= xRC.RC_DATEEND.Value.Date
                                   && Rate_Transaction == xRC.RC_RCOD1
                                   && Rate_Dogovor == xRC.RC_RCOD2);
                if (rc1.Count() > 0)
                    return _Course = (double)rc1.First().RC_COURSE.GetValueOrDefault(0);

                var rc2 = lSql.RealCourses.Where(xRC =>
                                   Date_Course.Date >= xRC.RC_DATEBEG.Value.Date
                                   && Date_Course.Date <= xRC.RC_DATEEND.Value.Date
                                   && Rate_Transaction == xRC.RC_RCOD2
                                   && Rate_Dogovor == xRC.RC_RCOD1);
                if (rc2.Count() > 0)
                    return _Course = (double)rc2.First().RC_COURSE.GetValueOrDefault(0);

                return _Course = 0;
            }
        }
    }
}
