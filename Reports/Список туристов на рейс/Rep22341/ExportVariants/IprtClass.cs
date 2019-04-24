using System.Linq;

namespace Rep22341.ExportVariants
{
    public enum VariantsEXType
    {
        None = 0,
        SplitPartner = 2
    }
    public abstract class IprtClass
    {
        public abstract void Start(IQueryable<ExportItem> exportItems);

        public abstract void Start(IQueryable<ExportItem> exportItems, bool SplitPartner);
    }
}
