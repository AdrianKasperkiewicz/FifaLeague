using System;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate.Events
{
    public class DivisionCreatedEvent : DomainEvent
    {
        public DivisionCreatedEvent(Guid seasonId, Guid divisionId, string name, int hierarchy)
            : base()
        {
            this.Name = name;
            this.SeasonId = seasonId;
            this.Hierarchy = hierarchy;
            this.DivisionId = divisionId;
        }

        public string Name { get; }

        public Guid SeasonId { get; }

        public Guid DivisionId { get; }

        public int Hierarchy { get; }
    }
}