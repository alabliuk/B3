using AssetData.Service;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AssetData.Repository
{
    class ExceptionRepository
    {
        public void Save(string ex)
        {
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "INSERT INTO Exceptions (Date, Exception) " +
                "VALUES (GETDATE(), @ex)";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@ex", ex);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                conn.Query<int>(sql, vParams).FirstOrDefault();
            }
        }
    }
}
