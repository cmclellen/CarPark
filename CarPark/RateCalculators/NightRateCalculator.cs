using CarPark.Utilities;

namespace CarPark.RateCalculators
{
    public class NightRateCalculator : BaseRateCalculator, IRateCalculator
    {
        public NightRateCalculator(IRateCalculator successor)
            : base(successor)
        {
        }

        public override string Name
        {
            get { return "Night Rate"; }
        }

        public override CalculateResponse Calculate(CalculateRequest request)
        {
            Guard.NotNull(() => request, request);

            int startHour = request.StartDateTime.Hour,
                endHour = request.EndDateTime.Hour;

            int inclMinStartHour = 18,
                exclMaxStartHour = 24,
                exclMaxEndHour = 6;
            int maxEligibleHours = (24 - inclMinStartHour + exclMaxEndHour);
            var dayOfWeek = request.StartDateTime.DayOfWeek;
            var isWeekend = dayOfWeek == System.DayOfWeek.Saturday || dayOfWeek == System.DayOfWeek.Sunday;

            var isEligible =
                !isWeekend &&
                (request.EndDateTime - request.StartDateTime).TotalHours <= maxEligibleHours &&
                (inclMinStartHour <= startHour && startHour < exclMaxStartHour)
                && (endHour < exclMaxEndHour);
            if (isEligible)
            {
                return new CalculateResponse(Name, 6.5M);
            }
            return base.Calculate(request);
        }
    }
}