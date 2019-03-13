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

        public WeekFixture(Guid seasonId, Guid divisionId, DateTime startDate, DateTime endDate, int fixtureWeekNumber)
        {
            if (endDate <= startDate.Date)
            {
                throw new ArgumentException("Fixture start date should be greater than end date");
            }

            this.ApplyChange(new WeekFixtureCreatedEvent(Guid.NewGuid(), seasonId, divisionId, startDate, endDate, fixtureWeekNumber));
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
            this.matches = new List<Match>();
        }

        public void Apply(FixtureMatchAddedEvent @event)
        {
            this.matches.Add(new Match(@event.MatchId, @event.HomeTeamId, @event.AwayTeamId));
        }

        public void Apply(MatchPostponedEvent @event)
        {
            this.matches.First(x => x.Id.Value == @event.MatchId).Postpone();
        }

        public void Apply(MatchRescheduledEvent @event)
        {
            var rescheduledMatch = new Match(@event.MatchId, @event.HomeTeamId, @event.AwayTeamId, isRescheduled: true);
            this.matches.Add(rescheduledMatch);
        }

        public void AddMatch(Guid homeTeam, Guid awayTeam)
        {
            if (homeTeam == Guid.Empty || awayTeam == Guid.Empty)
            {
                throw new ArgumentException("Incorrect team Id was provided");
            }

            this.ApplyChange(new FixtureMatchAddedEvent(Guid.NewGuid(), this.Id.Value, homeTeam, awayTeam));
        }

        public void Reschedule(Guid homeTeam, Guid awayTeam)
        {
            if (homeTeam == Guid.Empty || awayTeam == Guid.Empty)
            {
                throw new ArgumentException("Incorrect team Id was provided");
            }

            var abc = new MatchRescheduledEvent(
                Guid.NewGuid(), this.Id.Value, homeTeam, awayTeam);

            this.ApplyChange(abc);
        }

        public void PostponeMatch(Guid matchId)
        {
            if (!this.matches.Any(x => x.Id.Value == matchId))
            {
                throw new ArgumentException($"Match {matchId} not exist in fixture {this.Id.Value}");
            }

            this.ApplyChange(new MatchPostponedEvent(this.Id.Value, matchId));
        }
    }
}