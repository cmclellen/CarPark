using CarPark.RateCalculators;
using NUnit.Framework;

namespace CarPark.UnitTests.RateCalculators
{
    [TestFixture]
    public class WeekendRateCalculatorTests
    {
        [SetUp]
        protected void Setup()
        {
            SUT = new WeekendRateCalculator();
        }

        private WeekendRateCalculator SUT { get; set; }

        [Test]
        public void Name_ValidWeekendRateCalculator_CorrectRateName()
        {
            // ASSERT
            Assert.AreEqual("Weekend Rate", SUT.RateName);
        }
    }
}