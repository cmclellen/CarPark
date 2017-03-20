using System;

namespace CarPark.RateCalculators
{
    public class EarlyBirdRateCalculator : IRateCalculator
    {
        public string Name
        {
            get { return "Early Bird"; }
        }

        public decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}