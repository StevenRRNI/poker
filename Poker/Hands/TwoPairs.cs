using System.Collections.Generic;
using System.Linq;

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

        public override bool TryGetHand(List<Card> cards, out List<Card> hand)
        {
            hand = null;

            var pairs = cards
                .OrderBy(card => card.Rank)
                .GroupBy(card => card.Rank)
                .FirstOrDefault(group => group.Count() == 2)
                .ToList();

            if (pairs.Count >= 2) 
            {
                hand = pairs.Take(2).ToList();
            }

            return hand != null;
        }
    }
}
