using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace rep25991.ExtendedMethods.AutoWrappingText
{
    public static class PartnerAW
    {
        public static string[] WordwrapToArray(string value)
        {
            return AutoWrapping.WordWrapBySize(value, SizeLines.SizePartnerLines);
        }

        public static string Wordwrap(string value)
        {
            return string.Join("\r\n", WordwrapToArray(value));
        }
    }
}
