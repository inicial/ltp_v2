using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using TLW.SpamMashine.Structs;

namespace TLW.SpamMashine.Utilites
{
    public class ShablonParser
    {
        public string Start(String ParentShablon, Structs.stSqlList lSql, DataRow RootDataRow, ProcessParser PP)
        {
            string Result = ParentShablon;
            ListMatchValue ListIDSqlCommands = GetSQLCommandID(ParentShablon);

            foreach (stMatchValue IDSqlCommand in ListIDSqlCommands)
            {
                if (!lSql.ContainsID(IDSqlCommand.Code))
                    return Result;

                stSQL lCurrentUseSQL = lSql.GetByID(IDSqlCommand.Code);

                DataTable ReultGS = new DataTable();
                ReultGS.Generate(lCurrentUseSQL.SQLCmd, RootDataRow, PP.UseBeg.Value, PP.UseEnd.Value);
                if (ReultGS != null && ReultGS.Rows.Count == 0 && lCurrentUseSQL.RequiredPresent)
                {
                    PP.SkeepCurrentRow = true;
                    return "";
                }

                string GroupingNewValues = "";
                foreach (DataRow useRows in ReultGS.Rows)
                {
                    string NewValue = Utilites.ReplaceColumns.Replace(lCurrentUseSQL.extBody, useRows);
                    //Подмена %SQL#Название_запроса%
                    NewValue = this.Start(NewValue, lSql, useRows, PP);
                    GroupingNewValues += NewValue;
                }

                Result = Result.Replace(IDSqlCommand.FullLine, GroupingNewValues); 
            }
            return Result;
        }

        public static ListMatchValue GetSQLCommandID(String Shablon)
        {
            ListMatchValue result = new ListMatchValue();
            MatchCollection SqlCmdNameCollection = Regex.Matches(Shablon, "(?<FullLine>%SQL#(?<SQLCmdName>[A-Za-z]+)%)", RegexOptions.Singleline | RegexOptions.IgnoreCase);

            foreach (Match SqlCmdName in SqlCmdNameCollection)
            {
                result.Add(SqlCmdName.Groups["FullLine"].Value, SqlCmdName.Groups["SQLCmdName"].Value);
            }
            return result;
        }
    }
}
