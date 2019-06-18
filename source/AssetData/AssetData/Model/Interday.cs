using System.Collections.Generic;

namespace AssetData.Model
{
    public class InterdayItem
    {
        public long date { get; set; }
        public double price { get; set; }
        public double low { get; set; }
        public double high { get; set; }
        public double var { get; set; }
        public double varpct { get; set; }
        public long vol { get; set; }
    }

    public class Interday
    {
        public List<InterdayItem> data { get; set; }
        public long lastUpdate { get; set; }
        public string type { get; set; }
        public int timeOffSet { get; set; }
        public long today { get; set; }
    }
}
