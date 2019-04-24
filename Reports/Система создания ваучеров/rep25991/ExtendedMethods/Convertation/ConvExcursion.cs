using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ComponentModel;

namespace rep25991.ExtendedMethods.Convertation
{
    public class ConvExcursion
    {
        #region Вспомогательные классы
        public class ExcursionDataValue : ConvService.ServiceDataValue
        {
            #region Конструктор
            public ExcursionDataValue(tbl_DogovorList value, string turName, bool IsRussianVariant)
                : base(value, turName, IsRussianVariant)
            {
                this.CityName = value.CityDictionary != null ? value.CityDictionary.CT_NAMELAT : "";
                this.DopName = value.DL_CODE == 0 ? ""
                    : value.DL_SVKEY == 4
                        ? (IsRussianVariant ? value.ExcurDictionary.ED_NAME : value.ExcurDictionary.ED_NAMELAT)
                        : value.DL_SVKEY == 3140
                            ? (IsRussianVariant ? value.ServiceList.SL_NAME : value.ServiceList.SL_NAMELAT)
                            : "";
                this.DopName1 = value.DL_SUBCODE1.GetValueOrDefault(0) == 0 ? ""
                    : value.DL_SVKEY == 4 ? (IsRussianVariant ? value.Transport.TR_NAME : value.Transport.TR_NAMELAT)
                        : value.DL_SVKEY == 3140 ? (IsRussianVariant ? value.AddDescript1.A1_NAME : value.AddDescript1.A1_NAMELAT)
                            : "";
            }
            
            public ExcursionDataValue(TurService value)
                : base(value)
            {
                this.CityName = "";
                this.DopName = value.TS_CODE == 0 ? ""
                    : value.TS_SVKEY == 4
                        ? value.ExcurDictionary.ED_NAMELAT
                        : value.TS_SVKEY == 3140
                              ? value.ServiceList.SL_NAMELAT
                              : "";
                this.DopName1 = value.TS_SUBCODE1 == 0 ? ""
                    : value.TS_SVKEY == 4
                        ? value.Transport.TR_NAMELAT
                        : value.TS_SVKEY == 3140
                              ? value.AddDescript1.A1_NAMELAT
                              : "";

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
                    _htVariants = typeof(ExcursionDataValue).PropertyToHashTable();
                }
                return _htVariants;
            }
        }
        #endregion

        public static string Convert(ExcursionDataValue value, string outFormat)
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