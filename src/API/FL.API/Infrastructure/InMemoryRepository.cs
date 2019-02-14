using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.Aggregates.TeamAggregate;

namespace FL.API.Infrastructure
{
    public class InMemoryRepository : ITeamRepository
    {
        private readonly List<Team> databaseTeams;

        public InMemoryRepository()
        {
            this.databaseTeams = new List<Team>();
        }

        public Task<Team> Get(Guid id)
        {
           return Task.FromResult(this.databaseTeams.FirstOrDefault(x => x.Id == id));
        }

        public Task Save(Team team)
        {
            this.databaseTeams.Add(team);

            return Task.CompletedTask;
        }
    }
}