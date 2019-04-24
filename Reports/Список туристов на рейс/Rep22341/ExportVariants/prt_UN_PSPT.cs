using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("UN PSPT")]
    public class prt_UN_PSPT : IprtClass
    {
        public override void Start(IQueryable<ExportItem> exportItems, bool SplitPartner)
        {
            throw new NotImplementedException();
        }

        public override void Start(IQueryable<ExportItem> exportItems)
        {
            ExcelControl ec = new ExcelControl();
            int lineOut = 1;

            int lastFirstCode = -1;
            int lastFirstCode1 = -1;
            int lastFirstPRKey = -1;
            DateTime lastFirstDate = DateTime.MinValue;

            int lastBackCode = -1;
            int lastBackCode1 = -1;
            DateTime lastBackDate = DateTime.MinValue;
            int KeyInRais = 1;

            var outvalues = exportItems.ToList();
            foreach (var q in outvalues
                .OrderBy(x => x.FirstReis.Charter.ToString())
                .ThenByDescending(x => (x.FirstReis != null ? x.FirstReis.BegServ : DateTime.MaxValue))
                .ThenByDescending(x => (x.BackReis != null ? x.BackReis.BegServ : DateTime.MaxValue))
                .ThenBy(x => (x.FirstReis != null ? x.FirstReis.Charter.CH_KEY : 0))
                .ThenBy(x => (x.BackReis != null ? x.BackReis.Charter.CH_KEY : 0))
                .ThenBy(x => (x.FirstReis != null ? x.FirstReis.AirService.AS_CODE : ""))
                .ThenBy(x => (x.BackReis != null ? x.BackReis.AirService.AS_CODE : ""))
                .ThenBy(x => x.NameLat)
                .ThenBy(x => x.FNameLat))
            {
                if (
                    lastFirstDate.Date != q.FirstReis.BegServ.Date ||
                    lastFirstCode != q.FirstReis.DL_CODE ||
                    lastFirstCode1 != q.FirstReis.DL_SUBCODE1.GetValueOrDefault(0) ||
                    q.BackReis != null && lastBackCode != q.BackReis.DL_CODE ||
                    q.BackReis != null && lastBackCode1 != q.BackReis.DL_SUBCODE1.GetValueOrDefault(0) ||
                    q.BackReis != null && lastBackDate.Date != q.BackReis.BegServ.Date
                    )
                {
                    lastFirstCode = q.FirstReis.DL_CODE;
                    lastFirstCode1 = q.FirstReis.DL_SUBCODE1.GetValueOrDefault(0);
                    lastFirstDate = q.FirstReis.BegServ.Date;
                    lastFirstPRKey = q.FirstReis.DL_PARTNERKEY;
                    if (q.BackReis != null)
                    {
                        lastBackCode = q.BackReis.DL_CODE;
                        lastBackCode1 = q.BackReis.DL_SUBCODE1.GetValueOrDefault(0);
                        lastBackDate = q.BackReis.BegServ.Date;
                    }

                    KeyInRais = 1;
                    lineOut++;
                }
                ec.SetCellFormat(lineOut);

                ec.SetCellValue(1, lineOut,
                    "SSR:PSPT UN HK1/"
                    + "P" 
                    + q.Turist.TU_PASPORTTYPE + "N" + q.Turist.TU_PASPORTNUM 
                    + "/RU/"
                    + (q.Turist.TU_BIRTHDAY.HasValue
                        ?   q.Turist.TU_BIRTHDAY.Value.ToString("dd") + 
                            q.Turist.TU_BIRTHDAY.Value.GetShortLatMonth() +
                            q.Turist.TU_BIRTHDAY.Value.ToString("yy")
                        : "")
                    + "/"
                    + q.Turist.TU_NAMELAT.ReplaceAnalogChar()
                    + "/"
                    + q.Turist.TU_FNAMELAT.ReplaceAnalogChar()
                    + "/"
                    + q.Turist.SexShort
                    + "/P" + (KeyInRais).ToString());
                lineOut++;
                KeyInRais++;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}
