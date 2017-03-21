using CarPark.RateCalculators;
using NUnit.Framework;
using System;

namespace CarPark.UnitTests.RateCalculators
{
    [TestFixture]
    public class CalculatePriceRequestTests
    {
        private DateTime StartDate { get; } = new DateTime(2017, 2, 1, 15, 0, 0);

        [Test]
        public void ctor_EndDateTimeEarlierThanStartDateTime_ThrowsException()
        {
            // ACT
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new CalculatePriceRequest(StartDate, StartDate.AddSeconds(-1)));

            // ASSERT
            Assert.That(ex.Message, Is.EqualTo("Start time must be greater or equal to end time.\r\nParameter name: endDateTime"));
            Assert.That(ex.ParamName, Is.EqualTo("endDateTime"));
        }
    }
}