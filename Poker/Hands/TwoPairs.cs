using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
    public class TwoPairs : Hand  
    {
        public override bool HasHand(List<Card> cards)
        {
            return cards.GroupBy(card => card.Rank)
                .Where(group => group.Count() >= 2)
                .Count() >= 2;
        }
    }
}
