using System;
using System.Collections.Generic;
using Models.Currency;
using Models.DatabaseModels;
using Models.Enams;

namespace BusinessLogic.Interfaces
{
    public interface ICurrencyService : IDisposable
    {
        double TransferOfCurrency(double value, Currency fromWhat, Currency inWhich);
        Rate GetRate(Currency currency);
        double GetProfitability(List<Order> orders);
        double GetNetProfit(List<Order> orders);
    }
}