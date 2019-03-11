using System;
using System.Collections.Generic;
using System.Linq;

using FL.Domain.Aggregates.FixtureAggregate.Events;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate
{
    public class WeekFixture : AggregateRoot
    {
        private List<Match> matches;

        public WeekFixture()
        {
        }

        public WeekFixture(Guid seasonId, Guid divisionId, DateTime startDate, DateTime endDate, List<KeyValuePair<Guid, Guid>> matchList, int fixtureWeekNumber)
        {
            if (endDate <= startDate.Date)
            {
                throw new ArgumentException("Fixture start date should be greater than end date");
            }

            this.ApplyChange(new WeekFixtureCreatedEvent(Guid.NewGuid(), seasonId, divisionId, startDate, endDate, matchList, fixtureWeekNumber));
        }

        public Guid SeasonId { get; private set; }

        public Guid DivisionId { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public IReadOnlyList<Match> Matches => this.matches.AsReadOnly();

        public int FixtureWeekNumber { get; private set; }

        public void Apply(WeekFixtureCreatedEvent @event)
        {
            base.Id = new Identity(@event.FixtureId);
            this.SeasonId = @event.SeasonId;
            this.DivisionId = @event.DivisionId;
            this.StartDate = @event.StartDate;
            this.EndDate = @event.EndDate;
            this.FixtureWeekNumber = @event.FixtureWeekNumber;
            this.matches = @event.MatchList.Select(x => new Match(x.Key, x.Value)).ToList();
        }

        public void Reschedule(Guid matchId)
        {
            throw new NotImplementedException();
        }
    }
}