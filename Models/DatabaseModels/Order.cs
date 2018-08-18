using System;

namespace Models.DatabaseModels
{
    public class Order
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Customer Customer { get; set; }
        public Contractor Contractor { get; set; }
        public DateTime Date { get; set; }
        public double Coast { get; set; }
        public double PrimeCost { get; set; }
        public decimal DealerInterestInPercents { private get; set; }
        public double DealerInterestInCurrency { private get; set; }
        public double DealerInterest { get; set; }
        public Enams.Currency Currency { get; set; }
        public Enams.OrderStatus Status { get; set; }

        private double GetDealerInterest()
        {
            return DealerInterestInPercents != null && DealerInterestInPercents != 0
                ? Coast / 100 * (double) DealerInterestInPercents
                : DealerInterestInCurrency;
        }
    }
}