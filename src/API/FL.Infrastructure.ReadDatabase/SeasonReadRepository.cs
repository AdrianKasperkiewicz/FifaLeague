using System.Collections.Generic;
using System.Threading.Tasks;

using FL.Infrastructure.ReadDatabase.Database;
using Microsoft.EntityFrameworkCore;

namespace FL.Infrastructure.ReadDatabase
{
    public class SeasonReadRepository : ISeasonReadRepository
    {
        private readonly LeagueReadModelContext context;

        public SeasonReadRepository(LeagueReadModelContext context)
        {
            this.context = context;
        }

        public async Task<IList<SeasonViewModel>> GetSeasons()
        {
            return await this.context.Season.ToListAsync();
        }
    }
}
