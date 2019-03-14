namespace FL.Domain.Aggregates.MatchAggregate.Events
{
    using System;
    using FL.Domain.BaseObjects;

    public class LeagueMatchResultAddedEvent : DomainEvent
    {
        public LeagueMatchResultAddedEvent(Guid matchResultId, Guid fixtureId, Guid homeTeamId, Guid awayTeamId, int homeGoals, int awayGoals)
        {
            this.MatchResultId = matchResultId;
            this.FixtureId = fixtureId;
            this.HomeTeamId = homeTeamId;
            this.AwayTeamId = awayTeamId;
            this.HomeGoals = homeGoals;
            this.AwayGoals = awayGoals;
        }

        public Guid MatchResultId { get; }

        public Guid FixtureId { get; }

        public Guid HomeTeamId { get; }

        public Guid AwayTeamId { get; }

        public int HomeGoals { get; }

        public int AwayGoals { get; }
    }
}
