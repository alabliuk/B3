using AssetData.Model;
using AssetData.Repository;
using AssetData.Service;
using AssetData.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AssetData.Business
{
    class InterdayController
    {
        public void InterdayManager(DateTime begintDate, DateTime endDate, bool loadListAsset = default(bool))
        {
            new StockQuote().RunInterday($"Start Date: {string.Format("{0:d}", begintDate)} ~ End Data: {string.Format("{0:d}", endDate)}\n\n");

            List<AssetItem> listAssets;

            if (loadListAsset)
            {
                listAssets = new ProcessingAssetRepository().ProcessingAssetList();
            }
            else
            {
                listAssets = new AssetRepository().GetAllAssets();
            }
            
            for (int y = 0; y < listAssets.Count; y++)
            {
                //RequestApi
                Interday interday = new InterdayController().GetInterday(listAssets[y].idt, begintDate, endDate);

                if (interday.data != null)
                {
                    for (int x = 0; x < interday.data.Count; x++)
                    {
                        bool dataVerification = new InterdayRepository().InterdayVerification(interday.data[x].date, listAssets[y].idt);
                        if (!dataVerification)
                            new InterdayRepository().Save(listAssets[y].idt, interday.data[x]);
                    }
                }
                new StockQuote().RunningInterdayScreen($"{listAssets[y].asset} - {listAssets[y].companyAbvName}");
            }

            new MainMenu().GoBackMainMenu();

        }

        public Interday GetInterday(int idtAsset, DateTime begintDate, DateTime endDate)
        {
            double beginDateUnix = new Utils().DatetimeToMillis(begintDate);
            double dtendDateUnix = new Utils().DatetimeToMillis(endDate);

            string InterdayParameter = $"begin={beginDateUnix}&end={dtendDateUnix}";

            Interday interday = new Interday();
            string urlRequest = new Utils().UrlBuild("API_Access:UrlBase", "API_Access:InterdayService", idtAsset.ToString());
            string respApiJson = new ServiceRequester().GetRequest(urlRequest + InterdayParameter);

            if (!string.IsNullOrEmpty(respApiJson))
            {
                interday = JsonConvert.DeserializeObject<Interday>(respApiJson);
            }

            return interday;
        }
    }
}
