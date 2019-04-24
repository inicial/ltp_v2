using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("Ancodes")]
    public class prt_Ancodes : IprtClass
    {
        public override void Start(IQueryable<ExportItem> exportItems, bool SplitPartner)
        {
            throw new NotImplementedException();
        }

        public override void Start(IQueryable<ExportItem> exportItems)
        {
            ExcelControl ec = new ExcelControl();
            int lineOut = 4;
            int KeyInRais = 1;

            ec.SetCellValue(1, lineOut, "№");
            ec.SetCellValue(2, lineOut, "Фамилия");
            ec.SetCellValue(3, lineOut, "Пол");
            ec.SetCellValue(4, lineOut, "Дата рождения");
            ec.SetCellValue(5, lineOut, "Номер паспорта");
            ec.SetCellValue(6, lineOut, "Гр-во");
            ec.SetCellValue(7, lineOut, "Срок з/паспорта");
            ec.SetCellValue(8, lineOut, "Вылет");
            ec.SetCellValue(9, lineOut, "Рейс");
            ec.SetCellValue(10, lineOut, "Возврат");
            ec.SetCellValue(11, lineOut, "Рейс");
            lineOut++;

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
                ec.SetCellValue(2, lineOut, q.Turist.TU_NAMELAT + "/" + q.Turist.TU_FNAMELAT);
                ec.SetCellValue(3, lineOut, q.Turist.SexFull);
                if (q.Turist.TU_BIRTHDAY.HasValue)
                    ec.SetCellValue(4, lineOut, q.Turist.TU_BIRTHDAY.Value.ToString("dd") + q.Turist.TU_BIRTHDAY.Value.GetShortLatMonth() + q.Turist.TU_BIRTHDAY.Value.ToString("yyyy"));
                ec.SetCellValue(5, lineOut, q.Turist.TU_PASPORTTYPE + " " + q.Turist.TU_PASPORTNUM);
                ec.SetCellValue(6, lineOut, "");
                if (q.Turist.TU_PASPORTDATEEND.HasValue)
                    ec.SetCellValue(7, lineOut, q.Turist.TU_PASPORTDATEEND.Value.ToString("dd") + q.Turist.TU_PASPORTDATEEND.Value.GetShortLatMonth() + q.Turist.TU_PASPORTDATEEND.Value.ToString("yyyy"));
                ec.SetCellValue(8, lineOut, q.FirstReis.BegServ.ToString("dd") + q.FirstReis.BegServ.GetShortLatMonth() + q.FirstReis.BegServ.ToString("yyyy"));
                ec.SetCellValue(9, lineOut, q.FirstReis.Charter.ToString());
                if (q.BackReis != null)
                {
                    if (q.BackReis.BegServ != null)
                    {
                        ec.SetCellValue(10, lineOut, q.BackReis.BegServ.ToString("dd") + q.BackReis.BegServ.GetShortLatMonth() + q.BackReis.BegServ.ToString("yyyy"));
                    }
                    ec.SetCellValue(11, lineOut, q.BackReis.Charter.ToString());
                }

                lineOut++;
                KeyInRais++;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}
