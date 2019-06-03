﻿using AssetData.Model;
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

            List<AssetItem> listAssets = new IntradayRepository().IntradayGetAssetsToProcess();

            for (int y = 0; y < listAssets.Count; y++)
            {
                //RequestApi
                Intraday intraday = new IntradayController().GetAllIntraday(listAssets[y].idt);

                if (intraday.data != null)
                {
                    for (int x = 0; x < intraday.data.Count; x++)
                    {
                        bool dataVerification = new IntradayRepository().IntradayVerification(intraday.data[x].date, listAssets[y].idt);
                        if (!dataVerification)
                            new IntradayRepository().IntradaySave(listAssets[y].idt, intraday.data[x]);
                    }
                }
                new StockQuote().RunningIntradayScreen(outputMsg, status, $"PROCESS: {listAssets[y].asset}");
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

        public Tuple<string, string> AddAssetOnProcessingList(string inputAssetCode)
        {
            string outputMsg = string.Empty;
            string status = string.Empty;

            //Verifica se o ativo já esta cadastrado
            bool vefAsset = new IntradayRepository().IntradayAssetVerification(inputAssetCode);

            if (!vefAsset)
            {
                new IntradayRepository().IntradayAssetSave(inputAssetCode);
                outputMsg = $"Ativo {inputAssetCode} cadastrado com sucesso!";
                status = "S";

            }
            else
            {
                outputMsg = $"Ativo {inputAssetCode} já cadastrado.";
                status = "W";
            }

            return Tuple.Create(outputMsg, status);
        }

        public Tuple<string, string> RemoveAssetOnProcessingList(string inputAssetCode)
        {
            string outputMsg = string.Empty;
            string status = string.Empty;

            //Verifica se o ativo já esta cadastrado
            bool vefAsset = new IntradayRepository().IntradayAssetVerification(inputAssetCode);

            if (vefAsset)
            {
                new IntradayRepository().IntradayAssetDelete(inputAssetCode);
                outputMsg = $"Ativo {inputAssetCode} removido com sucesso!";
                status = "S";

            }
            else
            {
                outputMsg = $"Ativo {inputAssetCode} não encontrado";
                status = "W";
            }

            return Tuple.Create(outputMsg, status);
        }

        public bool IsValidAssetCode(string assetCode)
        {
            return new AssetRepository().AssetVerification(assetCode);
        }
    }
}
