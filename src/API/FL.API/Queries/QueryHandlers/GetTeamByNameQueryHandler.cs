using FL.API.Queries.ViewModels;

namespace FL.API.Queries.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using FL.API.Queries.Database;
    using FL.Application;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetTeamByNameQueryHandler : IRequestHandler<GetTeamByNameQuery, IList<TeamViewModel>>
    {
        private readonly LeagueReadModelContext repository;

        public GetTeamByNameQueryHandler(LeagueReadModelContext repository)
        {
            this.repository = repository;
        }

        public async Task<IList<TeamViewModel>> Handle(GetTeamByNameQuery request, CancellationToken cancellationToken)
        {
            return await this.repository
                .Team
                .Where(x =>
                    x.FirstName.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase) ||
                    x.LastName.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase))
                .ToListAsync(cancellationToken);
        }
    }

    public class GetTeamByNameQuery : IRequest<IList<TeamViewModel>>
    {
        public GetTeamByNameQuery(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
