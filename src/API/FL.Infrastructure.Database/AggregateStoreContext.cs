using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace FL.Infrastructure.Database
{
    public class AggregateStoreContext : DbContext
    {
        public AggregateStoreContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<DbAggregate> AggregateStore { get; set; }
    }

    public class DbAggregate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public string Value { get; set; }
    }
}
