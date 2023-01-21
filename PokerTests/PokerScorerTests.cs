using NUnit.Framework;
using Poker;

namespace ScorerTests
{
    [TestFixture]
    public class PokerScorerTests
    {
        [Test]
        public void AddShouldReturnSumOfTwoIntegers()
        {
            var sut = new PokerScorer();

            var result = sut.Add(2, 3);

            Assert.AreEqual(5, result);
        }
    }
}