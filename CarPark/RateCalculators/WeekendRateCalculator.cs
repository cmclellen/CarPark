using System;

namespace CarPark.RateCalculators
{
    public class WeekendRateCalculator : IRateCalculator
    {
        public string Name
        {
            get { return "Weekend Rate"; }
        }

        public CalculateResponse Calculate(CalculateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}