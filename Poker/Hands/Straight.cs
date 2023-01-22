using System.Collections.Generic;

namespace Poker.Hands
{
    public class Straight : Hand
    {
        private const int RequiredCards = 5;

        public override bool TryGetHand(List<PlayingCard> cards, out List<PlayingCard> hand)
        {
            return TryGetSequence(cards, RequiredCards,out hand);
        }
    }
}
