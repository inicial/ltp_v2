using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("Дон Авиа")]
    public class prt_DONAvia : IprtClass
    {
        public override void Start(IQueryable<ExportItem> exportItems, bool SplitPartner)
        {
            throw new NotImplementedException();
        }

        public override void Start(IQueryable<ExportItem> exportItems)
        {
            ExcelControl ec = new ExcelControl();
            int lineOut = 1;
            int KeyInRais = 1;

            var outvalues = exportItems.ToList();
            foreach (var q in outvalues
                .OrderBy(x => x.FirstReis.Charter.ToString())
                .ThenByDescending(x => (x.BackReis != null ? x.BackReis.BegServ : DateTime.MaxValue))
                .ThenBy(x => (x.BackReis != null ? x.BackReis.AirService.AS_CODE : ""))
                .ThenBy(x => x.NameLat)
                .ThenBy(x => x.FNameLat))
            {
                ec.SetCellFormat(lineOut);

                ec.SetCellValue(1, lineOut, KeyInRais);
                ec.SetCellValue(2, lineOut, q.Turist.TU_NAMELAT);
                ec.SetCellValue(3, lineOut, q.Turist.TU_FNAMELAT);
                ec.SetCellValue(4, lineOut, q.Turist.SexShort);
                if (q.Turist.TU_BIRTHDAY.HasValue)
                    ec.SetCellValue(5, lineOut, q.Turist.TU_BIRTHDAY.Value.ToString("dd-MM-yyyy"));
                ec.SetCellValue(6, lineOut, "RU");
                ec.SetCellValue(7, lineOut, "RU");
                ec.SetCellValue(8, lineOut, (q.Turist.TU_PASPORTTYPE + " " + q.Turist.TU_PASPORTNUM).Replace(" ", ""));
                if (q.Turist.TU_PASPORTDATEEND.HasValue)
                    ec.SetCellValue(9, lineOut, q.Turist.TU_PASPORTDATEEND.Value.ToString("dd.MM.yyyy"));

                lineOut++;
                KeyInRais++;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}
