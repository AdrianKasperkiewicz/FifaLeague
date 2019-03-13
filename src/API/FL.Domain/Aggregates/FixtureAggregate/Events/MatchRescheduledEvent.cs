namespace FL.Domain.Aggregates.FixtureAggregate.Events
{
    using System;

    using FL.Domain.BaseObjects;

    public class MatchRescheduledEvent : DomainEvent
    {
        public MatchRescheduledEvent(Guid matchId, Guid fixtureId, Guid homeTeamId, Guid awayTeamId)
        {
            this.MatchId = matchId;
            this.FixtureId = fixtureId;
            this.HomeTeamId = homeTeamId;
            this.AwayTeamId = awayTeamId;
        }

        public Guid MatchId { get; }

        public Guid FixtureId { get; }

        public Guid HomeTeamId { get; }

        public Guid AwayTeamId { get; }
    }
}
