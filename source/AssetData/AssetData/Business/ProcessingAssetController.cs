using AssetData.Repository;
using System;

namespace AssetData.Business
{
    class ProcessingAssetController
    {
        public bool IsValidAssetCode(string assetCode)
        {
            return new AssetRepository().AssetVerification(assetCode);
        }

        public Tuple<string, string> AddAssetOnProcessingList(string inputAssetCode)
        {
            string outputMsg = string.Empty;
            string status = string.Empty;

            //Verifica se o ativo já esta cadastrado
            bool vefAsset = new ProcessingAssetRepository().AssetVerification(inputAssetCode);

            if (!vefAsset)
            {
                new ProcessingAssetRepository().Save(inputAssetCode);
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
            bool vefAsset = new ProcessingAssetRepository().AssetVerification(inputAssetCode);

            if (vefAsset)
            {
                new ProcessingAssetRepository().Delete(inputAssetCode);
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
    }
}
