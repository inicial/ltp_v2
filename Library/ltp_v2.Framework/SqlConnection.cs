using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace ltp_v2.Framework
{
    public class SqlConnection
    {
        public static DateTime ServerDateTime
        {
            get
            {
                DateTime t;
                using (ReferencesModelDataContext RMDC = new ReferencesModelDataContext(SqlConnection.Connection))
                {
                    t = RMDC.ExecuteQuery<DateTime>("SELECT getdate()", new object[0]).First();
                }
                return t;
            }
        }

        public static string ConnectionData
        {
            get
            {
                return ConnectionString(ConnectionUserName, ConnectionPassword);
            }
        }

        public static string ConnectionPassword;
        public static string ConnectionProgram;
        public static string ConnectionUserName;
        public static string ConnectionDBName
        {
            get
            {
                string[] Tags = global::ltp_v2.Framework.ApplicationConf.LantaSqlConnection.Split(';');
                foreach (string Tag in Tags)
                {
                    string[] TagValue = Tag.Split('=');
                    if (TagValue.Length == 2 && TagValue[0].ToLower() == ("Initial Catalog").ToLower())
                    {
                        return TagValue[1];
                    }
                }
                return "";
            }
        }

        public static string ConnectionDBServer
        {
            get
            {
                string[] Tags = global::ltp_v2.Framework.ApplicationConf.LantaSqlConnection.Split(';');
                foreach (string Tag in Tags)
                {
                    string[] TagValue = Tag.Split('=');
                    if (TagValue.Length == 2 && TagValue[0].ToLower() == ("Data Source").ToLower())
                    {
                        return TagValue[1];
                    }
                }
                return "";
            }
        }

        private static UserList userInformation;

        public static UserList ConnectionUserInformation
        {
            get
            {
                if (userInformation == null)
                    userInformation = new ReferencesModelDataContext(SqlConnection.Connection)
                    .UserLists.Where(X => X.US_USERID.ToLower() == SqlConnection.ConnectionUserName.ToLower())
                    .First();
                return userInformation;
            }
        }
        public static string Connection
        {
            get
            {
                return string.Format(global::ltp_v2.Framework.ApplicationConf.LantaSqlConnection, ConnectionUserName, ConnectionPassword, ConnectionProgram);
            }
        }

        public static string ConnectionString(string UserName, string UserPass)
        {
            ConnectionPassword = UserPass;
            ConnectionUserName = UserName;
            return ConnectionString(ConnectionUserName, ConnectionPassword, ConnectionProgram);
        }

        public static string ConnectionString(string UserName, string UserPass, string ProgramName)
        {
            string res = string.Format(global::ltp_v2.Framework.ApplicationConf.LantaSqlConnection, UserName, UserPass, ProgramName);
            if (!res.ToLower().Contains("app"))
                res += ";app="+ProgramName;
            return res;
        }

        public static bool CheckConnectionValid()
        {
            bool result = true;
            try
            {
                using (System.Data.SqlClient.SqlConnection tmpSqlConn = new System.Data.SqlClient.SqlConnection(ConnectionData))
                {
                    tmpSqlConn.Open();
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
