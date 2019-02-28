namespace FL.Domain.Aggregates.SeasonAggregate.Events
{
    using System;
    using FL.Domain.BaseObjects;

    public class TeamAddedToDivisionEvent : DomainEvent
    {
        public TeamAddedToDivisionEvent(Guid seasonId, Guid divisionId, Guid teamId)
        {
            this.SeasonId = seasonId;
            this.DivisionId = divisionId;
            this.TeamId = teamId;
        }

        public Guid SeasonId { get; }

        public Guid DivisionId { get; }

        public Guid TeamId { get; }
    }
}