using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace FL.Infrastructure.Database
{
    public class AggregateStoreContext : DbContext
    {
        public AggregateStoreContext(DbContextOptions<AggregateStoreContext> options)
            : base(options)
        {
        }

        public DbSet<EventStore> EventStore { get; set; }
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
