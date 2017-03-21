using CarPark.RateCalculators;
using CarPark.UnitTests.Helpers;
using NUnit.Framework;
using System;
using System.Linq;

namespace CarPark.UnitTests.RateCalculators
{
    [TestFixture]
    public class StandardRateCalculatorTests
    {
        [SetUp]
        protected void Setup()
        {
            SUT = new StandardRateCalculator();
        }

        private DateTime StartDate { get; } = new DateTime(2017, 2, 1, 15, 0, 0);
        private StandardRateCalculator SUT { get; set; }
        private string ExpectedRateName { get; } = "Standard Rate";

        [Test]
        public void Name_ValidStandardRateCalculator_CorrectRateName()
        {
            // ACT
            SUT.Calculate(new CalculateRequest(StartDate, StartDate));

            // ASSERT
            Assert.AreEqual(ExpectedRateName, SUT.RateName);
        }

        [Test]
        public void Calculate_FirstHour_CorrectRate()
        {
            // ARRANGE
            var endDates = new[] { 0.0, .5, .9 }.Select(i => StartDate.AddHours(i));

            // ACT
            var responses = endDates.Select(i => SUT.Calculate(new CalculateRequest(StartDate, i))).ToList();

            // ASSERT
            AssertHelpers.AssertCalculateResponses(responses, Enumerable.Repeat(5M, 3).ToList(), ExpectedRateName);
        }

        [Test]
        public void Calculate_SecondHour_CorrectRate()
        {
            // ARRANGE
            var endDateTimes = new[] { 1.0, 1.5, 1.9 }.Select(i => StartDate.AddHours(i));

            // ACT
            var responses = endDateTimes.Select(i => SUT.Calculate(new CalculateRequest(StartDate, i))).ToList();

            // ASSERT
            AssertHelpers.AssertCalculateResponses(responses, Enumerable.Repeat(10M, 3).ToList(), ExpectedRateName);
        }

        [Test]
        public void Calculate_ThirdHour_CorrectRate()
        {
            // ARRANGE
            var endDateTimes = new[] { 2.0, 2.5, 2.9 }.Select(i => StartDate.AddHours(i));

            // ACT
            var responses = endDateTimes.Select(i => SUT.Calculate(new CalculateRequest(StartDate, i))).ToList();

            // ASSERT
            AssertHelpers.AssertCalculateResponses(responses, Enumerable.Repeat(15M, 3).ToList(), ExpectedRateName);
        }

        [Test]
        public void Calculate_ThreePlusHours_CorrectRate()
        {
            // ARRANGE
            var endDateTimes = new[] { 3, 9, 18, 27, 36 }.Select(i => StartDate.AddHours(i));

            // ACT
            var responses = endDateTimes.Select(i => SUT.Calculate(new CalculateRequest(StartDate, i))).ToList();

            // ASSERT
            var expectedPrices = new[] { 20M, 40M, 40M, 40M, 60M }.ToList();
            AssertHelpers.AssertCalculateResponses(responses, expectedPrices, ExpectedRateName);
        }
    }
}