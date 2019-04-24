using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace TLW.SpamMashine.Utilites
{
    public class ReplaceColumns
    {
        public static string Replace(string InputLine, DataRow useRows)
        {
            //(?<FullLine>%SQC#(?<SQLColumnName>[^%]+)%)
            MatchCollection MCInBody = Regex.Matches(InputLine, @"(?<FullLine>%SQC#(?<SQLColumnName>[^%#]+)(#(?<SQLColumnFormat>[^%]*)|)%)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            foreach (Match tmpMatch in MCInBody)
            {
                bool IsUpdate = false;
                if (tmpMatch.Groups["SQLColumnFormat"].Value != "")
                {
                    DateTime ValueDate = DateTime.MinValue;
                    if (useRows[tmpMatch.Groups["SQLColumnName"].Value].GetType() == typeof(DateTime))
                    {
                        ValueDate= (DateTime)useRows[tmpMatch.Groups["SQLColumnName"].Value];
                    }
                    else if (DateTime.TryParse(useRows[tmpMatch.Groups["SQLColumnName"].Value].ToString(), out ValueDate))
                    {
                        
                    }

                    if (ValueDate != DateTime.MinValue)
                    {
                        InputLine = InputLine.Replace(tmpMatch.Groups["FullLine"].Value
                            , (ValueDate).ToString(tmpMatch.Groups["SQLColumnFormat"].Value));
                        IsUpdate = true;
                    }
                }
                if (!IsUpdate)
                {
                    InputLine = InputLine.Replace(tmpMatch.Groups["FullLine"].Value
                        , useRows[tmpMatch.Groups["SQLColumnName"].Value].ToString());
                }
            }

            return InputLine;
        }
    }
}
