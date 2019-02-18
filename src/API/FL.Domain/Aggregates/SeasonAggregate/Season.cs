using System;
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

        private readonly List<League> Leagues;


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