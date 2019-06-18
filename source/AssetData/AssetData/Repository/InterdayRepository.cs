using AssetData.Model;
using AssetData.Service;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AssetData.Repository
{
    class InterdayRepository
    {
        public bool InterdayVerification(long unixTime, int idtAsset)
        {
            var config = new Utils().ReadTokensAppsettings();
            bool dataVerification;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT COUNT(1) FROM Interday WHERE unixTime = @unixTime AND idtAsset = @idtAsset";

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

        public void Save(int idtAsset, InterdayItem i)
        {
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "INSERT INTO Interday (idtAsset, date, unixTime, price, low, high, var, varpct, vol) " +
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
    }
}
