using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep25991
{
    public class structIndexedService
    {
        public int Key;
        public int SVKey;
        public int Index;

        public structIndexedService(TurService value)
        {
            Key = value.TS_Key;
            SVKey = value.TS_SVKEY;
            var services = value.tbl_TurList.TurServices.Where(xTS =>
                xTS.TS_SVKEY == value.TS_SVKEY
                && (
                        xTS.TS_DAY.GetValueOrDefault(0) < value.TS_DAY.GetValueOrDefault(0)
                        || xTS.TS_DAY.GetValueOrDefault(0) == value.TS_DAY.GetValueOrDefault(0)
                        && xTS.TS_Key < value.TS_Key)
                );
            Index = services.Count() + 1;
        }

        public structIndexedService(tbl_DogovorList value)
        {
            Key = value.DL_KEY;
            SVKey = value.DL_SVKEY;
            var services = value.tbl_Dogovor.tbl_DogovorLists.Where(xDL =>
                    xDL.DL_SVKEY == value.DL_SVKEY
                    && (
                        xDL.DL_DAY.GetValueOrDefault(0) < value.DL_DAY.GetValueOrDefault(0)
                        || xDL.DL_DAY.GetValueOrDefault(0) == value.DL_DAY.GetValueOrDefault(0)
                        && xDL.DL_KEY < value.DL_KEY)
                    );
            
            // Если услуга дублирующая
            if (value.DL_SVKEY == 3)
            {
                services = services.Where(x => 
                    x.DL_DAY.GetValueOrDefault(0) != value.DL_DAY.GetValueOrDefault(0) 
                    || x.DL_DAY.GetValueOrDefault(0) == value.DL_DAY.GetValueOrDefault(0) 
                    && x.DL_CODE != value.DL_CODE 
                    && x.DL_SUBCODE1 != value.DL_SUBCODE1);
            }
            else
            {
                services = services.Where(x => 
                    x.DL_DAY.GetValueOrDefault(0) != value.DL_DAY.GetValueOrDefault(0) 
                    || x.DL_DAY.GetValueOrDefault(0) == value.DL_DAY.GetValueOrDefault(0) 
                    && x.DL_CODE != value.DL_CODE);
            }

            // и если услуга не содержит тех-же туристов
            services = services.Where(x =>
                x.DL_DAY.GetValueOrDefault(0) != value.DL_DAY.GetValueOrDefault(0)
                || x.DL_CODE != value.DL_CODE
                || x.DL_DAY.GetValueOrDefault(0) == value.DL_DAY.GetValueOrDefault(0) 
                && x.TuristServices.Select(xTS => 
                    new { xTS.TU_TUKEY }
                ).Intersect(
                    value.TuristServices.Select(xVTS => new { xVTS.TU_TUKEY })
                ).Count() == 0);
            Index =  services.Count() + 1;
        }
    }
}
