﻿namespace FL.Domain.Aggregates.MatchAggregate
{
    using System;

    using FL.Domain.Aggregates.MatchAggregate.Events;
    using FL.Domain.Aggregates.MatchResultAggregate.MatchTypeEnumeration;
    using FL.Domain.BaseObjects;

    public class MatchResult : AggregateRoot
    {
        public MatchResult()
        {
        }

        public MatchResult(Guid homeTeamId, Guid awayTeamId, int homeGoals, int awayGoals)
        {
            this.ApplyChange(new FriendlyMatchResultAddedEvent(Guid.NewGuid(), homeTeamId, awayTeamId, homeGoals, awayGoals));
        }

        public MatchResult(Guid fixtureId, Guid homeTeamId, Guid awayTeamId, int homeGoals, int awayGoals)
        {
            this.ApplyChange(new LeagueMatchResultAddedEvent(Guid.NewGuid(), fixtureId, homeTeamId, awayTeamId, homeGoals, awayGoals));
        }

        public Guid HomeTeamId { get; private set; }

        public Guid AwayTeamId { get; private set; }

        public int HomeGoals { get; private set; }

        public int AwayGoals { get; private set; }

        public MatchResultType MatchType { get; private set; }

        public Guid? FixtureId { get; private set; }

        public void Apply(FriendlyMatchResultAddedEvent @event)
        {
            this.HomeTeamId = @event.HomeTeamId;
            this.AwayTeamId = @event.AwayTeamId;
            this.HomeGoals = @event.HomeGoals;
            this.AwayGoals = @event.AwayGoals;
            this.MatchType = MatchResultType.Friendly;
        }

        public void Apply(LeagueMatchResultAddedEvent @event)
        {
            this.HomeTeamId = @event.HomeTeamId;
            this.AwayTeamId = @event.AwayTeamId;
            this.HomeGoals = @event.HomeGoals;
            this.AwayGoals = @event.AwayGoals;
            this.MatchType = MatchResultType.League;
            this.FixtureId = @event.FixtureId;
        }
    }
}