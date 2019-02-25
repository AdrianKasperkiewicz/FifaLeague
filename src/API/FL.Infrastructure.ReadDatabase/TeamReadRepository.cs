using System.Collections.Generic;
using System.Threading.Tasks;
using FL.Infrastructure.ReadDatabase.Database;
using Microsoft.EntityFrameworkCore;

namespace FL.Infrastructure.ReadDatabase
{
    public class TeamReadRepository : ITeamReadRepository
    {
        private readonly LeagueReadModelContext context;

        public TeamReadRepository(LeagueReadModelContext context)
        {
            this.context = context;
        }

        public async Task<IList<TeamViewModel>> Get()
        {
            return
                await this.context.Team.ToListAsync();
        }
    }
}