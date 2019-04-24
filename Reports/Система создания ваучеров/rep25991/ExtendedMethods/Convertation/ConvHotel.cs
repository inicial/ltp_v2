using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;

namespace rep25991.ExtendedMethods.Convertation
{
    public class ConvHotel
    {
        #region Вспомогательные классы
        public class HotelDataValue
        {
            #region Свойства
            [DisplayName("отель")]
            public string HDName { get; set; }
            [DisplayName("звездность")]
            public string HDStar { get; set; }
            [DisplayName("адрес")]
            public string HDAddress { get; set; }
            [DisplayName("курорт")]
            public string RSName { get; set; }
            [DisplayName("телефон")]
            public string HDPhone { get; set; }
            [DisplayName("факс")]
            public string HDFax { get; set; }
            [DisplayName("код питания")]
            public string PNCode { get; set; }
            [DisplayName("питание")]
            public string PNName { get; set; }
            [DisplayName("код размещения")]
            public string RMCode { get; set; }
            [DisplayName("размещение")]
            public string RMName { get; set; }
            [DisplayName("кол-во мест")]
            public short RMNPlaces { get; set; }
            [DisplayName("код категории")]
            public string RCCode { get; set; }
            [DisplayName("категория")]
            public string RCName { get; set; }
            [DisplayName("код возраста")]
            public string ACCode { get; set; }
            [DisplayName("возраст")]
            public string ACName { get; set; }
            [DisplayName("город")]
            public string CTName { get; set; }
            [DisplayName("страна")]
            public string CNName { get; set; }
            [DisplayName("кол-во ночей")]
            public short DLNDays { get; set; }
            [DisplayName("коментарий на услугу в мт")]
            public string DLComment { get; set; }
            [DisplayName("перенос строки")]
            public object _NewLine { get { return null; } }
            [DisplayName("название партнера")]
            public string PartnerName { get; private set; }
            #endregion

            public void SetTest()
            {
                HDName = "North star";
                HDStar = "5";
                HDAddress = "Urjupinsk, Kulibyakina st. 696";
                RSName = "Bronze beach";
                HDPhone = "+7(123)4567890";
                HDFax = "+7(098)7654321";
                PNCode = "НВ";
                PNName = "half board";
                RMCode = "DBL";
                RMName = "Double";
                RMNPlaces = 2;
                RCCode = "APT";
                RCName = "Apartment";
                ACCode = "ad";
                ACName = "Adult";
                CTName = "Urjupinsk";
                CNName = "Russia";
                DLNDays = 23;
                DLComment = "коментарий на услугу в мт";
                PartnerName = "Lohhh&Co";
            }

            #region Конструктор
            public HotelDataValue()
            {
            }

            /// <summary>
            /// Для FIT
            /// </summary>
            public HotelDataValue(short NDays, string Comment, int? parnetKey, int dlCode)
            {
                sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
                DLNDays = NDays;
                DLComment = Comment;
                var FITData = sqlDC.lanta_2011_hotelFIT_adons.FirstOrDefault(x => x.sl_key == dlCode);

                var Partner = sqlDC.tbl_Partners.FirstOrDefault(x => x.PR_KEY == parnetKey);
                PartnerName = (Partner != null ? Partner.GetName() : "");

                if (FITData != null)
                {
                    HDName = FITData.HotelName;
                    HDStar = FITData.hotelstar;
                    HDAddress = FITData.hdadress;
                    HDPhone = FITData.hdpfone;
                    HDFax = "";
                    CTName = FITData.hdcity;
                    CNName = FITData.hdcountru;
                    RSName = "";
                    PNName = PNCode = FITData.hdpansion;
                    RMCode = RMName = FITData.hdroom;
                    RCCode = RCName = "";
                    ACCode = ACName = "";
                }
            }

            public HotelDataValue(short NDays, string Comment, int? parnetKey, int hdKey, int? hrKey, int? pnKey, bool IsRussiaVariant)
            {
                sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
                DLNDays = NDays;
                DLComment = Comment;

                var Partner = sqlDC.tbl_Partners.FirstOrDefault(x => x.PR_KEY == parnetKey);
                PartnerName = (Partner != null ? Partner.GetName() : "");
                var HotelDictionary = sqlDC.HotelDictionaries.FirstOrDefault(x => x.HD_KEY == hdKey);
                var Pansion = sqlDC.Pansions.FirstOrDefault(x => x.PN_KEY == pnKey);
                var HotelRoom = sqlDC.HotelRooms.FirstOrDefault(x => x.HR_KEY == hrKey);

                if (HotelDictionary != null)
                {
                    HDName = (IsRussiaVariant ? HotelDictionary.HD_NAME : HotelDictionary.HD_NAMELAT);
                    HDStar = HotelDictionary.HD_STARS;
                    HDAddress = HotelDictionary.HD_ADDRESS;
                    HDPhone = HotelDictionary.HD_PHONE;
                    HDFax = HotelDictionary.HD_FAX;
                    if (HotelDictionary.CityDictionary != null)
                    {
                        CTName = (IsRussiaVariant ? HotelDictionary.CityDictionary.CT_NAME : HotelDictionary.CityDictionary.CT_NAMELAT);
                        if (HotelDictionary.CityDictionary.tbl_Country != null)
                        {
                            CNName = (IsRussiaVariant ? HotelDictionary.CityDictionary.tbl_Country.CN_NAME : HotelDictionary.CityDictionary.tbl_Country.CN_NAMELAT);
                        }
                    }
                    if (HotelDictionary.Resort != null)
                    {
                        RSName = (IsRussiaVariant ? HotelDictionary.Resort.RS_NAME : HotelDictionary.Resort.RS_NAMELAT);
                    }
                }

                if (Pansion != null)
                {
                    PNCode = Pansion.PN_CODE;
                    //PNNameRus = Pansion.PN_NAME;
                    PNName = Pansion.PN_NAMELAT;
                }

                if (HotelRoom != null)
                {
                    if (HotelRoom.Room != null)
                    {
                        RMCode = HotelRoom.Room.RM_CODE;
                        RMName = (IsRussiaVariant ? HotelRoom.Room.RM_NAME : HotelRoom.Room.RM_NAMELAT);
                        RMNPlaces = HotelRoom.Room.RM_NPLACES.GetValueOrDefault(0);
                    }
                    if (HotelRoom.RoomsCategory != null)
                    {
                        RCCode = HotelRoom.RoomsCategory.RC_CODE;
                        RCName = (IsRussiaVariant ? HotelRoom.RoomsCategory.RC_NAME : HotelRoom.RoomsCategory.RC_NAMELAT);
                    }
                    if (HotelRoom.Accmdmentype != null)
                    {
                        ACCode = HotelRoom.Accmdmentype.AC_CODE;
                        ACName = (IsRussiaVariant ? HotelRoom.Accmdmentype.AC_NAME : HotelRoom.Accmdmentype.AC_NAMELAT);
                    }
                }
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
                    _htVariants = typeof(HotelDataValue).PropertyToHashTable();
                }
                return _htVariants;
            }
        }
        #endregion

        public static string Convert(HotelDataValue value, string outFormat)
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
                        var val = value.GetType().GetProperty(propertyName).GetValue(value, null);
                        if (val == null) val = "";

                        switch (propertyName)
                        {
                            case "HDAddress":
                                result = result.Replace(m.Value, val.ToString().Trim() != "" ? "\r\nAddress:" + val.ToString().Trim() : "");
                                break;
                            case "HDPhone":
                                result = result.Replace(m.Value, val.ToString().Trim() != "" ? "\r\nPhone:" + val.ToString().Trim() : "");
                                break;
                            default:
                                result = result.Replace(m.Value, val.ToString().Trim());
                                break;
                        }
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
