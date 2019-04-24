using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using ltp_v2.Controls;
using System.ComponentModel;

namespace rep25991.ExtendedMethods.Convertation
{
    public class Tourist
    {
        #region Вспомогательные классы
        public class TouristDataValue
        {
            #region Свойства
            private bool UseRussiaVariant = false;
            public string TU_PASPORTTYPE;
            public string TU_PASPORTNUM;
            public short SexKey;
            public DateTime _TurDate;
            public DateTime TurDate
            {
                get { return _TurDate; }
                set
                {
                    _TurDate = value;
                    ChangeDate(UseRussiaVariant);
                }
            }
            private DateTime? _Birthday;
            public DateTime? Birthday
            {
                get { return _Birthday; }
                set
                {
                    _Birthday = value;
                    ChangeDate(UseRussiaVariant);
                }
            }
            public int? Ages { get; private set; }

            [DisplayName("фамилия")]
            public string NAME { get; set; }
            [DisplayName("имя")]
            public string FNAME { get; set; }

            [DisplayName("пол")]
            public string SEX { get; private set; }
            [DisplayName("возвраст для всех")]
            public string AGE { get; private set; }
            [DisplayName("возвраст для детей")]
            public string AGE_CH { get; private set; }
            [DisplayName("№ паспорта")]
            public string PASSPORT { get; set; }

            [DisplayName("дата рождения для всех")]
            public object _TU_BIRTHDAY { get { return null; } }
            [DisplayName("дата рождения для детей")]
            public object _BIRTHDAY_CH { get { return null; } }
            [DisplayName("перенос строки")]
            public object _NewLine { get { return null; } }
            #endregion

            #region Методы
            private void ChangeDate(bool IsRussiaVariant)
            {
                if (Birthday.HasValue && TurDate != null)
                {
                    this.Ages = this.Birthday.Value.Date.TotalYearsOfTheDate(this.TurDate.Date);

                    this.AGE = this.Ages.ToString() + (IsRussiaVariant ? "лет" : "age");
                    this.AGE_CH = this.Ages < 9 ? this.Ages.ToString() + (IsRussiaVariant ? "лет" : "age") : "";
                }
                else
                {
                    this.Ages = null;
                }
            }
            #endregion

            #region Конструктор
            public TouristDataValue()
            {
            }

            public TouristDataValue(tbl_Turist value, bool IsRussiaVariant)
                : this()
            {
                this.UseRussiaVariant = IsRussiaVariant;
                this.NAME = (IsRussiaVariant ? value.TU_NAMERUS : value.TU_NAMELAT);
                this.FNAME = (IsRussiaVariant ? value.TU_FNAMERUS : value.TU_FNAMELAT);
                this.TU_PASPORTTYPE = value.TU_PASPORTTYPE;
                this.TU_PASPORTNUM = value.TU_PASPORTNUM;
                this.SexKey = value.TU_SEX.GetValueOrDefault(0);
                this.TurDate = value.tbl_Dogovor.DG_TURDATE;
                this.Birthday = value.TU_BIRTHDAY;
                this.SEX = References.VariantsSex.Convert(this.SexKey);
                this.PASSPORT = this.TU_PASPORTTYPE + "№" + this.TU_PASPORTNUM;
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
                    _htVariants = typeof(TouristDataValue).PropertyToHashTable();
                }
                return _htVariants;
            }
        }
        #endregion

        #region Методы
        public static string TestConvert(string outFormat, string dateFormat)
        {
            return Tourist.Convert(new TouristDataValue()
            {
                Birthday = DateTime.Now.Date.AddYears(-1),
                FNAME = "Ivan",
                NAME = "Ivanov",
                TU_PASPORTNUM = "56789012",
                TU_PASPORTTYPE = "1234",
                SexKey = 1,
                TurDate = DateTime.Now.Date
            }, outFormat, dateFormat);
        }

        //public static string Convert(tbl_Turist turist, string outFormat, string dateFormat)
        //{
        //    return Tourist.Convert(new TouristDataValue(turist), outFormat, dateFormat);
        //}

        public static string Convert(TouristDataValue value, string outFormat, string dateFormat)
        {
            string result = outFormat;
            MatchCollection mc = Regex.Matches(outFormat, "<%.*?%>");
            foreach (Match m in mc)
            {
                var tx = m.Value.Replace("<%", "").Replace("%>", "").ToLower();
                if (htVariants.ContainsKey(tx))
                {
                    var propertyName = htVariants[tx].ToString();
                    if (propertyName.IndexOf('_') != 0)
                    {
                        if (value.GetType().GetProperty(propertyName).GetValue(value, null) != null)
                            result = result.Replace(m.Value, value.GetType().GetProperty(propertyName).GetValue(value, null).ToString().Trim());
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
                            default:
                                if (value.Ages.HasValue)
                                {
                                    switch (propertyName)
                                    {
                                        case "_BIRTHDAY_CH":
                                            result = result.Replace(m.Value, (value.Ages < 9 ? value.Birthday.Value.ConvertToMyFormat(dateFormat) : ""));
                                            break;
                                        case "_TU_BIRTHDAY":
                                            result = result.Replace(m.Value, value.Birthday.Value.ConvertToMyFormat(dateFormat));
                                            break;
                                    }
                                }
                                else
                                {
                                    result = result.Replace(m.Value, "");
                                }
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
        #endregion
    }
}