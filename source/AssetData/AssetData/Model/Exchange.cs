using System.Collections.Generic;

namespace AssetData.Model
{
    public class ExchangeItem
    {
        public string simbolo { get; set; }
        public string nomeFormatado { get; set; }
        public string tipoMoeda { get; set; }
    }

    public class Exchange
    {
        //public string __invalid_name__@odata.context { get; set; }
        public List<ExchangeItem> value { get; set; }
    }
}
