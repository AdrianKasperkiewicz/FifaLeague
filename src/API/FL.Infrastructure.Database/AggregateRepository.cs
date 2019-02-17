using System;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.BaseObjects;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FL.Infrastructure.Database
{
    public class AggregateRepository<T> : IRepository<T> where T : Entity, IAggregateRoot
    {
        private readonly AggregateStoreContext context;

        public AggregateRepository(AggregateStoreContext context)
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