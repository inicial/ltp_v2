using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TLW.SpamMashine.Structs
{
    public struct stRunAtDaysList
    {
        #region Переменные
        private Dictionary<int, stRunAtDay> stRunAtDay;
        #endregion

        #region Методы для работы с DataSet
        /// <summary>
        /// Получение настроек из DataSet
        /// </summary>
        public static stRunAtDaysList getFromDataSet(DataSet Value)
        {
            stRunAtDaysList result = new stRunAtDaysList();
            result.stRunAtDay = new Dictionary<int, stRunAtDay>();
            result.stRunAtDay.Clear();
            if (!Value.Tables.Contains("RunAt")) 
                return result;

            DataTable tmpDT = Value.Tables["RunAt"];

            foreach (DataRow tmDR in tmpDT.Rows)
            {
                int DayOfWeek = Int32.Parse(tmDR["DayOfWeek"].ToString());
                stRunAtDay tmpRunAt = new stRunAtDay();
                tmpRunAt.BeginWork = new stTime(tmDR["Begin"].ToString());
                tmpRunAt.EndWork = new stTime(tmDR["End"].ToString());
                tmpRunAt.IsUse = (bool)tmDR["IsUse"];
                tmpRunAt.IntervalWorkAtMinutes = (int)tmDR["Interval"];
                result.stRunAtDay.Add(DayOfWeek, tmpRunAt);
            }
            return result;
        }

        /// <summary>
        /// Настройки в виде DataSet
        /// </summary>
        public DataTable ConvertedToDataSet
        {
            get
            {
                DataSet Result = new DataSet();
                Result.ReadXmlSchema("services/Configuration.xsd");
                foreach (int Keys in this.stRunAtDay.Keys)
                {
                    DataRow tmpDR = Result.Tables["RunAT"].NewRow();
                    tmpDR["DayOfWeek"] = Keys;
                    tmpDR["Begin"] = this.stRunAtDay[Keys].BeginWork.ToString();
                    tmpDR["End"] = this.stRunAtDay[Keys].EndWork.ToString();
                    tmpDR["IsUse"] = this.stRunAtDay[Keys].IsUse;
                    tmpDR["Interval"] = this.stRunAtDay[Keys].IntervalWorkAtMinutes;
                    Result.Tables["RunAT"].Rows.Add(tmpDR);
                }
                return Result.Tables["RunAT"];
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Текущий день недели 1-пн 7-вс
        /// </summary>
        public int CurrentDayOfWeek
        {
            get { return (Utilites.Consts.ServerDateTime.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)Utilites.Consts.ServerDateTime.DayOfWeek); }
        }

        /// <summary>
        /// Параметры запуска сервиса на текущий день
        /// </summary>
        public stRunAtDay GetSettingByCurentDay
        {
            get { return this.GetSettingByDay(CurrentDayOfWeek); }
        }

        /// <summary>
        /// Параметры запуска сервиса на указанный день недели
        /// </summary>
        /// <param name="IndexDay">День недели 1-пн 7-вс, если 0 то автоматически будет 7</param>
        /// <returns>Если нет данных для запуска на указанные день то возвращает 0:00:00-23:59:59 каждые 60 мин</returns>
        public stRunAtDay GetSettingByDay(DayOfWeek dow)
        {
            return GetSettingByDay((int)dow);
        }

        /// <summary>
        /// Параметры запуска сервиса на указанный день недели
        /// </summary>
        /// <param name="IndexDay">День недели 1-пн 7-вс, если 0 то автоматически будет 7</param>
        /// <returns>Если нет данных для запуска на указанные день то возвращает 0:00:00-23:59:59 каждые 60 мин</returns>
        public stRunAtDay GetSettingByDay(int IndexDay)
        {
            if (IndexDay == 0) IndexDay = 7;
            if (this.stRunAtDay  != null && this.stRunAtDay.ContainsKey(IndexDay))
                return this.stRunAtDay[IndexDay];
            else
                return new stRunAtDay(new stTime("00:00:00"), new stTime("23:59:59"), true, 60);
        }

        /// <summary>
        /// Установка значения рассписания работы сервиса
        /// </summary>
        /// <param name="IndexDay">День недели 1-пн 7-вс</param>
        /// <param name="value">Значение рассписания</param>
        public void SetDay(int IndexDay, stRunAtDay value)
        {
            if (this.stRunAtDay.ContainsKey(IndexDay))
            {
                this.stRunAtDay[IndexDay] = value;
            }
            else
            {
                this.stRunAtDay.Add(IndexDay, value);
            }
        }
        #endregion
    }
}
