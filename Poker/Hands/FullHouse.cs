using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class FullHouse : Hand
    {
        public override bool TryGetHand(List<Card> cards, out List<Card> hand)
        {
            hand = null;

            var pairs = cards.GroupBy(card => card.Rank)
                .Where(group => group.Count() >= 2);

            if (pairs.Count() < 1)
            {
                return false;
            }

            var triplets = cards.GroupBy(card => card.Rank)
                .Where(group => group.Count() >= 3);

            if (triplets.Count() < 1)
            {
                return false;
            }

            hand = triplets.First().Concat(pairs.First()).ToList();

            return true;
        }
    }
}
