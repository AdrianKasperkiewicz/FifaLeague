namespace FL.Domain.Aggregates.FixtureAggregate.Events
{
    using System;

    using FL.Domain.BaseObjects;

    public class MatchPostponedEvent : DomainEvent
    {
        public MatchPostponedEvent(Guid fixtureId, Guid matchId)
        {
            this.FixtureId = fixtureId;
            this.MatchId = matchId;
        }

        public Guid FixtureId { get; }

        public Guid MatchId { get; }
    }
}
