using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Arhivarius.ObjectModel;

namespace Arhivarius.Report
{
    public class Reporting : ArhiveDocument
    {
        public Reporting(ArhiveDocument ad)
        {
            this.ARH_UserName = ad.ARH_UserName;
            this.ARH_Number = ad.ARH_Number;
            this.Chield.Assign(ad.Chield.OrderBy(x => x.ARH_Number));

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE39Extended;
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            b.RotateFlipType = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            b.IncludeLabel = true;
            System.Drawing.Image image = b.Encode(type, this.ARH_Number, System.Drawing.Color.Black, System.Drawing.Color.White, 200, 40);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            BarCode = ms.ToArray();
        }

        public byte[] BarCode { get; private set; }
    }
}
