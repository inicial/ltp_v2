using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Text.RegularExpressions;

using ltp_v2.Framework;
using ltp_v2.Controls;

namespace AgencyManager.ObjectModel
{
    public static class Permission
    {
        private static AccessForAgency _Permission = null;

        public static AccessForAgency Get
        {
            get
            {
                if (_Permission != null)
                    return _Permission;

                PartnersListDataContext PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);

                var CurrentPermissions = SqlConnection.ConnectionUserInformation.AccessForAgency;
                if (CurrentPermissions == null)
                    _Permission = new AccessForAgency();
                else 
                    _Permission = CurrentPermissions;

                return _Permission;
            }
        }

        public static IQueryable<LTP_PrtDog> SetPermissionFilter(this IQueryable<LTP_PrtDog> sender)
        {
            if (Get.LTP_AC_Dog_Full)
                return sender;

            return sender.Where(xDT =>
                    Get.LTP_AC_Dog_Agency  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_Agency"
                    || Get.LTP_AC_Dog_AviaZD  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_AviaZD"
                    || Get.LTP_AC_Dog_Cruize  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_Cruize"
                    || Get.LTP_AC_Dog_FIT  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_FIT"
                );
        }

        public static IQueryable<LTP_TempPartner> SetPerimssionFilter(this IQueryable<LTP_TempPartner> sender)
        {
            sender = sender.Where(x => 
                x.LTP_Name != ""
                || x.LTP_NameLat != ""
                || x.LTP_FullName != "");

            if (Get.LTP_AC_Dog_Full)
                return sender;

            return sender
                .Where(xSender => xSender.LTP_PrtDogLinks.Where(xDT =>
                    Get.LTP_AC_Dog_Agency  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_Agency"
                    || Get.LTP_AC_Dog_AviaZD  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_AviaZD"
                    || Get.LTP_AC_Dog_Cruize  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_Cruize"
                    || Get.LTP_AC_Dog_FIT  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_FIT"
                ).Count() > 0);
        }

        public static IQueryable<PrtDogTypes> SetPermissionFilter(this IQueryable<PrtDogTypes> sender)
        {
            if (Get.LTP_AC_Dog_Full)
                return sender.Where(x => x.LTP_DogType.LDT_IsDisable == false);

            return sender
                    .Where(x => x.LTP_DogType.LDT_IsDisable == false)
                    .Where(xDT =>
                        Get.LTP_AC_Dog_Agency  && xDT.LTP_DogType.LDT_Permission == "LTP_AC_Dog_Agency"
                        || Get.LTP_AC_Dog_AviaZD  && xDT.LTP_DogType.LDT_Permission == "LTP_AC_Dog_AviaZD"
                        || Get.LTP_AC_Dog_Cruize  && xDT.LTP_DogType.LDT_Permission == "LTP_AC_Dog_Cruize"
                        || Get.LTP_AC_Dog_FIT  && xDT.LTP_DogType.LDT_Permission == "LTP_AC_Dog_FIT"
                    );
        }

        public static IQueryable<tbl_Partners> SetPermissionFilter(this IQueryable<tbl_Partners> sender)
        {
            if (Get.LTP_AC_Dog_Full)
                return sender;

            return sender
                .Where(x2 =>
                    x2.LTP_PrtDogs.Where(xDT =>
                        //xDT.LTPD_DateEnd.Date >= DateTime.Now.Date && 
                        xDT.PrtDogTypes != null
                        && (Get.LTP_AC_Dog_Agency  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_Agency"
                                || Get.LTP_AC_Dog_AviaZD  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_AviaZD"
                                || Get.LTP_AC_Dog_Cruize  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_Cruize"
                                || Get.LTP_AC_Dog_FIT  && xDT.PrtDogTypes.LTP_DogType.LDT_Permission == "LTP_AC_Dog_FIT"
                        )
                    ).Select(x => x.LTPD_Key).Count() > 0
                    // === BEG === Список партнеров для работы с CallCenter
                    || Get.LTP_AC_CallCenter 
                    && x2.LCC_Partner != null
                    && (x2.LCC_Partner.LCP_UsedCallCenter)
                    // === END === Список партнеров для работы с CallCenter
                );
        }
    }
}