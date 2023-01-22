using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public static class PlayingCards
    {
        public static List<PlayingCard> Parse(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new List<PlayingCard>();
            }

            return value.Split(",").Select(val => PlayingCard.Parse(val)).ToList();
        }

        public static List<List<PlayingCard>> GenerateCombinations(this List<PlayingCard> cards, int? minimumCards = 1, int? maxiumCards = 1)
        {
            List<List<PlayingCard>> combinations = new List<List<PlayingCard>>();

            // Recursive method for find all combinations, could likely be done iteratively
            GetCombinations(cards, -1, combinations, new List<PlayingCard>());

            // Feels like this could be done in the above method to avoid wasted work
            return combinations.Where(combination => combination.Count >= minimumCards && combination.Count <= maxiumCards).ToList();
        }

        private static void GetCombinations(List<PlayingCard> cards, int position, List<List<PlayingCard>> combinations, List<PlayingCard> current)
        {
            if (position >= cards.Count)
            {
                return;
            }

            combinations.Add(current);

            for (int index  = position + 1; index < cards.Count; index++)
            {
                var newCombination = new List<PlayingCard>(current)
                {
                    cards[index]
                };

                GetCombinations(cards, index, combinations, newCombination);
            }
        }
    }
}
