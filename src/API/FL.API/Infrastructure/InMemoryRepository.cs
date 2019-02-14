using FL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FL.API.Infrastructure
{
    public class InMemoryRepository : ITeamRepository
    {
        private readonly List<Team> databaseTeams;

        public InMemoryRepository(List<Team> databaseTeams)
        {
            this.databaseTeams = databaseTeams;
        }

        public Task<Team> Get(Guid Id)
        {
           return Task.FromResult(this.databaseTeams.FirstOrDefault(x => x.Id == Id));
        }

        public Task Save(Team team)
        {
            this.databaseTeams.Add(team);

            return Task.CompletedTask;
        }
    }
}