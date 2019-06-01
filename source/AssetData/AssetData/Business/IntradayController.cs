using AssetData.Model;
using AssetData.Service;
using Newtonsoft.Json;
using System;

namespace AssetData.Business
{
    class IntradayController
    {
        public void IntradayManager()
        {
            Console.WriteLine("\n\nCarregando Intraday...");
            Intraday intraday = new IntradayController().GetAllIntraday();

            //var date = (new DateTime(1970, 1, 1)).AddMilliseconds(double.Parse(intraday.today));

            var time = TimeSpan.FromMilliseconds(intraday.today);
            DateTime startdate = new DateTime(1970, 1, 1) + time;

        }

        public Intraday GetAllIntraday()
        {
            Intraday intraday = new Intraday();
            string urlRequest = new Utils().UrlBuild("API_Access:UrlBase", "API_Access:IntradayService", "484");
            string respApiJson = new ServiceRequester().GetRequest(urlRequest);

            respApiJson = respApiJson.Replace("uolfinancecallback0(", "").Replace(");", "");

            if (!string.IsNullOrEmpty(respApiJson))
            {
                intraday = JsonConvert.DeserializeObject<Intraday>(respApiJson);
            }

            return intraday;
        }
    }
}
