using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rep22341
{
    public static class ExtendedMethods
    {
        public static string GetShortLatMonth(this DateTime value)
        {
            switch (value.Month)
            {
                case 1:
                    return "jan";
                case 2:
                    return "feb";
                case 3:
                    return "mar";
                case 4:
                    return "apr";
                case 5:
                    return "may";
                case 6:
                    return "jun";
                case 7:
                    return "jul";
                case 8:
                    return "aug";
                case 9:
                    return "sep";
                case 10:
                    return "oct";
                case 11:
                    return "nov";
                case 12:
                    return "dec";
                default:
                    return "";
            }
        }
    }
}
