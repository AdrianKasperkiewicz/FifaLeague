using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate.StateEnumeration
{
    public class FixtureState : Enumeration
    {
        public static readonly FixtureState Ready = new Ready();
        public static readonly FixtureState Started = new Started();
        public static readonly FixtureState Finished = new Finished();

        public FixtureState(int id, string name)
            : base(id, name)
        {
        }
    }

    public class Ready : FixtureState
    {
        public Ready()
            : base(1, "Ready")
        {
        }
    }

    public class Started : FixtureState
    {
        public Started()
            : base(2, "Started")
        {
        }
    }

    public class Finished : FixtureState
    {
        public Finished()
            : base(3, "Finished")
        {
        }
    }
}
