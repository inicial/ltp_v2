using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep25991.References
{
    public struct structMonthName
    {
        public string ShortName;
        public string LongName;
        public structMonthName(string ShortName, string LongName)
        {
            this.ShortName = ShortName;
            this.LongName = LongName;
        }
    }
}