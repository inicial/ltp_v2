using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace rep25991.ExtendedMethods.AutoWrappingText
{
    public static class PersonAW
    {
        public static string[] WordwrapToArray(string value)
        {
            return AutoWrapping.WordWrapBySize(value, SizeLines.SizePersonLines);
        }
        
        public static string Wordwrap(string value)
        {
            return string.Join("\r\n", WordwrapToArray(value));
        }

        public static string Wordwrap(LT_V_Person person)
        {
            return Wordwrap(person.VT_Name);
        }
    }
}
