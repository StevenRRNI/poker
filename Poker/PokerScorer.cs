using Poker.Hands;
using System.Collections.Generic;

namespace Poker
{
    public class PokerScorer
    {
        public static List<Hand> DefaultHandRanking = new List<Hand>() 
        {
            new StraightFlush(),
            new FourOfAKind(),
            new FullHouse(),   
            new Straight(),
            new Flush(),
            new ThreeofAKind(),
            new TwoPairs(),
            new Pair(),
        };   

        public string CalculateBestHand(List<Card> own, List<Card> shared)
        {
            List<Card> allCards = new List<Card>();
            allCards.AddRange(own);
            allCards.AddRange(shared);

            foreach (Hand hand in DefaultHandRanking)
            {
                if (hand.HasHand(allCards))
                {
                    return hand.GetType().Name;
                }
            }

            return "HighCard";
        }
    }
}