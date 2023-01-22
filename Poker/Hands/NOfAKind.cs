using System.Collections.Generic;
using System.Linq;

namespace Poker.Hands
{
    public class NOfAKind : Hand
    {
        public int Count { get; private set; }

        public NOfAKind(int count) 
        {
            Count = count;
        }

        public override bool TryGetHand(List<Card> cards, out List<Card> hand)
        {
            hand = null;

            var highestGroup = cards
                .OrderBy(card => card.Rank)
                .GroupBy(card => card.Rank)
                .FirstOrDefault(group => group.Count() >= Count);

            if (highestGroup!= null) 
            { 
                hand = highestGroup.Take(Count).ToList();
            }

            return hand != null;
        }
    }
}
