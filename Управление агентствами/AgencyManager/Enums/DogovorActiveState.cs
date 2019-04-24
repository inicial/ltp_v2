using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencyManager
{
    /// <summary>
    /// Статус активации договора
    /// </summary>
    public enum DogovorActiveState
    {
        NotActive = -1,
        TmpActive = 0,
        Active = 1
    }

    public static class DASExtensionMethods
    {
        public static string ToNormalStr(this DogovorActiveState sender)
        {
            if (sender == DogovorActiveState.NotActive)
            {
                return "Неактивирован";
            }
            else if (sender == DogovorActiveState.Active)
            {
                return "Активирован";
            }
            else if (sender == DogovorActiveState.TmpActive)
            {
                return "Временно активен";
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
