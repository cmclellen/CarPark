using System;

namespace CarPark.RateCalculators
{
    public class EarlyBirdRateCalculator : IRateCalculator
    {
        public string Name
        {
            get { return "Early Bird"; }
        }

        public CalculatePriceResponse CalculatePrice(CalculatePriceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}