using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ComponentModel;

namespace rep25991.ExtendedMethods.Convertation
{
    public class ConvService
    {
        #region Вспомогательные классы
        public class ServiceDataValue
        {
            #region Свойства
            [DisplayName("дата начала услуги")]
            public DateTime ServDateBeg { get; set; }
            [DisplayName("дата завершения услуги")]
            public DateTime ServDateEnd { get; set; }
            [DisplayName("название из мт")]
            public string DLName { get; set; }
            [DisplayName("название партнера")]
            public string PartnerName { get; private set; }
            [DisplayName("назвние типа услуги")]
            public string ServiceName { get; set; }
            [DisplayName("город")]
            public string CityName { get; set; }
            [DisplayName("доп описание")]
            public string DopName { get; set; }
            [DisplayName("доп описание1")]
            public string DopName1 { get; set; }
            [DisplayName("доп описание2")]
            public string DopName2 { get; set; }
            [DisplayName("название тура")]
            public string TourName { get; set; }
            [DisplayName("перенос строки")]
            public object _NewLine { get { return null; } }

            public string DateFormat;
            public int? PRKey
            {
                set
                {
                    using (sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
                    {
                        var Partner = sqlDC.tbl_Partners.FirstOrDefault(x => x.PR_KEY == value);
                        PartnerName = (Partner != null ? Partner.GetName() : "");
                    }
                }
            }
            #endregion

            #region Конструктор
            public ServiceDataValue(TurService value)
            {
                DateTime begServUse = DateTime.Now.AddDays(value.TS_DAY.GetValueOrDefault(1) - 1).Date;
                DateTime endServUse = DateTime.Now.AddDays(value.TS_DAY.GetValueOrDefault(1) + value.TS_NDAYS.GetValueOrDefault(1) - 1).Date;

                TourName = value.tbl_TurList.TL_NAME;
                ServiceName = value.Service != null ? value.Service.SV_NAMELAT : "";
                CityName = "";

                DopName = value.TS_CODE == 0 ? "" : value.ServiceList.SL_NAMELAT;
                DopName1 = value.TS_SUBCODE1.GetValueOrDefault(0) == 0 ? "" : value.AddDescript1.A1_NAMELAT;
                DopName2 = value.TS_SUBCODE2.GetValueOrDefault(0) == 0 ? "" : value.AddDescript2.A2_NAMELAT;
                DLName = value.TS_NameLat;

                PRKey = value.TS_PARTNERKEY;
                ServDateBeg = begServUse;
                ServDateEnd = endServUse;
                DateFormat = value.tbl_Partner.LT_V_MappingPartner.VMP_DateFormat;
            }

            public ServiceDataValue(tbl_DogovorList value, string turName, bool IsRussiaVariant)
            {
                DateTime begServUse = value.tbl_Dogovor.DG_TURDATE.AddDays(
                    value.DL_DAY.GetValueOrDefault(1) - 1).Date;
                DateTime endServUse = value.tbl_Dogovor.DG_TURDATE.AddDays(
                    value.DL_DAY.GetValueOrDefault(1) + value.DL_NDAYS.GetValueOrDefault(1) - 1).Date;
                
                this.TourName = turName;

                ServiceName = value.Service != null ? (IsRussiaVariant ? value.Service.SV_NAME : value.Service.SV_NAMELAT) : "";
                if (this.GetType() == typeof(ServiceDataValue))
                {
                    this.CityName = value.CityDictionary != null ? value.CityDictionary.CT_NAMELAT : "";
                    DopName = value.DL_CODE == 0 ? "" : (IsRussiaVariant ? value.ServiceList.SL_NAME : value.ServiceList.SL_NAMELAT);
                    DopName1 = value.DL_SUBCODE1.GetValueOrDefault(0) == 0 ? "" : (IsRussiaVariant ? value.AddDescript1.A1_NAME : value.AddDescript1.A1_NAMELAT);
                    DopName2 = value.DL_SUBCODE2.GetValueOrDefault(0) == 0 ? "" : (IsRussiaVariant ? value.AddDescript2.A2_NAME : value.AddDescript2.A2_NAMELAT);
                }
                PRKey = value.DL_PARTNERKEY;
                ServDateBeg = begServUse;
                ServDateEnd = endServUse;
                DateFormat = value.tbl_Partner.LT_V_MappingPartner.VMP_DateFormat;
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
                    _htVariants = typeof(ServiceDataValue).PropertyToHashTable();
                }
                return _htVariants;
            }
        }
        #endregion

        public static string Convert(ServiceDataValue value, string outFormat)
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