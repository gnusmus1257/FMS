using System.Net.Http;
using BusinessLogic.Interfaces;
using Models.Currency;
using Models.Enams;
using Newtonsoft.Json;

namespace BusinessLogic.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _client;

        public CurrencyService(HttpClient client)
        {
            _client = client;
        }

        public float TransferOfCurrency(float value, Currency fromWhat, Currency inWhich)
        {
            throw new System.NotImplementedException();
        }

        public Rate GetRate(Currency currency)
        {
            var uri = $"http://www.nbrb.by/API/ExRates/Rates/{currency}";
            var response = _client.GetStringAsync(uri).Result;
            return JsonConvert.DeserializeObject<Rate>(response);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}