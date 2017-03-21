using CarPark.Utilities;
using System;
using System.Collections.Generic;

namespace CarPark.RateCalculators
{
    public class WeekendRateCalculator : BaseRateCalculator, IRateCalculator
    {
        public WeekendRateCalculator(IRateCalculator successor)
            : base(successor)
        {
        }

        public override string RateName { get; } = "Weekend Rate";

        public override CalculateResponse Calculate(CalculateRequest request)
        {
            Guard.NotNull(() => request, request);

            var startDayOfWeek = request.StartDateTime.DayOfWeek;
            var endDayOfWeek = request.EndDateTime.DayOfWeek;

            var isEligible = new HashSet<DayOfWeek> { request.StartDateTime.DayOfWeek, request.EndDateTime.DayOfWeek }.IsSubsetOf(new HashSet<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday });
            if (isEligible)
            {
                return new CalculateResponse(RateName, 10M);
            }
            return base.Calculate(request);
        }
    }
}