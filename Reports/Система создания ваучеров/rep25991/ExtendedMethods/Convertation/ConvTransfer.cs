using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ComponentModel;

namespace rep25991.ExtendedMethods.Convertation
{
    public class ConvTransfer
    {
        #region Вспомогательные классы
        public class TransferDataValue : ConvService.ServiceDataValue
        {
            #region Конструктор
            public TransferDataValue(tbl_DogovorList value, string turName, bool IsRussianVariant)
                : base(value, turName, IsRussianVariant)
            {
                this.CityName = value.CityDictionary != null ? value.CityDictionary.CT_NAMELAT : "";
                this.DopName = value.Transfer != null ? (IsRussianVariant ? value.Transfer.TF_NAME : value.Transfer.TF_NAMELAT) : "";
                this.DopName1 = value.Transport != null ? (IsRussianVariant ? value.Transport.TR_NAME : value.Transport.TR_NAMELAT) : "";
            }

            public TransferDataValue(TurService value)
                : base(value)
            {
                this.DopName = value.Transfer != null ? value.Transfer.TF_NAMELAT : "";
                this.DopName1 = value.Transport != null ? value.Transport.TR_NAMELAT : "";
            }
            #endregion
        }
        #endregion

        #region Свойства
        private static Hashtable _htVariants;
        public static Hashtable htVariants
        {
            get
            {
                if (_htVariants == null)
                {
                    _htVariants = typeof(TransferDataValue).PropertyToHashTable();
                }
                return _htVariants;
            }
        }
        #endregion

        public static string Convert(TransferDataValue value, string outFormat)
        {
            string result = outFormat;
            if (result == null)
                return "";

            MatchCollection mc = Regex.Matches(result, "<%.*?%>");
            foreach (Match m in mc)
            {
                var tx = m.Value.Replace("<%", "").Replace("%>", "").ToLower();
                if (htVariants.ContainsKey(tx))
                {
                    var propertyName = htVariants[tx].ToString();
                    if (propertyName.IndexOf('_') != 0)
                    {
                        if (value.GetType().GetProperty(propertyName).GetValue(value, null) != null)
                            if (value.GetType().GetProperty(propertyName).PropertyType == typeof(DateTime))
                            {
                                result = result.Replace(m.Value, ((DateTime)value.GetType().GetProperty(propertyName).GetValue(value, null)).ConvertToMyFormat(value.DateFormat)).Trim();
                            }
                            else
                            {
                                result = result.Replace(m.Value, value.GetType().GetProperty(propertyName).GetValue(value, null).ToString().Trim());
                            }
                        else
                            result = result.Replace(m.Value, "");
                    }
                    else
                    {
                        switch (propertyName)
                        {
                            case "_NewLine":
                                result = result.Replace(m.Value, "\r\n");
                                break;
                        }
                    }
                }
            }

            result = Regex.Replace(result, @"(/|\\|\.|\,)*(|\s)$", "");
            result = Regex.Replace(result, @"/{2,}", "/");
            result = Regex.Replace(result, @"\\{2,}", "\\");
            result = Regex.Replace(result, @"\.{2,}", ".");
            result = Regex.Replace(result, @"\,{2,}", ",");
            return result.RemoveSpace();
        }
    }
}