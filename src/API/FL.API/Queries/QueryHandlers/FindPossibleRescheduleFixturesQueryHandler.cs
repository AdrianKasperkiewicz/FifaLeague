namespace FL.API.Queries.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FL.API.Queries.Database;
    using FL.API.Queries.ViewModels;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class FindPossibleRescheduleFixturesQueryHandler : IRequestHandler<FindPossibleRescheduleFixturesQuery, IList<FixtureViewModel>>
    {
        private readonly LeagueReadModelContext dbContext;

        public FindPossibleRescheduleFixturesQueryHandler(LeagueReadModelContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<FixtureViewModel>> Handle(FindPossibleRescheduleFixturesQuery request, CancellationToken cancellationToken)
        {
            var match = await this.dbContext.FixtureMatches.SingleAsync(x => x.MatchId == request.MatchId, cancellationToken);

            return await this.dbContext
                .Fixtures
                .Where(x => x.DivisionId == match.DivisionId)
                .Where(x => x.WeekNumber > match.WeekNumber)
                .ToListAsync();
        }
    }

    public class FindPossibleRescheduleFixturesQuery : IRequest<IList<FixtureViewModel>>
    {
        public FindPossibleRescheduleFixturesQuery(Guid matchId)
        {
            this.MatchId = matchId;
        }

        public Guid MatchId { get; }
    }
}
