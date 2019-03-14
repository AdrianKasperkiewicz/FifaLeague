namespace FL.Domain.Aggregates.MatchAggregate.Events
{
    using System;

    using FL.Domain.BaseObjects;

    public class FriendlyMatchResultAddedEvent : DomainEvent
    {
        public FriendlyMatchResultAddedEvent(Guid guid, Guid homeTeamId, Guid awayTeamId, int homeGoals, int awayGoals)
        {
            this.Guid = guid;
            this.HomeTeamId = homeTeamId;
            this.AwayTeamId = awayTeamId;
            this.HomeGoals = homeGoals;
            this.AwayGoals = awayGoals;
        }

        public Guid Guid { get; }

        public Guid HomeTeamId { get; }

        public Guid AwayTeamId { get; }

        public int HomeGoals { get; }

        public int AwayGoals { get; }
    }
}
