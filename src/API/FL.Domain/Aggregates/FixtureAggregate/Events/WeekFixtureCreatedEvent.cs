using System;
using System.Collections.Generic;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate.Events
{
    public class WeekFixtureCreatedEvent : DomainEvent
    {
        public WeekFixtureCreatedEvent(Guid fixtureId, Guid seasonId, Guid divisionId, DateTime startDate, DateTime endDate, List<KeyValuePair<Guid, Guid>> matchList, int fixtureWeekNumber)
            : base()
        {
            this.FixtureId = fixtureId;
            this.DivisionId = divisionId;
            this.SeasonId = seasonId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.MatchList = matchList;
            this.FixtureWeekNumber = fixtureWeekNumber;
        }

        public Guid FixtureId { get; }
        
        public int FixtureWeekNumber { get; }

        public Guid SeasonId { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public List<KeyValuePair<Guid, Guid>> MatchList { get; }

        public Guid DivisionId { get; }
    }
}
