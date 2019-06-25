using AssetData.Model;
using AssetData.Service;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AssetData.Repository
{
    class ExchangeRepository
    {
        public List<string> GetAllCurrencies()
        {
            List<string> currencies;
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT A.asset + ' - ' + A.companyAbvName as assetName FROM Assets A INNER JOIN ProcessingAssets I ON A.asset = I.assetCode";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                currencies = conn.Query<string>(sql).ToList();
            }
            return currencies;
        }

        public bool CurrencyIsNew(ExchangeItem ex)
        {
            var config = new Utils().ReadTokensAppsettings();
            bool dataVerification;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT COUNT(1) FROM Currencies WHERE isoCode = @isoCode ";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@isoCode", ex.simbolo);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dataVerification = conn.Query<bool>(sql, vParams).FirstOrDefault();
            }
            return !dataVerification;
        }

        public bool CurrencyIsUpdated(ExchangeItem ex)
        {
            var config = new Utils().ReadTokensAppsettings();
            bool dataVerification;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT COUNT(1) FROM Currencies WHERE isoCode = @isoCode " +
                "AND [name] = @name " +
                "AND [type] = @type";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@isoCode", ex.simbolo);
                vParams.Add("@name", ex.nomeFormatado);
                vParams.Add("@type", ex.tipoMoeda);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dataVerification = conn.Query<bool>(sql, vParams).FirstOrDefault();
            }
            return dataVerification;
        }
    }
}
