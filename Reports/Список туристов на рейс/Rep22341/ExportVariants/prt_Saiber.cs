using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rep22341.ExportVariants
{
    [DisplayName("Сейбр")]
    public class prt_Saiber : IprtClass
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
            int lastFirstCode = -1;
            int lastBackCode = -1;
            DateTime lastFirstDate = DateTime.MinValue;
            DateTime lastBackDate = DateTime.MinValue;

            var outvalues = exportItems.ToList();
            foreach (var q in outvalues
                .OrderBy(x => x.FirstReis.Charter.ToString())
                .ThenByDescending(x => (x.BackReis != null ? x.BackReis.BegServ : DateTime.MaxValue))
                .ThenBy(x => (x.BackReis != null ? x.BackReis.AirService.AS_CODE : ""))
                .ThenBy(x => x.Turist.TU_BIRTHDAY.GetValueOrDefault(DateTime.MinValue).Date)
                .ThenBy(x => x.NameLat)
                .ThenBy(x => x.FNameLat))
            {
                if (lastFirstDate != q.FirstReis.BegServ.Date ||
                    lastFirstCode != q.FirstReis.DL_CODE ||
                    q.BackReis != null && lastBackDate != q.BackReis.BegServ.Date ||
                    q.BackReis != null && lastBackCode != q.BackReis.DL_CODE)
                {
                    lineOut++;
                    lastFirstDate = q.FirstReis.BegServ.Date;
                    lastFirstCode = q.FirstReis.DL_CODE;
                    if (q.BackReis != null)
                    {
                        lastBackDate = q.BackReis.BegServ.Date;
                        lastBackCode = q.BackReis.DL_CODE;
                    }
                    else
                    {
                        lastBackDate = DateTime.MinValue;
                        lastBackCode = -1;
                    }
                    ec.SetCellFormat(lineOut);
                    ec.SetCellValue(1, lineOut, q.FirstReis.BegServ.ToString("dd.MM.yyyy")
                        + " " + q.FirstReis.Charter.ToString()
                        + " - " + q.FirstReis.Charter.CH_PORTCODEFROM);
                    lineOut++;
                    ec.SetCellFormat(lineOut);
                    if (q.BackReis != null && q.BackReis.BegServ != null)
                    {
                        ec.SetCellValue(1, lineOut, q.BackReis.BegServ.ToString("dd.MM.yyyy")
                            + " " + q.BackReis.Charter.ToString()
                            + " - " + q.BackReis.Charter.CH_PORTCODEFROM);
                    }
                    lineOut += 2;
                    KeyInRais = 1;
                }

                ec.SetCellFormat(lineOut);
                if (KeyInRais > 9) KeyInRais = 1;

                ec.SetCellValue(1, lineOut, KeyInRais.ToString() + ".1");
                if (q.Turist.TU_BIRTHDAY.HasValue && ltp_v2.Framework.SqlConnection.ServerDateTime.Year - q.Turist.TU_BIRTHDAY.Value.Year < 12)
                {
                    ec.SetCellValue(2, lineOut, 
                        "-" + q.Turist.TU_NAMELAT 
                        + "/" + q.Turist.TU_FNAMELAT 
                        + "*DOB" + q.Turist.TU_BIRTHDAY.Value.ToString("dd MMM yy"));
                }
                else
                {
                    ec.SetCellValue(2, lineOut,
                        "-" + q.Turist.TU_NAMELAT
                        + "/" + q.Turist.TU_FNAMELAT
                        + " " + q.Turist.SexFull);
                }
                if (q.Turist.TU_BIRTHDAY.HasValue)
                {
                    ec.SetCellValue(3, lineOut, q.Turist.TU_BIRTHDAY.Value.ToString());
                }

                ec.SetCellValue(4, lineOut, "3OSI SU PSPT" + q.Turist.TU_PASPORTNUM + "-" + KeyInRais.ToString() + ".1");

                if (q.Turist.TU_BIRTHDAY.HasValue && ltp_v2.Framework.SqlConnection.ServerDateTime.Year - q.Turist.TU_BIRTHDAY.Value.Year < 12)
                {
                    ec.SetCellValue(5, lineOut, "3OSI SU 1CHD DOB " + q.Turist.TU_BIRTHDAY.Value.ToString("dd MMM yy") + "-" + KeyInRais.ToString() + ".1");
                }

                ec.SetCellValue(6, lineOut, ("3DOCS/P/RU/" +
                          q.Turist.TU_PASPORTNUM + "/RU/" +
                          q.Turist.TU_BIRTHDAY.Value.ToString("dd MMM yy") + "/" +
                          q.Turist.SexShort + "/" +
                          q.Turist.TU_NAMELAT + "/" +
                          q.Turist.TU_FNAMELAT + "-" +
                          KeyInRais.ToString() + ".1"));

                lineOut++;
                KeyInRais++;
            }
            ec.End();
            outvalues.Clear();
            outvalues = null;
        }
    }
}
