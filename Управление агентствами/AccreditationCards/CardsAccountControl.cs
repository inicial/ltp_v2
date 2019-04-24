using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ltp_v2.AccountCreator.ObjectModel;

namespace AccreditationCards
{
    public static class CardsAccountControl
    {
        #region Свойства
        private static bool IsDelete = false;
        public static int MaximumCanUsedCard = 3;
        #endregion

        private class DC
        {
            public int DogovorId;
            public int[] CardsType;
            public int NumberZakaz;
            public int SendCardToOffice_PRKey;
        }

        // Получение последнего ID Договора
        private static int? GetRootDogovorId(tbl_Partner partner)
        {
            var rootDogovors = partner.LTP_PrtDogs.Where(xD => xD.LTP_DogType.LDT_IsRoot && xD.LTPD_DateEnd.Value.Date > DateTime.Now.Date);
            
            if (rootDogovors.Count() == 0)
                return null;

            var rootDogovor = rootDogovors.First(x => x.LTPD_DateEnd == rootDogovors.Max(xM => xM.LTPD_DateEnd));
         
            return rootDogovor.LTPD_Key;
        }

        public static ErrCode AccountCreateCards(int partnerKey, int[] cardsType, int? dogovorId, int numberZakaz, int sendCardToOffice_PRKey)
        {
            ltsDataContext lts = new ltsDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            var partner = lts.tbl_Partners.First(x => x.PR_KEY == partnerKey);
            if (dogovorId.HasValue)
            {
                if (partner.LTP_PrtDogs
                        .Where(x => x.LTPD_Key == dogovorId.Value)
                        .Select(x => x.LTP_DogType)
                        .Where(x => x.LDT_IsRoot).Count() == 0)
                    dogovorId = null;
            }

            if (!dogovorId.HasValue)
            {
                dogovorId = GetRootDogovorId(partner);
                if (!dogovorId.HasValue)
                    return ErrCode.NotGiveDogovor; // Не возможно найти договор
            }

            // Получение данных по договору
            var dogovorS = partner.LTP_PrtDogs.Where(x => x.LTPD_Key == dogovorId && x.LTP_DogType.LDT_IsRoot);
            if (dogovorS.Count() > 0)
            {
                var dogovor = partner.LTP_PrtDogs.First(x => x.LTPD_Key == dogovorId && x.LTP_DogType.LDT_IsRoot);

                int[] ResultCreated = new int[0];

                foreach (int cardType in cardsType)
                {
                    if (dogovor.LTP_AccreditationCards.Count(xC => xC.LTPA_CardType == cardType) > 0)
                        continue; // Подобная карта для данного договора присутствует
                    Array.Resize(ref ResultCreated, ResultCreated.Length + 1);
                    ResultCreated[ResultCreated.Length - 1] = cardType;
                }

                // Создание карты

                if (ResultCreated.Length > 0)
                {
                    ltp_v2.AccountCreator.AccountCreator ac = new ltp_v2.AccountCreator.AccountCreator();
                    ac.ClearAndSetDafault();
                    ac.UseAccount.Buyer = ac.GetPartnerByKey(partnerKey);
                    ac.UseAccount.LTA_AccountType = ac.GetAccountType(3);
                    ac.OnCreate += new EventHandler(ac_OnCreateCards);
                    ac.ObjectSave = new DC()
                    {
                        DogovorId = dogovorId.Value,
                        CardsType = ResultCreated,
                        NumberZakaz = numberZakaz,
                        SendCardToOffice_PRKey = sendCardToOffice_PRKey
                    };

                    foreach (dict_AccountDefaultService adsItem in ac.GetDefaultServices(ac.UseAccount.LTA_AccountType).Where(x => x.ADS_Name.Contains("Оформление")))
                    {
                        LTA_AccountService asItem = new LTA_AccountService();
                        asItem.AS_Count = ResultCreated.Length;
                        asItem.AS_CountType = "шт";
                        asItem.AS_Price = adsItem.ADS_Price;
                        asItem.AS_Name = adsItem.ADS_Name;
                        ac.UseAccount.LTA_AccountServices.Add(asItem);
                    }
                    ac.ViewAccount(
                        lts.tbl_Partners.First(x => x.PR_KEY == partnerKey).PR_EMAIL,
                        "Счет на оплату",
                        "Счет на оплату в прикрепленном файле");
                }
            }
            return ErrCode.NoError;

            throw new Exception("Ненайдены варианты для создания карт");
        }

        public static bool AccountDropCards(int partnerKey, string CardNum)
        {
            IsDelete = false;
            ltp_v2.AccountCreator.AccountCreator ac = new ltp_v2.AccountCreator.AccountCreator();
            ac.ClearAndSetDafault();
            ac.UseAccount.Buyer = ac.GetPartnerByKey(partnerKey);
            ac.UseAccount.LTA_AccountType = ac.GetAccountType(3);
            ac.UseAccount.AC_Param1 = CardNum;
            ac.OnCreate += new EventHandler(ac_OnDropCards);

            foreach (dict_AccountDefaultService adsItem in ac.GetDefaultServices(ac.UseAccount.LTA_AccountType).Where(x => x.ADS_Name.Contains("Штраф")))
            {
                LTA_AccountService asItem = new LTA_AccountService();
                asItem.AS_Count = 1;
                asItem.AS_CountType = "шт";
                asItem.AS_Price = adsItem.ADS_Price;
                asItem.AS_Name = (adsItem.ADS_Name + " " + CardNum).Replace("  ", " ");
                ac.UseAccount.LTA_AccountServices.Add(asItem);
            }
            
            ltsDataContext lts = new ltsDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            ac.ViewAccount(
                lts.tbl_Partners.First(x => x.PR_KEY == partnerKey).PR_EMAIL,
                "Счет на оплату",
                "Счет на оплату в прикрепленном файле");
            lts.Dispose();
            return IsDelete;
        }

        private static void ac_OnDropCards(object sender, EventArgs e)
        {
            ltp_v2.AccountCreator.AccountCreator ac = (ltp_v2.AccountCreator.AccountCreator)sender;
            ltsDataContext lts = new ltsDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);

            var q = lts.LTP_AccreditationCards.First(x => x.LTPA_CardNum == ac.UseAccount.AC_Param1);
            q.DeactivateCard();
            lts.SubmitChanges();
            lts.Dispose();
            IsDelete = true;
        }

        private static void ac_OnCreateCards(object sender, EventArgs e)
        {
            ltp_v2.AccountCreator.AccountCreator ac = (ltp_v2.AccountCreator.AccountCreator)sender;
            ltsDataContext lts = new ltsDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            tbl_Partner usingPartner = lts.tbl_Partners.First(x => x.PR_KEY == ac.UseAccount.AC_PRKey);

            DC _dc = ((DC)ac.ObjectSave);
            foreach (int cardType in _dc.CardsType)
            {
                LTP_AccreditationCard newACC = new LTP_AccreditationCard();
                newACC.LTPA_ACId = ac.UseAccount.AC_ID;
                newACC.LTPA_CardType = cardType;
                newACC.LTPA_LTPDKey = _dc.DogovorId;
                newACC.LTPA_NumberZakaz = _dc.NumberZakaz.ToString();
                newACC.LTPA_SendCardToOffice = _dc.SendCardToOffice_PRKey;
                usingPartner.LTP_AccreditationCards.Add(newACC);
            }
            
            lts.SubmitChanges();
            lts.Dispose();                
        }
    }
}
