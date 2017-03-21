using System;

namespace CarPark.RateCalculators
{
    public class NightRateCalculator : IRateCalculator
    {
        public string Name
        {
            get { return "Night Rate"; }
        }

        public CalculatePriceResponse CalculatePrice(CalculatePriceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}