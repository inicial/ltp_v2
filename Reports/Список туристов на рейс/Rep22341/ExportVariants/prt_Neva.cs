using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("Нева")]
    public class prt_Neva : IprtClass
    {
        public override void Start(IQueryable<ExportItem> exportItems, bool SplitPartner)
        {
            throw new NotImplementedException();
        }

        public override void Start(IQueryable<ExportItem> exportItems)
        {
            ExcelControl ec = new ExcelControl();
            int lineOut = 1;
            
            DateTime lastFirstDate = DateTime.MinValue;

            var outvalues = exportItems.ToList();
            foreach (var reisItem in outvalues.GroupBy(x=>x.FirstReis))
            {
                ec.SetCellFormat(lineOut);
                ec.SetCellValue(1, lineOut, "на выписку авиабилетов на рейс " + reisItem.Key.Charter.ToString(), false);
                ec.SetCellFormat(lineOut+2);
                ec.SetCellValue(1, lineOut +2, "Список туристов, вылетающих рейсом " + reisItem.Key.Charter.ToString(),false);
                ec.SetCellFormat(lineOut + 3);
                ec.SetCellValue(1, lineOut + 3, "Список туристов, вылетающих рейсом " + reisItem.Key.Charter.ToString() + " по маршруту " + reisItem.Key.Charter.AirportFrom.AP_NAME + " " + reisItem.Key.Charter.AirportTo.AP_NAME, false);
                ec.SetCellFormat(lineOut + 4);
                ec.SetCellValue(1, lineOut + 4, "с " + reisItem.Key.tbl_Dogovor.DG_TURDATE.AddDays(reisItem.Key.DL_DAY.GetValueOrDefault(1) - 1).ToString("dd.MM.yyyy")
                    + " по " + reisItem.Key.tbl_Dogovor.DG_TURDATE.AddDays(reisItem.Key.DL_DAY.GetValueOrDefault(1) - 1).ToString("dd.MM.yyyy"), false);
                lineOut += 6;

                ec.SetCellFormat(lineOut);
                ec.SetCellValue(1,lineOut,"Фамилия", false);
                ec.SetCellValue(2, lineOut, "Имя", false);
                ec.SetCellValue(3,lineOut,"Дата рождения", false);
                ec.SetCellValue(4,lineOut,"Серия паспорта", false);
                ec.SetCellValue(5,lineOut,"Номер паспорта", false);
                ec.SetCellValue(6,lineOut,"Окончание срока действия паспорта", false);
                lineOut++;
                foreach (var personItem in reisItem.Select(x=>x.Turist))
                {
                    ec.SetCellFormat(lineOut);
                    ec.SetCellValue(1, lineOut, personItem.TU_NAMELAT, false);
                    ec.SetCellValue(2, lineOut, personItem.TU_FNAMELAT, false);
                    ec.SetCellValue(3, lineOut, (personItem.TU_BIRTHDAY.HasValue ? personItem.TU_BIRTHDAY.Value.ToString("dd.MM.yyyy") : ""), false);
                    ec.SetCellValue(4, lineOut, personItem.TU_PASPORTTYPE, false);
                    ec.SetCellValue(5, lineOut, personItem.TU_PASPORTNUM, false);
                    ec.SetCellValue(6, lineOut, (personItem.TU_PASPORTDATEEND.HasValue ? personItem.TU_PASPORTDATEEND.Value.ToString("dd.MM.yyyy") : ""), false);
                    lineOut++;
                }
                lineOut += 2;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}
