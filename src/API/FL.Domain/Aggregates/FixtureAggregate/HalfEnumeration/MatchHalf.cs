
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate
{
    public class MatchHalf : Enumeration
    {
        public static readonly MatchHalf First = new FirstMatchHalf();
        public static readonly MatchHalf Second = new SecondMatchHalf();

        public MatchHalf(int id, string name)
            : base(id, name)
        {
        }
    }
}