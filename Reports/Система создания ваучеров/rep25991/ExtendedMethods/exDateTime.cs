using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rep25991.References;

namespace rep25991
{
    public static class exDateTime
    {
        public static structDateFormat[] VariantsDateTime = new structDateFormat[] {
            new structDateFormat("dd-MM-yyyy"),
            new structDateFormat("dd.MM.yyyy"),
            new structDateFormat("dd/MM/yyyy"),
            new structDateFormat("LMM.dd.yy"),
            new structDateFormat("LMM.dd.yyyy"),
            new structDateFormat("LMMM.dd.yy"),
            new structDateFormat("LMMM.dd.yyyy"),
            new structDateFormat("RMM.dd.yy"),
            new structDateFormat("RMM.dd.yyyy"),
            new structDateFormat("RMMM.dd.yy"),
            new structDateFormat("RMMM.dd.yyyy"),
            new structDateFormat("LMM-dd-yy"),
            new structDateFormat("LMM-dd-yyyy"),
            new structDateFormat("LMMM-dd-yy"),
            new structDateFormat("LMMM-dd-yyyy"),
            new structDateFormat("RMM-dd-yy"),
            new structDateFormat("RMM-dd-yyyy"),
            new structDateFormat("RMMM-dd-yy"),
            new structDateFormat("RMMM-dd-yyyy")
        };

        public static string ConvertToMyFormat(this DateTime value, structDateFormat Format)
        {
            return value.ConvertToMyFormat(Format.FormatDate);
        }

        public static string ConvertToMyFormat(this DateTime value, string Format)
        {
            if (Format == null)
                return value.ToString("dd.MM.yyyy");
            int day = value.Day;
            int month = value.Month;
            int year = value.Year;
            string format = (string.IsNullOrEmpty(Format) ? "" : Format);
            return format
                .Replace("dd", (day < 10)
                    ? ("0" + day.ToString())
                    : day.ToString())
                .Replace("yyyy", year.ToString())
                .Replace("yy", year.ToString().Substring(2, 2))
                .Replace("LMMM", ((structMonthName)VariantsLatMonthName.MonthNames[month - 1]).LongName)
                .Replace("LMM", ((structMonthName)VariantsLatMonthName.MonthNames[month - 1]).ShortName)
                .Replace("RMMM", ((structMonthName)VariantsRusMonthName.MonthNames[month - 1]).LongName)
                .Replace("RMM", ((structMonthName)VariantsRusMonthName.MonthNames[month - 1]).ShortName)
                .Replace("MM", (month < 10) ? ("0" + month.ToString()) : month.ToString());
        }
    }
}
