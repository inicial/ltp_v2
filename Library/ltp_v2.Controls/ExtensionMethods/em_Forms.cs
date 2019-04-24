using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltp_v2.Controls
{
    public static class em_Forms
    {
        public static void ClearFormFromMemory(this System.Windows.Forms.Form sender)
        {
            sender.Dispose();
            GC.SuppressFinalize(sender);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
