using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rep22341.ExportVariants
{
    public static class ExtendedMethods
    {
        public static string ReplaceAnalogChar(this string value)
        {
            var latCap = new char[] {'E','T','Y','O','P','A','H','K','X','C','B','M'};
            var lat = new char[] {'e','t','y','o','p','a','h','k','x','c','b','m'};
            var rusCap = new char[] {'Е','Т','У','О','Р','А','Н','К','Х','С','В','М'};
            var rus = new char[] {'е','т','у','о','р','а','н','к','х','с','в','м'};
            //ETYOPAHKXCBM
            for (int i = 0; i < latCap.Length; i++)
            {
                value = value.Replace(rusCap[i], latCap[i]);
                value = value.Replace(rus[i], lat[i]);
            }
            return value;
        }
    }
}
