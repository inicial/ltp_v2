using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("Данко")]
    public class prt_Danko : IprtClass
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
            DateTime lastBack = DateTime.MinValue;
            int KeyInRais = 1;

            KeyInRais = 1;

            ec.SetCellFormat(4);
            ec.SetCellValue(1, 4, "№", false);
            ec.SetCellValue(2, 4, "Фамилия", false);
            ec.SetCellValue(3, 4, "Имя", false);
            ec.SetCellValue(6, 4, "Пол", false);
            ec.SetCellValue(7, 4, "Дата рождения", false);
            ec.SetCellValue(8, 4, "№ паспорта", false);
            ec.SetCellValue(9, 4, "Срок  паспорта", false);

            var outvalues = exportItems.ToList();
            foreach (var q in outvalues
                .OrderBy(x => x.FirstReis.Charter.ToString())
                .ThenByDescending(x => (x.BackReis != null ? x.BackReis.BegServ : DateTime.MaxValue))
                .ThenBy(x => (x.BackReis != null ? x.BackReis.AirService.AS_CODE : ""))
                .ThenBy(x => x.NameLat)
                .ThenBy(x => x.FNameLat))
            {
                ec.SetCellFormat(lineOut);
                if (lastCode != q.RootCode || q.BackReis != null && lastBack.Date != q.BackReis.BegServ.Date)
                {
                    lineOut++;
                    lastCode = q.RootCode;
                    if (q.BackReis != null)
                        lastBack = q.BackReis.BegServ.Date;
                    else
                        lastBack = DateTime.MinValue;
                    //U63511/3512 Москва-Римини-Москва   30.04.2011-07.05.2011
                    ec.SetCellValue(1, lineOut,
                        q.FirstReis.Charter.ToString() + "/"
                        + (q.BackReis != null ? q.BackReis.Charter.ToString() : "") + " "
                        + q.FirstReis.Charter.AirportFrom.CityDictionary.CT_NAME + "-"
                        + q.FirstReis.Charter.AirportTo.CityDictionary.CT_NAME + "-"
                        + (q.BackReis != null ? q.BackReis.Charter.AirportTo.CityDictionary.CT_NAME : "") + "  "
                        + q.FirstReis.BegServ.ToString("dd.MM.yyyy") + "-"
                        + (q.BackReis != null ? q.BackReis.BegServ.ToString("dd.MM.yyyy") : ""), false);
                    lineOut += 2;
                    if (lineOut == 4)
                        lineOut = 5;
                }
                
                ec.SetCellFormat(lineOut);
                ec.SetCellValue(1, lineOut, KeyInRais.ToString());
                ec.SetCellValue(2, lineOut, q.NameLat);
                ec.SetCellValue(3, lineOut, q.FNameLat);
                ec.SetCellValue(6, lineOut, q.Turist.SexFull);
                
                if (q.Birthday.HasValue)
                    ec.SetCellValue(7, lineOut, q.Birthday.Value.ToString("dd.MM.yy"));
                ec.SetCellValue(8, lineOut, q.Turist.TU_PASPORTTYPE + " № " + q.Turist.TU_PASPORTNUM);
                if (q.Turist.TU_PASPORTDATEEND.HasValue)
                    ec.SetCellValue(9, lineOut, q.Turist.TU_PASPORTDATEEND.Value.ToString("dd.MM.yy"));

                lineOut++;
                KeyInRais++;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}
