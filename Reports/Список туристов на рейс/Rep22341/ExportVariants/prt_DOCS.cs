using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
//1334
namespace Rep22341.ExportVariants
{

    [DisplayName("DOCS")]
    public class prt_DOCS : IprtClass
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
            foreach (var q in outvalues
                .OrderBy(x => x.FirstReis.Charter.ToString())
                .ThenByDescending(x => (x.FirstReis != null ? x.FirstReis.BegServ : DateTime.MaxValue))
                .ThenByDescending(x => (x.BackReis != null ? x.BackReis.BegServ : DateTime.MaxValue))
                .ThenBy(x => (x.FirstReis != null ? x.FirstReis.AirService.AS_CODE : ""))
                .ThenBy(x => x.NameLat)
                .ThenBy(x => x.FNameLat))
            {
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
                    + q.Turist.TU_NAMELAT
                    + "/"
                    + q.Turist.TU_FNAMELAT
                    + "-"
                    + (lineOut+1) + ".1");
                lineOut++;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}
