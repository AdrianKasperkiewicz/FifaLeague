using System;

using FL.Domain.BaseObjects;
using MediatR;

namespace FL.Domain.Aggregates.SeasonAggregate.Events
{
    public class SeasonCreated : IDomainEvent
    {
        public SeasonCreated(Guid id, int number)
        {
            this.Id = id;
        }

        public Guid Id { get; }

        public int Number { get; }
    }
}