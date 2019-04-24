using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLW.SpamMashine.Structs
{
    public class stTime
    {
        #region Свойства
        public int Hour;
        public int Minute;
        public int Second;
        public TimeSpan getTime
        {
            get
            {
                return new TimeSpan(Hour, Minute, Second);
            }
        }
        public DateTime getTimeOfCurrentDate
        {
            get
            {
                return new DateTime(
                    Utilites.Consts.ServerDateTime.Year, 
                    Utilites.Consts.ServerDateTime.Month, 
                    Utilites.Consts.ServerDateTime.Day, 
                    getTime.Hours, getTime.Minutes, getTime.Seconds);
            }
        }
        #endregion

        #region Инициализация
        public stTime(DateTime Value)
        {
            this.Hour = Value.Hour;
            this.Minute = Value.Minute;
            this.Second = Value.Second;
        }

        public stTime(String ValueInTimeFormat)
        {
            string[] Values = ValueInTimeFormat.Split(':');
            this.Hour = Int32.Parse(Values[0]);
            this.Minute = Int32.Parse(Values[1]);
            this.Second = Int32.Parse(Values[2]);
        }
        #endregion

        public override string ToString()
        {
            return (Hour < 10 ? "0" : "") + Hour.ToString() + ":"
                + (Minute < 10 ? "0" : "") + Minute.ToString() + ":"
                + (Second < 10 ? "0" : "") + Second.ToString();
        }
    }
}
