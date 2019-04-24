using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltp_v2.Controls
{
    public static class em_String
    {
        /// <summary>
        /// Проверка на схожесть даных типа string с игнорированием регистра
        /// </summary>
        public static bool CheckEntryValue(this string Input, string Pattern)
        {
            Input = Input.Trim();
            Pattern = Pattern.Trim();
            if (Input == null && Pattern == null || Input == "" && Pattern == "")
                return true;
            else if (Input == null || Pattern == null || Input == "" || Pattern == "")
                return false;
            //Input = Input.Replace(@"\", @"\\").Replace("(", "\\(").Replace(")","\\)");
            Pattern = Pattern.Trim()
                .Replace(@"\", @"\\")
                .Replace(@"(", @"\(")
                .Replace(@")", @"\)")
                .Replace(@"+", @"\+")
                .Replace(@"[", @"\[")
                .Replace(@"*", @"\*")
                .Replace(@".", @"\.");
            return System.Text.RegularExpressions.Regex.IsMatch(Input, Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
        
        public static bool IsNullOrEmptyOrSpace(this string sender)
        {
            if (sender == null)
                return true;
            return (String.IsNullOrEmpty(sender.Trim()));
        }

        public static string ConvertCP1251toUTF8(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return "";
            Encoding srcEncoding = Encoding.GetEncoding("windows-1251");
            Encoding dstEncoding = Encoding.UTF8;
            byte[] bytes = dstEncoding.GetBytes(source.ToString().Replace("'", "''"));
            byte[] buffer2 = Encoding.Convert(srcEncoding, dstEncoding, bytes);
            return dstEncoding.GetString(buffer2);
        }

        public static string ConvertUTF8toCP1251(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return "";
            Encoding dstEncoding = Encoding.GetEncoding("windows-1251");
            Encoding srcEncoding = Encoding.UTF8;
            byte[] bytes = dstEncoding.GetBytes(source.ToString().Replace("'", "''"));
            byte[] buffer2 = Encoding.Convert(srcEncoding, dstEncoding, bytes);
            return dstEncoding.GetString(buffer2);
        }
    }
}
