using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.ComponentModel;

namespace ltp_v2.Framework
{
    public static class ExtensionMethods
    {
        public static String EncriptIntValue(string value)
        {
            return new ReferencesModelDataContext(SqlConnection.Connection).LANTA_TLW_EncodeIntValue(value, DateTime.Now);
        }

        /// <summary>
        /// проверка на возможность конвертации string в int
        /// </summary>
        /// <returns>True если возможно в противном False</returns>
        public static bool TryConvertToInt(this string sender)
        {
            int tmpInt;
            return int.TryParse(sender, out tmpInt);
        }

        /// <summary>
        /// Конвертация string в int
        /// </summary>
        public static int ConvertToInt(this string sender)
        {
            int tmpInt;
            int.TryParse(sender, out tmpInt);
            return tmpInt;
        }
    }
}
