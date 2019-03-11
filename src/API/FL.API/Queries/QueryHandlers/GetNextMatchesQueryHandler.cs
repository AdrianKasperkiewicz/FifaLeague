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
    public class GetNextMatchesQueryHandler : IRequestHandler<GetCurrentFixtureQuery, IList<FixtureViewModel>>
    {
        private readonly LeagueReadModelContext dbContext;

        public GetNextMatchesQueryHandler(LeagueReadModelContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<FixtureViewModel>> Handle(GetCurrentFixtureQuery request, CancellationToken cancellationToken)
        {

            return await this.dbContext.Fixtures
                .Where(x => x.StartDate.Date >= DateTime.Now.Date && x.EndDate.Date <= DateTime.Now.Date)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetCurrentFixtureQuery : IRequest<IList<FixtureViewModel>>
    {
        public GetCurrentFixtureQuery(int? number)
        {
            this.Number = number;
        }

        public int? Number { get; }
    }
}