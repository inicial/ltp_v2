using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TLW.SpamMashine.Structs
{
    public struct stSQL
    {
        #region Переменные
        public string SqlID;
        public string SQLCmd;
        public string extBody;
        public bool RequiredPresent;
        #endregion

        #region Инициализация
        public stSQL(string SqlID, string SQLCmd, string extBody, bool RequiredPresent)
        {
            this.SqlID = SqlID;
            this.SQLCmd = SQLCmd;
            this.extBody = extBody;
            this.RequiredPresent = RequiredPresent;
        }
        #endregion

        #region Методы
        public static stSqlList getFromDataSet(DataSet Value)
        {
            if (Value.Tables.IndexOf("SQL") < 0) return null;
            if (Value.Tables["SQL"].Rows.Count == 0) return null;

            stSqlList result = null;

            foreach (DataRow tmpDR in Value.Tables["SQL"].Rows)
            {
                if (result == null)
                    result = new stSqlList();

                stSQL tmpstSQL = new stSQL
                {
                    SqlID = tmpDR["SqlID"].ToString(),
                    SQLCmd = tmpDR["SQLCmd"].ToString(),
                    extBody = tmpDR["extBody"].ToString(),
                    RequiredPresent = (Boolean)tmpDR["RequiredPresent"]
                };

                result.Add(tmpstSQL);
            }

            return result;
        }

        public override string ToString()
        {
            return SqlID + " [" + (SQLCmd.Trim() != "" ? "SQLCmd" : "") + " " + (extBody.Trim() != "" ? "extBody" : "") + "]";
        }

        public DataRow getDataRow(DataSet DS)
        {
            DataRow tmpDR = DS.Tables["SQL"].NewRow();
            tmpDR["SqlID"] = this.SqlID;
            tmpDR["SQLCmd"] = this.SQLCmd;
            tmpDR["extBody"] = this.extBody;
            tmpDR["RequiredPresent"] = this.RequiredPresent;
            return tmpDR;
        }
        #endregion

        public static string ConvertCP1251toUTF8(object source)
        {
            Encoding srcEncoding = Encoding.GetEncoding("windows-1251");
            Encoding dstEncoding = Encoding.UTF8;
            byte[] bytes = dstEncoding.GetBytes(source.ToString().Replace("'", "''"));
            byte[] buffer2 = Encoding.Convert(srcEncoding, dstEncoding, bytes);
            return dstEncoding.GetString(buffer2);
        }

        public static string ConvertUTF8toCP1251(object source)
        {
            Encoding dstEncoding = Encoding.GetEncoding("windows-1251");
            Encoding srcEncoding = Encoding.UTF8;
            byte[] bytes = dstEncoding.GetBytes(source.ToString().Replace("'", "''"));
            byte[] buffer2 = Encoding.Convert(srcEncoding, dstEncoding, bytes);
            return dstEncoding.GetString(buffer2);
        }
    }
}

