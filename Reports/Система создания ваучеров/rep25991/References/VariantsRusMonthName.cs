using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep25991.References
{
    public class VariantsRusMonthName
    {
        private static structMonthName[] monthNames = null;
        public static structMonthName[] MonthNames
        {
            get
            {
                sqlDataContext sqlS = new sqlDataContext();

                if (monthNames == null)
                {
                    monthNames = new structMonthName[] {
                        new structMonthName("Янв", "Январь"),
                        new structMonthName("Фев", "Февраль"),
                        new structMonthName("Мар", "Март"),
                        new structMonthName("Апр", "Апрель"),
                        new structMonthName("Май", "Май"),
                        new structMonthName("Июн", "Июнь"),
                        new structMonthName("Июл", "Июль"),
                        new structMonthName("Авг", "Август"),
                        new structMonthName("Сен", "Сентябрь"),
                        new structMonthName("Окт", "Октябрь"),
                        new structMonthName("Нов", "Ноябрь"),
                        new structMonthName("Дек", "Декабрь")
                    };
                }
                return monthNames;
            }
        }
    }
}