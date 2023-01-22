using NUnit.Framework;
using Poker;
using Poker.Hands;
using System.Collections.Generic;

namespace PokerTests
{
    public class HandTests
    {
        [TestCase("2♥,3♥,4♥,5♥,8♥", true, "2♥,3♥,4♥,5♥,8♥")]
        [TestCase("2♥,3♥,4♥,5♥,8♣", false, "")]
        [TestCase("2♥,3♥,4♥,5♥,8♥,9♥", true, "3♥,4♥,5♥,8♥,9♥")]
        public void TryGetFlushReturnsResult(string cardsString, bool expectedResult, string expectedCards)
        {
            var cards = Cards.Parse(cardsString);

            List<Card> outputCards;

            bool result = new Flush().TryGetHand(cards, out outputCards);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("5♠,5♥", true)] // Different suits
        [TestCase("5♠,5♠", true)] // Same suits
        [TestCase("5♠,A♥", false)] // No match
        [TestCase("5♥,A♥", false)] // Same suits but different ranks
        [TestCase("5♠,5♦,5♥", true)] // Three of a kind but still has a pair
        [TestCase("5♠,5♦,6♥", true)] // Three cards with one pair
        public void HandHasPair(string cardsString, bool expectedResult)
        {
            HandTest(cardsString, expectedResult, new Pair());
        }


        [TestCase("5♠,5♥,4♠,4♥", true)]
        [TestCase("4♠,4♥", false)]
        public void HandHasTwoPair(string cardsString, bool expectedResult)
        {
            HandTest(cardsString, expectedResult, new TwoPairs());
        }

        [TestCase("5♠,5♥,5♦,4♥,3♥", true)]
        public void HandHasThreeOfAKind(string cardsString, bool expectedResult)
        {
            HandTest(cardsString, expectedResult, new ThreeOfAKind());
        }

        [TestCase("2♥,3♥,4♥,5♥,6♥", true)]
        public void HandHasFlush(string cardsString, bool expectedResult)
        {
            HandTest(cardsString, expectedResult, new Flush());
        }

        [TestCase("2♥,3♥,4♦,5♥,6♥", true)]
        public void HandHasStraight(string cardsString, bool expectedResult)
        {
            HandTest(cardsString, expectedResult, new Straight());
        }

        [TestCase("3♦,3♦,4♦,4♥,4♣", true)]
        public void HandHasFullHouse(string cardsString, bool expectedResult)
        {
            HandTest(cardsString, expectedResult, new FullHouse());
        }

        [TestCase("3♦,4♠,4♦,4♥,4♣", true)]
        public void HandHasFourOfAKind(string cardsString, bool expectedResult)
        {
            HandTest(cardsString, expectedResult, new FourOfAKind());
        }

        [TestCase("2♥,3♥,4♥,5♥,6♥", true)]
        [TestCase("2♥,5♥,3♥,4♥,6♥", true)] // Out of order
        [TestCase("9♥,10♥,J♥,Q♥,K♥", true)]
        [TestCase("A♥,2♥,3♥,4♥,5♥", true)] // Ace low
        [TestCase("10♥,J♥,Q♥,K♥,A♥", true)] // Ace high
        [TestCase("2♥,3♥,4♥,5♥,6♥,7♥", true)] // More than 5 cards
        [TestCase("2♥,3♥,4♥,5♥", false)] // Not enough cards
        [TestCase("2♥,3♥,4♠,5♥,7♥", false)] // Not the same suit
        [TestCase("2♥,3♥,4♥,6♥,7♥", false)] // Gap in sequence
        public void HandHasStraightFlush(string cardsString, bool expectedResult)
        {
            HandTest(cardsString, expectedResult, new StraightFlush());
        }

        private void HandTest(string cardsString, bool expectedResult, Hand hand)
        {
            var cards = Cards.Parse(cardsString);

            Assert.AreEqual(hand.HasHand(cards), expectedResult);
        }
    }
}
