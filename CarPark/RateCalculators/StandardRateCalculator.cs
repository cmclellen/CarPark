using System;

namespace CarPark.RateCalculators
{
    public class StandardRateCalculator : IRateCalculator
    {
        public StandardRateCalculator(DateTime startDateTime, DateTime endDateTime)
        {
            if(DateTime.Compare(startDateTime, endDateTime) > 0)
            {
                throw new ArgumentException("Start time must be greater or equal to end time.", "endDateTime");
            }
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        private DateTime StartDateTime { get; set; }
        private DateTime EndDateTime { get; set; }

        public string Name
        {
            get { return "Standard Rate"; }
        }

        public decimal CalculatePrice()
        {
            var totalHours = (EndDateTime - StartDateTime).TotalHours;
            if(totalHours < 1)
            {
                return 5M;
            }
            else if (totalHours < 2)
            {
                return 10M;
            }
            else if (totalHours < 3)
            {
                return 15M;
            }
            return 20M * ((EndDateTime.Date - StartDateTime.Date).Days + 1);
        } 
    }
}