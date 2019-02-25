using System;

using FL.Domain.Aggregates.SeasonAggregate.Events;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate
{
    public class Season : Entity, IAggregateRoot
    {
        public Season(string name)
        {
            this.Number = 1;
            base.Id = new Identity();

            this.AddDomainEvent(new SeasonCreated(base.Id.Value, this.Number));
        }

        public int Number { get; }

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