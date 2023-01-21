using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class FullHouse : Hand
    {
        public override bool HasHand(List<Card> cards)
        {
            var groups = cards.GroupBy(card => card.Rank)
                .Where(group => group.Count() >= 2);

            if (groups.Count() < 2)
            {
                return false;
            }

            return groups.Any(group => group.Count() >= 3);
        }
    }
}
