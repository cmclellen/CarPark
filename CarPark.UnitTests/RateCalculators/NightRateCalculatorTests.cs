using CarPark.RateCalculators;
using CarPark.UnitTests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPark.UnitTests.RateCalculators
{
    [TestFixture]
    public class NightRateCalculatorTests
    {
        [SetUp]
        protected void Setup()
        {
            SUT = new NightRateCalculator(null);
        }

        private DateTime EnclMinStartDateTime = new DateTime(2017, 3, 21, 18, 0, 0);
        private DateTime ExclMaxStartDateTime = new DateTime(2017, 3, 22, 0, 0, 0);
        private DateTime ExclMaxEndDateTime = new DateTime(2017, 3, 22, 6, 0, 0);
        private string ExpectedRateName { get; } = "Night Rate";
        private NightRateCalculator SUT { get; set; }

        [Test]
        public void Name_ValidNightRateCalculator_CorrectRateName()
        {
            // ASSERT
            Assert.AreEqual(ExpectedRateName, SUT.RateName);
        }
        
        [Test]
        public void Name_EligibleTimesOnWeekdays_CorrectPrice()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(EnclMinStartDateTime, ExclMaxEndDateTime.AddMilliseconds(-1)),
                    new CalculateRequest(ExclMaxStartDateTime.AddMilliseconds(-1), ExclMaxEndDateTime.AddMilliseconds(-1)),
                };

            // ACT
            var responses = requests.Select(i => SUT.Calculate(i)).ToList();

            // ASSERT
            AssertHelpers.AssertCalculateResponses(responses, Enumerable.Repeat(6.5M, 2).ToList(), ExpectedRateName);
        }

        [Test]
        public void Name_EligibleStartTimesButIneligibleEndTimesOnWeekdays_NotEligible()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(EnclMinStartDateTime, ExclMaxEndDateTime),
                    new CalculateRequest(ExclMaxStartDateTime.AddMilliseconds(-1), ExclMaxEndDateTime),
                };

            // ACT
            var responses = requests.Select(i => SUT.Calculate(i)).ToList();

            // ASSERT
            Assert.IsTrue(responses.All(i => i == null));
        }

        [Test]
        public void Name_IneligibleStartTimesButEligibleEndTimesOnWeekdays_NotEligible()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(EnclMinStartDateTime.AddMilliseconds(-1), ExclMaxEndDateTime.AddMilliseconds(-1)),
                    new CalculateRequest(ExclMaxStartDateTime, ExclMaxEndDateTime.AddMilliseconds(-1)),
                };

            // ACT
            var responses = requests.Select(i => SUT.Calculate(i)).ToList();

            // ASSERT
            Assert.IsTrue(responses.All(i => i == null));
        }

        [Test]
        public void Name_EligibleTimesOnWeekdaysExceptDurationIsMoreThanADay_NotEligible()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(EnclMinStartDateTime, ExclMaxEndDateTime.AddMilliseconds(-1).AddDays(1)),
                    new CalculateRequest(ExclMaxStartDateTime.AddMilliseconds(-1), ExclMaxEndDateTime.AddMilliseconds(-1).AddDays(1)),
                };

            // ACT
            var responses = requests.Select(i => SUT.Calculate(i)).ToList();

            // ASSERT
            Assert.IsTrue(responses.All(i => i == null));
        }

        [Test]
        public void Name_EligibleTimesOnNonWeekdays_NotEligible()
        {
            // ARRANGE
            var requests =
                new[]
                {
                    new CalculateRequest(EnclMinStartDateTime.AddDays(-2), ExclMaxEndDateTime.AddMilliseconds(-1).AddDays(-2)),
                    new CalculateRequest(ExclMaxStartDateTime.AddMilliseconds(-1).AddDays(-2), ExclMaxEndDateTime.AddMilliseconds(-1).AddDays(-2)),
                };

            // ACT
            var responses = requests.Select(i => SUT.Calculate(i)).ToList();

            // ASSERT
            Assert.IsTrue(responses.All(i => i == null));
        }
    }
}