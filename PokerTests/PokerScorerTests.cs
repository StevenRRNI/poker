using NUnit.Framework;
using Poker;
using Poker.Hands;
using System.Collections.Generic;
using System.Linq;

namespace PokerTests
{
    [TestFixture]
    public class PokerScorerTests
    {
        [TestCase("2♠,3♠", "5♠,A♥,K♦,4♠,K♠", "TexasHoldEm", "Flush")]
        [TestCase("2♠,3♦", "5♠,A♠,K♠,4♠,K♦", "TexasHoldEm", "Straight")] // Flush under normal rules but must use two means a straight
        [TestCase("2♠,3♦,2♣,3♣", "5♠,A♠,K♠,4♠,K♦", "Omaha", "Straight")] // Not a flush because two hole cards must be used
        [TestCase("4♠,4♦,4♣,4♥", "5♠,A♠,Q♠,6♠,K♦", "Omaha", "Pair")] // Can only use two hole cards which rules out four of a kind
        public void CalculateBestHandShouldReturnBestHand(string hand, string shared, string variant, string expectedBestHand)
        {
            var sut = new PokerScorer();

            var handCards = PlayingCards.Parse(hand);
            var sharedCards = PlayingCards.Parse(shared);

            // Sanity check for tests but could be part of validation in scorer
            bool hasDuplicates = handCards
                .Concat(sharedCards)
                .GroupBy(card => card.ToString())
                .Any(group => group.Count() > 1);

            Assert.IsFalse(hasDuplicates, "Duplicate cards found");

            var result = sut.CalculateBestHand(PlayingCards.Parse(hand), PlayingCards.Parse(shared), PokerVariant.Parse(variant));

            Assert.AreEqual(expectedBestHand, result);
        }

        [TestCase("2♠,3♠", "5♠,A♥,Q♦,4♠,K♠", "TexasHoldEm", "HighCard")] // Flush under normal rules but no pairs
        [TestCase("2♠,3♦", "5♠,A♠,K♠,4♠,3♦", "TexasHoldEm", "Pair")]
        public void CalculateBestHandWithCustomRankingsShouldReturnBestHand(string hand, string shared, string variant, string expectedBestHand)
        {
            List<Hand> rankings = new List<Hand>()
            {
                new Pair(),
            };

            var sut = new PokerScorer(rankings);

            var result = sut.CalculateBestHand(PlayingCards.Parse(hand), PlayingCards.Parse(shared), PokerVariant.Parse(variant));

            Assert.AreEqual(expectedBestHand, result);
        }

        [TestCase("J♠,K♠", "5♠,Q♥,Q♦,Q♠,3♠", "TexasHoldEm", "Royalty")]
        public void CalculateBestHandWithCustomHandShouldReturnBestHand(string hand, string shared, string variant, string expectedBestHand)
        {
            List<Hand> rankings = new List<Hand>(PokerScorer.DefaultHandRanking);

            rankings.Insert(0, new Royalty());

            var sut = new PokerScorer(rankings);

            var result = sut.CalculateBestHand(PlayingCards.Parse(hand), PlayingCards.Parse(shared), PokerVariant.Parse(variant));

            Assert.AreEqual(expectedBestHand, result);
        }

        public class Royalty : Hand
        {
            public override bool TryGetHand(List<PlayingCard> cards, out List<PlayingCard> hand)
            {
                hand = null;

                var royals = cards.Where(card => card.Rank == Rank.Queen || card.Rank == Rank.Jack || card.Rank == Rank.King);

                if (royals.Count() >= 5)
                {
                    hand = royals.Take(5).ToList();

                    return true;
                }

                return false;
            }
        }
    }
}