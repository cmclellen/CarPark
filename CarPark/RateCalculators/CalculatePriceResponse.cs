using CarPark.Utilities;

namespace CarPark.RateCalculators
{
    public class CalculatePriceResponse
    {
        public CalculatePriceResponse(string rateName, decimal price)
        {
            Guard.NotNullOrEmpty(rateName);
            this.RateName = rateName;
            this.Price = price;
        }

        public string RateName { get; }
        public decimal Price { get; }
    }
}