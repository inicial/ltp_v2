namespace AgencyManager.ObjectModel
{
    using System.Linq;
    using System.Data.Linq;
    using ltp_v2.Framework;
    using System.Collections.Generic;
    using System;

    partial class MinimumDate
    {
        public void GetMinimumDate(int PartnerKey, int PDTId)
        {
            ReferencesDataContext RDC = new ReferencesDataContext(SqlConnection.ConnectionData);
            List<MinimumDate> ListMinimumDate = RDC.ExecuteQuery<MinimumDate>(@"
DECLARE @DateStart DateTime
DECLARE @PRKey Int
DECLARE @PDTID Int
SET @DateStart = {0}
SET @PRKey = {1}
SET @PDTID = {2}

declare @isRootType bit 
set @isRootType = 0

select @isRootType = case when LDT_IsRoot = 1 then 1 else 0 end
from LTP_DogType
where LDT_PDTID = @PDTID

SELECT
    CASE WHEN min(DG_CRDate) > isNull(MaxTempDog, @DateStart) THEN
        CASE WHEN min(DG_CRDate) > isNull(MaxLastDog, @DateStart) THEN
            min(DG_CRDate)
        ELSE
            isNull(MaxLastDog, @DateStart) + Day(0)
        END
    ELSE    
        CASE WHEN isNull(MaxLastDog, @DateStart) > isNull(MaxTempDog, @DateStart) THEN
            isNull(MaxLastDog, @DateStart) + Day(0)
        ELSE
            isNull(MaxTempDog, @DateStart) + Day(0)
        END
    END as NewDate,
    MaxTempDog,
    MaxLastDog,
    min(DG_CRDate) as MinDateCreate,
    CASE WHEN isNull(MaxLastDog, @DateStart) > isNull(MaxTempDog, @DateStart) THEN
        /*DateAdd(year, -1, */isNull(MaxLastDog, getdate())--)
    ELSE
        /*DateAdd(year, -1, */isNull(MaxTempDog, getdate())--)
    END as LastDogovor
FROM
(
    SELECT
        isNull(DG_CRDate, GetDate()) as DG_CRDate,
        max(LTPD_DateEnd) as MaxTempDog,
        max(PD_DateEnd) as MaxLastDog
    FROM    PartnerAcess
    LEFT JOIN LTP_DogType ON LDT_PDTID = @PDTID and @isRootType = 0 or @isRootType = 1 and LDT_IsRoot = 1
    LEFT JOIN LTP_PrtDog ON LTPD_PRKey = PR_Key and LTPD_LDTId = LDT_PDTID
    LEFT JOIN PrtDogs ON PD_PRKey = PR_Key and Pd_DogType = LDT_PDTID
    LEFT JOIN tbl_Dogovor ON DG_PartnerKey = PR_Key
    WHERE   PR_Key = @PRKey and PR_Deleted = 0
    GROUP BY DG_CRDate
) as tblMinDGDate
--WHERE  DG_CRDate > MaxTempDog and DG_CRDate > MaxLastDog or DG_CRDate is null
GROUP BY MaxTempDog, MaxLastDog
", new DateTime(2007, 06, 01), PartnerKey, PDTId).ToList();
            if (ListMinimumDate.Count() == 0)
            {
                this.LastDogovor = DateTime.Now;
                this.MaxLastDog = DateTime.Now;
                this.MaxTempDog = DateTime.Now;
                this.MinDateCreate = DateTime.Now;
                this.NewDate = DateTime.Now;
            }
            else
            {
                MinimumDate result = ListMinimumDate.First();
                this.LastDogovor = result.LastDogovor;
                this.MaxLastDog = result.MaxLastDog;
                this.MaxTempDog = result.MaxTempDog;
                this.MinDateCreate = result.MinDateCreate;
                this.NewDate = result.NewDate;
            }
        }
    }
}
