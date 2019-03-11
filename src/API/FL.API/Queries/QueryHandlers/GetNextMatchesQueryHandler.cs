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

            var query = this.dbContext.Fixtures
                .Where(x => x.StartDate.Date >= DateTime.Now.Date && x.EndDate.Date <= DateTime.Now.Date);

                return request.Number.HasValue ?
                    await query.Take(request.Number.Value).ToListAsync(cancellationToken) :
                    await query.ToListAsync(cancellationToken);
        }
    }

    public class GetCurrentFixtureQuery : IRequest<IList<FixtureViewModel>>
    {
        public GetCurrentFixtureQuery(int? number = null)
        {
            this.Number = number;
        }

        public int? Number { get; }
    }
}