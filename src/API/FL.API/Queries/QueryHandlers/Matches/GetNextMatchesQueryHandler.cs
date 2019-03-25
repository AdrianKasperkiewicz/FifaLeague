using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FL.API.Queries.QueryHandlers.Matches
{
    public class GetNextMatchesQueryHandler : IRequestHandler<GetCurrentFixtureQuery, IList<FixtureMatchViewModel>>
    {
        private readonly LeagueReadModelContext dbContext;

        public GetNextMatchesQueryHandler(LeagueReadModelContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<FixtureMatchViewModel>> Handle(GetCurrentFixtureQuery request, CancellationToken cancellationToken)
        {
            var fixture = this.GetCurrentOrNextFixture();

            if (fixture == null)
            {
                return new List<FixtureMatchViewModel>();
            }

            var query = this.dbContext.FixtureMatches
                .Where(x => x.FixtureId == fixture.FixtureId)
                .Where(x => !x.Posponed);

                return request.Number.HasValue ?
                    await query.Take(request.Number.Value).ToListAsync(cancellationToken) :
                    await query.ToListAsync(cancellationToken);
        }

        private FixtureViewModel GetCurrentOrNextFixture()
        {
            var fixture = this.dbContext.Fixtures.FirstOrDefault(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now);

            if (fixture == null)
            {
                return this.dbContext.Fixtures
                    .Where(x => x.StartDate > DateTime.Now)
                    .OrderBy(x => x.StartDate)
                    .FirstOrDefault();
            }

            return fixture;
        }
    }

    public class GetCurrentFixtureQuery : IRequest<IList<FixtureMatchViewModel>>
    {
        public GetCurrentFixtureQuery(int? number = null)
        {
            this.Number = number;
        }

        public int? Number { get; }
    }
}