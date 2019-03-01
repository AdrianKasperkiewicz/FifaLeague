using System;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate.Events
{
    public class DivisionCreatedEvent : DomainEvent
    {
        public DivisionCreatedEvent(Guid seasonId, Guid divisionId, string name, int hierarchy, int numberOfDegraded, int numberOfPromoted)
            : base()
        {
            this.Name = name;
            this.SeasonId = seasonId;
            this.Hierarchy = hierarchy;
            this.NumberOfDegraded = numberOfDegraded;
            this.NumberOfPromoted = numberOfPromoted;
            this.DivisionId = divisionId;
        }

        public string Name { get; }

        public Guid SeasonId { get; }

        public Guid DivisionId { get; }

        public int Hierarchy { get; }

        public int NumberOfDegraded { get; }

        public int NumberOfPromoted { get; }
    }
}