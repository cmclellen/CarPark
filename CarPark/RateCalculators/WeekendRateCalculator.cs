using System;

namespace CarPark.RateCalculators
{
    public class WeekendRateCalculator : IRateCalculator
    {
        public string Name
        {
            get { return "Weekend Rate"; }
        }

        public decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}