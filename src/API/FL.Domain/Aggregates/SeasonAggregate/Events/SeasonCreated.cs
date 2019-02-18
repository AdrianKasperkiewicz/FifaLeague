using System;

using FL.Domain.BaseObjects;
using MediatR;

namespace FL.Domain.Aggregates.SeasonAggregate.Events
{
    public class SeasonCreated : IDomainEvent
    {
        public SeasonCreated(Guid id, string name, int number)
        {
            this.Id = id;
            this.Number = number;
            this.Name = name;
        }

        public Guid Id { get; }

        public int Number { get; }

        public string Name { get; }
    }
}