using System;
using System.Collections.Generic;
using System.Text;
using FL.Domain.Aggregates.SeasonAggregate;

namespace FL.Domain
{
    public interface ISeasonnRepository
    {
        void Save(Season season);
        Season Get(Guid id);
    }
}
