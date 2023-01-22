using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class StraightFlush : Hand
    {
        private const int RequiredCards = 5;

        public override bool TryGetHand(List<PlayingCard> cards, out List<PlayingCard> hand)
        {
            hand = null;

            var groups = cards.GroupBy(card => card.Suit)
                .Where(group => group.Count() >= RequiredCards);

            foreach (var group in groups)
            {
                if (TryGetSequence(cards, RequiredCards, out hand)) 
                {
                    return true;
                }
            }

            return false;
        }
    }
}
