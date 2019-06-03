using AssetData.Model;
using AssetData.Service;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AssetData.Repository
{
    class IntradayRepository
    {
        public void IntradaySave(int idtAsset, IntradayItem i)
        {
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "INSERT INTO Intraday (idtAsset, date, unixTime, price, low, high, var, varpct, vol) " +
                "VALUES (@idtAsset, @date, @unixTime, @price, @low, @high, @var, @varpct, @vol)";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@idtAsset", idtAsset);
                vParams.Add("@date", new Utils().MillisToDatetimeNow(i.date));
                vParams.Add("@unixTime", i.date);
                vParams.Add("@price", i.price);
                vParams.Add("@low", i.low);
                vParams.Add("@high", i.high);
                vParams.Add("@var", i.var);
                vParams.Add("@varpct", i.varpct);
                vParams.Add("@vol", i.vol);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                conn.Query<int>(sql, vParams).FirstOrDefault();
            }
        }

        public bool IntradayVerification(long unixTime, int idtAsset)
        {
            var config = new Utils().ReadTokensAppsettings();
            bool dataVerification;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT COUNT(1) FROM Intraday WHERE unixTime = @unixTime AND idtAsset = @idtAsset";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@unixTime", unixTime);
                vParams.Add("@idtAsset", idtAsset);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dataVerification = conn.Query<bool>(sql, vParams).FirstOrDefault();
            }
            return dataVerification;
        }

        public List<AssetItem> IntradayGetAssetsToProcess()
        {
            List<AssetItem> asset;
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT A.idt, A.asset FROM Assets A INNER JOIN IntradayAsset I ON A.asset = I.assetCode";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                asset = conn.Query<AssetItem>(sql).ToList();
            }
            return asset;
        }

        public List<string> IntradayAssetList()
        {
            List<string> asset;
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT A.asset + ' - ' + A.companyAbvName as assetName FROM Assets A INNER JOIN IntradayAsset I ON A.asset = I.assetCode";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                asset = conn.Query<string>(sql).ToList();
            }
            return asset;
        }

        public bool IsValidAssetCode(long unixTime, int idtAsset)
        {
            var config = new Utils().ReadTokensAppsettings();
            bool dataVerification;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT COUNT(1) FROM Intraday WHERE unixTime = @unixTime AND idtAsset = @idtAsset";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@unixTime", unixTime);
                vParams.Add("@idtAsset", idtAsset);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dataVerification = conn.Query<bool>(sql, vParams).FirstOrDefault();
            }
            return dataVerification;
        }

        public bool IntradayAssetVerification(string assetCode)
        {
            var config = new Utils().ReadTokensAppsettings();
            bool asset = false;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT COUNT(1) FROM IntradayAsset WHERE assetCode = @assetCode";

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

        public void IntradayAssetSave(string assetCode)
        {
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "INSERT INTO IntradayAsset (assetCode, createDate) " +
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

        public bool IntradayAssetDelete(string assetCode)
        {
            var config = new Utils().ReadTokensAppsettings();
            bool dataVerification;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "DELETE FROM IntradayAsset WHERE AssetCode =  @assetCode";

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
    }
}
