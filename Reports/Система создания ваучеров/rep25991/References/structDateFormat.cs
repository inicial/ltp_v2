using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace rep25991.References
{
    //[StructLayout(LayoutKind.Sequential)]
    public class structDateFormat
    {
        public string FormatDate;
        public structDateFormat(string FormatDate)
        {
            this.FormatDate = FormatDate;
        }

        public override string ToString()
        {
            return DateTime.Now.ConvertToMyFormat(this);
        }
    }
}
