namespace CarPark.RateCalculators
{
    public interface IRateCalculator
    {
        string Name { get; }
        decimal CalculatePrice();
    }
}