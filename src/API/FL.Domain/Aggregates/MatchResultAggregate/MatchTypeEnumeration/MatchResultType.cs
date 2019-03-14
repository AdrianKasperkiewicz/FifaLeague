namespace FL.Domain.Aggregates.MatchResultAggregate.MatchTypeEnumeration
{
    using FL.Domain.BaseObjects;

    public class MatchResultType : Enumeration
    {
        public static readonly MatchResultType Friendly = new FriendlyType();
        public static readonly MatchResultType League = new LeagueType();

        public MatchResultType(int id, string name)
       : base(id, name)
        {
        }
    }

    public class FriendlyType : MatchResultType
    {
        public FriendlyType()
            : base(1, "Friendly")
        {
        }
    }

    public class LeagueType : MatchResultType
    {
        public LeagueType()
            : base(1, "League")
        {
        }
    }
}