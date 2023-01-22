using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class Flush : Hand
    {
        private const int RequiredCards = 5;

        public override bool TryGetHand(List<Card> cards, out List<Card> hand)
        {
            var flush = cards.GroupBy(card => card.Suit).FirstOrDefault(group => group.Count() >= RequiredCards);

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
