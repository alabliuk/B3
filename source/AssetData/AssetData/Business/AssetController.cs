using AssetData.Model;
using AssetData.Service;
using Newtonsoft.Json;
using System;
using AssetData.Repository;

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

                            Console.WriteLine("Ativo atualizado com sucesso: " + assetsApi.data[x].code + " - " + assetsApi.data[x].companyName);
                            update++;
                        }
                        else
                        {
                            Console.WriteLine("Ativo sem Alteração: " + assetsApi.data[x].code + " - " + assetsApi.data[x].companyName);
                            discard++;
                        }                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERRO: " + assetsApi.data[x].code + " - " + assetsApi.data[x].companyName + " --> " + e.Message);
                        error++;
                    }
                }
                else
                {
                    try
                    {
                        new AssetRepository().AssetSave(assetsApi.data[x]);
                        Console.WriteLine("Ativo cadastrado com sucesso: " + assetsApi.data[x].code + " - " + assetsApi.data[x].companyName);
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
        }



        public Asset GetAllAssets()
        {
            Console.WriteLine("\nCarregando lista de ativos...");
            Asset asset = new Asset();
            string respApiJson = new AssetService().GetAllAssetsApi();

            if (!string.IsNullOrEmpty(respApiJson))
            {
                asset = JsonConvert.DeserializeObject<Asset>(respApiJson);
            }
            return asset;
        }
    }
}
