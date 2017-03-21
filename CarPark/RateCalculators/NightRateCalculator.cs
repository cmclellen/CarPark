using System;

namespace CarPark.RateCalculators
{
    public class NightRateCalculator : IRateCalculator
    {
        public string Name
        {
            get { return "Night Rate"; }
        }

        public CalculateResponse Calculate(CalculateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}