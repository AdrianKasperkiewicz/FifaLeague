using System;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate.Events
{
    public class SeasonCreated : DomainEvent
    {
        public SeasonCreated(Guid seasonId)
        {
            this.SeasonId = seasonId;
        }

        public Guid SeasonId { get; }
    }
}