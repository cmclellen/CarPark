using System;

namespace CarPark.RateCalculators
{
    public class WeekendRateCalculator : IRateCalculator
    {
        public string RateName { get; } = "Weekend Rate";

        public CalculateResponse Calculate(CalculateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}