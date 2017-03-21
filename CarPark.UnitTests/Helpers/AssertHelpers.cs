using CarPark.RateCalculators;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CarPark.UnitTests.Helpers
{
    public static class AssertHelpers
    {
        internal static void AssertCalculateResponses(IList<CalculateResponse> responses, IList<decimal> expectedPrices, string rateName)
        {
            var actualPrices = responses.Select(i => i.Price).ToList();
            CollectionAssert.AreEqual(expectedPrices, actualPrices);
            Assert.IsTrue(responses.All(i => string.Equals(i.RateName, rateName)));
        }
    }
}