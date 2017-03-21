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
        public void Name_ValidEarlyBirdRateCalculator_CorrectRateName()
        {
            // ASSERT
            Assert.AreEqual("Early Bird", SUT.RateName);
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
            var responses = requests.Select(request => SUT.Calculate(request)).ToList();

            // ASSERT
            Assert.IsTrue(responses.All(i => i.Price == 13M));
            Assert.IsTrue(responses.All(i => string.Equals(i.RateName, "Early Bird")));
        }

        [Test]
        public void Calculate_EligibleStartTimeButIneligibleEndTime_NotEligible()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(IncMinStartDateTime, IncMinEndDateTime.AddMilliseconds(-1)),
                    new CalculateRequest(ExclMaxStartDateTime.AddMilliseconds(-1), ExclMaxEndDateTime),
                };

            // ACT
            var responses = requests.Select(i=>SUT.Calculate(i)).ToList();

            // ASSERT
            Assert.IsTrue(responses.All(i => i == null));
        }

        [Test]
        public void Calculate_IneligibleStartTimeButEligibleEndTime_NotEligible()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(IncMinStartDateTime.AddMilliseconds(-1), IncMinEndDateTime),
                    new CalculateRequest(ExclMaxStartDateTime, ExclMaxEndDateTime.AddMilliseconds(-1)),
                };

            // ACT
            var responses = requests.Select(i => SUT.Calculate(i)).ToList();

            // ASSERT
            Assert.IsTrue(responses.All(i => i == null));
        }
    }
}