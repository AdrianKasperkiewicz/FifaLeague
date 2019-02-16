using System;
using FL.Domain.Aggregates.SeasonAggregate;

namespace FL.Domain
{
    public interface ISeasonRepository
    {
        void Save(Season season);
        Season Get(Guid id);
    }
}
