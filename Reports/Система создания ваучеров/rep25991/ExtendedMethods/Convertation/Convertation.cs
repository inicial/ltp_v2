using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace rep25991.ExtendedMethods.Convertation
{
    public static class Convertation
    {
        public static string Convert(this tbl_DogovorList value, string formatOut, string dateFormat, string turName)
        {
            if (string.IsNullOrEmpty(formatOut))
                return value.DL_NAME;

            DateTime begServUse = DateTime.Now.AddDays(value.DL_DAY.GetValueOrDefault(1) - 1).Date;
            DateTime endServUse = DateTime.Now.AddDays(value.DL_DAY.GetValueOrDefault(1) + value.DL_NDAYS.GetValueOrDefault(1) - 1).Date;

            if (value.DL_SVKEY == 2)
                return ConvTransfer.Convert(new ConvTransfer.TransferDataValue(value, turName, value.tbl_Dogovor.IsRussianVariant()), formatOut);

            else if (value.DL_SVKEY == 3149)
            {
                // Из-за отсутствия данных в справочнике formatOut - сначала форматируется как услуга
                formatOut = ConvService.Convert(new ConvService.ServiceDataValue(value, turName, value.tbl_Dogovor.IsRussianVariant()), formatOut);

                if (value.lanta_2011_hotelFIT_adon != null)
                    return ConvHotel.Convert(
                        new ConvHotel.HotelDataValue(
                            value.DL_NDAYS.GetValueOrDefault(0),
                            value.DL_Comment,
                            value.DL_PARTNERKEY,
                            value.DL_CODE), formatOut);
                else
                    return formatOut;
            }

            else if (value.DL_SVKEY == 3)
                return ConvHotel.Convert(
                    new ConvHotel.HotelDataValue(
                        value.DL_NDAYS.GetValueOrDefault(0),
                        value.DL_Comment,
                        value.DL_PARTNERKEY,
                        value.DL_CODE,
                        value.DL_SUBCODE1,
                        value.DL_SUBCODE2,
                        value.tbl_Dogovor.IsRussianVariant()),
                    formatOut);
            else if (value.DL_SVKEY == 4 || value.DL_SVKEY == 3140)
            {
                return ConvExcursion.Convert(
                    new ConvExcursion.ExcursionDataValue(value, turName, value.tbl_Dogovor.IsRussianVariant()), formatOut);
            }
            else
                return ConvService.Convert(
                    new ConvService.ServiceDataValue(value, turName, value.tbl_Dogovor.IsRussianVariant()), formatOut);
        }

        public static string Convert(this TurService value, string formatOut, string formatDate)
        {
            string result = "";
            DateTime begServUse = DateTime.Now.AddDays(value.TS_DAY.GetValueOrDefault(1) - 1).Date;
            DateTime endServUse = DateTime.Now.AddDays(value.TS_DAY.GetValueOrDefault(1) + value.TS_NDAYS.GetValueOrDefault(1) - 1).Date;
            if (value.TS_SVKEY == 2)
                return ConvTransfer.Convert(new ConvTransfer.TransferDataValue(value), formatOut);

            else if (value.TS_SVKEY == 3)
                result = ConvHotel.Convert(
                    new ConvHotel.HotelDataValue(
                        value.TS_NDAYS.GetValueOrDefault(0),
                        "",
                        value.TS_PARTNERKEY,
                        value.TS_CODE,
                        value.TS_SUBCODE1,
                        value.TS_SUBCODE2,
                        value.tbl_TurList.TL_CNKEY == 460), formatOut);
            else if (value.TS_SVKEY == 4 || value.TS_SVKEY == 3140)
            {
                var excursion =
                    value.TS_SVKEY == 4 && value.ExcurDictionary != null
                        ? value.ExcurDictionary.ED_NAMELAT
                        : value.TS_SVKEY == 3140 && value.ServiceList != null
                              ? value.ServiceList.SL_NAMELAT
                              : "";
                var transport =
                     value.TS_SVKEY == 4 && value.Transport != null
                        ? value.Transport.TR_NAMELAT
                        : value.TS_SVKEY == 3140 && value.AddDescript1 != null
                              ? value.AddDescript1.A1_NAMELAT
                              : "";

                result = ConvExcursion.Convert(new ConvExcursion.ExcursionDataValue(value), formatOut);
            }
            else
                return ConvService.Convert(new ConvService.ServiceDataValue(value), formatOut);

            return result;
        }

        public static Hashtable GetVariantsByType(int svKey)
        {
            if (svKey == 2)
                return ConvTransfer.htVariants;
            else if (svKey == 3)
                return ConvHotel.htVariants;
            else if (svKey == 4 || svKey == 3140)
                return ConvExcursion.htVariants;
            else
                return ConvService.htVariants;
        }
    }
}
