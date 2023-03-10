using System;
using System.Drawing;

namespace Poker
{
    public class PlayingCard
    {
        public Rank Rank { get; private set; }

        public Suit Suit { get; private set; }

        public PlayingCard(Rank rank, Suit suit) 
        {
            Rank = rank;
            Suit = suit;
        }

        public static PlayingCard Parse(string value) 
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2)
            {
                throw new ArgumentException("Invalid card");
            }

            Suit suit = ParseSuit(value[value.Length - 1]);

            Rank rank = ParseRank(value.Remove(value.Length - 1));
            
            return new PlayingCard(rank, suit);
        }

        public override string ToString()
        {
            return Rank.ToString() + Suit.ToString();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                PlayingCard card = (PlayingCard)obj;

                return Rank == card.Rank && Suit == card.Suit;
            }
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
