namespace CarPark.RateCalculators
{
    public interface IRateCalculator
    {
        string Name { get; }
        CalculatePriceResponse CalculatePrice(CalculatePriceRequest request);
    }
}