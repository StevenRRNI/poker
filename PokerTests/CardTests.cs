using NUnit.Framework;
using Poker;

namespace PokerTests
{
    internal class CardTests
    {
        // Black unicode suits
        [TestCase("2♠", Rank.Two, Suit.Spades)]
        [TestCase("2♣", Rank.Two, Suit.Clubs)]
        [TestCase("2♦", Rank.Two, Suit.Diamonds)]
        [TestCase("2♥", Rank.Two, Suit.Hearts)]

        // White unicode suits
        [TestCase("2♤", Rank.Two, Suit.Spades)]
        [TestCase("2♧", Rank.Two, Suit.Clubs)]
        [TestCase("2♢", Rank.Two, Suit.Diamonds)]
        [TestCase("2♡", Rank.Two, Suit.Hearts)]

        // Alphabet suits
        [TestCase("2S", Rank.Two, Suit.Spades)]
        [TestCase("2C", Rank.Two, Suit.Clubs)]
        [TestCase("2D", Rank.Two, Suit.Diamonds)]
        [TestCase("2H", Rank.Two, Suit.Hearts)]

        // Ten as its longer than the rest
        [TestCase("10♥", Rank.Ten, Suit.Hearts)]
        [TestCase("10H", Rank.Ten, Suit.Hearts)]
        [TestCase("10♡", Rank.Ten, Suit.Hearts)]

        // Non digit ranks
        [TestCase("J♠", Rank.Jack, Suit.Spades)]
        [TestCase("Q♠", Rank.Queen, Suit.Spades)]
        [TestCase("K♠", Rank.King, Suit.Spades)]
        [TestCase("A♠", Rank.Ace, Suit.Spades)]
        public void ParseReturnsCard(string value, Rank expectedRank, Suit expectedSuit)
        {
            var card = PlayingCard.Parse(value);

            Assert.AreEqual(expectedRank, card.Rank);
            Assert.AreEqual(expectedSuit, card.Suit);
        }
    }
}
