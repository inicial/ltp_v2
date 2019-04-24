using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep25991.ExtendedMethods
{
    public static class HelperVoucherCreated
    {
        public class helperVoucherService
        {
            public tbl_DogovorList Service;
            public LT_V_ShablonService Shablon;

            public helperVoucherService(tbl_DogovorList service, LT_V_ShablonService shablon)
            {
                this.Service = service;
                this.Shablon = shablon;
            }
        }

        /// <summary>
        /// Создание ваучера
        /// </summary>
        public static LT_V_Voucher CreateVoucher(this sqlDataContext sqlDC, int? prKey, int? cnKey, int dgKey)
        {
            LT_V_Voucher newVoucher = new LT_V_Voucher();
            newVoucher.tbl_Partner = sqlDC.tbl_Partners.FirstOrDefault(x => x.PR_KEY == prKey);
            newVoucher.tbl_Country = sqlDC.tbl_Countries.FirstOrDefault(x => x.CN_KEY == cnKey);
            newVoucher.tbl_Dogovor = sqlDC.tbl_Dogovors.FirstOrDefault(x => x.DG_Key == dgKey);
            newVoucher.V_DateBeg = DateTime.MaxValue;
            newVoucher.V_DateEnd = DateTime.MinValue;
            if (newVoucher.tbl_Dogovor != null)
            {
                newVoucher.tbl_TurList = newVoucher.tbl_Dogovor.tbl_TurList;
                var mappingTur = sqlDC.LT_V_MappingTurLists.FirstOrDefault(x => x.VT_TLKey == newVoucher.tbl_Dogovor.DG_TRKEY);
                newVoucher.V_TourName = (mappingTur != null ? mappingTur.VT_Name : newVoucher.tbl_Dogovor.tbl_TurList.TL_NameLat);
            }
            return newVoucher;
        }

        /// <summary>
        /// Добавление туриста в ваучер
        /// </summary>
        public static void SetPersonToVoucher(this LT_V_Voucher value, sqlDataContext sqlDC, tbl_Turist[] listTourists)
        {
            foreach (var turist in listTourists)
            {
                value.LT_V_Persons.Add(new LT_V_Person() { tbl_Turist = turist});
            }

            if (value.tbl_Partner.LT_V_MappingPartner.VMP_ReisOut)
            {
                value.V_Reis = sqlDC.getAviaReis(value);
            }
        }

        // Добавление услуги на ваучер
        private static void SetServiceToVoucher(this LT_V_Voucher value, sqlDataContext sqlDC, tbl_DogovorList dogovorService, int lineOut, string formatOut)
        {
            var currDateBeg = dogovorService.tbl_Dogovor.DG_TURDATE.AddDays(dogovorService.DL_DAY.GetValueOrDefault(1) - 1);
            var currDateEnd = currDateBeg.AddDays(dogovorService.DL_NDAYS.GetValueOrDefault(1) - ((dogovorService.DL_SVKEY == 3 || dogovorService.DL_SVKEY == 3149) ? 0 : 1));

            if (value.V_DateBeg > currDateBeg.Date)
                value.V_DateBeg = currDateBeg.Date;
            if (value.V_DateEnd < currDateEnd.Date)
                value.V_DateEnd = currDateEnd.Date;

            value.LT_V_Services.Add(new LT_V_Service()
            {
                tbl_DogovorList = dogovorService,
                VS_PrintLine = lineOut,
                FormatOutText = formatOut
            });
        }

        public static void SetServiceToVoucher(this LT_V_Voucher value, sqlDataContext sqlDC, helperVoucherService[] listService)
        {
            foreach (var itemDL in listService.OrderBy(x => x.Service.DL_DAY))
            {
                string format = itemDL.Shablon != null ? itemDL.Shablon.LT_V_ShablonFormatService.SHFS_FormatOut : "";
                int LineOut = itemDL.Shablon != null ? itemDL.Shablon.SHS_LineOut : 1;
                value.SetServiceToVoucher(sqlDC, itemDL.Service, LineOut, format);

                if (itemDL.Shablon == null || itemDL.Shablon.SHS_UseCommentToBron)
                {
                    if (itemDL.Service.DL_Comment != null
                        && itemDL.Service.DL_Comment.RemoveSpace() != ""
                        && itemDL.Service.DL_Comment.Contains('!'))
                    {
                        string[] lComment = itemDL.Service.DL_Comment.Split('!');
                        if (lComment.Length > 1)
                            value.V_BronNumber = lComment[0].RemoveSpace();
                    }
                }
            }
        }
    }
}
