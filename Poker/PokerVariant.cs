using System;

namespace Poker
{
    public class PokerVariant
    {
        public int HoleCardsCount { get; private set; }

        public int CommunityCardsCount { get; private set; }

        public int RequiredHoleCards { get; private set; }

        public PokerVariant(int holeCardsCount, int communityCardsCount, int requiredHoleCards)
        {
            HoleCardsCount = holeCardsCount;
            CommunityCardsCount = communityCardsCount;
            RequiredHoleCards = requiredHoleCards;
        }

        public static PokerVariant Parse(string value)
        {
            switch (value.ToLower())
            {
                case "texasholdem":
                    return PokerVariants.TexasHoldEm;

                case "fivecarddraw":
                    return PokerVariants.FiveCardDraw;

                case "omaha":
                    return PokerVariants.Omaha;

                default:
                    throw new ArgumentException("Unknown variant: " + value);
            }
        }
    }

    public class FiveCardDraw : PokerVariant
    {
        public FiveCardDraw() : base(5, 0, 5) { }
    }

    public class TexasHoldEm : PokerVariant
    { 
        public TexasHoldEm() : base(2, 5, 2) { }
    }

    public class Omaha : PokerVariant
    {
        public Omaha() : base(4, 5, 2) { }
    }
}
