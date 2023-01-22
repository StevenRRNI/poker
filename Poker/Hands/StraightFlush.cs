using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class StraightFlush : Hand
    {
        private const int RequiredCards = 5;

        public override bool TryGetHand(List<Card> cards, out List<Card> hand)
        {
            hand = null;

            var groups = cards.GroupBy(card => card.Suit)
                .Where(group => group.Count() >= RequiredCards);

            foreach (var group in groups)
            {
                var orderedList = group.OrderBy(c => c.Rank).ToList();

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

                    if (cardsInSequence.Count == RequiredCards - 1)
                    {
                        hand = cardsInSequence;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
