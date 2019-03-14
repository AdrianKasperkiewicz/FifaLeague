using System;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate.Events
{
    public class FixtureStartedEvent : DomainEvent
    {
        public FixtureStartedEvent(Guid fixtureId)
        {
            this.FixtureId = fixtureId;
        }

        public Guid FixtureId { get; }
    }
}
