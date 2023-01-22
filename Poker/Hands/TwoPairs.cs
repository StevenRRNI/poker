using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class TwoPairs : Hand  
    {
        private int Pair = 2;

        public override bool TryGetHand(List<PlayingCard> cards, out List<PlayingCard> hand)
        {
            hand = null;

            var pairs = cards
                .OrderBy(card => card.Rank)
                .GroupBy(card => card.Rank)
                .Where(group => group.Count() >= Pair);

            if (pairs != null && pairs.Count() >= 2) 
            {
                hand = pairs.SelectMany(pair => pair.Take(2)).ToList();
            }

            return hand != null;
        }
    }
}
