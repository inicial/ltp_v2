using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TLW.SpamMashine.Utilites;

namespace TLW.SpamMashine.Structs
{
    public class stProcess
    {
        #region Перменные
        public string ServiceID { get; set; }
        public string FilePath { get; set; }
        public string Subject;
        public string extBody;
        public string MailFrom;
        public string MailTo;
        public stSqlList SQLCommands;
        public stRunAtDaysList RunAt;

        public string FileName
        {
            get { return new System.IO.FileInfo(FilePath).Name; }
        }

        private DateTime? _LastStartProcess;

        public DateTime? LastStartProcess
        {
            private set
            {
                _LastStartProcess = value;
            }
            get
            {
                if (_LastStartProcess == null)
                {
                    ResulDTInterval value = GetNextInterval();
                    _LastStartProcess = value.BegInterval;
                }
                return _LastStartProcess;
            }
        }

        public TimeSpan NextStartAfter
        {
            get
            {
                TimeSpan result = new TimeSpan(999, 23, 59, 59, 999);
                int AddsDay = 0;
                while (AddsDay < 7)
                {
                    DateTime currentUseDateTime = Utilites.Consts.ServerDateTime.AddDays(AddsDay);

                    stRunAtDay rad = this.RunAt.GetSettingByDay(currentUseDateTime.DayOfWeek);
                    if (rad.IsUse) // используется в выбранный день
                    {
                        DateTime BeginWork = currentUseDateTime.Date.Add(rad.BeginWork.getTime);
                        DateTime EndWork = currentUseDateTime.Date.Add(rad.EndWork.getTime);
                        DateTime LastUse = (LastStartProcess.HasValue ? LastStartProcess.Value : DateTime.MinValue);
                        DateTime NextUse = LastUse.AddMinutes(rad.IntervalWorkAtMinutes);

                        if (AddsDay == 0 && BeginWork <= currentUseDateTime && EndWork >= currentUseDateTime) // Рассчет для текущего дня и времени
                        {
                            result = (NextUse - Utilites.Consts.ServerDateTime);
                            break;
                        }
                        else if (AddsDay == 0 && NextUse.Date <= Utilites.Consts.ServerDateTime.Date && EndWork >= NextUse)
                        {
                            result = BeginWork - Utilites.Consts.ServerDateTime;
                            break;
                        }
                        else if (AddsDay != 0) // Рассчет следующего дня
                        {
                            result = (BeginWork - Utilites.Consts.ServerDateTime);
                            break;
                        }
                    }

                    AddsDay++;
                }
                if (result.TotalSeconds < 0)
                    LastStartProcess = null;
                return result;
            }
        }
        #endregion

        #region Инициализация
        public stProcess()
        {
            this.SQLCommands = new stSqlList();
            this.RunAt = new stRunAtDaysList();
        }
        
        public stProcess(string extBody, string MailTo, string MailFrom, string Subject, string ServiceID) : this()
        {
            this.extBody = extBody;
            this.MailTo = MailTo;
            this.MailFrom = MailFrom;
            this.Subject = Subject;
            this.ServiceID = ServiceID;
        }
        #endregion

        public override string ToString()
        {
            return this.ServiceID;
        }

        #region Методы
        public ResulDTInterval GetNextInterval()
        {
            smSQLDataContext dc = new smSQLDataContext(global::TLW.SpamMashine.Properties.Settings.Default.dbConnectionString);
            ResulDTInterval result = dc.GetNextUsePerriod(this.ServiceID, this.RunAt.GetSettingByCurentDay.IntervalWorkAtMinutes);
            dc.Dispose();
            return result;
        }
        #endregion

        #region Методы для работы с DataSet
        /// <summary>
        /// Получение настроек из DataSet
        /// </summary>
        public static stProcess getFromDataSet(string fileName, DataSet value)
        {
            if (value.Tables.IndexOf("Service") < 0) return new stProcess();
            if (value.Tables["Service"].Rows.Count == 0) return new stProcess();

            DataRow tmpDR = value.Tables["Service"].Rows[0];

            stProcess stService = new stProcess
            {
                extBody = tmpDR["extBody"].ToString(),
                MailTo = tmpDR["MailTo"].ToString(),
                MailFrom = tmpDR["MailFrom"].ToString(),
                Subject = tmpDR["Subject"].ToString(),
                ServiceID = tmpDR["ServiceID"].ToString(),
                FilePath = fileName
            };
            stService.SQLCommands = stSQL.getFromDataSet(value);
            stService.RunAt = stRunAtDaysList.getFromDataSet(value);
            return stService;
        }

        /// <summary>
        /// Настройки процесса в виде DataSet
        /// </summary>
        public DataSet ConvertedToDataSet
        {
            get
            {
                DataSet Result = new DataSet();
                Result.ReadXmlSchema("services/Configuration.xsd");

                DataRow tmpDR = Result.Tables["Service"].NewRow();
                tmpDR["extBody"] = this.extBody;
                tmpDR["MailFrom"] = this.MailFrom;
                tmpDR["MailTo"] = this.MailTo;
                tmpDR["ServiceID"] = this.ServiceID;
                tmpDR["Subject"] = this.Subject;
                Result.Tables["Service"].Rows.Add(tmpDR);

                foreach (stSQL drSql in this.SQLCommands)
                {
                    Result.Tables["SQL"].Rows.Add(drSql.getDataRow(Result));
                }
                Result.Tables["RunAt"].Clear();
                foreach (DataRow tmpDRItem in this.RunAt.ConvertedToDataSet.Rows)
                {
                    DataRow dr = Result.Tables["RunAt"].NewRow();
                    foreach (DataColumn tmpCol in Result.Tables["RunAt"].Columns)
                    {
                        dr[tmpCol.ColumnName] = tmpDRItem[tmpCol.ColumnName];
                    }
                    Result.Tables["RunAt"].Rows.Add(dr);
                }
                return Result;
            }
        }
        #endregion
    }
}
