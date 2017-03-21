using CarPark.Utilities;

namespace CarPark.RateCalculators
{
    public class CalculateResponse
    {
        public CalculateResponse(string rateName, decimal price)
        {
            Guard.NotNullOrEmpty(() => rateName, rateName);
            this.RateName = rateName;
            this.Price = price;
        }

        public string RateName { get; }
        public decimal Price { get; }
    }
}