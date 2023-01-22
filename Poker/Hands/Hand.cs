﻿using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public abstract class Hand
    {
        public virtual bool HasHand(List<Card> cards)
        {
            List<Card> hand;

            return TryGetHand(cards, out hand);
        }

        public virtual bool TryGetHand(List<Card> cards, out List<Card> hand)
        {
            hand = null;

            return false;
        }

        public bool TryGetSequence(List<Card> cards, int sequenceLength, out List<Card> hand)
        {
            hand = null;

            var orderedList = cards.OrderBy(c => c.Rank).ToList();

            List<Card> cardsInSequence = new List<Card>();

            for (int index = 0; index < orderedList.Count - 1; index++)
            {
                var card = orderedList[index];
                var nextCard = orderedList[index + 1];

                if (card.Rank + 1 == nextCard.Rank)
                {
                    cardsInSequence.Add(orderedList[index]);
                }
                else if (nextCard.Rank == Rank.Ace && orderedList[0].Rank == Rank.Two)
                {
                    cardsInSequence.Insert(0, nextCard);
                }
                else
                {
                    cardsInSequence.Clear();
                }

                if (cardsInSequence.Count == sequenceLength - 1)
                {
                    hand = cardsInSequence;
                    return true;
                }
            }

            return false;
        }
    }
}
