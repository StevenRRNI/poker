using NUnit.Framework;
using Poker;
using System.Linq;

namespace PokerTests
{
    [TestFixture]
    public class PokerScorerTests
    {
        [TestCase("2♠,3♠", "5♠,A♥,K♦,4♠,K♠", "TexasHoldEm", "Flush")]
        [TestCase("2♠,3♦", "5♠,A♠,K♠,4♠,K♦", "TexasHoldEm", "Straight")] // Flush under normal rules but must use two means a straight
        [TestCase("2♠,3♦,2♣,3♣", "5♠,A♠,K♠,4♠,K♦", "Omaha", "Straight")]
        public void CalculateBestHandShouldReturnBestHand(string hand, string shared, string variant, string expectedBestHand)
        {
            var sut = new PokerScorer();

            var handCards = Cards.Parse(hand);
            var sharedCards = Cards.Parse(shared);

            // Sanity check for tests but could be part of validation in scorer
            bool hasDuplicates = handCards
                .Concat(sharedCards)
                .GroupBy(card => card.ToString())
                .Any(group => group.Count() > 1);

            Assert.IsFalse(hasDuplicates, "Duplicate cards found");

            var result = sut.CalculateBestHand(Cards.Parse(hand), Cards.Parse(shared), PokerVariants.Parse(variant));

            Assert.AreEqual(expectedBestHand, result);
        }
    }
}