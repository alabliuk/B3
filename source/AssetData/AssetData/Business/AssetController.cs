using AssetData.Model;
using AssetData.Service;
using Newtonsoft.Json;
using System;
using AssetData.Repository;
using AssetData.UI;

namespace AssetData.Business
{
    public class AssetController
    {
        public void AssetManager()
        {
            int create = 0;
            int update = 0;
            int error = 0;
            int discard = 0;

            new LineColorLine().Bold("\nCarregando lista de ativos...\n");
            Asset assetsApi = GetAllAssets();
            for (int x = 0; x < assetsApi.data.Count; x++)
            {
                bool isAvailable = new AssetRepository().AssetVerification(assetsApi.data[x].idt);
                if (isAvailable)
                {
                    try
                    {
                        bool isUpdated = new AssetRepository().AssetIsUpdated(assetsApi.data[x]);
                        if (isUpdated)
                        {
                            //Captura os dados antigos
                            AssetItem assetOld = new AssetRepository().AssetGetOld(assetsApi.data[x].idt);

                            //Salva os dados antigos na tabela de log (Historico do ativo)
                            new AssetRepository().AssetSaveLog(assetOld);

                            //Atualiza as novas informações na tabela de ativo
                            new AssetRepository().AssetUpdate(assetsApi.data[x]);

                            new LineColorLine().Green("Ativo atualizado com sucesso: ");
                            Console.WriteLine(assetsApi.data[x].code + " - " + assetsApi.data[x].companyName);
                            update++;
                        }
                        else
                        {
                            new LineColorLine().Yellow("Ativo sem Alteração: ");
                            Console.WriteLine(assetsApi.data[x].code + " - " + assetsApi.data[x].companyName);
                            discard++;
                        }
                    }
                    catch (Exception e)
                    {
                        new LineColorLine().Red("ERRO: ");
                        Console.WriteLine(assetsApi.data[x].code + " - " + assetsApi.data[x].companyName);
                        error++;
                    }
                }
                else
                {
                    try
                    {
                        new AssetRepository().AssetSave(assetsApi.data[x]);
                        new LineColorLine().Green("Ativo cadastrado com sucesso: ");
                        Console.WriteLine(assetsApi.data[x].code + " - " + assetsApi.data[x].companyName);
                        create++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(assetsApi.data[x].code + " - " + assetsApi.data[x].companyName + ": ERRO --> " + e.Message);
                        error++;
                    }
                }
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("Ativos Cadastrados Com Sucesso: " + create);
            Console.WriteLine("Ativos Atualizados Com Sucesso: " + update);
            Console.WriteLine("Ativos Sem Alteração: " + discard);
            Console.WriteLine("Ativos Com Erro: " + error);

            new MainMenu().GoBackMainMenu();
        }

        public Asset GetAllAssets()
        {
            Asset asset = new Asset();
            string urlRequest = new Utils().UrlBuild("API_Access:UrlBase", "API_Access:AssetService");
            string respApiJson = new ServiceRequester().GetRequest(urlRequest);

            if (!string.IsNullOrEmpty(respApiJson))
            {
                asset = JsonConvert.DeserializeObject<Asset>(respApiJson);
            }

            return asset;
        }
    }
}
