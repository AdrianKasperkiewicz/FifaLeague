using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FL.API.Queries.QueryHandlers.Divisions
{
    public class GetDivisionTeamsQueryHandler : IRequestHandler<GetDivisionTeamsQuery, IList<DivisionTeamViewModel>>
    {
        private readonly LeagueReadModelContext repository;

        public GetDivisionTeamsQueryHandler(LeagueReadModelContext repository)
        {
            this.repository = repository;
        }

        public async Task<IList<DivisionTeamViewModel>> Handle(GetDivisionTeamsQuery request, CancellationToken cancellationToken)
        {
            return await this.repository
                .DivisionTeams.Where(x => x.DivisionId == request.Id)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetDivisionTeamsQuery : IRequest<IList<DivisionTeamViewModel>>
    {
        public GetDivisionTeamsQuery(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }
    }
}
