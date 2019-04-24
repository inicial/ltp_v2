using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("Вим_Авиа")]
    public class prt_VIMAvia : IprtClass
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
            int lastCode = -1;
            DateTime lastDate = DateTime.MinValue;
            

            var outvalues = exportItems.ToList();
            foreach (var q in outvalues
                .OrderBy(x => x.FirstReis.Charter.ToString())
                .ThenByDescending(x => (x.BackReis != null ? x.BackReis.BegServ : DateTime.MaxValue))
                .ThenBy(x => (x.BackReis != null ? x.BackReis.AirService.AS_CODE : ""))
                .ThenBy(x => x.NameLat)
                .ThenBy(x => x.FNameLat))
            {
                ec.SetCellFormat(lineOut);
                if (lastCode != q.RootCode ||
                    lastDate != q.FirstReis.BegServ.Date)
                {
                    lastCode = q.RootCode;
                    lastDate = q.FirstReis.BegServ.Date;

                    ec.SetCellValue(1, lineOut, "Список на авиабилеты", false);
                    ec.SetCellValue(1, lineOut + 2, "Дата вылета: " + q.FirstReis.BegServ.ToString());
                    ec.SetCellValue(1, lineOut + 3, "Рейс: " + q.FirstReis.Charter.ToString());
                    if (q.FirstReis.FlyFrom.HasValue)
                        ec.SetCellValue(1, lineOut + 4, "Время вылета: " + q.FirstReis.FlyFrom.Value.ToString("HH:mm:ss"));
                    ec.SetCellValue(1, lineOut + 5, "Маршрут: " + q.FirstReis.Charter.AirportTo.CityDictionary.CT_NAME + " - " + q.FirstReis.Charter.AirportTo.CityDictionary.CT_NAMELAT);

                    lineOut += 8;
                    KeyInRais = 1;
                }
                
                ec.SetCellFormat(lineOut);

                ec.SetCellValue(1, lineOut, KeyInRais);
                ec.SetCellValue(2, lineOut, q.Turist.TU_NAMELAT + " " + q.Turist.TU_FNAMELAT);
                ec.SetCellValue(3, lineOut, q.Turist.SexFull);
                if (q.Turist.TU_BIRTHDAY.HasValue)
                    ec.SetCellValue(4, lineOut, q.Turist.TU_BIRTHDAY.Value.ToString("dd.MM.yyyy"));
                ec.SetCellValue(5, lineOut, q.Turist.TU_PASPORTTYPE + " " + q.Turist.TU_PASPORTNUM);
                ec.SetCellValue(6, lineOut, q.FirstReis.AirService.AS_CODE + " - " + q.FirstReis.AirService.AS_NAMERUS);
                ec.SetCellValue(7, lineOut, "RU");
                if (q.Turist.TU_PASPORTDATEEND.HasValue)
                    ec.SetCellValue(8, lineOut, q.Turist.TU_PASPORTDATEEND.Value.ToString("dd.MM.yyyy"));

                lineOut++;
                KeyInRais++;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}
