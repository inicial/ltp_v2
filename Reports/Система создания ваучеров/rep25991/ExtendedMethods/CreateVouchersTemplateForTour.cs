using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep25991.ExtendedMethods
{
    /// <summary>
    /// Создание вачера по шаблону
    /// </summary>
    public class CreateVouchersTemplateForTour
    {
        private class helperService
        {
            public int DLKey;
            public int Index;
        }

        private class helperTurist
        {
            public int TUKey;
            public List<helperService> service = new List<helperService>();
        }

        private class helperPartner
        {
            public int PRKEy;
            public List<helperTurist> turist = new List<helperTurist>();
        }

        private class helperCountry
        {
            public int CNKey;
            public List<helperPartner> partner = new List<helperPartner>();
        }

        private class helperShablon
        {
            public int SHId;
            public List<helperCountry> country = new List<helperCountry>();
        }

        private static void SetServiceToVoucher(sqlDataContext sqlDC, ref LT_V_Voucher voucher, List<helperService> helperServices, int VTId)
        {
            DateTime dateBeg = DateTime.MaxValue;
            DateTime dateEnd = DateTime.MinValue;

            var filteredDL = sqlDC.tbl_DogovorLists.Where(x => helperServices.Select(xhs => xhs.DLKey).Contains(x.DL_KEY)).ToArray();

            var query = from xDL in filteredDL
                        from xHS in helperServices
                        from xMTS in sqlDC.LT_V_MappingTurServices
                        where xDL.DL_KEY == xHS.DLKey
                                && xMTS.VS_Index == xHS.Index
                                && xMTS.VS_SVKey == xDL.DL_SVKEY
                                && xMTS.VS_VTId == VTId
                        select new { 
                            xDL.DL_DAY, 
                            xMTS.LT_V_ShablonService.SHS_LineOut,
                            tbl_DogovorList = xDL, 
                            ShablonService = xMTS.LT_V_ShablonService};
            
            List<HelperVoucherCreated.helperVoucherService> listServices = new List<HelperVoucherCreated.helperVoucherService>();
            foreach (var itemDL in query.OrderBy(x => x.SHS_LineOut).ThenBy(x => x.DL_DAY))
            {
                listServices.Add(new HelperVoucherCreated.helperVoucherService(itemDL.tbl_DogovorList, itemDL.ShablonService));
            }
            voucher.SetServiceToVoucher(sqlDC, listServices.ToArray());
            listServices.Clear();
            listServices = null;
        }

        /// <summary>
        /// Разбитие тура на составляющие по шаблону, партнеру, туристу, услуге
        /// </summary>
        private static List<helperShablon> GroupServices(sqlDataContext sqlDC, int dgKey)
        {
            var currentDog = sqlDC.tbl_Dogovors.FirstOrDefault(x => x.DG_Key == dgKey);
            var indexdDL = currentDog.GetIndexedStructService();

            // Список доступных предустановленных шаблонов для тура
            var shablons = from xMTL in currentDog.tbl_TurList.LT_V_MappingTurLists
                           from xMTS in xMTL.LT_V_MappingTurServices
                           select new
                           {
                               VTId = xMTL.VT_Id,
                               toCut = (
                                   // Если эта услуга единственная в шаблоне
                                   xMTS.LT_V_ShablonService.LT_V_Shablon.LT_V_ShablonServices.Count() == 1 
                                   // && xMTL.LT_V_MappingTurServices.Count() == 1
                                   && xMTS.LT_V_ShablonService.LT_V_Shablon.LT_V_ShablonServices.Any(x=>!x.SHS_IsGroupToOneVoucher))
                           };

            // Список доступных услуг по шаблону на которые не созданны ваучеры
            var services = (
                from xIDL in indexdDL
                from xDL in currentDog.tbl_DogovorLists.Where(x => x.DL_KEY == xIDL.Key)
                from xMTS in sqlDC.LT_V_MappingTurServices.Where(x => shablons.Select(xSH => xSH.VTId).Contains(x.VS_VTId))
                from xTS in sqlDC.TuristServices.Where(x => x.TU_DLKEY == xDL.DL_KEY)
                where xMTS.VS_SVKey == xIDL.SVKey
                        && xMTS.VS_Index == xIDL.Index
                        && (xDL.LT_V_Services.Count() == 0 || !xDL.LT_V_Services.Any(x => !x.LT_V_Voucher.V_AnnulDate.HasValue))
                select new
                {
                    Index = xIDL.Index,
                    VTId = xMTS.VS_VTId,
                    PrintLine = xMTS.LT_V_ShablonService.SHS_LineOut,
                    CNKey = xDL.DL_CNKEY.GetValueOrDefault(0),
                    PartnerKey = xDL.DL_PARTNERKEY.GetValueOrDefault(0),
                    DLKey = xDL.DL_KEY,
                    TUKey = xTS.TU_TUKEY
                });

            List<helperShablon> hshablons = new List<helperShablon>();
            foreach (var itemShablon in shablons.Distinct())
            {
                helperShablon newHS = new helperShablon() { SHId = itemShablon.VTId };
                hshablons.Add(newHS);
                // Список партнеров 

                foreach (var itemCountry in services.Where(x => x.VTId == itemShablon.VTId).GroupBy(x => x.CNKey))
                {
                    helperCountry hc = new helperCountry() { CNKey = itemCountry.Key };
                    newHS.country.Add(hc);

                    foreach (var itemPartner in itemCountry.GroupBy(x => x.PartnerKey))
                    {
                        helperPartner hp = new helperPartner() { PRKEy = itemPartner.Key };
                        hc.partner.Add(hp);

                        // Список туристов
                        foreach (var itemTurist in itemPartner.GroupBy(x => x.TUKey))
                        {
                            // Список услуг
                            if (itemShablon.toCut)
                            {
                                var listServices = itemTurist.ToList();
                                while (listServices.Count > 0)
                                {
                                    helperTurist ht = new helperTurist() { TUKey = itemTurist.Key };
                                    hp.turist.Add(ht);
                                    var serv = listServices.First();
                                    ht.service.Add(new helperService() { DLKey = serv.DLKey, Index = serv.Index });
                                    listServices.Remove(serv);
                                }
                            }
                            else
                            {
                                helperTurist ht = new helperTurist() { TUKey = itemTurist.Key };
                                hp.turist.Add(ht);
                                foreach (var itemService in itemTurist
                                .Select(x => new { x.DLKey, x.Index })
                                .Distinct())
                                {
                                    ht.service.Add(new helperService() { DLKey = itemService.DLKey, Index = itemService.Index });
                                }
                            }
                        }
                    }
                }
            }
            services = null;
            return hshablons;
        }

        private static List<LT_V_Voucher> GenerateVoucher(sqlDataContext sqlDC, int dgKey)
        {
            List<LT_V_Voucher> createdVouchers = new List<LT_V_Voucher>();
            // Разбитие на состовляющие
            var q = GroupServices(sqlDC, dgKey);
            // Сбор составляющих в ваучеры
            foreach (var itemShablon in q)
            {
                foreach (var itemCountry in itemShablon.country)
                {
                    foreach (var itemPartner in itemCountry.partner)
                    {
                        bool isNotFindAnalogTuris = true;
                        LT_V_Voucher newVoucher = null;

                        var queryTurist =
                            (from xTU in sqlDC.tbl_Turists.Where(x => itemPartner.turist.Select(xht => xht.TUKey).Contains(x.TU_KEY)).ToArray()
                             from xHT in itemPartner.turist
                             where xHT.TUKey == xTU.TU_KEY
                             select new { tbl_Turist = xTU, xHT.service, xHT })
                            .OrderBy(x => x.tbl_Turist.TU_NAMELAT).ThenBy(x => x.tbl_Turist.TU_NAMELAT)
                            .ToList();

                        var firstTurist = queryTurist.First();
                        firstTurist = null;

                        while (queryTurist.Count() > 0)
                        {
                            if (newVoucher == null || firstTurist == null || isNotFindAnalogTuris)
                            {
                                firstTurist = queryTurist.First();
                                newVoucher = sqlDC.CreateVoucher(itemPartner.PRKEy, itemCountry.CNKey, dgKey);
                                var itemMTL = sqlDC.LT_V_MappingTurLists.FirstOrDefault(x => x.VT_Id == itemShablon.SHId);
                                newVoucher.V_TourName = itemMTL.VT_Name;
                                createdVouchers.Add(newVoucher);

                                sqlDC.LT_V_Vouchers.InsertOnSubmit(newVoucher);
                                SetServiceToVoucher(sqlDC, ref newVoucher, firstTurist.service, itemShablon.SHId);

                                var turist = sqlDC.tbl_Turists.First(x => x.TU_KEY == firstTurist.tbl_Turist.TU_KEY);
                                newVoucher.SetPersonToVoucher(sqlDC, new tbl_Turist[] { turist });
                                queryTurist.Remove(firstTurist);
                            }

                            isNotFindAnalogTuris = true;

                            foreach (var itemTurist in queryTurist)
                            {
                                if (itemTurist.service.Count == firstTurist.service.Count
                                    && itemTurist.service.Select(x => x.DLKey).Except(firstTurist.service.Select(x => x.DLKey)).Count() == 0)
                                {
                                    newVoucher.LT_V_Persons.Add(new LT_V_Person() { tbl_Turist = itemTurist.tbl_Turist });
                                    queryTurist.Remove(itemTurist);
                                    isNotFindAnalogTuris = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return createdVouchers;
        }

        //todo: 259991 2011/12/13 - Найти что это делает
        public static List<LT_V_Voucher> Create(sqlDataContext sqlDC, int[] dgKeys)
        {
            List<LT_V_Voucher> vouchers = new List<LT_V_Voucher>();
            foreach (int dgKey in dgKeys)
            {
                vouchers.AddRange(GenerateVoucher(sqlDC, dgKey));
            }

            if (new Report.ReportGenerator(sqlDC, vouchers.ToArray(), true, false, false).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var itemInsertedVS in (sqlDC.GetChangeSet().Inserts.Where(x => x.GetType() == typeof(LT_V_Service)).Select(x => (LT_V_Service)x)).ToArray())
                {
                    using (sqlDataContext checkSqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
                    {
                        if (checkSqlDC.LT_V_Services.Any(x => x.VS_DLKey == itemInsertedVS.VS_DLKey && !x.LT_V_Voucher.V_AnnulDate.HasValue))
                        {
                            itemInsertedVS.LT_V_Voucher.LT_V_Services.Remove(itemInsertedVS);
                            itemInsertedVS.tbl_DogovorList.LT_V_Services.Remove(itemInsertedVS);
                            sqlDC.LT_V_Services.DeleteOnSubmit(itemInsertedVS);
                        }
                    }
                }

                foreach (var iV in (sqlDC.GetChangeSet().Inserts.Where(x => x.GetType() == typeof(LT_V_Voucher)).Select(x => (LT_V_Voucher)x)))
                {
                    if (iV.LT_V_Services.Count() == 0)
                    {
                        sqlDC.LT_V_Vouchers.DeleteOnSubmit(iV);
                        vouchers.Remove(iV);

                        foreach (var iVP in iV.LT_V_Persons)
                        {
                            iVP.tbl_Turist.LT_V_Persons.Remove(iVP);
                            sqlDC.LT_V_Persons.DeleteOnSubmit(iVP);
                        }
                        iV.LT_V_Persons.Clear();
                    }
                }

                sqlDC.SubmitChanges();
                return vouchers;
            }
            return null;
        }

        public static LT_V_Voucher[] Create(sqlDataContext sqlDC, int dgKey)
        {
            return GenerateVoucher(sqlDC, dgKey).ToArray();
        }
    }
}
