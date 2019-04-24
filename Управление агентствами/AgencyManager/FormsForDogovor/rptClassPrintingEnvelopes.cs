using System;
using AgencyManager.ObjectModel;

namespace AgencyManager.FormsForDogovor
{
    public class rptClassPrintingEnvelopes
    {
        public rptClassPrintingEnvelopes(LTP_PrtDogPack value)
        {
            this.Index = value.LTP_PrtDog.tbl_Partners.PR_POSTINDEX;
            this.City = value.LTP_PrtDog.tbl_Partners.PR_CITY;
            this.Address = value.LTP_PrtDog.tbl_Partners.PR_ADRESS;
            this.CompanyName = value.LTP_PrtDog.tbl_Partners.PR_FULLNAME;

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE39Extended;
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            b.RotateFlipType = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            b.IncludeLabel = true;
            b.LabelFont = new System.Drawing.Font("Arial", 9);
            System.Drawing.Image image = b.Encode(type, value.LTPP_Number.ToString(), System.Drawing.Color.Black, System.Drawing.Color.White, 240, 30);
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                b.SaveImage(ms, BarcodeLib.SaveTypes.JPG);
                BarCode = ms.GetBuffer();
            }
        }

        public byte[] BarCode { get; private set; }
        public string Index { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string CompanyName { get; private set; }
    }

    public class rptDogovorList
    {
        public string DogovorNumber { get; private set; }
        public string DogovorType { get; private set; }

        public rptDogovorList(LTP_PrtDog value)
        {
            DogovorNumber = value.LTPD_DogNum;
            DogovorType = value.DogovorTypeName;
        }
    }
}
