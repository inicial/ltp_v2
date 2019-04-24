using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep25991.References
{
    public class VariantsSex
    {
        public  static string Convert(int? value)
        {
            switch (value.GetValueOrDefault(0))
            {
                case 1:
                    return "MRS";
                case 2:
                    return "CHD";
                case 3:
                    return "INF";
                default:
                    return "MR";
            }
        }
    }
}
