using System.Net;
using System.Net.Http;

namespace AssetData.Service
{
    class IntradayService
    {
        public string GetIntraday()
        {
            var config = new Utils().ReadTokensAppsettings();
            var _urlBase = config.GetSection("API_Access:UrlBase").Value + "/484/intraday?size=3&callback=uolfinancecallback0";

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
