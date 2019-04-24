using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("Асент Тревел СПБ")]
    public class prt_AsentTravel : IprtClass
    {
        public override void Start(IQueryable<ExportItem> exportItems, bool SplitPartner)
        {
            throw new NotImplementedException();
        }

        public override void Start(IQueryable<ExportItem> exportItems)
        {
            ExcelControl ec = new ExcelControl();
            
            var outvalues = exportItems.ToList();
            if (outvalues.Count() == 0)
                return;

            ec.SetCellFormat(1);
            ec.SetCellValue(1, 1, "Список на авиабилеты");
            ec.SetCellValue(1, 3, "Дата вылета:" + outvalues.First().FirstReis.BegServ.ToString("dd.MM.yyyy"));
            ec.SetCellValue(1, 4, "Рейс:" + outvalues.First().FirstReis.Charter.CH_FLIGHT);
            if (outvalues.First().FirstReis.FlyFrom.HasValue)
                ec.SetCellValue(1, 5, "Время вылета:" + outvalues.First().FirstReis.FlyFrom.Value.ToString("HH:mm:ss"));
            ec.SetCellValue(1, 6, "Маршрут:" + outvalues.First().FirstReis.Charter.CH_PORTCODEFROM + "-" + outvalues.First().FirstReis.Charter.CH_PORTCODETO);

            ec.SetCellValue(1, 8, "№");
            ec.SetCellValue(2, 8, "Фамилия, имя");
            ec.SetCellValue(3, 8, "Пол");
            ec.SetCellValue(4, 8, "Дата Рождения");
            ec.SetCellValue(5, 8, "№ паспорта");
            ec.SetCellValue(6, 8, "Класс");
            ec.SetCellValue(7, 8, "Гражданство");
            ec.SetCellValue(8, 8, "Срок действия");

            int lineOut = 9;
            
            foreach (var q in outvalues
                .OrderBy(x => x.FirstReis.Charter.ToString())
                .ThenByDescending(x => (x.FirstReis != null ? x.FirstReis.BegServ : DateTime.MaxValue))
                .ThenByDescending(x => (x.BackReis != null ? x.BackReis.BegServ : DateTime.MaxValue))
                .ThenBy(x => (x.FirstReis != null ? x.FirstReis.AirService.AS_CODE : ""))
                .ThenBy(x => x.NameLat)
                .ThenBy(x => x.FNameLat))
            {
                ec.SetCellFormat(lineOut);
                ec.SetCellValue(1, lineOut, lineOut - 8);
                ec.SetCellValue(2, lineOut, q.Turist.TU_NAMELAT + " " + q.Turist.TU_FNAMELAT);
                ec.SetCellValue(3, lineOut, q.Turist.SexFull);
                if (q.Turist.TU_BIRTHDAY.HasValue)
                    ec.SetCellValue(4, lineOut, q.Turist.TU_BIRTHDAY.Value.ToString("dd.MM.yyyy"));
                ec.SetCellValue(5, lineOut, q.Turist.TU_PASPORTTYPE + " " + q.Turist.TU_PASPORTNUM);
                ec.SetCellValue(6, lineOut, q.FirstReis.AirService.AS_CODE + "-" + q.FirstReis.AirService.AS_NAMERUS);
                ec.SetCellValue(7, lineOut, "Ru");
                if (q.Turist.TU_PASPORTDATEEND.HasValue)
                    ec.SetCellValue(8, lineOut, q.Turist.TU_PASPORTDATEEND.Value.ToString("dd.MM.yyyy"));
                lineOut++;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}
