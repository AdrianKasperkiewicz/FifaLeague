using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FL.Domain.BaseObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FL.Infrastructure.Database
{
    public class AggregateStoreContext : DbContext
    {
        private readonly IMediator mediator;

        public AggregateStoreContext(DbContextOptions<AggregateStoreContext> options, IMediator mediator)
            : base(options)
        {
            this.mediator = mediator;
        }

        public DbSet<EventStore> EventsStore { get; set; }

        public override int SaveChanges()
        {
            this.DispatchDomainEvent();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.DispatchDomainEvent();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void DispatchDomainEvent()
        {
            var domainEvents = this.ChangeTracker.Entries<EventStore>().Select(x => x.Entity);

            foreach (var @event in domainEvents.Select(x => JsonConvert.DeserializeObject(x.Event, Type.GetType(x.EventType)) as DomainEvent))
            {
                this.mediator.Publish(@event);
            }
        }
    }

    public class EventStore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid EventId { get; set; }

        public Guid AggregateId { get; set; }

        public string EventType { get; set; }

        public string Event { get; set; }

        public DateTime TimeCreated { get; set; }
    }
}
