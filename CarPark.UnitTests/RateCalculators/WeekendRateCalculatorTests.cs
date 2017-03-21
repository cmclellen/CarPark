using CarPark.RateCalculators;
using CarPark.UnitTests.Helpers;
using NUnit.Framework;
using System;
using System.Linq;

namespace CarPark.UnitTests.RateCalculators
{
    [TestFixture]
    public class WeekendRateCalculatorTests
    {
        [SetUp]
        protected void Setup()
        {
            SUT = new WeekendRateCalculator(null);
        }

        private string ExpectedRateName { get; } = "Weekend Rate";
        private WeekendRateCalculator SUT { get; set; }
        private DateTime inclMinStartDateTime = new DateTime(2017, 3, 25);
        private DateTime exclMaxEndDateTime = new DateTime(2017, 3, 27);

        [Test]
        public void Name_ValidWeekendRateCalculator_CorrectRateName()
        {
            // ASSERT
            Assert.AreEqual(ExpectedRateName, SUT.RateName);
        }

        [Test]
        public void Calculate_EligibleStartsAndEndTimes_CorrectPrice()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(inclMinStartDateTime, exclMaxEndDateTime.AddMilliseconds(-1)),
                };

            // ACT
            var responses = requests.Select(i => SUT.Calculate(i)).ToList();

            // ASSERT
            AssertHelpers.AssertCalculateResponses(responses, Enumerable.Repeat(10M, 1).ToList(), ExpectedRateName);
        }

        [Test]
        public void Calculate_EligibleStartTimesButIneligibleEndTimes_NotEligible()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(inclMinStartDateTime, exclMaxEndDateTime),
                };

            // ACT
            var responses = requests.Select(i => SUT.Calculate(i)).ToList();

            // ASSERT
            Assert.IsTrue(responses.All(i => i == null));
        }

        [Test]
        public void Calculate_IneligibleStartTimesButEligibleEndTimes_NotEligible()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(inclMinStartDateTime.AddMilliseconds(-1), exclMaxEndDateTime.AddMilliseconds(-1)),
                };

            // ACT
            var responses = requests.Select(i => SUT.Calculate(i)).ToList();

            // ASSERT
            Assert.IsTrue(responses.All(i => i == null));
        }

        [Test]
        public void Calculate_EligibleStartAndEndTimesOnSameDay_CorrectPrice()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(inclMinStartDateTime, inclMinStartDateTime.AddMinutes(5)),
                };

            // ACT
            var responses = requests.Select(i => SUT.Calculate(i)).ToList();

            // ASSERT
            AssertHelpers.AssertCalculateResponses(responses, Enumerable.Repeat(10M, 1).ToList(), ExpectedRateName);
        }
    }
}