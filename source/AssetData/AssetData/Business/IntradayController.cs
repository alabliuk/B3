using AssetData.Model;
using AssetData.Repository;
using AssetData.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AssetData.Business
{
    class IntradayController
    {
        public void IntradayManager()
        {
            Console.WriteLine("\n\nCarregando Intraday...");

            //string idtAsset = "484"; //--> For debug PETR4

            List<int> listAssets = new IntradayRepository().IntradayGetAssetsToProcess();
            foreach(int idtAsset in listAssets)
            {
                Intraday intraday = new IntradayController().GetAllIntraday(idtAsset);

                Console.WriteLine(idtAsset);

                if (intraday.data != null)
                {
                    for (int x = 0; x < intraday.data.Count; x++)
                    {
                        Console.WriteLine(idtAsset + " - " + intraday.data[x].price);

                        bool dataVerification = new IntradayRepository().IntradayVerification(intraday.data[x].date, idtAsset);
                        if (!dataVerification)
                            new IntradayRepository().IntradaySave(idtAsset, intraday.data[x]);
                    }
                }
            }            
        }

        public Intraday GetAllIntraday(int idtAsset)
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

        public void AddAssetOnProcessingList()
        {

        }

        public void RemoveAssetOnProcessingList()
        {

        }

        public bool IsValidAssetCode(string assetCode)
        {
            return new AssetRepository().AssetVerification(assetCode);
        }
    }
}
