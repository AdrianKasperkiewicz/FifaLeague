using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using FL.Domain.Aggregates.SeasonAggregate.Events;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate
{
    public class Season : Entity, IAggregateRoot
    {
        private readonly List<Division> divisions;

        public Season(string name)
        {
            this.Number = 1;
            base.Id = new Identity();
            this.divisions = new List<Division>();

            this.AddDomainEvent(new SeasonCreated(base.Id.Value, this.Number));
        }

        public ReadOnlyCollection<Division> Divisions => this.divisions.AsReadOnly();

        public int Number { get; }

        public void AddDivision(Division division)
        {
            if (this.divisions.Any(x => x.Hierarchy == division.Hierarchy))
            {
                throw new ArgumentException($"Division with {division.Hierarchy} Hierarchy, was already addeded.");
            }

            if (this.divisions.Any(x => x.Hierarchy < 0))
            {
                throw new ArgumentException($"Division Hierarchy, could not be smaller than 0.");
            }

            this.divisions.Add(division);

            this.AddDomainEvent(new DivisionCreatedEvent(base.Id.Value, division.Id.Value, division.Name));
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Finish()
        {
            throw new NotImplementedException();
        }

        public void StartNew()
        {
            throw new NotImplementedException();
        } // returns new season ?
    }
}