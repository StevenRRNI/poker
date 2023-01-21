using NUnit.Framework;
using Poker;

namespace ScorerTests
{
    [TestFixture]
    public class PokerScorerTests
    {
        [TestCase("2♠,3♠", "5♠,A♥,K♦,4♠,K♠", "Flush")]
        public void AddShouldReturnSumOfTwoIntegers(string hand, string shared, string expectedBestHand)
        {
            var sut = new PokerScorer();

            var result = sut.Add(2, 3);

            Assert.AreEqual(5, result);
        }
    }
}