using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

using FL.Domain.BaseObjects;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FL.Infrastructure.Database
{
    public class AggregateStoreContext : DbContext
    {
        public DbSet<DbAggregate> AggregateStore { get; set; }
    }

    public class DbAggregate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public string Value { get; set; }
    }

    public class Repository<T> where T : Entity, IAggregateRoot
    {
        private readonly AggregateStoreContext context;

        public Repository(AggregateStoreContext context)
        {
            this.context = context;
        }

        public async Task Save(T aggregate)
        {
            var aggregateToStore = new DbAggregate
            {
                Id = aggregate.Id,
                Value = JsonConvert.SerializeObject(aggregate)
            };

            await this.context.AddAsync(aggregateToStore);

            await this.context.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            var dbAggregate = await this.context.AggregateStore.FirstAsync(x => x.Id == id);

            return JsonConvert.DeserializeObject<T>(dbAggregate.Value);
        }
    }
}
