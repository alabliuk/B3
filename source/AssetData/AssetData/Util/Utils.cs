using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AssetData.Service
{
    class Utils
    {
        public IConfigurationRoot ReadTokensAppsettings()
        {
            var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile($"appsettings.json");
            var config = builder.Build();
            return config;
        }

        public IConfigurationRoot ReadTokensConnsettings()
        {
            var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile($"connsettings.json");
            var config = builder.Build();
            return config;
        }

        public string UrlBuild(string urlBase, string urlFinal, string _assetIdt = null)
        {
            var config = new Utils().ReadTokensAppsettings();
            string _urlBase = config.GetSection(urlBase).Value;
            string _urlFinal = config.GetSection(urlFinal).Value;

            if (!string.IsNullOrEmpty(_assetIdt))
            {
                _assetIdt = "/" + _assetIdt;
            }

            return _urlBase + _assetIdt + _urlFinal;
        }

        public DateTime MillisToDatetimeNow(long millis)
        {
            var time = TimeSpan.FromMilliseconds(millis);
            DateTime datetimeConvert = new DateTime(1970, 1, 1) + time;
            return datetimeConvert = datetimeConvert - (DateTime.UtcNow - DateTime.Now);
        }

        public double DatetimeToMillis(DateTime datetime)
        {
            return datetime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        public int ConvertMinutesToMillis(int min)
        {
            return min * 60000;
        }

        public int ConvertStringToInt(string str)
        {
            return Convert.ToInt32(str);
        }
    }
}
