
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using TLW.SpamMashine.Structs;

namespace TLW.SpamMashine.Utilites
{
    public class ProcessParser
    {
        #region Свойства
        public DateTime? UseBeg;
        public DateTime? UseEnd;
        public bool SkeepCurrentRow = false;
        #endregion

        #region локальные свойства
        /// <summary>
        /// Настройки сервиса
        /// </summary>
        private stProcess CurrentProcess;
        #endregion

        public ProcessParser(Structs.stProcess process)
        {
            this.CurrentProcess = process;
            UseBeg = null;
            UseEnd = null;
            ResulDTInterval UsePerriod = process.GetNextInterval();

            UseBeg = UsePerriod.BegInterval;
            UseEnd = UsePerriod.EndInterval;
        }

        public bool CheckStartAtTime()
        {
            if (CurrentProcess.NextStartAfter.TotalSeconds > 0)
            {
                return false;
            }
            return true;
        }

        public stOutData GetOutData()
        {
            if (UseBeg == null || UseEnd == null || UseBeg == DateTime.MinValue || UseBeg == UseEnd)
            {
                return null;
            }

            DateTime CurrentDateTime = Utilites.Consts.ServerDateTime;
            if (!CheckStartAtTime())
            {
                return null;
            }

            stOutData outData = new stOutData(CurrentProcess);

            stMatchValue SqlCommandID = ShablonParser.GetSQLCommandID("%SQL#RootSql%")[0];

            if (!CurrentProcess.SQLCommands.ContainsID(SqlCommandID.Code))
                throw new Exception("Нет основного sql запроса " + SqlCommandID);

            stSQL UsingSQL = CurrentProcess.SQLCommands.GetByID(SqlCommandID.Code);

            DataTable ResultGSql = new DataTable();
            ResultGSql.Generate(UsingSQL.SQLCmd, null, UseBeg.Value, UseEnd.Value);

            foreach (DataRow useRows in ResultGSql.Select("", "PR_Key, ExtEMail"))
            {
                #region Подмена Subject
                string Subject = CurrentProcess.Subject;
                Subject = Regex.Replace(Subject, "%PerriodBeg%", UseBeg.Value.ToString("dd-MM-yyyy HH:MM"), RegexOptions.IgnoreCase);
                Subject = Regex.Replace(Subject, "%PerriodEnd%", UseEnd.Value.ToString("dd-MM-yyyy HH:MM"), RegexOptions.IgnoreCase);
                
                SkeepCurrentRow = false;
                string NewValue = Utilites.ReplaceColumns.Replace(UsingSQL.extBody, useRows);
                Subject = Utilites.ReplaceColumns.Replace(Subject, useRows);
                #endregion

                //Подмена %SQL#Название_запроса%
                ShablonParser SP = new ShablonParser();
                NewValue = SP.Start(NewValue, CurrentProcess.SQLCommands, useRows, this);

                // Добавление записи
                if (!SkeepCurrentRow)
                {
                    stPartner PartnerValue = new stPartner(
                        (int)useRows["PR_Key"]
                        , CurrentProcess.MailFrom
                        , useRows["ExtEMail"].ToString().Trim()
                            + (useRows["ExtEMail"].ToString().Trim() == "" ? CurrentProcess.MailTo : (CurrentProcess.MailTo.Trim() != "" ? ";" + CurrentProcess.MailTo : ""))
                        , CurrentProcess.ServiceID
                        , Subject);
                    outData.Add(PartnerValue, NewValue);
                }
            }

            outData.Modify_SqlRoot_Value_By_Shablon(CurrentProcess.extBody);
            return outData;
        }
    }
}