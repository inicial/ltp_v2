using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
//1334
namespace Rep22341.ExportVariants
{

    [DisplayName("SU DOCS")]
    public class prt_SU_DOCS : IprtClass
    {
        public override void Start(IQueryable<ExportItem> exportItems, bool SplitPartner)
        {
            throw new NotImplementedException();
        }

        public override void Start(IQueryable<ExportItem> exportItems)
        {
            ExcelControl ec = new ExcelControl();
            int lineOut = 1;

            var outvalues = exportItems.ToList();

            int lastFirstCode = -1;
            int lastFirstCode1 = -1;
            int lastFirstPRKey = -1;
            DateTime lastFirstDate = DateTime.MinValue;

            int lastBackCode = -1;
            int lastBackCode1 = -1;
            DateTime lastBackDate = DateTime.MinValue;

            int KeyInRais = 2;
            var values = outvalues
                .OrderBy(x => x.FirstReis.Charter.ToString())
                .ThenByDescending(x => (x.FirstReis != null ? x.FirstReis.BegServ : DateTime.MaxValue))
                .ThenByDescending(x => (x.BackReis != null ? x.BackReis.BegServ : DateTime.MaxValue))
                .ThenBy(x => (x.FirstReis != null ? x.FirstReis.Charter.CH_KEY : 0))
                .ThenBy(x => (x.BackReis != null ? x.BackReis.Charter.CH_KEY : 0))
                .ThenBy(x => (x.FirstReis != null ? x.FirstReis.AirService.AS_CODE : ""))
                .ThenBy(x => (x.BackReis != null ? x.BackReis.AirService.AS_CODE : ""))
                .ThenBy(x => x.NameLat)
                .ThenBy(x => x.FNameLat);
            foreach (var q in values)
            {
                //var countBrothers = values.Count(x => x.NameLat == q.NameLat);
                if (
                    KeyInRais > 10 ||
                    //countBrothers < 9 && countBrothers + KeyInRais > 9 ||
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

                    KeyInRais = 2;
                    lineOut++;
                }

                ec.SetCellFormat(lineOut);

                ec.SetCellValue(1, lineOut,
                    "3DOCS/P/RU/"
                    + q.Turist.TU_PASPORTNUM
                    + "/RU/"
                    + (q.Turist.TU_BIRTHDAY.HasValue
                        ? q.Turist.TU_BIRTHDAY.Value.ToString("dd") +
                            q.Turist.TU_BIRTHDAY.Value.GetShortLatMonth() +
                            q.Turist.TU_BIRTHDAY.Value.ToString("yy")
                        : "")
                    + "/"
                    + q.Turist.SexShort
                    + "/"
                    + (q.Turist.TU_PASPORTDATEEND.HasValue
                        ? q.Turist.TU_PASPORTDATEEND.Value.ToString("dd") +
                            q.Turist.TU_PASPORTDATEEND.Value.GetShortLatMonth() +
                            q.Turist.TU_PASPORTDATEEND.Value.ToString("yy")
                        : "")
                    + "/"
                    + q.Turist.TU_NAMELAT.ReplaceAnalogChar()
                    + "/"
                    + q.Turist.TU_FNAMELAT.ReplaceAnalogChar()
                    + "-"
                    + (KeyInRais) + ".1");

                lineOut++;
                KeyInRais++;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}