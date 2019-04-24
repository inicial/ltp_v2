using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace rep25991.ExtendedMethods.AutoWrappingText
{
    public class AutoWrapping
    {
        private string[] _convert_WW_to_Array = new string[0];
        private int _count_word_wrapping = 0;
        private string _text;
        private string _text_from_word_wrapping;

        public System.Drawing.Font Font;
        /// <summary>
        /// Максимально допустимая длина текста
        /// </summary>
        public float MaxWidth_SM;

        public sizeAllsF getSizeString(string inStr)
        {
            Bitmap image = new Bitmap(1, 1);
            sizeAllsF sf = new sizeAllsF();
            Graphics graphics = Graphics.FromImage(image);
            sf.Size_PX.Width = graphics.MeasureString(inStr, this.Font).Width;
            sf.Size_PX.Height = graphics.MeasureString(inStr, this.Font).Height;
            sf.Resolution.Vertical = image.VerticalResolution;
            sf.Resolution.Horizontal = image.HorizontalResolution;
            return sf;
        }

        /// <summary>
        /// Текст после разбиения на строки по максимально допустимой длине
        /// </summary>
        public string[] Convert_WW_to_Array
        {
            get
            {
                if (this._convert_WW_to_Array.Length <= 0)
                {
                    this._convert_WW_to_Array = new string[0];
                    int num = 0;
                    for (int i = 0; i < this.Text_from_word_wrapping.Length; i++)
                    {
                        if ((this.Text_from_word_wrapping.Substring(i, 1) == "\r") || (this.Text_from_word_wrapping.Substring(i, 1) == "\x00b6"))
                        {
                            num++;
                        }
                        else if (this.Text_from_word_wrapping.Substring(i, 1) != "\n")
                        {
                            string[] strArray2;
                            IntPtr ptr;
                            if (this._convert_WW_to_Array.Length < (num + 1))
                            {
                                Array.Resize<string>(ref this._convert_WW_to_Array, num + 1);
                            }
                            (strArray2 = this._convert_WW_to_Array)[(int)(ptr = (IntPtr)num)] = strArray2[(int)ptr] + this.Text_from_word_wrapping.Substring(i, 1);
                        }
                    }
                }
                return this._convert_WW_to_Array;
            }
        }

        /// <summary>
        /// Кол-во получающихся строк подходящих под длинну
        /// </summary>
        public int Count_word_wrapping
        {
            get
            {
                if (this._count_word_wrapping <= 1)
                {
                    this._count_word_wrapping = 0;
                    if (this.Text_from_word_wrapping.Length > 0)
                    {
                        this._count_word_wrapping = 1;
                    }
                    for (int i = 0; i < this.Text_from_word_wrapping.Length; i++)
                    {
                        if (this.Text_from_word_wrapping.Substring(i, 1) == "\r")
                        {
                            this._count_word_wrapping++;
                        }
                        if (this.Text_from_word_wrapping.Substring(i, 1) == "\x00b6")
                        {
                            this._count_word_wrapping++;
                        }
                    }
                }
                return this._count_word_wrapping;
            }
        }

        /// <summary>
        /// Проверяемый текст
        /// </summary>
        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
                this._text_from_word_wrapping = "";
                this._count_word_wrapping = 0;
                this._convert_WW_to_Array = new string[0];
            }
        }

        public string Text_from_word_wrapping
        {
            get
            {
                if (this._text_from_word_wrapping == "")
                {
                    bool flag = true;
                    string str = this.Text.Replace("\t", " ").Replace("\r", " ").Replace("\n", " ").Replace("  ", " ").Trim();
                    int length = 0;
                    int startIndex = 0;
                    int num3 = 0;
                    while (flag)
                    {
                        num3 = 0x7fffffff;
                        if ((length + 3) >= str.Length)
                        {
                            this._text_from_word_wrapping = str;
                            break;
                        }
                        if (num3 > str.IndexOf(" ", (int)(length + 1)))
                        {
                            num3 = (str.IndexOf(" ", (int)(length + 1)) >= 0) ? str.IndexOf(" ", (int)(length + 1)) : num3;
                        }
                        if (num3 > str.IndexOf(",", (int)(length + 1)))
                        {
                            num3 = (str.IndexOf(",", (int)(length + 1)) >= 0) ? str.IndexOf(",", (int)(length + 1)) : num3;
                        }
                        if (num3 > str.IndexOf(".", (int)(length + 1)))
                        {
                            num3 = (str.IndexOf(".", (int)(length + 1)) >= 0) ? str.IndexOf(".", (int)(length + 1)) : num3;
                        }
                        if (num3 > str.IndexOf("/", (int)(length + 1)))
                        {
                            num3 = (str.IndexOf("/", (int)(length + 1)) >= 0) ? str.IndexOf("/", (int)(length + 1)) : num3;
                        }
                        if (num3 == 0x7fffffff)
                        {
                            num3 = str.Length;
                        }
                        if (this.MaxWidth_SM < this.getSizeString(str.Substring(startIndex, (num3 - startIndex) - 1)).Size_SM.Width && length > 0)
                        {
                            str = str.Substring(0, length) + "\r\n" + str.Substring(length, str.Length - length);
                            startIndex = length + 2;
                        }
                        length = num3;
                        if (num3 <= startIndex)
                        {
                            this._text_from_word_wrapping = str;
                            break;
                        }
                    }
                }
                return this._text_from_word_wrapping;
            }
        }

        public class sizeAllsF
        {
            public resolution Resolution = new resolution(96f, 96f);
            public SizeF Size_PX;

            public SizeF Size_SM
            {
                get
                {
                    return new SizeF((float)((this.Size_PX.Width / this.Resolution.Horizontal) * 2.541176), (float)((this.Size_PX.Height / this.Resolution.Vertical) * 2.541176));
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct resolution
            {
                public float Vertical;
                public float Horizontal;
                public resolution(float vertical, float horizontal)
                {
                    this.Vertical = vertical;
                    this.Horizontal = horizontal;
                }
            }
        }

        public static string[] WordWrapBySize(string value, float[] sizeArray, int startFromLine)
        {
            List<string> resultList = new List<string>();
            int lineOut = startFromLine;

            AutoWrapping StringData = new AutoWrapping();
            StringData.Font = new Font("Arial", 10f);

            value = value.Replace("\r", "");

            foreach (string lineText in value.Split('\n'))
            {
                string searchText = lineText.RemoveSpace();
                if (lineText.RemoveSpace() == "")
                {
                    resultList.Add("");
                    lineOut++;
                }
                while (searchText.Length > 0)
                {
                    lineOut = lineOut % sizeArray.Length;

                    StringData.MaxWidth_SM = sizeArray[lineOut];
                    StringData.Text = searchText;
                    if (StringData.Convert_WW_to_Array.Length > 0)
                    {
                        resultList.Add(StringData.Convert_WW_to_Array[0]);
                        searchText = searchText.Substring(StringData.Convert_WW_to_Array[0].Length).RemoveSpace();
                        lineOut++;
                    }
                }
            }
            string[] result = resultList.ToArray();
            resultList.Clear();
            resultList = null;
            return result;
        }

        public static string[] WordWrapBySize(string value, float[] sizeArray)
        {
            return WordWrapBySize(value, sizeArray, 0);
        }
    }
}