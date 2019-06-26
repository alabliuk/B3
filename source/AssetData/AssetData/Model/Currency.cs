using System.Collections.Generic;

namespace AssetData.Model
{
    public class CurrencyItem
    {
        public string id { get; set; }
        public string simbolo { get; set; }
        public string nomeFormatado { get; set; }
        public string tipoMoeda { get; set; }
    }

    public class Currency
    {
        public List<CurrencyItem> value { get; set; }
    }
}
