using System.Runtime.Serialization;

namespace Poker
{
    public enum Rank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        [EnumMember(Value = "J")]
        Jack = 11,
        [EnumMember(Value = "Q")]
        Queen = 12,
        [EnumMember(Value = "K")]
        King = 13,
        [EnumMember(Value = "A")]
        Ace = 14 // Also 1 for certain hands
    }
}
