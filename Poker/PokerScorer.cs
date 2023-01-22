using Poker.Hands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerScorer
    {
        private const int HandSize = 5;

        /// <summary>
        /// Standard list of poker rankings with strongest hand first
        /// </summary>
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

        /// <summary>
        /// Scores poker hands using the default rankings and supplied variant
        /// </summary>
        /// <param name="variant">Variant of Poker to be used when calculating hand</param>
        public PokerScorer(PokerVariant variant) : this (variant, DefaultHandRanking)
        {      
        }

        /// <summary>
        /// Scores poker hands using the supplied variant and ranking list
        /// </summary>
        /// <param name="variant">Variant of Poker to be used when calculating hand</param>
        /// <param name="rankings">List of ordered poker rankings with the strongest hand first</param>
        public PokerScorer(PokerVariant variant, List<Hand> rankings) 
        {
            _variant = variant;
            _rankings = rankings;
        }

        /// <summary>
        /// Calculates the best hand for given cards
        /// </summary>
        /// <param name="own">Cards in the players hand (hole cards)</param>
        /// <param name="shared">Cards shared between players (community cards)</param>
        /// <returns>String representation of the best hand possible</returns>
        public string CalculateBestHand(List<PlayingCard> own, List<PlayingCard> shared)
        {
            AssertNoDuplicates(own, shared);

            Hand bestHand = null;

            // Calculates all possible 5 card hands based on the variants rules and finds all possible rankings to return the 
            // highest ranking hand
            //
            // Its very likely this has room for optimization as the rules would mean once some hands are found others are
            // ruled out.
            //
            // Another possible way of doing this would have been to go through the best hands possible given all cards and
            // then rule them out if they didn't using enough cards according to the variants rules but this felt like it
            // may not have as been as extensible.
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
                            // The rankings position could be pre-calculated instead of always looking it up
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