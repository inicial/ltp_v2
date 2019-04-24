using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencyManager.FormsForPartners
{
    public class UnicalCodeBoss
    {
        public static string Generate
        {
            get
            {
                return new Random().Next(10000000, 99999999).ToString();
            }
        }
    }
}
