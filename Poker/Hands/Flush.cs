using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class Flush : Hand
    {
        public override bool HasHand(List<Card> cards)
        {
            return cards.GroupBy(card => card.Suit).Any(group => group.Count() >= 5);
        }

        public override bool TryGetHand(List<Card> cards, out List<Card> hand)
        {
            var flush = cards.GroupBy(card => card.Suit).FirstOrDefault(group => group.Count() >= 5);

            if (flush != null)
            {
                hand =  flush.OrderByDescending(card => card.Rank).Take(5).ToList();
                
                return true;
            }

            hand = null;

            return false;
        }
    }
}
