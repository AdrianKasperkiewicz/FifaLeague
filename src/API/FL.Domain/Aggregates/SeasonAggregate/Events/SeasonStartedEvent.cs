using System;
using System.Collections.Generic;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate.Events
{
    public class SeasonStartedEvent : DomainEvent
    {
        public SeasonStartedEvent(Guid seasonId, DateTime firstMatchDate, Dictionary<Guid, Guid> teamsDivisions)
        {
            this.SeasonId = seasonId;
            this.FirstMatchDate = firstMatchDate;
            this.TeamsDivisions = teamsDivisions;
        }

        public Guid SeasonId { get; }

        public DateTime FirstMatchDate { get; }

        public Dictionary<Guid, Guid> TeamsDivisions { get; }
    }
}