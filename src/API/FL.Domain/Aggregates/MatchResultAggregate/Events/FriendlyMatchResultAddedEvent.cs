namespace FL.Domain.Aggregates.MatchAggregate.Events
{
    using System;

    using FL.Domain.BaseObjects;

    public class FriendlyMatchResultAddedEvent : DomainEvent
    {
        public FriendlyMatchResultAddedEvent(Guid matchId, Guid homeTeamId, Guid awayTeamId, int homeGoals, int awayGoals, DateTime date)
        {
            this.MatchId = matchId;
            this.HomeTeamId = homeTeamId;
            this.AwayTeamId = awayTeamId;
            this.HomeGoals = homeGoals;
            this.AwayGoals = awayGoals;
            this.Date = date;
        }

        public Guid MatchId { get; }

        public Guid HomeTeamId { get; }

        public Guid AwayTeamId { get; }

        public int HomeGoals { get; }

        public int AwayGoals { get; }

        public DateTime Date { get; }
    }
}
