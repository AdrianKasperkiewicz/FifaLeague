using System;
using System.Collections.Generic;

using FL.Domain.Aggregates.FixtureAggregate.Events;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate
{
    public class WeekFixture : AggregateRoot
    {
        public WeekFixture()
        {
        }

        public WeekFixture(Guid seasonId, Guid divisionId, DateTime startDate, DateTime endDate, List<KeyValuePair<Guid, Guid>> matchList)
        {
            if (endDate <= startDate.Date)
            {
                throw new ArgumentException("Fixyure start date should be greater than end date");
            }

            this.ApplyChange(new WeekFixtureCreatedEvent(Guid.NewGuid(), seasonId, divisionId, startDate, endDate, matchList));
        }

        public Guid SeasonId { get; set; }

        public Guid DivisionId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Match> Matches { get; set; }

        public void Apply(WeekFixtureCreatedEvent @event)
        {
            base.Id = new Identity(@event.FixtureId);
            this.SeasonId = @event.SeasonId;
            this.DivisionId = @event.DivisionId;
            this.StartDate = @event.StartDate;
            this.EndDate = @event.EndDate;
        }

        public void Reschedule(Guid matchId)
        {
            throw new NotImplementedException();
        }
    }
}