using System.Net;
using System.Net.Http;

namespace AssetData.Service
{
    class ServiceRequester
    {
        public string GetRequest(string _urlApi)
        {
            HttpResponseMessage respApi;
            string respApiJson = string.Empty;

            using (var client = new HttpClient())
            {
                respApi = client.GetAsync(_urlApi).Result;
            }

            if (respApi.StatusCode == HttpStatusCode.OK)
            {
                respApiJson = respApi.Content.ReadAsStringAsync().Result;
            }

            return respApiJson;
        }
    }
}