using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public static class Cards
    {
        public static List<Card> Parse(string value)
        {
            return value.Split(",").Select(val => Card.Parse(val)).ToList();
        }

        public static List<List<Card>> GenerateCombinations(this List<Card> cards, int? minimum = 1, int? maxium = 1)
        {
            Card[][] combinations = FastPowerSet(cards.ToArray());

            List<List<Card>> combinationsList = new List<List<Card>>();

            foreach (var combination in combinations)
            {
                if (combination.Length >= minimum && combination.Length <= maxium)
                {
                    combinationsList.Add(combination.ToList());
                }
            }

            return combinationsList;
        }

        public static T[][] FastPowerSet<T>(T[] seq)
        {
            var powerSet = new T[1 << seq.Length][];
            powerSet[0] = new T[0]; // starting only with empty set

            for (int i = 0; i < seq.Length; i++)
            {
                var cur = seq[i];
                int count = 1 << i; // doubling list each time
                for (int j = 0; j < count; j++)
                {
                    var source = powerSet[j];
                    var destination = powerSet[count + j] = new T[source.Length + 1];
                    for (int q = 0; q < source.Length; q++)
                        destination[q] = source[q];
                    destination[source.Length] = cur;
                }
            }

            return powerSet;
        }
    }
}
