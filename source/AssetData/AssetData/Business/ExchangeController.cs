using AssetData.Model;
using AssetData.Repository;
using AssetData.Service;
using AssetData.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using AssetData.Util;

namespace AssetData.Business
{
    class ExchangeController
    {
        public void ExchangeManager(DateTime begintDate, DateTime endDate)
        {
            new ExchangeMenu().RunExchange($"Start Date: {string.Format("{0:d}", begintDate)} ~ End Data: {string.Format("{0:d}", endDate)}\n\n");

            List<CurrencyItem> cItem = new ExchangeRepository().GetAllCurrenciesObject();

            for (int y = 0; y < cItem.Count; y++)
            {
                CurrencyRate cRate = new CurrencyRate();
                try
                {
                    //RequestApi
                    cRate = GetCurrencyRate(cItem[y].simbolo, begintDate, endDate);
                }
                catch (Exception exReq)
                {
                    new LineColorLine().PrintResult($"{cItem[y].simbolo} - {cItem[y].nomeFormatado}", StatusScreen.Error);
                    new ExceptionRepository().Save($"{cItem[y].simbolo} || Currency Rate Request Error --> {exReq.Message}");
                }

                try
                {
                    if (cRate.value != null)
                    {
                        for (int x = 0; x < cRate.value.Count; x++)
                        {
                            //bool dataVerification = new ExchangeRepository().InterdayVerification(interday.data[x].date, listAssets[y].idt);
                            //if (!dataVerification)
                            //    new InterdayRepository().Save(listAssets[y].idt, interday.data[x]);
                        }
                    }
                    new LineColorLine().PrintResult($"{cItem[y].simbolo} - {cItem[y].nomeFormatado}", StatusScreen.Success);
                }
                catch (Exception exReqBD)
                {
                    new LineColorLine().PrintResult($"{cItem[y].simbolo} - {cItem[y].nomeFormatado}", StatusScreen.Warning);
                    new ExceptionRepository().Save($"{cItem[y].simbolo} || Currency Rate Repository Error --> {exReqBD.Message}");
                }
            }

            new MainMenu().GoBackMainMenu();
        }

        public void UpdateCurrencyList()
        {
            Currency currency = GetCurrencies();

            for (int x = 0; x < currency.value.Count(); x++)
            {
                bool isNew = new ExchangeRepository().CurrencyIsNew(currency.value[x]);
                if (isNew)
                {
                    new ExchangeRepository().SaveCurrency(currency.value[x]);
                }
                else
                {
                    bool isUpdated = new ExchangeRepository().CurrencyIsUpdated(currency.value[x]);
                    if (isUpdated)
                    {
                        CurrencyItem exItem = new ExchangeRepository().GetOld(currency.value[x].simbolo);
                        new ExchangeRepository().SaveUpdateLog(exItem);
                        new ExchangeRepository().UpdateCurrency(currency.value[x]);
                    }
                }
            }
            new ExchangeMenu().RenderCurrencieList($"Updated list at {DateTime.Now}", "R");
        }

        private Currency GetCurrencies()
        {
            Currency currency = new Currency();
            var config = new Utils().ReadTokensAppsettings();

            string urlRequest = config.GetSection("BCB_Olinda:UrlMoedas").Value;
            string respApiJson = new ServiceRequester().GetRequest(urlRequest);

            if (!string.IsNullOrEmpty(respApiJson))
            {
                currency = JsonConvert.DeserializeObject<Currency>(respApiJson);
            }

            return currency;
        }

        private CurrencyRate GetCurrencyRate(string isoCode, DateTime begintDate, DateTime endDate)
        {
            CurrencyRate cRate = new CurrencyRate();
            var config = new Utils().ReadTokensAppsettings();

            string urlRequest = config.GetSection("BCB_Olinda:UrlCotacaoMoeda").Value;
            string urlParameters = $"@moeda='{isoCode}'&@dataInicial='{string.Format("{0:MM-dd-yyyy}", begintDate.Date)}'&@dataFinalCotacao='{string.Format("{0:MM-dd-yyyy}", endDate.Date)}'&$top=10000&$filter=tipoBoletim%20eq%20'Fechamento'&$format=json";

            urlRequest = urlRequest + urlParameters;

            string respApiJson = new ServiceRequester().GetRequest(urlRequest);

            if (!string.IsNullOrEmpty(respApiJson))
            {
                cRate = JsonConvert.DeserializeObject<CurrencyRate>(respApiJson);
            }

            return cRate;
        }
    }
}
