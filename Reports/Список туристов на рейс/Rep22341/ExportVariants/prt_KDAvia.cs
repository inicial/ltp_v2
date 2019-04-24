using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("КД Авиа")]
    public class prt_KDAvia : IprtClass
    {
        public override void Start(IQueryable<ExportItem> exportItems, bool SplitPartner)
        {
            throw new NotImplementedException();
        }

        public override void Start(IQueryable<ExportItem> exportItems)
        {
            ExcelControl ec = new ExcelControl();

            ec.SetCellValue(4, 1, "на выписку билетов № ",false);
            ec.SetCellValue(4, 2, "Заявка", false);

            ec.SetCellValue(1, 4, "№№", false);
            ec.SetCellValue(2, 4, "Маршрут", false);
            ec.SetCellValue(3, 4, "Номер рейса", false);
            ec.SetCellValue(4, 4, "Дата прямого вылета", false);
            ec.SetCellValue(5, 4, "Дата обратного вылета", false);
            ec.SetCellValue(6, 4, "Фамилия, имя", false);
            ec.SetCellValue(7, 4, "Пол", false);
            ec.SetCellValue(8, 4, "Номер паспорта", false);
            ec.SetCellValue(9, 4, "Дата рождения", false);
            int lineOut = 5;

            int KeyInRais = 1;

            var outvalues = exportItems.ToList();
            foreach (var q in outvalues
                .OrderBy(x => x.NameLat)
                .ThenBy(x => x.FNameLat))
            {
                ec.SetCellFormat(lineOut);

                ec.SetCellValue(1, lineOut, KeyInRais);
                ec.SetCellValue(2, lineOut, string.Join("-", q.DogovorList
                    .OrderBy(x=>x.DL_DAY)
                    .Select(x=>x.Charter.CH_PORTCODEFROM).ToArray()) + (q.BackReis != null ? " - " + q.BackReis.Charter.CH_PORTCODETO: ""));
                ec.SetCellValue(3, lineOut, string.Join("-", q.DogovorList
                    .OrderBy(x => x.DL_DAY)
                    .Select(x => x.Charter.CH_FLIGHT).ToArray()));
                ec.SetCellValue(4, lineOut, q.FirstReis.BegServ.ToString("dd.MM.yy"));
                if (q.BackReis != null)
                    ec.SetCellValue(5, lineOut, q.BackReis.BegServ.ToString("dd.MM.yy"));
                ec.SetCellValue(6, lineOut, q.Turist.TU_NAMELAT + " " + q.Turist.TU_FNAMELAT);
                ec.SetCellValue(7, lineOut, q.Turist.SexFull);
                ec.SetCellValue(8, lineOut, q.Turist.TU_PASPORTTYPE + " " + q.Turist.TU_PASPORTNUM);
                if (q.Turist.TU_BIRTHDAY.HasValue)
                    ec.SetCellValue(9, lineOut, q.Turist.TU_BIRTHDAY.Value.ToString("dd.MM.yy"));

                
                lineOut++;
                KeyInRais++;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}
