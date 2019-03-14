namespace FL.Domain.Aggregates.FixtureAggregate.Events
{
    using System;
    using FL.Domain.BaseObjects;

    public class FixtureMatchAddedEvent : DomainEvent
    {
        public FixtureMatchAddedEvent(Guid matchId, Guid fixtureGuid, Guid homeTeamId, Guid awayTeamId)
        {
            this.MatchId = matchId;
            this.FixtureGuid = fixtureGuid;
            this.HomeTeamId = homeTeamId;
            this.AwayTeamId = awayTeamId;
        }

        public Guid MatchId { get; }

        public Guid FixtureGuid { get; }

        public Guid HomeTeamId { get; }

        public Guid AwayTeamId { get; }
    }
}
