using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.BaseObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FL.Infrastructure.Database
{
    public class AggregateRepository<T> : IRepository<T>
        where T : AggregateRoot, new()
    {
        private readonly AggregateStoreContext context;
        private readonly IMediator mediator;

        public AggregateRepository(AggregateStoreContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task Save(T aggregate)
        {
            var eventsToStore = new List<EventStore>();

            foreach (var @event in aggregate.GetUncommittedChanges())
            {
                var aggregateToStore = new EventStore
                {
                    EventId = @event.EventId,
                    AggregateId = aggregate.Id.Value,
                    Event = JsonConvert.SerializeObject(@event),
                    EventType = @event.GetType().AssemblyQualifiedName,
                    TimeCreated = DateTime.Now
                };

                eventsToStore.Add(aggregateToStore);
            }

            await this.context.AddRangeAsync(eventsToStore);
            await this.context.SaveChangesAsync();

            this.PublishUncomitedEvents(aggregate);
        }

        public async Task<T> Get(Guid id)
        {
            T aggregate = new T();
            var serializedEvents = this.context.EventStore.Where(x => x.AggregateId == id);

            var domainEvents = await serializedEvents
                .Select(x => JsonConvert.DeserializeObject(x.Event, Type.GetType(x.EventType)) as DomainEvent)
                .ToListAsync();

            aggregate.LoadsFromHistory(domainEvents);

            return aggregate;
        }

        private void PublishUncomitedEvents(T aggregate)
        {
            foreach (var @event in aggregate.GetUncommittedChanges())
            {
                this.mediator.Publish(@event);
            }

            aggregate.MarkChangesAsCommitted();
        }
    }
}