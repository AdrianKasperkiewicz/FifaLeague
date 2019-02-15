
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate
{
    public class MatchHalf : Enumeration
    {
        public static MatchHalf First = new FirstMatchHalf();
        public static MatchHalf Second = new SecondMatchHalf();

        public MatchHalf(int id, string name)
            : base(id, name)
        {
        }
    }
}