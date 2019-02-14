using System;
using System.Threading.Tasks;

namespace FL.Domain
{
    public interface ITeamRepository
    {
        Task Save(Team team);

        Task<Team> Get(Guid Id);
    }
}