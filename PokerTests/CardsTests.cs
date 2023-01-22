using NUnit.Framework;
using Poker;

namespace PokerTests
{
    public class CardsTests
    {
        [TestCase("2♠,3♠,2♦,3♦", 2, 2, 6)]
        [TestCase("2♠,3♠,2♦,3♦", 1, 1, 4)]
        [TestCase("2♠,3♠,2♦,3♦", 1, 2, 10)]
        [TestCase("2♠,3♠,2♦,3♦", 1, 4, 15)]
        [TestCase("2♠,3♠,2♦,3♦", 0, 4, 16)]
        [TestCase("2♠,3♠,2♦,3♦", 4, 4, 1)]
        [TestCase("2♠,3♠,2♦,3♦", 4, 5, 1)]
        [TestCase("2♠,3♠,2♦,3♦", -1, 5, 16)]
        public void GenerateCombinationsReturnsExpectedResult(string hand, int minCards, int maxCards, int expectedCount)
        {
            var combinations = Cards.Parse(hand).GenerateCombinations(minCards, maxCards);

            Assert.AreEqual(expectedCount, combinations.Count);
        }
    }
}
