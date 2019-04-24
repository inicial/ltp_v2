using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ltp_v2.Controls.Forms.TBHS.Util;

namespace TLW.SpamMashine.Utilites
{
    public class Consts
    {
        public static HighlightItemCollection HL_HTML
        {
            get
            {
                HighlightItemCollection result = new HighlightItemCollection();
                result.Add(@"(%SQL#)([^%]+?)(%)", null, Color.Red);
                result.Add(@"()(%SQL#)()", new Font("Arial", 9, FontStyle.Bold), Color.Blue);
                result.Add(@"(%SQC#)([^%]+?)(%)", null, Color.Red);
                result.Add(@"()(%SQC#)()", new Font("Arial", 9, FontStyle.Bold), Color.Blue);
                result.Add(@"()(<[^>]+>?)()", null, Color.Green);
                result.Add(@"(%SQC#[^%]+#)([^%]+?)(%)", null, Color.Blue);
                result.Add(@"()(#[0-9]{6})()", null, Color.Purple);
                return result;
            }
        }

        public static HighlightItemCollection HL_SQL
        {
            get
            {
                HighlightItemCollection result = new HighlightItemCollection();
                result.Add(@"(\W|^|,|\G){1}(DECLARE|SELECT|DISTINCT|FROM|WHERE|LEFT|INNER|JOIN|ORDER|GROUP|BY|IF|BEGIN|SET|END|ELSE|RETURN|AS|CASE|WHEN|THEN){1}?(\W|,|\G){1}", null, Color.Green);
                result.Add(@"(\W|^|,|\G){1}(INSERT|INTO|UPDATE|DELETE){1}?(\W|,|\G){1}", new Font("Arial", 9, FontStyle.Bold) , Color.Red);
                result.Add(@"(\W|^|,|\G){1}(AND|OR|IS|NULL|NOT){1}?(\W|,|\G){1}", null, Color.Blue);
                result.Add(@"(\W|^|,|\G){1}(GETDATE\(\)|DATEADD|cast|convert|year|month|day|min){1}?(\W|,|\G){1}", null, Color.Purple);
                result.Add(@"(\W|^|,|\G){1}(bigint|numeric|bit|smallint|decimal|smallmoney|int|tinyint|money|float|real|datetimeoffset|datetime2|smalldatetime|datetime|char|varchar|text|nchar|nvarchar|ntext|binary|varbinary|image){1}?(\W|,|\G){1}", new Font("Arial", 9, FontStyle.Italic), Color.Green);
                result.Add(@"(\W|^)(@\w{1,}?)(\W|$)", null, Color.Blue);
                return result;
            }
        }

        public static DateTime ServerDateTime
        {
            get
            {
                DateTime t;
                using (smSQLDataContext RMDC = new smSQLDataContext(global::TLW.SpamMashine.Properties.Settings.Default.dbConnectionString))
                {
                    t = RMDC.ExecuteQuery<DateTime>("SELECT getdate()", new object[0]).First();
                }
                return t;
            }
        }
    }
}
