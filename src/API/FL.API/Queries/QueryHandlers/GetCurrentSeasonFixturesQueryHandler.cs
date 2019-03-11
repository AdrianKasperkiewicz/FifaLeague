using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FL.API.Queries.QueryHandlers
{
    public class GetCurrentSeasonFixturesQueryHandler : IRequestHandler<GetCurrentSeasonFixturesQuery, List<FixtureViewModel>>
    {
        private readonly LeagueReadModelContext dbContext;

        public GetCurrentSeasonFixturesQueryHandler(LeagueReadModelContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<FixtureViewModel>> Handle(GetCurrentSeasonFixturesQuery request, CancellationToken cancellationToken)
        {
            var seasonId = this.dbContext.Seasons.FirstOrDefault(x => x.IsRunning)?.Id;

            if (seasonId != null)
            {
                return await this.dbContext.Fixtures.Where(x => x.SeasonId == seasonId).ToListAsync(cancellationToken);
            }

            seasonId = this.dbContext.Seasons
                .Where(x => x.StartDate.Date > DateTime.Now.Date)
                .OrderBy(x => x.StartDate)
                .FirstOrDefault()?.Id;

            return seasonId.HasValue ? 
                await this.dbContext.Fixtures.Where(x => x.SeasonId == seasonId).ToListAsync(cancellationToken) :
                new List<FixtureViewModel>();
        }
    }

    public class GetCurrentSeasonFixturesQuery : IRequest<List<FixtureViewModel>>
    {
    }
}