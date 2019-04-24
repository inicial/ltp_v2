using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace rep25991.ExtendedMethods.AutoWrappingText
{
    public static class ServiceAW
    {
        public static string[] WordwrapToArray(string value)
        {
            return AutoWrapping.WordWrapBySize(value, SizeLines.SizeServiceLines, 0);
        }

        public static string[] WordwrapToArray(LT_V_Service service)
        {
            string value = service.VS_Name;
            var countLines = service.LT_V_Voucher.LT_V_Services.Where(x => x.VS_PrintLine < service.VS_PrintLine).Select(x => x.VS_Name.Replace("\r\n", "\n").Split('\n').Length).Sum(x => x);
            return AutoWrapping.WordWrapBySize(value, SizeLines.SizePersonLines, countLines);
        }

        public static string Wordwrap(LT_V_Service service)
        {
            return string.Join("\r\n", WordwrapToArray(service));
        }
    }
}
