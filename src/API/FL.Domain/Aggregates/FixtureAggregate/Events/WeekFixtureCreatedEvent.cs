using System;
using System.Collections.Generic;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate.Events
{
    public class WeekFixtureCreatedEvent : DomainEvent
    {
        public WeekFixtureCreatedEvent(Guid seasonId, Guid divisionId, DateTime startDate, DateTime endDate, List<KeyValuePair<Guid, Guid>> matchList)
            : base()
        {
            this.DivisionId = divisionId;
            this.SeasonId = seasonId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.MatchList = matchList;
        }

        public Guid SeasonId { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public List<KeyValuePair<Guid, Guid>> MatchList { get; }

        public Guid DivisionId { get; }
    }
}
