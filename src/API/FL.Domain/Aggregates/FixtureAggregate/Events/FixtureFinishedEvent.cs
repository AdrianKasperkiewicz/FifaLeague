using System;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate.Events
{
    public class FixtureFinishedEvent : DomainEvent
    {
        public FixtureFinishedEvent(Guid fixtureId)
        {
            this.FixtureId = fixtureId;
        }

        public Guid FixtureId { get; }
    }
}