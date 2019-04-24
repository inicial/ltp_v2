using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltp_v2.Controls
{
    public static class em_DateTime
    {
        /// <summary>
        /// Рассчет кол-ва лет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="OnDate"></param>
        /// <returns></returns>
        public static int TotalYearsOfTheDate(this DateTime sender, DateTime OnDate)
        {
            DateTime DFrom = (sender.Date > OnDate.Date ? OnDate.Date : sender.Date);
            DateTime DTo = (sender.Date > OnDate.Date ? sender.Date : OnDate.Date);

            return new DateTime((DTo - DFrom).Ticks).Year - 1;
        }

        public static string SignedUnits(this int? value, string Minor, string Interim, string Major)
        {
            if (value == null)
                return "";
            return value.Value.SignedUnits(Minor, Interim, Major);
        }
        /// <summary>
        /// Определение правильности написания единиц измерения
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="Minor">1 Год</param>
        /// <param name="Interim">2 Года</param>
        /// <param name="Major">15 Лет</param>
        /// <returns></returns>
        public static string SignedUnits(this int value, string Minor, string Interim, string Major)
        {
            if (value > 99)
                value = (value - (int)value / (int)100 * (int)100);
            if (value > 20)
                value = (value - (int)value / (int)10 * (int)10);
            if (value == 1)
                return Minor;
            else if (value > 1 && value <= 4)
                return Interim;
            else if (value == 0 || value >= 5 && value <= 20)
                return Major;

            return "";
        }
    }
}
