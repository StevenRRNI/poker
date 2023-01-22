using System;

namespace Poker
{
    public static class PokerVariants
    {
        public static readonly FiveCardDraw FiveCardDraw = new FiveCardDraw();

        public static readonly TexasHoldEm TexasHoldEm = new TexasHoldEm();

        public static readonly Omaha Omaha = new Omaha();

        public static PokerVariant Parse(string value)
        {
            switch (value.ToLower())
            {
                case "texasholdem":
                    return TexasHoldEm;

                case "fivecarddraw":
                    return FiveCardDraw;

                case "omaha":
                    return Omaha;

                default:
                    throw new ArgumentException("Invalid variant: " + value);
            }
        }
    }
}
