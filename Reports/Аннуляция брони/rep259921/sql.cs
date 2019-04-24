namespace rep259921
{
    using System;
    using System.Linq;

    partial class sqlDataContext
    {
        private int? GetKey(String tabelKey)
        {
            sqlDataContext tmpSQLDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            int? result = 0;
            if (tabelKey.ToUpper() == "DOGOVORLIST")
            {
                result = tmpSQLDC.ExecuteQuery<int>(@"
declare @nNewKey int
update Key_DogovorList WITH (ROWLOCK) set @nNewKey = Id = (Select max(id) from Key_DogovorList) + 1
SELECT @nNewKey", new object[0]).FirstOrDefault();
            }
            else
            {
                tmpSQLDC.GetNKey(tabelKey, ref result);
            }
            tmpSQLDC.SubmitChanges();
            tmpSQLDC.Dispose();
            return result;
        }

        private void UpdateNewKeys()
        {
            foreach (object tmpItem in this.GetChangeSet().Inserts)
            {
                if (tmpItem.GetType() == typeof(tbl_DogovorList)) //DOGOVORLIST
                {
                    tbl_DogovorList dlItem = (tbl_DogovorList)tmpItem;
                    int? NewKey = 0;
                    NewKey = GetKey("DOGOVORLIST");
                    dlItem.DL_KEY = NewKey.Value;
                    if (!dlItem.DL_SUBCODE1.HasValue)
                        dlItem.DL_SUBCODE1 = 0;
                    if (!dlItem.DL_SUBCODE2.HasValue)
                        dlItem.DL_SUBCODE2 = 0;
                } else if (tmpItem.GetType() == typeof(ServiceList)) //SERVICELIST
                {
                    int? NewKey = 0;
                    NewKey = GetKey("SERVICELIST");
                    ((ServiceList)tmpItem).SL_KEY = NewKey.Value;
                }
                else if (tmpItem.GetType() == typeof(TuristService))
                {
                }
                else if (tmpItem.GetType() == typeof(tbl_Cost))
                {
                }
                else if (tmpItem.GetType() == typeof(History))
                {
                    ((History)tmpItem).HI_DATE = ltp_v2.Framework.SqlConnection.ServerDateTime;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
        {
            UpdateNewKeys();
            base.SubmitChanges(failureMode);
        }
    }

    partial class Service
    {
        public override string ToString()
        {
            return this.SV_NAME;
        }
    }

    partial class ServiceList
    {
        public ServiceList(Service sv, int cnKey, tbl_DogovorList source)
        {
            SL_CNKEY = cnKey;
            SL_CTKEY = 0;
            SL_NAME = source.DL_NAME.Trim() + " Бронь № " + source.DL_DGCOD;
            SL_NAMELAT = source.DL_NameLat.Trim() + " Бронь № " + source.DL_DGCOD;
            Service = sv;
        }

        public override string ToString()
        {
            return this.SL_NAME;
        }
    }

    partial class AnnulReason
    {
        public override string ToString()
        {
            return AR_NAME.Trim();
        }
    }

    partial class Order_Status
    {
        public override string ToString()
        {
            return this.OS_NAME_RUS.Trim();
        }
    }

    partial class tbl_Dogovor
    {
        public override string ToString()
        {
            return this.DG_CODE;
        }

        public bool PresendPayTransaction(sqlDataContext sqlDC)
        {
            return (sqlDC.FIN_TRANSACTIONs.Any(xFT =>
                            xFT.TR_FAPKEY == 0
                            && xFT.TR_TURSUM.GetValueOrDefault(0) != 0
                            && new int[] { 87, 88, 89, 90, 1000 }.Contains(xFT.TR_CREDIT)
                            && xFT.TR_CR_DGCODE == this.DG_CODE)
                || sqlDC.FIN_TRANSACTIONs.Any(xFT =>
                            xFT.TR_FAPKEY == 0
                            && xFT.TR_TURSUM.GetValueOrDefault(0) != 0
                            && new int[] { 87, 88, 89, 90, 1000 }.Contains(xFT.TR_DEBT)
                            && xFT.TR_DT_DGCODE == this.DG_CODE)
                || sqlDC.PaymentDetails.Any(x => x.PD_DGKey == this.DG_Key));
        }

        public void WriteAnnulHistory(AnnulReason annulReason)
        {
            this.Histories.Add(new History()
            {
                HI_MessEnabled = 1,
                HI_TEXT = "Аннулирование путевки, цена " + this.DG_PRICE.ToString() + " " + DG_RATE + ", дата заезда - " + this.DG_TURDATE.ToString("dd.MM.yyyy"),
                HI_REMARK = this.DG_TURDATE.ToString("dd.MM.yyyy"),
                HI_MOD = "ANN",
                HI_DGCOD = this.DG_CODE,
                HI_DGKEY = this.DG_Key,
                HI_WHO = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FullName
            });

            this.Histories.Add(new History()
            {
                HI_MessEnabled = 1,
                HI_TEXT = "Причина аннуляции - " + annulReason.AR_NAME.Trim(),
                HI_REMARK = this.DG_TURDATE.ToString("dd.MM.yyyy"),
                HI_MOD = "ANN",
                HI_DGCOD = this.DG_CODE,
                HI_DGKEY = this.DG_Key,
                HI_WHO = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FullName
            });
        }

        public void Annul(AnnulReason annulReason)
        {
            WriteAnnulHistory(annulReason);

            this.DG_TurDateBfrAnnul = this.DG_TURDATE;
            this.DG_TURDATE = new System.DateTime(1899, 12, 30);
            this.DG_ARKey = annulReason.AR_Key;
            this.DG_SOR_CODE = 2;
        }
    }

    partial class tbl_Cost
    {
        public tbl_Cost(int partnerKey, ServiceList sl, tbl_Dogovor dogovor, double total)
        {
            ServiceList = sl;

            CS_SVKEY = 10;
            CS_PRKEY = partnerKey;
            CS_DATE = dogovor.DG_TURDATE.Date;
            CS_DATEEND = dogovor.DG_TURDATE.Date;
            CS_COST = total;
            CS_COSTNETTO = total;
            CS_RATE = dogovor.DG_RATE;
                    
            CS_CREATOR = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_KEY;
            CS_UPDDATE = ltp_v2.Framework.SqlConnection.ServerDateTime;
            CS_UPDUSER = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FullName;

            CS_PKKEY = 0;
            CS_SUBCODE1 = 0;
            CS_SUBCODE2 = 0;
            CS_WEEK = "";
            CS_DISCOUNT = 0;
            CS_BYDAY = 2;
        }
    }

    partial class tbl_DogovorList
    {

        public tbl_DogovorList(tbl_Dogovor dogovor)
            : this()
        {
            tbl_Dogovor = dogovor;
            DL_CREATOR = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_KEY;

            DL_DGCOD = dogovor.DG_CODE;
            DL_DGKEY = dogovor.DG_Key;
            DL_CNKEY = dogovor.DG_CNKEY;
            DL_CTKEY = dogovor.DG_CTKEY;
            DL_TURDATE = dogovor.DG_TURDATE;
            DL_AGENT = dogovor.DG_PARTNERKEY;
            DL_Long = (short)dogovor.DG_NDAY;

            DL_PAKETKEY = null;
            DL_TIMEBEG = null;
            DL_TRKEY = dogovor.DG_TRKEY.GetValueOrDefault(0);

            DL_BLOCKED = 0;
            DL_CONTROL = 0;
            DL_OWNER = 0;
            DL_ISPAYED = 0;
            DL_QUOTEKEY = 0;
            DL_WAIT = 0;
            DL_WARNING = 0;
        }

        /// <summary>
        /// Создание услуги аннуляции
        /// </summary>
        public tbl_DogovorList(tbl_Dogovor dogovor, Service sv)
            : this(dogovor)
        {
            Service = sv;
            DL_CODE = 74907;

            DL_NAME = sv.SV_NAME;
            DL_NameLat = sv.SV_NAMELAT;
            
            DL_DAY = 1;
            DL_NDAYS = (short)dogovor.DG_NDAY;
            DL_DATEBEG = dogovor.DG_TURDATE;
            DL_DATEEND = dogovor.DG_TURDATE.AddDays(dogovor.DG_NDAY - 1);
            DL_NMEN = dogovor.DG_NMEN.GetValueOrDefault(0);

            DL_PARTNERKEY = 1;
            DL_ATTRIBUTE = 0;

            DL_SUBCODE1 = 0;
            DL_SUBCODE2 = 0;

            foreach (var item in dogovor.tbl_Turists)
            {
                this.TuristServices.Add(new TuristService() { TU_TUKEY = item.TU_KEY });
            }
        }
        
        /// <summary>
        /// Создание услуги штрафа
        /// </summary>
        public tbl_DogovorList(tbl_Dogovor dogovor, tbl_DogovorList source, Service sv, ServiceList sl)
            : this(dogovor)
        {
            DL_SUBCODE1 = 0;
            DL_SUBCODE2 = 0;

            ServiceList = sl;
            Service = sv;

            DL_NAME = sv.SV_NAME + ": " + sl.SL_NAME;
            DL_NameLat = sv.SV_NAMELAT + ": " + sl.SL_NAMELAT;

            DL_DAY = source.DL_DAY;
            DL_NDAYS = source.DL_NDAYS;
            DL_DATEBEG = source.DL_DATEBEG;
            DL_DATEEND = source.DL_DATEEND;

            DL_NMEN = source.DL_NMEN;
            DL_PARTNERKEY = source.DL_PARTNERKEY;

            DL_ATTRIBUTE = 159;
        }
    }
}
