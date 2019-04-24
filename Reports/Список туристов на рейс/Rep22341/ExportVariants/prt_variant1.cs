using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("Вариант1")]
    public class prt_variant1 : IprtClass
    {
        public override void Start(IQueryable<ExportItem> exportItems, bool SplitPartner)
        {
            throw new NotImplementedException();
        }

        public override void Start(IQueryable<ExportItem> exportItems)
        {
            ExcelControl ec = new ExcelControl();
            int lineOut = 1;
            int lastCode = -1;
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
                if (lastCode != q.RootCode)
                {
                    lineOut++;
                    lastCode = q.RootCode;
                    ec.SetCellValue(1, lineOut, "Список туристов на рейс №" + q.FirstReis.Charter.ToString() + " на " + q.FirstReis.BegServ.ToString("dd-MM-yyyy"), false);
                    lineOut += 2;
                    
                    ec.SetCellFormat(lineOut);
                    ec.SetCellValue(1, lineOut, "№",false);
                    ec.SetCellValue(2, lineOut, "Фамилия", false);
                    ec.SetCellValue(3, lineOut, "Имя", false);
                    ec.SetCellValue(4, lineOut, "Пол", false);
                    ec.SetCellValue(5, lineOut, "Дата рождения", false);
                    ec.SetCellValue(6, lineOut, "Серия", false);
                    ec.SetCellValue(7, lineOut, "№ паспорта", false);
                    ec.SetCellValue(8, lineOut, "Обратный вылет", false);
                    ec.SetCellValue(9, lineOut, "№ обратн. рейса", false);
                    ec.SetCellValue(10, lineOut, "Класс", false);
                    ec.SetCellValue(11, lineOut, "Примечания", false);
                    lineOut++;
                    KeyInRais = 1;
                }
                
                ec.SetCellFormat(lineOut);
                ec.SetCellValue(1, lineOut, KeyInRais.ToString());
                ec.SetCellValue(2, lineOut, q.NameLat);
                ec.SetCellValue(3, lineOut, q.FNameLat);
                ec.SetCellValue(4, lineOut, q.Turist.SexFull);
                if (q.Birthday.HasValue)
                    ec.SetCellValue(5, lineOut, q.Birthday.Value.ToString("dd-MM-yyyy"));
                ec.SetCellValue(6, lineOut, q.Turist.TU_PASPORTTYPE);
                ec.SetCellValue(7, lineOut, q.Turist.TU_PASPORTNUM);
                if (q.BackReis != null)
                {
                    if (q.BackReis.DL_TURDATE.HasValue)
                    {
                        ec.SetCellValue(8, lineOut, q.BackReis.DL_TURDATE.Value.AddDays(q.BackReis.DL_DAY.GetValueOrDefault(0) - 1).ToString("dd-MM-yyyy"));
                    }
                    ec.SetCellValue(9, lineOut, q.BackReis.Charter.CH_AIRLINECODE + " " + q.BackReis.Charter.CH_FLIGHT);
                    ec.SetCellValue(10, lineOut, q.BackReis.AirService.AS_CODE.ToUpper());
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
