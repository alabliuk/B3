using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AssetData.Service
{
    class Utils
    {
        public IConfigurationRoot ReadTokensAppsettings()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile($"appsettings.json");
                var config = builder.Build();
                return config;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
