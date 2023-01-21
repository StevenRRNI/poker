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
    }
}
