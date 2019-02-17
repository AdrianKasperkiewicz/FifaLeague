using System.Collections.Generic;
using FL.Domain.Aggregates.SeasonAggregate.Events;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate
{
    public class Season : Entity, IAggregateRoot
    {
        public Season(string name)
        {
            this.Name = name;
            this.Number = 1;
            this.Leagues = new List<League>();

            this.AddDomainEvent(new SeasonCreated(base.Id, this.Name, this.Number));
        }

        public string Name { get; }

        public int Number { get; }

        public List<League> Leagues;


        public void Start() { }

        public void Finish()
        {
        }

        public void StartNew() { } // returns new season ?
    }
}