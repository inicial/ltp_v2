using System;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using rep25991.ExtendedMethods.AutoWrappingText;

namespace rep25991.ExtendedMethods
{
    public static class LogoCreater
    {
        public static readonly Size Logosize = new Size(253, 102); //60x20 = 277x76 4,6x3,8  //55x27 = 253 x 102
        public static readonly Size Resolution = new Size(96, 96);

        public static Stream CreateMemoryStram(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0)
                return null;

            MemoryStream stream = new MemoryStream();
            if (buffer != null && buffer.Length > 0)
                stream.Write(buffer, 0, buffer.Length);

            return stream;
        }

        public static Bitmap CreateLogo(Stream streamLogo, Size logoSize, string partnerName)
        {
            Font sourceFont = new Font("Arial", 12f, FontStyle.Bold);

            AutoWrapping awText = new AutoWrapping();
            awText.Font = sourceFont;

            Bitmap sourceBMP;
            Bitmap outputBMP = new Bitmap(Logosize.Width, Logosize.Height);
            outputBMP.SetResolution((float)Resolution.Width, (float)Resolution.Height);

            using (Graphics gxOutput = Graphics.FromImage(outputBMP))
            {
                gxOutput.Clear(Color.White);
                if (streamLogo != null && streamLogo.Length > 0)
                {
                    sourceBMP = new Bitmap(streamLogo);
                }
                else
                {
                    SizeF sizePartnerName = awText.getSizeString(partnerName).Size_PX;
                    if (sizePartnerName.Width <= 0) sizePartnerName.Width = 1;
                    if (sizePartnerName.Height <= 0) sizePartnerName.Height = 1;
                    sourceBMP = new Bitmap((int)sizePartnerName.Width, (int)sizePartnerName.Height);
                    using (Graphics gxPartnerName = Graphics.FromImage(sourceBMP))
                    {
                        gxPartnerName.SmoothingMode = SmoothingMode.AntiAlias;
                        gxPartnerName.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                        gxPartnerName.DrawString(partnerName, sourceFont, new SolidBrush(Color.Black), new PointF(0f, 0f));
                    }
                }

                float ScaleValue = ((float)outputBMP.Width) / ((float)sourceBMP.Width);
                if (sourceBMP.Height * ScaleValue > outputBMP.Height)
                {
                    ScaleValue = outputBMP.Height / ((float)sourceBMP.Height);
                }

                gxOutput.DrawImage(
                    sourceBMP,
                    new RectangleF(
                        ((float)outputBMP.Width / 2f) - (sourceBMP.Width * ScaleValue / 2f),
                        ((float)outputBMP.Height / 2f) - (sourceBMP.Height * ScaleValue / 2f),
                        sourceBMP.Width * ScaleValue,
                        sourceBMP.Height * ScaleValue),
                        new RectangleF(0f, 0f, (float)sourceBMP.Width, (float)sourceBMP.Height), GraphicsUnit.Pixel);
            }
            return outputBMP;
        }

        public static Bitmap CreateLogo(byte[] buffer, Size logoSize, string partnerName)
        {
            return CreateLogo(CreateMemoryStram(buffer), logoSize, partnerName);
        }

        public static Bitmap CreateLogo(byte[] buffer, string partnerName)
        {
            return CreateLogo(CreateMemoryStram(buffer), partnerName);
        }

        public static Bitmap CreateLogo(Stream streamLogo, string partnerName)
        {
            return CreateLogo(streamLogo, Logosize, partnerName);
        }
    }
}
