using CarPark.Utilities;

namespace CarPark.RateCalculators
{
    public class EarlyBirdRateCalculator : BaseRateCalculator, IRateCalculator
    {
        public EarlyBirdRateCalculator(IRateCalculator successor)
            : base(successor)
        {
        }

        public override string Name
        {
            get { return "Early Bird"; }
        }

        public override CalculateResponse Calculate(CalculateRequest request)
        {
            Guard.NotNull(() => request, request);

            double startHour = (double)request.StartDateTime.Hour + (request.StartDateTime.Minute / 60.0),
                endHour = (double)request.EndDateTime.Hour + (request.EndDateTime.Minute / 60.0);

            var isEligible = (6 <= startHour && startHour < 9)
                && (15.5 <= endHour && endHour < 23.5);
            if (isEligible)
            {
                return new CalculateResponse(Name, 13M);
            }
            return base.Calculate(request);
        }
    }
}