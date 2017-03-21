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
            var actual = Assert.Throws<ArgumentNullException>(() => Guard.NotNull(()=> xxx, xxx));

            // ASSERT
            Assert.That(actual.Message, Is.EqualTo("Cannot be null.\r\nParameter name: xxx"));
            Assert.That(actual.ParamName, Is.EqualTo("xxx"));
        }

    }
}