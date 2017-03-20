using System;

namespace CarPark.RateCalculators
{
    public class NightRateCalculator : IRateCalculator
    {
        public string Name
        {
            get { return "Night Rate"; }
        }

        public decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}