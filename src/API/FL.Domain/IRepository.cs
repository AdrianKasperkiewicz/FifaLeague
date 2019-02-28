using System;
using System.Threading.Tasks;

using FL.Domain.BaseObjects;

namespace FL.Domain
{
    public interface IRepository<T>
        where T : AggregateRoot, new()
    {
        Task Save(T aggregate);

        Task<T> Get(Guid id);
    }
}