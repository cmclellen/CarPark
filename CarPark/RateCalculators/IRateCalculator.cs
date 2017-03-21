namespace CarPark.RateCalculators
{
    public interface IRateCalculator
    {
        string Name { get; }
        CalculateResponse Calculate(CalculateRequest request);
    }
}