using AssetData.Model;
using AssetData.Service;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AssetData.Repository
{
    class ProcessingAssetRepository
    {
        public bool Delete(string assetCode)
        {
            var config = new Utils().ReadTokensConnsettings();
            bool dataVerification;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "DELETE FROM ProcessingAssets WHERE AssetCode =  @assetCode";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@assetCode", assetCode);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dataVerification = conn.Query<bool>(sql, vParams).FirstOrDefault();
            }
            return dataVerification;
        }

        public void Save(string assetCode)
        {
            var config = new Utils().ReadTokensConnsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "INSERT INTO ProcessingAssets (assetCode, createDate) " +
                "VALUES (@assetCode, GETDATE())";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@assetCode", assetCode);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                conn.Query<int>(sql, vParams).FirstOrDefault();
            }
        }

        public bool AssetVerification(string assetCode)
        {
            var config = new Utils().ReadTokensConnsettings();
            bool asset = false;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT COUNT(1) FROM ProcessingAssets WHERE assetCode = @assetCode";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@assetCode", assetCode);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                asset = conn.Query<bool>(sql, vParams).FirstOrDefault();
            }
            return asset;
        }

        public List<string> AssetList()
        {
            List<string> asset;
            var config = new Utils().ReadTokensConnsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT A.asset + ' - ' + A.companyAbvName as assetName FROM Assets A INNER JOIN ProcessingAssets I ON A.asset = I.assetCode";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                asset = conn.Query<string>(sql).ToList();
            }
            return asset;
        }

        public List<AssetItem> ProcessingAssetList()
        {
            List<AssetItem> asset;
            var config = new Utils().ReadTokensConnsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT A.idt, A.asset, A.companyAbvName FROM Assets A INNER JOIN ProcessingAssets I ON A.asset = I.assetCode";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                asset = conn.Query<AssetItem>(sql).ToList();
            }
            return asset;
        }
    }
}
