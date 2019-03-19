namespace FL.API.Queries.QueryHandlers.Matches
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FL.API.Queries.Database;
    using FL.API.Queries.ViewModels;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetLastMatchesQueryHandler : IRequestHandler<GetLastMatchesQuery, IList<MatchViewModel>>
    {
        private readonly LeagueReadModelContext dbContext;

        public GetLastMatchesQueryHandler(LeagueReadModelContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<MatchViewModel>> Handle(GetLastMatchesQuery request, CancellationToken cancellationToken)
        {
            int numberOfMatches = request.NumberOfMatches.HasValue ? request.NumberOfMatches.Value : 5;

            return await this.dbContext
                .Matches
                .OrderByDescending(x => x.Date)
                .Take(numberOfMatches)
                .ToListAsync();
        }
    }

    public class GetLastMatchesQuery : IRequest<IList<MatchViewModel>>
    {
        public GetLastMatchesQuery(int? numberOfMatches)
        {
            this.NumberOfMatches = numberOfMatches;
        }

        public int? NumberOfMatches { get; }
    }
}