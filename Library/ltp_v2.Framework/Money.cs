using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltp_v2.Framework
{
    public class Money
    {
        private struct s_POWER
        {
            public int sex;
            public string one;
            public string four;
            public string many;
            public s_POWER(int sex, string one, string four, string many)
            {
                this.sex = sex;
                this.one = one;
                this.four = four;
                this.many = many;
            }
        }

        private struct s_UNIT
        {
            public string[] one;
            public string two;
            public string dec;
            public string hun;

            public s_UNIT(string[] one, string two, string dec, string hun)
            {
                this.one = one;
                this.two = two;
                this.dec = dec;
                this.hun = hun;
            }
        }

        private static s_POWER[] a_power = new s_POWER[4] { 
            new s_POWER(0,null,null,null),
            new s_POWER(1, "тысяча ", "тысячи ", "тысяч "),
            new s_POWER(2, "миллион ", "миллиона ", "миллионов "),
            new s_POWER(3, "миллиард ", "миллиарда ","миллиардов ")};

        private static s_UNIT[] digit = new s_UNIT[10] {
              new s_UNIT(new string[2]{""       ,""   }    ,"десять "      ,""            ,""          ),
              new s_UNIT(new string[2]{"один "  ,"одна "}  ,"одиннадцать " ,"десять "     ,"сто "      ),
              new s_UNIT(new string[2]{"два "   ,"две "}   ,"двенадцать "  ,"двадцать "   ,"двести "   ),
              new s_UNIT(new string[2]{"три "   ,"три "}   ,"тринадцать "  ,"тридцать "   ,"триста "   ),
              new s_UNIT(new string[2]{"четыре ","четыре "},"четырнадцать ","сорок "      ,"четыреста "),
              new s_UNIT(new string[2]{"пять "  ,"пять " } ,"пятнадцать "  ,"пятьдесят "  ,"пятьсот "  ),
              new s_UNIT(new string[2]{"шесть " ,"шесть " },"шестнадцать " ,"шестьдесят " ,"шестьсот "),
              new s_UNIT(new string[2]{"семь "  ,"семь "  },"семнадцать "  ,"семьдесят "  ,"семьсот "  ),
              new s_UNIT(new string[2]{"восемь ","восемь "},"восемнадцать ","восемьдесят ","восемьсот "),
              new s_UNIT(new string[2]{"девять ","девять "},"девятнадцать ","девяносто "  ,"девятьсот ")};

        public static string dec2string(double summ, int sex, string BigRate, string LowRate)
        {
            int mny;
            string str, result = "";
            Int64 devisor = 1;

            a_power[0].sex = sex;

            if (summ == 0) return "ноль " + BigRate + " 00 " + LowRate;
            if (summ < 0) { result = "минус "; summ = -summ; }

            int DG_Power = 6;
            for (int i = 0; i < DG_Power; i++)
                devisor *= 1000;

            for (int i = DG_Power - 1; i >= 0; i--)
            {
                devisor /= 1000;
                mny = (int)(summ / devisor);
                summ %= devisor;
                str = "";
                if (mny == 0)
                {
                    if (i > 0) continue;
                    str += a_power[i].one;
                }
                else
                {
                    if (mny >= 100) { str += digit[mny / 100].hun; mny %= 100; }
                    if (mny >= 20) { str += digit[mny / 10].dec; mny %= 10; }
                    if (mny >= 10) { str += digit[mny - 10].two; }
                    else if (mny >= 1)
                    {
                        str += digit[mny].one[a_power[i].sex];
                    }
                    switch (mny)
                    {
                        case 1: str += a_power[i].one; break;
                        case 2: str += a_power[i].four; break;
                        case 3: str += a_power[i].four; break;
                        case 4: str += a_power[i].four; break;
                        default: str += a_power[i].many; break;
                    }

                }
                result += str;
            }

            string lowSumm = Math.Round(summ, 2).ToString();
            if (lowSumm.IndexOf(",") == -1)
                lowSumm += ",00";
            if (lowSumm.Length < 4) lowSumm += "0";

            result = result + " " + BigRate + " " + lowSumm.Substring(2, 2) + " " + LowRate;
            result = result.Replace("  ", " ");
            result = System.Text.RegularExpressions.Regex.Replace(result, "^[a-zа-я]", result.Substring(0, 1).ToUpper());
            return result;
        }
    }
}