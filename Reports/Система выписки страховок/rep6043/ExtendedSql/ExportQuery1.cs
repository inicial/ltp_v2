using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep6043.ExtendedSql
{
    public class helperExportQuery
    {
        public string IN_PREMIUMTOTALRATE;
        public string IN_NUMBER;
        public DateTime IN_DATE;
        public string IN_INSURED;
        public DateTime IN_DATESTART;
        public DateTime IN_DATEEND;
        public decimal IN_PREMIUMTOTAL;
        public DateTime? IN_ANNULDATE;
        public int countPersons;
        public decimal RC_COURSE;
    }

    public static class ExportQuery1
    {
        public static string query = @"
DECLARE @fltDateBeg datetime, @fltDateEnd datetime
SET @fltDateBeg = {0}
SET @fltDateEnd = {1}

SELECT	Lower(IN_PREMIUMTOTALRATE) as IN_PREMIUMTOTALRATE,
        IN_NUMBER,
        IN_DATE,
        IN_INSURED,
        IN_DATESTART,
        IN_DATEEND,
        IN_PREMIUMTOTAL,
        IN_ANNULDATE,
        countPersons as countPersons,
        max(RC_COURSE) as RC_COURSE
FROM	(
	SELECT	IN_PREMIUMTOTALRATE,
			IN_NUMBER,
			IN_DATE,
			IN_INSURED,
			IN_DATESTART,
			IN_DATEEND,
			IN_PREMIUMTOTAL,
			IN_ANNULDATE,
			countPersons,
			RC_COURSE
	FROM	INS_Insurances
	INNER JOIN (SELECT count(*) as countPersons, IP_INKey FROM INS_Persons GROUP BY IP_INKey) as q ON IP_INKey = IN_Key
	LEFT JOIN RealCourses ON RC_RCOD1 = 'рб' 
				and case when IN_PREMIUMTOTALRATE = '$' then '$' else 'ec' end = Lower(RC_RCOD2) 
				and RC_DATEBEG >= DATEADD(dd, 0, DATEDIFF(dd, 0, IN_DATE))
				and RC_DATEEND <= DATEADD(dd, 0, DATEDIFF(dd, 0, IN_DATE))
	WHERE	IN_Date between @fltDateBeg and @fltDateEnd
			or IN_ANNULDATE between @fltDateBeg and @fltDateEnd
) as q
GROUP BY IN_PREMIUMTOTALRATE,
        IN_NUMBER,
        IN_DATE,
        IN_INSURED,
        IN_DATESTART,
        IN_DATEEND,
        IN_PREMIUMTOTAL,
        IN_ANNULDATE,
        countPersons
";
    }
}
