using System;
using Models.Currency;
using Models.Enams;

namespace BusinessLogic.Interfaces
{
    public interface ICurrencyService : IDisposable
    {
        double TransferOfCurrency(double value, Currency fromWhat, Currency inWhich);
        Rate GetRate(Currency currency);
    }
}