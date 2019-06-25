using AssetData.Model;
using AssetData.Repository;
using AssetData.Service;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace AssetData.Business
{
    class ExchangeController
    {
        public void ExchangeManager(DateTime begintDate, DateTime endDate)
        {

        }

        public void UpdateCurrenciesList()
        {
            Exchange exchange = GetCurrencies();

            for (int x = 0; x < exchange.value.Count(); x++)
            {
                bool isNew = new ExchangeRepository().CurrencyIsNew(exchange.value[x]);
                if (isNew)
                {

                }
                else
                {
                    bool isUpdated = new ExchangeRepository().CurrencyIsUpdated(exchange.value[x]);
                    if (isUpdated)
                    {

                    }
                }                
            }
        }

        private Exchange GetCurrencies()
        {
            Exchange exchange = new Exchange();

            string urlRequest = "https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/Moedas?$top=100&$format=json";
            string respApiJson = new ServiceRequester().GetRequest(urlRequest);

            if (!string.IsNullOrEmpty(respApiJson))
            {
                exchange = JsonConvert.DeserializeObject<Exchange>(respApiJson);
            }

            return exchange;
        }
    }
}
