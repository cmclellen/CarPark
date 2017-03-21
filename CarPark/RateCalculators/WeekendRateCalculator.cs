using System;

namespace CarPark.RateCalculators
{
    public class WeekendRateCalculator : IRateCalculator
    {
        public string Name
        {
            get { return "Weekend Rate"; }
        }

        public CalculatePriceResponse CalculatePrice(CalculatePriceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}