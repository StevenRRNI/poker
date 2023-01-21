using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Hands
{
    public abstract class Hand
    {
        public virtual bool HasHand(List<Card> cards)
        {
            return false;
        }
    }
}
