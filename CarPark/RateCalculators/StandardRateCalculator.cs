using CarPark.Utilities;
using System;

namespace CarPark.RateCalculators
{
    public class StandardRateCalculator : IRateCalculator
    {   
        public string Name
        {
            get { return "Standard Rate"; }
        }

        public CalculatePriceResponse CalculatePrice(CalculatePriceRequest request)
        {
            Guard.NotNull(() => request, request);

            decimal price;
            var totalHours = (request.EndDateTime - request.StartDateTime).TotalHours;
            if (totalHours < 1)
            {
                price = 5M;
            }
            else if (totalHours < 2)
            {
                price = 10M;
            }
            else if (totalHours < 3)
            {
                price = 15M;
            }
            else
            {
                price = 20M * ((request.EndDateTime.Date - request.StartDateTime.Date).Days + 1);
            }
            return new CalculatePriceResponse(Name, price);
        } 
    }
}