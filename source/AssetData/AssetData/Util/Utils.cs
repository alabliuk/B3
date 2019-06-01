﻿using Microsoft.Extensions.Configuration;
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
    }
}
