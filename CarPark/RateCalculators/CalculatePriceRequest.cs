using System;

namespace CarPark.RateCalculators
{
    public class CalculatePriceRequest
    {
        public CalculatePriceRequest(DateTime startDateTime, DateTime endDateTime)
        {
            if (DateTime.Compare(startDateTime, endDateTime) > 0)
            {
                throw new ArgumentException("Start time must be greater or equal to end time.", "endDateTime");
            }
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
    }
}