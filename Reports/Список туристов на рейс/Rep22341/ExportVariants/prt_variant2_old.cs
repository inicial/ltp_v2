using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("Вариант2 OLD")]
    [DefaultValue(VariantsEXType.SplitPartner)]
    public class prt_variant2_old : IprtClass
    {
        public override void Start(IQueryable<ExportItem> exportItems)
        {
            throw new NotImplementedException();
        }

        public override void Start(IQueryable<ExportItem> exportItems, bool SplitPartner)
        {
            ExcelControl ec = new ExcelControl();
            int lineOut = 1;
            
            int lastFirstCode = -1;
            int lastFirstCode1 = -1;
            int lastFirstPRKey = -1;
            DateTime lastFirstDate = DateTime.MinValue;
            
            int lastBackCode = -1;
            int lastBackCode1 = -1;
            DateTime lastBackDate = DateTime.MinValue;

            int KeyInRais = 1;

            var outvalues = exportItems.ToList();
            foreach (var q in outvalues
                .OrderBy(x => x.FirstReis.Charter.ToString())
                .ThenByDescending(x => (x.FirstReis != null ? x.FirstReis.BegServ : DateTime.MaxValue))
                .ThenByDescending(x => (x.BackReis != null ? x.BackReis.BegServ : DateTime.MaxValue))
                .ThenBy(x=>(x.FirstReis != null ? x.FirstReis.Charter.CH_KEY : 0))
                .ThenBy(x => (x.BackReis != null ? x.BackReis.Charter.CH_KEY : 0))
                .ThenBy(x => (x.FirstReis != null ? x.FirstReis.AirService.AS_CODE : ""))
                .ThenBy(x=> (x.BackReis != null ? x.BackReis.AirService.AS_CODE : ""))
                .ThenBy(x => x.NameLat)
                .ThenBy(x => x.FNameLat))
            {
                ec.SetCellFormat(lineOut);
                if (
                    lastFirstDate.Date != q.FirstReis.BegServ.Date ||
                    lastFirstCode != q.FirstReis.DL_CODE ||
                    lastFirstCode1 != q.FirstReis.DL_SUBCODE1.GetValueOrDefault(0) ||
                    lastFirstPRKey != q.FirstReis.DL_PARTNERKEY && SplitPartner ||
                    q.BackReis != null && lastBackCode != q.BackReis.DL_CODE ||
                    q.BackReis != null && lastBackCode1 != q.BackReis.DL_SUBCODE1.GetValueOrDefault(0) ||
                    q.BackReis != null && lastBackDate.Date != q.BackReis.BegServ.Date
                    )
                {
                    lineOut++;
                    lastFirstCode = q.FirstReis.DL_CODE;
                    lastFirstCode1 = q.FirstReis.DL_SUBCODE1.GetValueOrDefault(0);
                    lastFirstDate = q.FirstReis.BegServ.Date;
                    lastFirstPRKey = q.FirstReis.DL_PARTNERKEY;
                    if (q.BackReis != null)
                    {
                        lastBackCode = q.BackReis.DL_CODE;
                        lastBackCode1 = q.BackReis.DL_SUBCODE1.GetValueOrDefault(0);
                        lastBackDate = q.BackReis.BegServ.Date;
                    }

                    ec.SetCellFormat(lineOut);
                    ec.SetCellValue(1, lineOut,
                        q.FirstReis.BegServ.ToString("dd.MM.yyyy")
                        + " " + q.FirstReis.Charter.ToString() 
                        + " - " + q.FirstReis.Charter.CH_PORTCODEFROM
                        + " - " + q.FirstReis.AirService.AS_CODE, false);
                    
                    lineOut++;
                    ec.SetCellFormat(lineOut);
                    if (q.BackReis != null)
                    {
                        ec.SetCellValue(1, lineOut,
                            q.BackReis.BegServ.ToString("dd.MM.yyyy")
                            + " " + q.BackReis.Charter.ToString()
                            + " - " + q.BackReis.Charter.CH_PORTCODEFROM
                            + " - " + q.BackReis.AirService.AS_CODE, false);
                    }

                    lineOut++;
                    ec.SetCellFormat(lineOut);
                    ec.SetCellValue(1, lineOut, "Class: " + q.FirstReis.AirService.AS_NAMERUS, false);

                    lineOut++;
                    ec.SetCellFormat(lineOut);
                    ec.SetCellValue(1, lineOut, "Партнер: " + q.FirstReis.tbl_Partner.PR_NAME, false);

                    lineOut++;
                }
                
                ec.SetCellFormat(lineOut);
                ec.SetCellValue(1, lineOut, KeyInRais.ToString());
                ec.SetCellValue(2, lineOut, q.NameLat + " " + q.FNameLat + " / " + q.Turist.SexFull);
                if (q.Birthday.HasValue)
                    ec.SetCellValue(3, lineOut, q.Birthday.Value.ToString("dd.MM.yyyy"));
                ec.SetCellValue(4, lineOut, q.Turist.TU_PASPORTTYPE + "N" + q.Turist.TU_PASPORTNUM);
                ec.SetCellValue(5, lineOut, "RU");
                lineOut++;
                KeyInRais++;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}
