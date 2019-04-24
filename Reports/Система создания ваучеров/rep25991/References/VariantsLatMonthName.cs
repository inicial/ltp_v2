using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep25991.References
{
    public class VariantsLatMonthName
    {
        private static structMonthName[] monthNames = null;
        public static structMonthName[] MonthNames
        {
            get
            {
                if (monthNames == null)
                {
                    monthNames = new structMonthName[] {
                        new structMonthName("Jan", "January"),
                        new structMonthName("Feb", "February"),
                        new structMonthName("Mar", "March"),
                        new structMonthName("Apr", "April"),
                        new structMonthName("May", "May"),
                        new structMonthName("Jun", "June"),
                        new structMonthName("Jul", "July"),
                        new structMonthName("Aug", "August"),
                        new structMonthName("Sep", "September"),
                        new structMonthName("Oct", "October"),
                        new structMonthName("Nov", "November"),
                        new structMonthName("Dec", "December")
                    };
                }
                return monthNames;
            }
        }
    }
}