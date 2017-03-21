namespace CarPark.RateCalculators
{
    public abstract class BaseRateCalculator : IRateCalculator
    {
        public BaseRateCalculator(IRateCalculator successor)
        {
            Successor = successor;
        }

        public abstract string RateName { get; }

        private IRateCalculator Successor { get; set; }

        public virtual CalculateResponse Calculate(CalculateRequest request)
        {
            if (Successor != null)
            {
                return Successor.Calculate(request);
            }
            return null;
        }
    }
}