using System;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate.Events
{
    public class SeasonCreatedEvent : DomainEvent
    {
        public SeasonCreatedEvent(Guid seasonId, DateTime startDate)
        {
            this.SeasonId = seasonId;
            this.StartDate = startDate;
        }

        public DateTime StartDate { get; }

        public Guid SeasonId { get; }
    }
}