﻿using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class Flush : Hand
    {
        public override bool HasHand(List<Card> cards)
        {
            return cards.GroupBy(card => card.Suit).Any(group => group.Count() >= 5);
        }
    }
}
