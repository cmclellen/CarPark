using CarPark.RateCalculators;
using NUnit.Framework;
using System;
using System.Linq;

namespace CarPark.UnitTests.RateCalculators
{
    [TestFixture]
    public class StandardRateCalculatorTests
    {
        private DateTime StartDate { get; } = new DateTime(2017, 2, 1, 15, 0, 0);

        [Test]
        public void Name_ValidStandardRateCalculator_NamedCorrectly()
        {
            // ARRANGE
            StandardRateCalculator sut = new StandardRateCalculator(StartDate, StartDate);

            // ASSERT
            Assert.AreEqual("Standard Rate", sut.Name);
        }

        [Test]
        public void CalculatePrice_NegativeHours_ThrowsException()
        {
            // ACT
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new StandardRateCalculator(StartDate, StartDate.AddSeconds(-1)));

            // ASSERT
            Assert.That(ex.Message, Is.EqualTo("Start time must be greater or equal to end time.\r\nParameter name: endDateTime"));
            Assert.That(ex.ParamName, Is.EqualTo("endDateTime"));
        }

        [Test]
        public void CalculatePrice_FirstHour_CorrectRate()
        {
            // ARRANGE
            var validHours = new[] { 0.0, .5, .9 };

            // ACT
            var actual = validHours.Select(h => new StandardRateCalculator(StartDate, StartDate.AddHours(h)).CalculatePrice()).ToList();

            // ASSERT
            var expected = 5M;
            Assert.IsTrue(actual.All(i=>i == expected));
        }

        [Test]
        public void CalculatePrice_SecondHour_CorrectRate()
        {
            // ARRANGE
            var validHours = new[] { 1.0, 1.5, 1.9 };

            // ACT
            var actual = validHours.Select(h => new StandardRateCalculator(StartDate, StartDate.AddHours(h)).CalculatePrice()).ToList();

            // ASSERT
            var expected = 10M;
            Assert.IsTrue(actual.All(i => i == expected));
        }

        [Test]
        public void CalculatePrice_ThirdHour_CorrectRate()
        {
            // ARRANGE
            var validHours = new[] { 2.0, 2.5, 2.9 };

            // ACT
            var actual = validHours.Select(h => new StandardRateCalculator(StartDate, StartDate.AddHours(h)).CalculatePrice()).ToList();

            // ASSERT
            var expected = 15M;
            Assert.IsTrue(actual.All(i => i == expected));
        }

        [Test]
        public void CalculatePrice_ThreePlusHours_CorrectRate()
        {
            // ARRANGE
            var validHours = new[] { 3, 9, 18, 27, 36 };

            // ACT
            var actual = validHours.Select(h => new StandardRateCalculator(StartDate, StartDate.AddHours(h)).CalculatePrice()).ToList();

            // ASSERT
            var expected = new[] { 20, 40, 40, 40, 60 }.ToList();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}