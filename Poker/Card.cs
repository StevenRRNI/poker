using System;

namespace Poker
{
    public class Card
    {
        public Rank Rank { get; private set; }

        public Suit Suit { get; private set; }

        public Card(Rank rank, Suit suit) 
        {
            Rank = rank;
            Suit = suit;
        }

        public static Card Parse(string value) 
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2)
            {
                throw new ArgumentException("Invalid card");
            }

            Suit suit = ParseSuit(value[value.Length - 1]);

            Rank rank = ParseRank(value.Remove(value.Length - 1));
            
            return new Card(rank, suit);
        }

        private static Suit ParseSuit(char value)
        {
            switch (value)
            {
                case 'S':
                case '♠':
                case '♤':
                    return Suit.Spades;

                case 'H':
                case '♥':
                case '♡':
                    return Suit.Hearts;

                case 'C':
                case '♣':
                case '♧':
                    return Suit.Clubs;

                case 'D':
                case '♦':
                case '♢':
                    return Suit.Diamonds;

                default:
                    throw new ArgumentException("Invalid suit: " + value);
            }
        }

        private static Rank ParseRank(string value)
        {
            Rank? rank = null;
            
            int intValue;

            if (int.TryParse(value, out intValue))
            { 
                if (intValue > 1 && intValue < 11)
                {
                    rank = (Rank)intValue;
                }
            }

            switch (value)
            {
                case "J":
                    rank = Rank.Jack; 
                    break;

                case "Q":
                    rank = Rank.Queen;
                    break;

                case "K":
                    rank = Rank.King;
                    break;

                case "A":
                    rank = Rank.Ace;
                    break;
            }

            if (!rank.HasValue)
            {
                throw new ArgumentException("Invalid rank: " + value);
            }

            return rank.Value;
        }
    }
}
