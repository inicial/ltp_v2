using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace TLW.SpamMashine.Utilites
{
    /// <summary>
    /// Генерация SQL запроса к БД
    /// </summary>
    public static class GenerateSQL
    {
        private static void SetSqlParametr(this SqlCommand sender, String paramName, SqlDbType type, Object value)
        {
            if (type == SqlDbType.DateTime)
            {
                DateTime dtValue = Utilites.Consts.ServerDateTime;
                if (value.GetType() == typeof(DateTime))
                    dtValue = (DateTime)value;
                else if (value.GetType() == typeof(String))
                    dtValue = DateTime.Parse(value.ToString());

                sender.Parameters.Add(paramName, type).Value = dtValue.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                sender.Parameters.Add(paramName,type).Value = value;
            }
        }

        public static void Generate(this DataTable sender, string SQLCommand, DataRow RootDataRow, DateTime PeriodStart, DateTime PeriodEnd)
        {
            SqlCommand sqlCmd = new SqlCommand(SQLCommand, new SqlConnection(global::TLW.SpamMashine.Properties.Settings.Default.dbConnectionString));
            sqlCmd.Parameters.Clear();

            foreach (Match tmpDeclareMatch in
                Regex.Matches(SQLCommand, "--DECLARE +@(?<Param>[a-zA-Z0-9]+) +(?<Type>[a-zA-Z0-9]+)", RegexOptions.Singleline | RegexOptions.IgnoreCase))
            {
                string Param = tmpDeclareMatch.Groups["Param"].Value.ToUpper();
                SqlDbType Type = (
                    tmpDeclareMatch.Groups["Type"].Value.ToUpper() == "DATETIME" ? SqlDbType.DateTime :
                    tmpDeclareMatch.Groups["Type"].Value.ToUpper() == "INT" ? SqlDbType.Int :
                    tmpDeclareMatch.Groups["Type"].Value.ToUpper() == "BIT" ? SqlDbType.Bit :
                    SqlDbType.VarChar);

                if (tmpDeclareMatch.Groups["Type"].Value.ToUpper() != "TABLE")
                {
                    if (Param == "PERRIODBEG")
                    {
                        sqlCmd.SetSqlParametr(Param, Type, PeriodStart);
                    }
                    else if (Param == "PERRIODEND")
                    {
                        sqlCmd.SetSqlParametr(Param, Type, PeriodEnd);
                    }
                    else
                    {
                        sqlCmd.SetSqlParametr(Param, Type, RootDataRow[Param]);
                    }
                }
            }
            sqlCmd.Connection.Open();
            sqlCmd.CommandTimeout = 9999999;

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
            {
                adapter.Fill(sender);
            }

            sqlCmd.Connection.Close();
        }
    }
}
