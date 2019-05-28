using System.Net;
using System.Net.Http;

namespace AssetData.Service
{
    class AssetService
    {
        public string GetAllAssetsApi()
        {
            var config = new Utils().ReadTokensAppsettings();
            var _urlBase = config.GetSection("API_Access:UrlBase").Value + "/stock/list?size=10000";

            HttpResponseMessage respApi;
            string respApiJson = string.Empty;

            using (var client = new HttpClient())
            {
                respApi = client.GetAsync(_urlBase).Result;
            }

            if (respApi.StatusCode == HttpStatusCode.OK)
            {
                respApiJson = respApi.Content.ReadAsStringAsync().Result;
            }

            return respApiJson;
        }
    }
}
