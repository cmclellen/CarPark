using CarPark.RateCalculators;
using NUnit.Framework;
using System;
using System.Linq;

namespace CarPark.UnitTests.RateCalculators
{
    [TestFixture]
    public class EarlyBirdRateCalculatorTests
    {
        [SetUp]
        protected void Setup()
        {
            SUT = new EarlyBirdRateCalculator(null);
        }

        private DateTime IncMinStartDateTime { get; } = new DateTime(2017, 3, 21, 6, 0, 0);
        private DateTime ExclMaxStartDateTime { get; } = new DateTime(2017, 3, 21, 9, 0, 0);
        private DateTime IncMinEndDateTime { get; } = new DateTime(2017, 3, 21, 15, 30, 0);
        private DateTime ExclMaxEndDateTime { get; } = new DateTime(2017, 3, 21, 23, 30, 0);
        private EarlyBirdRateCalculator SUT { get; set; }

        [Test]
        public void Name_ValidEarlyBirdRateCalculator_NamedCorrectly()
        {
            // ASSERT
            Assert.AreEqual("Early Bird", SUT.Name);
        }

        [Test]
        public void Calculate_EligibleStartTimeAndEligibleEndTime_CorrectPrice()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(IncMinStartDateTime, IncMinEndDateTime),
                    new CalculateRequest(ExclMaxStartDateTime.AddMilliseconds(-1), ExclMaxEndDateTime.AddMilliseconds(-1)),
                };

            // ACT
            var actual = requests.Select(request => SUT.Calculate(request)).ToList();

            // ASSERT
            Assert.IsTrue(actual.All(i => i.Price == 13M));
        }

        [Test]
        public void Calculate_EligibleStartTimeAndIneligibleEndTime_()
        {
            // ARRANGE
            var request = new CalculateRequest(IncMinStartDateTime, ExclMaxEndDateTime);

            // ACT
            var actual = SUT.Calculate(request);

            // ASSERT
            Assert.IsNull(actual);
        }
    }
}