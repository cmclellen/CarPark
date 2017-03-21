using CarPark.RateCalculators;
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

        [Test]
        public void Name_ValidStandardRateCalculator_NamedCorrectly()
        {
            // ACT
            SUT.CalculatePrice(new CalculatePriceRequest(StartDate, StartDate));

            // ASSERT
            Assert.AreEqual("Standard Rate", SUT.Name);
        }

        [Test]
        public void CalculatePrice_FirstHour_CorrectRate()
        {
            // ARRANGE
            var endDates = new[] { 0.0, .5, .9 }.Select(i => StartDate.AddHours(i));

            // ACT
            var actual = endDates.Select(i => SUT.CalculatePrice(new CalculatePriceRequest(StartDate, i))).ToList();

            // ASSERT
            var expected = 5M;
            Assert.IsTrue(actual.All(i => i.Price == expected));
        }
        
        [Test]
        public void CalculatePrice_SecondHour_CorrectRate()
        {
            // ARRANGE
            var endDateTimes = new[] { 1.0, 1.5, 1.9 }.Select(i=> StartDate.AddHours(i));

            // ACT
            var actual = endDateTimes.Select(i => SUT.CalculatePrice(new CalculatePriceRequest(StartDate, i))).ToList();

            // ASSERT
            var expected = 10M;
            Assert.IsTrue(actual.All(i => i.Price == expected));
        }

        [Test]
        public void CalculatePrice_ThirdHour_CorrectRate()
        {
            // ARRANGE
            var endDateTimes = new[] { 2.0, 2.5, 2.9 }.Select(i => StartDate.AddHours(i));

            // ACT
            var actual = endDateTimes.Select(i => SUT.CalculatePrice(new CalculatePriceRequest(StartDate, i))).ToList();

            // ASSERT
            var expected = 15M;
            Assert.IsTrue(actual.All(i => i.Price == expected));
        }

        [Test]
        public void CalculatePrice_ThreePlusHours_CorrectRate()
        {
            // ARRANGE
            var endDateTimes = new[] { 3, 9, 18, 27, 36 }.Select(i => StartDate.AddHours(i));

            // ACT
            var responses = endDateTimes.Select(i => SUT.CalculatePrice(new CalculatePriceRequest(StartDate, i))).ToList();

            // ASSERT
            var expected = new[] { 20, 40, 40, 40, 60 }.ToList();
            var actual = responses.Select(i => i.Price).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}