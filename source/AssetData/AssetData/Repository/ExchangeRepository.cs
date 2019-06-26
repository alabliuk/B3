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

            string sql = "SELECT CONCAT('[', type, '] ', isoCode, ' - ' ,name) FROM Currencies order by type, isoCode ASC";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                currencies = conn.Query<string>(sql).ToList();
            }
            return currencies;
        }

        public List<CurrencyItem> GetAllCurrenciesObject()
        {
            List<CurrencyItem> currencies;
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT id, isoCode AS simbolo, [name] AS nomeFormatado, [type] AS tipoMoeda FROM Currencies";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                currencies = conn.Query<CurrencyItem>(sql).ToList();
            }
            return currencies;
        }

        public bool CurrencyIsNew(CurrencyItem exItem)
        {
            var config = new Utils().ReadTokensAppsettings();
            bool dataVerification;
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT COUNT(1) FROM Currencies WHERE isoCode = @isoCode ";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@isoCode", exItem.simbolo);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dataVerification = conn.Query<bool>(sql, vParams).FirstOrDefault();
            }
            return !dataVerification;
        }

        public bool CurrencyIsUpdated(CurrencyItem ex)
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

        public void SaveCurrency(CurrencyItem exItem)
        {
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "INSERT INTO Currencies (isoCode, name, type, createDate, updateDate) " +
                "VALUES (@isoCode, @name, @type, GETDATE(), GETDATE())";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@isoCode", exItem.simbolo);
                vParams.Add("@name", exItem.nomeFormatado);
                vParams.Add("@type", exItem.tipoMoeda);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                conn.Query<int>(sql, vParams).FirstOrDefault();
            }
        }

        public void SaveCurrencyRate(CurrencyItem exItem)
        {
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "INSERT INTO Currencies (isoCode, name, type, createDate, updateDate) " +
                "VALUES (@isoCode, @name, @type, GETDATE(), GETDATE())";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@isoCode", exItem.simbolo);
                vParams.Add("@name", exItem.nomeFormatado);
                vParams.Add("@type", exItem.tipoMoeda);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                conn.Query<int>(sql, vParams).FirstOrDefault();
            }
        }

        public void UpdateCurrency(CurrencyItem exItem)
        {
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "UPDATE Currencies SET isoCode = @isoCode, [name] = @name, [type] = @type, updateDate = GETDATE()" +
                "WHERE isoCode = @id";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@id", exItem.id);
                vParams.Add("@isoCode", exItem.simbolo);
                vParams.Add("@name", exItem.nomeFormatado);
                vParams.Add("@type", exItem.tipoMoeda);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                conn.Query<int>(sql, vParams).FirstOrDefault();
            }
        }

        public void SaveUpdateLog(CurrencyItem exItem)
        {
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "INSERT INTO CurrenciesUpdateLog (isoCode, name, type, createDate) " +
                "VALUES (@isoCode, @name, @type, GETDATE())";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@isoCode", exItem.simbolo);
                vParams.Add("@name", exItem.nomeFormatado);
                vParams.Add("@type", exItem.tipoMoeda);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                conn.Query<int>(sql, vParams).FirstOrDefault();
            }
        }

        public CurrencyItem GetOld(string isoCode)
        {
            CurrencyItem exItem = new CurrencyItem();
            var config = new Utils().ReadTokensAppsettings();
            string strConnectionString = config.GetSection("Conn:DB").Value;

            string sql = "SELECT isoCode AS simbolo, [name] AS nomeFormatado, [type] AS tipoMoeda FROM Currencies WHERE isoCode = @isoCode";

            using (IDbConnection conn = new SqlConnection(strConnectionString))
            {
                var vParams = new DynamicParameters();
                vParams.Add("@isoCode", isoCode);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                exItem = conn.Query<CurrencyItem>(sql, vParams).FirstOrDefault();
            }
            return exItem;
        }
    }
}
