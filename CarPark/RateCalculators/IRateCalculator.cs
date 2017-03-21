namespace CarPark.RateCalculators
{
    public interface IRateCalculator
    {
        string RateName { get; }
        CalculateResponse Calculate(CalculateRequest request);
    }
}