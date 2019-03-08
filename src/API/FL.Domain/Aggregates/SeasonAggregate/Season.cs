using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using FL.Domain.Aggregates.SeasonAggregate.Events;
using FL.Domain.Aggregates.SeasonAggregate.SeasonStateEnumeration;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate
{
    public class Season : AggregateRoot
    {
        private List<Division> divisions;

        public Season(DateTime startDate)
        {
            if (startDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("Start date can not be less than today");
            }

            base.ApplyChange(new SeasonCreatedEvent(Guid.NewGuid(), startDate));
        }

        public Season()
        {
        }

        public int Number { get; private set; }

        public DateTime StartDate { get; private set; }

        public SeasonState SeasonState { get; private set; }

        public ReadOnlyCollection<Division> Divisions => this.divisions.AsReadOnly();

        public void Apply(SeasonCreatedEvent @event)
        {
            base.Id = new Identity(@event.SeasonId);
            this.divisions = new List<Division>();
            this.Number = 1;
            this.StartDate = @event.StartDate;
            this.SeasonState = SeasonState.Proposed;
        }

        public void Apply(DivisionCreatedEvent @event)
        {
            var division = new Division(@event.DivisionId, @event.Name, @event.Hierarchy, @event.NumberOfDegraded, @event.NumberOfPromoted);

            this.divisions.Add(division);
        }

        public void Apply(TeamAddedToDivisionEvent @event)
        {
            this.divisions.First(x => x.Id.Value == @event.DivisionId).AddTeam(@event.TeamId);
        }

        public void Apply(SeasonStartedEvent @event)
        {
            this.SeasonState = SeasonState.Started;
        }

        public void AddTeam(Guid divisionId, Guid teamId)
        {
            this.VerifyEditingModeAndThrow();

            if (this.divisions.All(x => x.Id.Value != divisionId))
            {
                throw new ArgumentException($"Division with Id {divisionId} not found.");
            }

            if (this.divisions.Any(x => x.Teams.Contains(teamId)))
            {
                throw new TeamAlreadyAddedToDivisonException();
            }

            this.ApplyChange(new TeamAddedToDivisionEvent(base.Id.Value, divisionId, teamId));
        }

        public void AddDivision(string divisionName, int divisionHierarchy, int numberOfDegraded, int numberOfPromoted)
        {
            this.VerifyEditingModeAndThrow();

            if (this.divisions.Any(x => x.Hierarchy == divisionHierarchy))
            {
                throw new ArgumentException($"Division with {divisionHierarchy} Hierarchy, was already added.");
            }

            if (this.divisions.Any(x => x.Hierarchy < 0))
            {
                throw new ArgumentException($"Division Hierarchy, could not be smaller than 0.");
            }

            if (divisionHierarchy == 1 && numberOfPromoted > 0)
            {
                throw new ArgumentException("Team could not be promoted from highest division");
            }

            this.ApplyChange(new DivisionCreatedEvent(base.Id.Value, Guid.NewGuid(), divisionName, divisionHierarchy, numberOfDegraded, numberOfPromoted));
        }

        public void Start()
        {
            var teamsDivision = this.divisions
                .SelectMany(x => x.Teams, (division, team) => new {team, division.Id});

                //.ToDictionary(x => x.Id.Value, x => x.team);

            this.ApplyChange(new SeasonStartedEvent(this.Id.Value, this.StartDate, teamsDivision.ToDictionary(x => x.team, x => x.Id.Value)));
        }

        private void VerifyEditingModeAndThrow()
        {
            if (!Equals(this.SeasonState, SeasonState.Proposed))
            {
                throw new ArgumentException($"Season could be modify only in {SeasonState.Proposed} state.");
            }
        }
    }
}