using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using BusinessLogic.Interfaces;
using Models.Currency;
using Models.DatabaseModels;
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

        public double TransferOfCurrency(double value, Currency fromWhat, Currency inWhich)
        {
            return fromWhat == Currency.BelarusianRuble
                ? TransferOfCurrencyFromBelRub(value, fromWhat, inWhich)
                : TransferOfCurrencyToBelRub(value, fromWhat, inWhich);
        }

        public Rate GetRate(Currency currency)
        {
            var uri = $"http://www.nbrb.by/API/ExRates/Rates/{currency}";
            var response = _client.GetStringAsync(uri).Result;
            return JsonConvert.DeserializeObject<Rate>(response);
        }

        public double GetProfitability(List<Order> orders)
        {
            return GetNetProfit(orders) / orders.Where(x => x.Status == OrderStatus.Completed)
                       .Sum(order => order.Coast);
        }

        public double GetNetProfit(List<Order> orders)
        {
            return orders.Where(x => x.Status == OrderStatus.Completed)
                .Sum(order => order.Coast - order.DealerInterest - order.PrimeCost);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        private double TransferOfCurrencyFromBelRub(double value, Currency fromWhat, Currency inWhich)
        {
            var rate = GetRate(inWhich);
            return value / rate.CurOfficialRate * rate.CurScale;
        }

        private double TransferOfCurrencyToBelRub(double value, Currency fromWhat, Currency inWhich)
        {
            var rate = GetRate(fromWhat);
            return value / rate.CurScale * rate.CurOfficialRate;
        }
    }
}