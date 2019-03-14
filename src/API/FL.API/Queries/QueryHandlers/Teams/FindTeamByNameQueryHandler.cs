using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FL.API.Queries.QueryHandlers.Teams
{
    public class FindTeamByNameQueryHandler : IRequestHandler<FindTeamByNameQuery, IList<TeamViewModel>>
    {
        private readonly LeagueReadModelContext repository;

        public FindTeamByNameQueryHandler(LeagueReadModelContext repository)
        {
            this.repository = repository;
        }

        public async Task<IList<TeamViewModel>> Handle(FindTeamByNameQuery request, CancellationToken cancellationToken)
        {
            return await this.repository
                .Teams
                .Where(x =>
                    x.FirstName.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase) ||
                    x.LastName.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase))
                .ToListAsync(cancellationToken);
        }
    }

    public class FindTeamByNameQuery : IRequest<IList<TeamViewModel>>
    {
        public FindTeamByNameQuery(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
