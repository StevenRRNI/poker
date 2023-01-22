﻿using Poker.Hands;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerScorer
    {
        public static List<Hand> DefaultHandRanking = new List<Hand>() 
        {
            new StraightFlush(),
            new FourOfAKind(),
            new FullHouse(),
            new Flush(),
            new Straight(),  
            new ThreeOfAKind(),
            new TwoPairs(),
            new Pair(),
        };   

        public string CalculateBestHand(List<Card> own, List<Card> shared, PokerVariant variant)
        {
            Hand bestHand = null;

            var ownHandCombinations = own.GenerateCombinations(variant.RequiredHoleCards, variant.RequiredHoleCards);

            var sharedHandCombinations = shared.GenerateCombinations(5 - variant.RequiredHoleCards, 5 - variant.RequiredHoleCards);

            foreach (var ownHandCombination in ownHandCombinations)
            {
                foreach (var sharedHandCombination in sharedHandCombinations)
                {
                    var combination = ownHandCombination.Concat(sharedHandCombination).ToList();

                    foreach (Hand hand in DefaultHandRanking)
                    {
                        if (hand.HasHand(combination))
                        {
                            if (bestHand == null || 
                                DefaultHandRanking.IndexOf(hand) < DefaultHandRanking.IndexOf(bestHand))
                            {
                                bestHand = hand;
                            }
                        }
                    }
                }
            }

            return bestHand == null ? "HighCard" : bestHand.GetType().Name;
        }
    }
}