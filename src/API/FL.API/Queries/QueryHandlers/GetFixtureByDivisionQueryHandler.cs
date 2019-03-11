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
    public class GetFixtureByDivisionQueryHandler : IRequestHandler<GetFixtureByDivisionQuery, IList<FixtureViewModel>>
    {
        private readonly LeagueReadModelContext dbContext;

        public GetFixtureByDivisionQueryHandler(LeagueReadModelContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<FixtureViewModel>> Handle(GetFixtureByDivisionQuery request, CancellationToken cancellationToken)
        {
            return await this.dbContext.Fixtures
                .Where(x => x.DivisionId == request.DivisionId)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetFixtureByDivisionQuery : IRequest<IList<FixtureViewModel>>
    {
        public GetFixtureByDivisionQuery(Guid divisionId)
        {
            this.DivisionId = divisionId;
        }

        public Guid DivisionId { get; }
    }
}
