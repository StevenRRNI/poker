using NUnit.Framework;
using Poker;

namespace PokerTests
{
    [TestFixture]
    public class PokerScorerTests
    {
        [TestCase("2♠,3♠", "5♠,A♥,K♦,4♠,K♠", "Flush")]
        public void CalculateBestHandShouldReturnBestHand(string hand, string shared, string expectedBestHand)
        {
            var sut = new PokerScorer();

            var result = sut.CalculateBestHand(Cards.Parse(hand), Cards.Parse(shared));

            Assert.AreEqual(expectedBestHand, result);
        }
    }
}