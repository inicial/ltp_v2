using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("Аэрофлот")]
    public class prt_Aeroflot : IprtClass
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
            DateTime lastFirstDate = DateTime.MinValue;

            var outvalues = exportItems.ToList();
            foreach (var q in outvalues
                .OrderBy(x => x.FirstReis.Charter.ToString())
                .ThenByDescending(x => (x.BackReis != null ? x.BackReis.BegServ : DateTime.MaxValue))
                .ThenBy(x => (x.BackReis != null ? x.BackReis.AirService.AS_CODE : ""))
                .ThenBy(x => x.NameLat)
                .ThenBy(x => x.FNameLat))
            {
                if (lastFirstDate != q.FirstReis.BegServ.Date)
                {
                    lastFirstDate = q.FirstReis.BegServ.Date;
                    ec.SetCellFormat(lineOut);
                    ec.SetCellFormat(lineOut+1);
                    ec.SetCellValue(2, lineOut, "Дата", false);
                    ec.SetCellValue(2, lineOut + 1, "вылета", false);
                    ec.SetCellValue(3, lineOut + 1, q.FirstReis.BegServ.ToString("dd.MM.yyyy"), false);

                    ec.SetCellValue(4, lineOut, "фирма", false);
                    ec.SetCellValue(4, lineOut + 1, "заказчик", false);
                    ec.SetCellValue(5, lineOut + 1, "Lanta-tur Voyage", false);

                    ec.SetCellValue(6, lineOut + 1, "исполнитель", false);
                    ec.SetCellValue(7, lineOut + 1, "Казьмин", false);

                    ec.SetCellValue(9, lineOut, "ВСЕГО", false);
                    ec.SetCellValue(9, lineOut + 1, "БИЛЕТОВ", false);
                    ec.SetCellValue(10, lineOut + 1, outvalues.Count(x => x.FirstReis.BegServ.Date == lastFirstDate).ToString(), false);

                    ec.SetCellValue(11, lineOut, "ИЗ НИХ", false);
                    ec.SetCellValue(11, lineOut + 1, "БИЗНЕС", false);

                    lineOut += 3;
                    ec.SetCellFormat(lineOut);
                    ec.SetCellFormat(lineOut + 1);

                    ec.SetCellValue(1, lineOut, "#", false);

                    ec.SetCellValue(2, lineOut, "КОЛ-ВО", false);
                    ec.SetCellValue(2, lineOut + 1, "ДНЕЙ", false);

                    ec.SetCellValue(3, lineOut, "ДАТА", false);
                    ec.SetCellValue(3, lineOut + 1, "ВОЗВРАТА", false);

                    ec.SetCellValue(4, lineOut, "эк(0)", false);
                    ec.SetCellValue(4, lineOut + 1, "биз(1)", false);

                    ec.SetCellValue(5, lineOut + 1, "ПОЛ", false);

                    ec.SetCellValue(6, lineOut, "фамилия и имя", false);

                    ec.SetCellValue(7, lineOut, "дата", false);
                    ec.SetCellValue(7, lineOut + 1, "рождения", false);

                    ec.SetCellValue(8, lineOut, "номер", false);
                    ec.SetCellValue(8, lineOut + 1, "паспорта", false);

                    ec.SetCellValue(9, lineOut, "дата конца", false);
                    ec.SetCellValue(9, lineOut + 1, "паспорта", false);

                    ec.SetCellValue(10, lineOut, "фирма", false);
                    ec.SetCellValue(10, lineOut + 1, "заказчик", false);

                    ec.SetCellValue(11, lineOut, "гражданство", false);
                    lineOut += 2;
                    KeyInRais = 1;
                }
                ec.SetCellFormat(lineOut);
                ec.SetCellValue(1, lineOut, KeyInRais);
                if (q.BackReis != null && q.BackReis.BegServ != null)
                {
                    ec.SetCellValue(3, lineOut, q.BackReis.BegServ.ToString("dd.MM.yyyy"));
                }
                ec.SetCellValue(5, lineOut, q.Turist.SexFull);
                ec.SetCellValue(6, lineOut, q.Turist.TU_NAMELAT + " " + q.Turist.TU_FNAMELAT);
                if(q.Birthday.HasValue)
                    ec.SetCellValue(7, lineOut, q.Turist.TU_BIRTHDAY.Value.ToString("dd.MM.yyyy"));
                ec.SetCellValue(8, lineOut, q.Turist.TU_PASPORTTYPE + "N" + q.Turist.TU_PASPORTNUM);
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
