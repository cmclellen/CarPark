using CarPark.Utilities;
using NUnit.Framework;
using System;

namespace CarPark.UnitTests.Utilities
{
    [TestFixture]
    public class GuardTests
    {
        [Test]
        public void NotNull_NullInput_ThrowsException()
        {
            // ARRANGE
            object xxx = null;

            // ACT
            var actual = Assert.Throws<ArgumentNullException>(() => Guard.NotNull(() => xxx, xxx));

            // ASSERT
            Assert.That(actual.Message, Is.EqualTo("Cannot be null.\r\nParameter name: xxx"));
            Assert.That(actual.ParamName, Is.EqualTo("xxx"));
        }

        [Test]
        public void NotNull_NonNullInput_NoExceptionThrown()
        {
            // ARRANGE
            object xxx = new object();

            // ACT
            Guard.NotNull(() => xxx, xxx);

            // ASSERT
            Assert.Pass();
        }

        [Test]
        public void NotNullOrEmpty_NullInput_ThrowsException()
        {
            // ARRANGE
            string xxx = null;

            // ACT
            var actual = Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty(() => xxx, xxx));

            // ASSERT
            Assert.That(actual.Message, Is.EqualTo("Cannot be null.\r\nParameter name: xxx"));
            Assert.That(actual.ParamName, Is.EqualTo("xxx"));
        }

        [Test]
        public void NotNullOrEmpty_EmptyStringInput_ThrowsException()
        {
            // ARRANGE
            string xxx = String.Empty;

            // ACT
            var actual = Assert.Throws<ArgumentException>(() => Guard.NotNullOrEmpty(() => xxx, xxx));

            // ASSERT
            Assert.That(actual.Message, Is.EqualTo("Cannot be an empty string.\r\nParameter name: xxx"));
            Assert.That(actual.ParamName, Is.EqualTo("xxx"));
        }

        [Test]
        public void NotNullOrEmpty_NonEmptyStringInput_NoExceptionThrown()
        {
            // ARRANGE
            string xxx = "xxx";

            // ACT
            Guard.NotNullOrEmpty(() => xxx, xxx);

            // ASSERT
            Assert.Pass();
        }
    }
}