using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class Pair : Hand
    {
        public override bool HasHand(List<Card> cards)
        {
            return cards.GroupBy(card => card.Rank).Any(group => group.Count() >= 2);
        }

        public override bool TryGetHand(List<Card> cards, out List<Card> hand)
        {
            hand = cards
                .OrderBy(card => card.Rank)
                .GroupBy(card => card.Rank)
                .FirstOrDefault(group => group.Count() == 2)
                .ToList();

            return hand != null;
        }
    }
}
