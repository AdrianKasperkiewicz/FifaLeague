using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate.SeasonStateEnumeration
{
    public class SeasonState : Enumeration
    {
        public static readonly SeasonState Proposed = new ProposedSeasonState();
        public static readonly SeasonState Started = new StartedSeasonState();
        public static readonly SeasonState Finished = new FinishedSeasonState();

        public SeasonState(int id, string name)
            : base(id, name)
        {
        }
    }

    internal class FinishedSeasonState : SeasonState
    {
        public FinishedSeasonState()
            : base(3, "Finished")
        {
        }
    }

    internal class StartedSeasonState : SeasonState
    {
        public StartedSeasonState()
            : base(2, "Started")
        {
        }
    }

    internal class ProposedSeasonState : SeasonState
    {
        public ProposedSeasonState()
            : base(1, "Proposed")
        {
        }
    }
}