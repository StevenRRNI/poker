using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class Flush : Hand
    {
        private const int RequiredCards = 5;

        public override bool TryGetHand(List<PlayingCard> cards, out List<PlayingCard> hand)
        {
            var flush = cards.GroupBy(card => card.Suit).FirstOrDefault(group => group.Count() >= RequiredCards);

            if (flush != null)
            {
                hand =  flush.OrderBy(card => card.Rank).TakeLast(RequiredCards).ToList();
                
                return true;
            }

            hand = null;

            return false;
        }
    }
}
