using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltp_v2.Framework
{
    public static class DeclensionPluralNouns
    {
        public static int IndexOfAnyString(this string instr, string[] str)
        {
            int result = -1;
            foreach (string strItem in str)
            {
                if ((result = instr.IndexOf(strItem)) >= 0)
                    break;
            }
            return result;
        }

        public static int IndexOfAnyString(this string instr, string str)
        {
            return instr.IndexOfAnyString(str.Split(' '));
        }

        public static string CopyRight(this string instr, int count)
        {
            if (count > instr.Length)
                count = instr.Length;

            return instr.Substring(instr.Length - count, count);
        }

        public static string ToUpperFirstChar(this string instr)
        {
            instr = instr.Trim();
            instr = System.Text.RegularExpressions.Regex.Replace(instr, "  ", " ");
            string result = "";
            if (instr.Length > 0)
            {
                foreach (string item in instr.Split(' '))
                {
                    result += item[0].ToString().ToUpper() + item.Substring(1, item.Length - 1) + " ";
                }
            }
            return result.Trim();
        }

        public static string TranslateText(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            string GenitiveCase = "";

            value = System.Text.RegularExpressions.Regex.Replace(value, "[.,;:_]", ". ");
            while (value.Length != value.Replace("  ", " ").Length)
            {
                value = value.Replace("  ", " ").Trim();
            }

            foreach (string item in value.Split(new char[] { ' ' }))
            {
                string modItem = item.Trim();
                if (!System.Text.RegularExpressions.Regex.IsMatch(item, "[а-яА-Я]") || modItem.Length < 3)
                {
                    GenitiveCase += modItem;
                }
                else
                {
                    if (modItem.ToLower().CopyRight(1).IndexOfAny(new char[] { 'ь' }) >= 0)
                    {
                        GenitiveCase += modItem.Substring(0, modItem.Length - 1) + "я";
                    }
                    else if (modItem.ToLower().CopyRight(2).IndexOfAnyString(new string[] { "ый", "ий" }) >= 0)
                    {
                        GenitiveCase += modItem.Substring(0, modItem.Length - 2) + "ого";
                    }
                    else if (
                        modItem.ToLower().CopyRight(1).IndexOfAny(new char[] { 'у', 'а', 'ю', 'я', 'о' }) >= 0
                        || modItem.ToLower().CopyRight(3).IndexOfAnyString(new string[] { "ого" }) >= 0
                        || modItem.ToLower().CopyRight(2).IndexOfAnyString(new string[] { "ия", "их", "ии", "ге" }) >= 0
                        || modItem.ToLower().CopyRight(1).IndexOfAnyString(new string[] { ".", "-" }) >= 0)
                    {
                        GenitiveCase += modItem;
                    }
                    else if (modItem.ToLower().CopyRight(2).IndexOfAnyString(new string[] { "ец" }) >= 0)
                    {
                        GenitiveCase += modItem.Substring(0, modItem.Length - 2) + "ьца";
                    }
                    else
                    {
                        GenitiveCase += modItem + "а";
                    }
                }
                GenitiveCase += " ";
            }

            return (GenitiveCase[0].ToString().ToUpper() + GenitiveCase.Substring(1, GenitiveCase.Length - 1)).Trim();
        }

        public static string TranslateFIO(this string value)
        {
            return value;
            /*
            value = System.Text.RegularExpressions.Regex.Replace(value, "[.,;:_]", ". ");
            while (value.Length != value.Replace("  ", " ").Length)
            {
                value = value.Replace("  ", " ");
            }

            string[] splitName = value.Split(' ');
            string sSurname = (splitName.Length >= 1 ? splitName[0] : "");
            string sName = (splitName.Length >= 2 ? splitName[1] : "");
            string sPatronymic = (splitName.Length >= 3 ? splitName[2] : "");

            bool sex = (sPatronymic == "" || sPatronymic.CopyRight(1) == "ч");
            string GenitiveCase = "";

            sSurname = sSurname.ToLower().Trim();
            sName = sName.ToLower().Trim();
            sPatronymic = sPatronymic.ToLower().Trim();

            if (sSurname.Length > 2 && System.Text.RegularExpressions.Regex.IsMatch(sSurname, "[а-яА-Я]"))
            {
                string rightChar = sSurname.CopyRight(1);
                if (sex)
                {
                    if (rightChar.IndexOfAny(new char[] { 'о', 'и', 'я', 'а' }) >= 0)
                    {
                        GenitiveCase = sSurname;
                    }
                    else if (rightChar.IndexOf('й') >= 0)
                    {
                        GenitiveCase = sSurname.Substring(0, sSurname.Length - 2) + "ого";
                    }
                    else
                    {
                        GenitiveCase = sSurname + "а";
                    }
                }
                else
                {
                    if (rightChar.IndexOfAny(new char[] { 'о', 'и', 'б', 'в', 'г', 'д', 'ж', 'з', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь' }) >= 0)
                    {
                        GenitiveCase = sSurname;
                    }
                    else if (rightChar.IndexOf('я') >= 0)
                    {
                        GenitiveCase = sSurname.Substring(0, sSurname.Length - 2) + "ой";
                    }
                    else if (sSurname.CopyRight(2).IndexOfAnyString("ой") < 0)
                    {
                        GenitiveCase = sSurname.Substring(0, sSurname.Length - 1) + "ой";
                    }
                    else
                    {
                        GenitiveCase = sSurname;
                    }
                }
            }
            else
            {
                GenitiveCase = sSurname;
            }

            GenitiveCase += " ";
            //Имя
            if (sName.Length > 2 && System.Text.RegularExpressions.Regex.IsMatch(sName, "[а-яА-Я]"))
            {
                if (sex)
                {
                    if (sName.CopyRight(1).IndexOfAny(new char[] { 'й', 'ь' }) >= 0)
                        GenitiveCase += sName.Substring(0, sName.Length - 1) + "я";
                    else
                        GenitiveCase += sName + "а";
                }
                else
                {
                    if (sName.CopyRight(1) == "а")
                    {
                        if (sName.CopyRight(2)[0].ToString().IndexOfAny(new Char[] { 'и', 'г', 'ш', 'ж' }) >= 0)
                            GenitiveCase += sName.Substring(0, sName.Length - 1) + "и";
                        else
                            GenitiveCase += sName.Substring(0, sName.Length - 1) + "ы";
                    }
                    else if (sName.CopyRight(1) == "я")
                    {
                        GenitiveCase += sName.Substring(0, sName.Length - 1) + "и";
                    }
                    else if (sName.CopyRight(1) == "ь")
                    {
                        GenitiveCase += sName.Substring(0, sName.Length - 1) + "и";
                    }
                    else
                    {
                        GenitiveCase += sName;
                    }
                }
            }
            else
            {
                GenitiveCase += sName;
            }
            GenitiveCase += " ";
            // Отчество
            if (sPatronymic.Length > 2 && System.Text.RegularExpressions.Regex.IsMatch(sPatronymic, "[а-яА-Я]"))
            {
                if (sex)
                {
                    GenitiveCase += sPatronymic + "а";
                }
                else
                {
                    GenitiveCase += sPatronymic.Substring(0, sPatronymic.Length - 1) + "ы";
                }
            }
            else
            {
                GenitiveCase += sPatronymic;
            }

            return GenitiveCase.ToUpperFirstChar();
             */
        }
    }
}
