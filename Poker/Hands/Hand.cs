using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public abstract class Hand
    {
        public virtual bool HasHand(List<PlayingCard> cards)
        {
            List<PlayingCard> hand;

            return TryGetHand(cards, out hand);
        }

        public abstract bool TryGetHand(List<PlayingCard> cards, out List<PlayingCard> hand);

        public bool TryGetSequence(List<PlayingCard> cards, int sequenceLength, out List<PlayingCard> hand)
        {
            hand = null;

            var orderedList = cards.OrderBy(c => c.Rank).ToList();

            List<PlayingCard> cardsInSequence = new List<PlayingCard>();

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
