using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FL.API.Queries.QueryHandlers
{
    public class GetAllFixtureMatchesQueryHandler : IRequestHandler<GetAllFixtureMatchesQuery, IList<FixtureMatchViewModel>>
    {
        private readonly LeagueReadModelContext repository;

        public GetAllFixtureMatchesQueryHandler(LeagueReadModelContext repository)
        {
            this.repository = repository;
        }

        public async Task<IList<FixtureMatchViewModel>> Handle(GetAllFixtureMatchesQuery request, CancellationToken cancellationToken)
        {
            return await this.repository
                .FixtureMatches.ToListAsync(cancellationToken);
        }
    }

    public class GetAllFixtureMatchesQuery : IRequest<IList<FixtureMatchViewModel>>
    {
    }
}
