using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLW.SpamMashine.Structs
{
    public struct stRunAtDay
    {

        #region Свойства
        /// <summary>
        /// Время использования от
        /// </summary>
        public stTime BeginWork;
        /// <summary>
        /// Время использования по
        /// </summary>
        public stTime EndWork;
        /// <summary>
        /// Используется если значение true
        /// </summary>
        public bool IsUse;
        /// <summary>
        /// Интервал использования
        /// </summary>
        public int IntervalWorkAtMinutes;
        #endregion

        #region Инициализация
        public stRunAtDay(stTime beginWork, stTime endWork, bool isUse, int intervalWorkAtMinutes)
        {
            this.BeginWork = beginWork;
            this.EndWork = endWork;
            this.IsUse = isUse;
            this.IntervalWorkAtMinutes = intervalWorkAtMinutes;
        }
        #endregion
    }
}
