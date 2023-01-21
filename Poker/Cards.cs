using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class Cards
    {
        public static List<Card> Parse(string value)
        {
            return value.Split(",").Select(val => Card.Parse(val)).ToList();
        }
    }
}
