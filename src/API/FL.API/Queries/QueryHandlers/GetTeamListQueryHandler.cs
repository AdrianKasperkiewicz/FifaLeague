using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FL.API.Queries.Database;
using FL.Application;
using FL.API.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FL.API.Queries.QueryHandlers
{
    public class GetTeamListQueryHandler : IRequestHandler<GetTeamListQuery, List<TeamViewModel>>
    {
        private readonly LeagueReadModelContext repository;

        public GetTeamListQueryHandler(LeagueReadModelContext repository)
        {
            this.repository = repository;
        }

        public async Task<List<TeamViewModel>> Handle(GetTeamListQuery request, CancellationToken cancellationToken)
        {
            return await this.repository.Team.ToListAsync(cancellationToken);
        }
    }

    public class GetTeamListQuery : IRequest<List<TeamViewModel>>
    {
    }
}
