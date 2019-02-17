using System;
using System.Threading.Tasks;

using FL.Domain.Aggregates.TeamAggregate;
using FL.Domain.BaseObjects;

namespace FL.Domain
{
    public interface IRepository<T> where T : Entity, IAggregateRoot
    {
        Task Save(T aggregate);

        Task<T> Get(Guid id);
    }
}