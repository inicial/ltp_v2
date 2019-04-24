using System;
using System.Text.RegularExpressions;

namespace rep25991
{
    public static class exText
    {
        public static string RemoveSpace(this string value)
        {
            if (value == null)
                return value;

            return Regex.Replace(value, @"[ ]{2,}|\t{2,}|\f{2,}|[\r\n]{2,}", delegate(Match match)
            {
                string v = match.ToString();
                return char.ToUpper(v[0]).ToString();
            }).Trim().Replace("\n", "\r").Replace("\r", "\r\n");
        }
    }
}
