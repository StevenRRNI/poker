using NUnit.Framework;
using Poker;
using Poker.Hands;
using System;
using System.Collections.Generic;

namespace PokerTests
{
    internal class DeckTests
    {
        /// <summary>
        /// Given a full deck it must always be possible to make a hand
        /// </summary>
        [Test]
        public void DeckReturnsTrueForAllHands()
        {
            List<PlayingCard> cards = new List<PlayingCard>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new PlayingCard(rank, suit));
                }
            }

            Assert.AreEqual(52, cards.Count);

            foreach (Hand hand in PokerScorer.DefaultHandRanking)
            {
                Assert.IsTrue(hand.HasHand(cards), $"Hand '{ hand.GetType().Name }' not found");
            }
        }
    }
}
