using System.Configuration;
using RestSharp;

namespace TestableApplication
{
    public class CurrencyService : ICurrencyService
    {
        public CurrencyData GetLatest()
        {
            var client = new RestClient("http://data.fixer.io/api/");

            var request = new RestRequest("latest");
            request.AddQueryParameter("access_key", ConfigurationManager.AppSettings["FixerApiKey"]);

            var result = client.Execute<CurrencyData>(request);

            return result.Data;
        }
    }
}