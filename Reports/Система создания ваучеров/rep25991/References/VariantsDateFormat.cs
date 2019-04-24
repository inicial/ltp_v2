namespace rep25991.References
{
    public class VariantsDateFormat
    {
        private static structDateFormat[] dateFormats = null;
        public static structDateFormat[] DateFormats
        {
            get
            {
                if (dateFormats == null)
                {
                    dateFormats = new structDateFormat[]{
                        new structDateFormat("dd-MM-yyyy"),
                        new structDateFormat("dd.MM.yyyy"),
                        new structDateFormat("dd/MM.yyyy"),
                        new structDateFormat("LMM.dd.yy"),
                        new structDateFormat("LMM.dd.yyyy"),
                        new structDateFormat("LMMM.dd.yy"),
                        new structDateFormat("LMMM.dd.yyyy"),
                        new structDateFormat("RMM.dd.yy"),
                        new structDateFormat("RMM.dd.yyyy"),
                        new structDateFormat("RMMM.dd.yy"),
                        new structDateFormat("RMMM.dd.yyyy"),
                        new structDateFormat("LMM-dd-yy"),
                        new structDateFormat("LMM-dd-yyyy"),
                        new structDateFormat("LMMM-dd-yy"),
                        new structDateFormat("LMMM-dd-yyyy"),
                        new structDateFormat("RMM-dd-yy"),
                        new structDateFormat("RMM-dd-yyyy"),
                        new structDateFormat("RMMM-dd-yy"),
                        new structDateFormat("RMMM-dd-yyyy")
                    };
                }
                return dateFormats;
            }
        }
    }
}