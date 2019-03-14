using System;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate.Events
{
    public class WeekFixtureCreatedEvent : DomainEvent
    {
        public WeekFixtureCreatedEvent(Guid fixtureId, Guid seasonId, Guid divisionId, DateTime startDate, DateTime endDate, int fixtureWeekNumber)
            : base()
        {
            this.FixtureId = fixtureId;
            this.DivisionId = divisionId;
            this.SeasonId = seasonId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.FixtureWeekNumber = fixtureWeekNumber;
        }

        public Guid FixtureId { get; }

        public int FixtureWeekNumber { get; }

        public Guid SeasonId { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public Guid DivisionId { get; }
    }
}
