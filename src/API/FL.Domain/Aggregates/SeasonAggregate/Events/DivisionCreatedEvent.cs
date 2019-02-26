using System;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate.Events
{
    public class DivisionCreatedEvent : IDomainEvent
    {
        public DivisionCreatedEvent(Guid seasonId, Guid divisionId, string name)
        {
            this.Id = divisionId;
            this.Name = name;
            this.SeasonId = seasonId;
        }

        public Guid Id { get; }

        public string Name { get; }

        public Guid SeasonId { get; }
    }
}