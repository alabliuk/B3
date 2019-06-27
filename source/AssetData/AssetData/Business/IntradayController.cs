using AssetData.Model;
using AssetData.Repository;
using AssetData.Service;
using AssetData.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AssetData.Business
{
    class IntradayController
    {
        public void IntradayManager()
        {
            string outputMsg = "Running Intraday Service...";
            string status = "R";
            string asset = string.Empty;

            List<AssetItem> listAssets = new ProcessingAssetRepository().ProcessingAssetList();

            for (int y = 0; y < listAssets.Count; y++)
            {
                //RequestApi
                Intraday intraday = new IntradayController().GetIntraday(listAssets[y].idt);

                if (intraday.data != null)
                {
                    for (int x = 0; x < intraday.data.Count; x++)
                    {
                        bool dataVerification = new IntradayRepository().IntradayVerification(intraday.data[x].date, listAssets[y].idt);
                        if (!dataVerification)
                            new IntradayRepository().Save(listAssets[y].idt, intraday.data[x]);
                    }
                }
                new StockQuoteMenu().RunningIntradayScreen(outputMsg, status, $"PROCESS: {listAssets[y].asset}");
            }

            new StockQuoteMenu().RunningIntradayScreen("Waiting...", "W", $"Next Process: {DateTime.Now.AddMinutes(5)}");
            Thread.Sleep(300000);
        }

        private Intraday GetIntraday(int idtAsset)
        {
            Intraday intraday = new Intraday();
            string urlRequest = new Utils().UrlBuild("API_Access:UrlBase", "API_Access:IntradayService", idtAsset.ToString());
            string respApiJson = new ServiceRequester().GetRequest(urlRequest);

            respApiJson = respApiJson.Replace("uolfinancecallback0(", "").Replace(");", "");

            if (!string.IsNullOrEmpty(respApiJson))
            {
                intraday = JsonConvert.DeserializeObject<Intraday>(respApiJson);
            }

            return intraday;
        }
    }
}
