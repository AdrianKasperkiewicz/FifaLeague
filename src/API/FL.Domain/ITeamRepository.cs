using System;
using System.Threading.Tasks;

using FL.Domain.Aggregates.TeamAggregate;

namespace FL.Domain
{
    public interface ITeamRepository
    {
        Task Save(Team team);

        Task<Team> Get(Guid id);
    }
}