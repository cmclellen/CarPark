using System;

namespace CarPark.RateCalculators
{
    public class RateCalculatorFactory
    {
        public IRateCalculator Create(DateTime startDateTime, DateTime endDateTime)
        {
            return new StandardRateCalculator(startDateTime, endDateTime);
        }
    }
}