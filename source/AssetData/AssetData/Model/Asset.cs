using System.Collections.Generic;

namespace AssetData.Model
{
    public class AssetItem
    {
        public int idt { get; set; }
        public string code { get; set; }
        public string asset { get; set; }
        public string companyName { get; set; }
        public string companyAbvName { get; set; }
    }

    public class Asset
    {
        public List<AssetItem> data { get; set; }
        public int timeOffSet { get; set; }
    }
}
