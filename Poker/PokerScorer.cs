using Poker.Hands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerScorer
    {
        private const int HandSize = 5;

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

        private List<Hand> _rankings;

        private PokerVariant _variant;

        public PokerScorer(PokerVariant variant) : this (variant, DefaultHandRanking)
        {      
        }

        public PokerScorer(PokerVariant variant, List<Hand> rankings) 
        {
            _variant = variant;
            _rankings = rankings;
        }

        public string CalculateBestHand(List<PlayingCard> own, List<PlayingCard> shared)
        {
            AssertNoDuplicates(own, shared);

            Hand bestHand = null;

            // Calculates all possible 5 card hands base on the variants rules and finds all possible rankings to return the 
            // highest ranking hand
            //
            // Its very likely this has room for optimization as the rules would mean once some hands are found others are
            // ruled out.
            var ownHandCombinations = own.GenerateCombinations(_variant.RequiredHoleCards, _variant.RequiredHoleCards);

            var sharedHandCombinations = shared.GenerateCombinations(HandSize - _variant.RequiredHoleCards, HandSize - _variant.RequiredHoleCards);

            foreach (var ownHandCombination in ownHandCombinations)
            {
                foreach (var sharedHandCombination in sharedHandCombinations)
                {
                    var combination = ownHandCombination.Concat(sharedHandCombination).ToList();

                    foreach (Hand hand in _rankings)
                    {
                        if (hand.HasHand(combination))
                        {
                            if (bestHand == null ||
                                _rankings.IndexOf(hand) < _rankings.IndexOf(bestHand))
                            {
                                bestHand = hand;
                            }
                        }
                    }
                }
            }

            return bestHand == null ? "HighCard" : bestHand.GetType().Name;
        }

        private void AssertNoDuplicates(List<PlayingCard> own, List<PlayingCard> shared)
        {
            // Sanity check for tests but could be part of validation in scorer
            bool hasDuplicates = own
                .Concat(shared)
                .GroupBy(card => card.ToString())
                .Any(group => group.Count() > 1);

            if (hasDuplicates)
            {
                throw new ArgumentException("Duplicate cards found");
            }
        }
    }
}