namespace Rep22341
{
    using System;
    using System.Linq;

    partial class tbl_Turist
    {
        public string SexFull
        {
            get
            {
                switch (this.TU_SEX)
                {
                    case 1: return "MRS";
                    case 2: return "CHD";
                    case 3: return "INF";
                    default: return "MR";
                }
            }
        }

        public string SexShort
        {
            get
            {
                switch (this.TU_SEX)
                {
                    case 1: return "F";
                    case 2: return "C";
                    case 3: return "I";
                    default: return "M";
                }
            }
        }
    }

    partial class Charter
    {
        public override string ToString()
        {
            return this.CH_AIRLINECODE.Trim() + CH_FLIGHT.Trim();
        }
    }

    partial class tbl_DogovorList
    {
        /// <summary>
        /// Дата рейса
        /// </summary>
        public DateTime BegServ
        {
            get { return this.DL_TURDATE.Value.AddDays(this.DL_DAY.GetValueOrDefault(0) - 1); }
        }

        private AirSeason getCurrentAirSeason
        {
            get
            {
                var q = this.Charter.AirSeasons.Where(x =>
                    x.AS_DATEFROM.HasValue
                    && x.AS_DATETO.HasValue
                    && x.AS_DATEFROM.Value.Date <= this.BegServ.Date
                    && x.AS_DATETO.Value.Date >= this.BegServ.Date);
                if (q.Count() > 0)
                    return q.First();
                else
                    return null;
            }
        }

        /// <summary>
        /// Время вылета
        /// </summary>
        public DateTime? FlyFrom
        {
            get
            {
                if (getCurrentAirSeason.AS_TIMEFROM.HasValue)
                    return getCurrentAirSeason.AS_TIMEFROM.Value;
                else
                    return null;
            }
        }

        /// <summary>
        /// Время прилета
        /// </summary>
        public DateTime? FlyTo
        {
            get
            {
                if (getCurrentAirSeason.AS_TIMETO.HasValue)
                    return getCurrentAirSeason.AS_TIMETO.Value;
                else
                    return null;
            }
        }
    }
}