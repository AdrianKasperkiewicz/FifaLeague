using FL.API.Queries.ViewModels;

namespace FL.API.Queries.QueryHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using FL.API.Queries.Database;
    using FL.Application;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetTopFiveTeamQueryHandler : IRequestHandler<GetTopFiveTeamQuery, List<TeamViewModel>>
    {
        private readonly LeagueReadModelContext repository;

        public GetTopFiveTeamQueryHandler(LeagueReadModelContext repository)
        {
            this.repository = repository;
        }

        public async Task<List<TeamViewModel>> Handle(GetTopFiveTeamQuery request, CancellationToken cancellationToken)
        {
            return await this.repository.Team.Take(5).ToListAsync(cancellationToken);
        }
    }

    public class GetTopFiveTeamQuery : IRequest<List<TeamViewModel>>
    {
    }
}
