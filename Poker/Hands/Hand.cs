using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Hands
{
    public abstract class Hand
    {
        public virtual bool HasHand(List<Card> cards)
        {
            List<Card> hand;

            return TryGetHand(cards, out hand);
        }

        public virtual bool TryGetHand(List<Card> cards, out List<Card> hand)
        {
            hand = null;

            return false;
        }
    }
}
