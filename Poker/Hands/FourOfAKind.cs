using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class FourOfAKind : Hand
    {
        public override bool HasHand(List<Card> cards)
        {
            return cards.GroupBy(card => card.Rank).Any(group => group.Count() >= 4);
        }

        public override bool TryGetHand(List<Card> cards, out List<Card> hand)
        {
            hand = cards.GroupBy(card => card.Rank).FirstOrDefault(group => group.Count() >= 4).ToList();

            if (hand != null)
            {
                return true;
            }

            return false;
        }
    }
}
