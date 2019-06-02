using AssetData.Model;
using AssetData.Service;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AssetData.Repository
{
    public class AssetRepository
    {
        public bool AssetVerification(int idt)
        {
            var config = new Utils().ReadTokensAppsettings();
            bool asset = false;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT COUNT(1) FROM ASSETS WHERE idt = @idt";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@idt", idt);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                asset = conn.Query<bool>(sql, vParams).FirstOrDefault();
            }
            return asset;
        }

        public bool AssetVerification(string codeAsset)
        {
            var config = new Utils().ReadTokensAppsettings();
            bool asset = false;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT COUNT(1) FROM ASSETS WHERE asset = @asset";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@asset", codeAsset);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                asset = conn.Query<bool>(sql, vParams).FirstOrDefault();
            }
            return asset;
        }

        public bool AssetIsUpdated(AssetItem assets)
        {
            var config = new Utils().ReadTokensAppsettings();
            bool asset = false;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT COUNT(1) FROM ASSETS " +
                "WHERE (code <> @code OR companyName <> @companyName OR companyAbvName <> @companyAbvName) " +
                "AND idt = @idt";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@idt", assets.idt);
                vParams.Add("@code", assets.code.TrimEnd());
                vParams.Add("@companyName", assets.companyName.TrimEnd());
                vParams.Add("@companyAbvName", assets.companyAbvName.TrimEnd());

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                asset = conn.Query<bool>(sql, vParams).FirstOrDefault();
            }
            return asset;
        }

        public void AssetSave(AssetItem assets)
        {
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "INSERT INTO ASSETS (idt, code, asset, companyName, companyAbvName, createDate, updateDate) " +
                "VALUES (@idt, @code, @asset, @companyName, @companyAbvName, GETDATE(), GETDATE())";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@idt", assets.idt);
                vParams.Add("@code", assets.code.TrimEnd());
                vParams.Add("@asset", assets.code.Replace(".SA", "").TrimEnd().ToUpper());
                vParams.Add("@companyName", assets.companyName.TrimEnd().ToUpper());
                vParams.Add("@companyAbvName", assets.companyAbvName.TrimEnd().ToUpper());

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                conn.Query<int>(sql, vParams).FirstOrDefault();
            }
        }

        public AssetItem AssetGetOld(int idt)
        {
            AssetItem asset = new AssetItem();
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT idt, code, asset, companyName, companyAbvName " +
                "FROM ASSETS WHERE idt = @idt";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@idt", idt);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                asset = conn.Query<AssetItem>(sql, vParams).FirstOrDefault();
            }
            return asset;
        }

        public void AssetSaveLog(AssetItem assetOld)
        {
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sqlInsert = "INSERT INTO AssetsUpdateLog (idt, code, asset, companyName, companyAbvName, createDate) " +
                "VALUES (@idt, @code, @asset, @companyName, @companyAbvName, GETDATE())";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@idt", assetOld.idt);
                vParams.Add("@code", assetOld.code.TrimEnd());
                vParams.Add("@asset", assetOld.code.Replace(".SA", "").TrimEnd());
                vParams.Add("@companyName", assetOld.companyName.TrimEnd());
                vParams.Add("@companyAbvName", assetOld.companyAbvName.TrimEnd());

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                conn.Query<int>(sqlInsert, vParams).FirstOrDefault();
            }
        }

        public void AssetUpdate(AssetItem assetNew)
        {
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "UPDATE ASSETS SET " +
                "code = @code, asset = @asset, companyName = @companyName, companyAbvName = @companyAbvName, updateDate = GETDATE() " +
                "WHERE idt = @idt";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@idt", assetNew.idt);
                vParams.Add("@code", assetNew.code.TrimEnd());
                vParams.Add("@asset", assetNew.code.Replace(".SA", "").TrimEnd());
                vParams.Add("@companyName", assetNew.companyName.TrimEnd());
                vParams.Add("@companyAbvName", assetNew.companyAbvName.TrimEnd());

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                conn.Query<AssetItem>(sql, vParams).FirstOrDefault();
            }
        }
    }
}
