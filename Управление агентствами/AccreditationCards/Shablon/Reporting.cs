using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AccreditationCards.Shablon
{
    public class Reporting : LTP_AccreditationCard
    {
        public byte[] BarCode { get; private set; }
        public string ParnterName { get; private set; }
        public string BossJob { get; private set; }
        public string BossName { get; private set; }

        public Reporting(LTP_AccreditationCard card)
        {
            string[] CompanyType = new string[] {"ООО", "ЗАО", "ОАО", "ИП"};
            this.LTPA_CardNum = card.LTPA_CardNum;
            this.LTPA_CRDate = card.LTPA_CRDate;
            this.LTPA_CardType = card.LTPA_CardType;

            this.ParnterName = card.tbl_Partner_UsingCard.PR_FULLNAME;
            foreach (string ct in CompanyType)
            {
                if (Regex.IsMatch(this.ParnterName, @"\s" + ct + "$", RegexOptions.IgnoreCase))
                {
                    this.ParnterName = ct + " \"" + Regex.Replace(this.ParnterName, @"\s" + ct + "$", "", RegexOptions.IgnoreCase) + "\"";
                    break;
                }
            }

            this.BossJob = card.tbl_Partner_UsingCard.PR_BOSS;
            string[] Boss = card.tbl_Partner_UsingCard.PR_BOSSNAME.Split(' ');
            if (Boss.Length > 0)
                this.BossName = Boss[0];
            if (Boss.Length > 1)
                this.BossName += "\r\n" + string.Join(" ", Boss, 1, Boss.Length - 1);
          
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE39Extended;
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            b.RotateFlipType = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            b.IncludeLabel = true;
            System.Drawing.Image image = b.Encode(type, 
                this.LTPA_CardNum, 
                System.Drawing.Color.Black, 
                System.Drawing.Color.White, 
                180, 40);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            BarCode = ms.ToArray();
        }
    }
}
