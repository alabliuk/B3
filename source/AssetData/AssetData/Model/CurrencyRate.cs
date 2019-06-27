using System;
using System.Collections.Generic;

namespace AssetData.Model
{
    public class CurrencyRateItem
    {
        public string isoCode { get; set; }
        public double paridadeCompra { get; set; }
        public double paridadeVenda { get; set; }
        public double cotacaoCompra { get; set; }
        public double cotacaoVenda { get; set; }
        public DateTime dataHoraCotacao { get; set; }
        //public string tipoBoletim { get; set; } //--> Sempre Fechamento (Filtro na URL)
    }

    public class CurrencyRate
    {
        public List<CurrencyRateItem> value { get; set; }
    }
}
