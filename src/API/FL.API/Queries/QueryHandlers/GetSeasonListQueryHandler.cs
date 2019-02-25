using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FL.API.Queries.QueryHandlers
{
    public class GetSeasonListQueryHandler : IRequestHandler<GetSeasonListQuery, IList<SeasonViewModel>>
    {
        private readonly LeagueReadModelContext repository;

        public GetSeasonListQueryHandler(LeagueReadModelContext repository)
        {
            this.repository = repository;
        }

        public async Task<IList<SeasonViewModel>> Handle(GetSeasonListQuery request, CancellationToken cancellationToken)
        {
            return await this.repository.Season.ToListAsync(cancellationToken);
        }
    }

    public class GetSeasonListQuery : IRequest<IList<SeasonViewModel>>
    {
    }
}
