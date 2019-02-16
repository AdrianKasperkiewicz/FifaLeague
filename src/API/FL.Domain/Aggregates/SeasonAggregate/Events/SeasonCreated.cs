using System;

using FL.Domain.BaseObjects;
using MediatR;

namespace FL.Domain.Aggregates.SeasonAggregate.Events
{
    public class SeasonCreated : IDomainEvent, INotification
    {
        public SeasonCreated(Guid id, int number)
        {
            this.Id = id;
            this.Number = number;
        }

        public Guid Id { get; }

        public int Number { get; }
    }
}