﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FL.API.Queries.QueryHandlers.Teams
{
    public class GetTopFiveTeamQueryHandler : IRequestHandler<GetTopTeamQuery, List<TeamViewModel>>
    {
        private readonly LeagueReadModelContext repository;

        public GetTopFiveTeamQueryHandler(LeagueReadModelContext repository)
        {
            this.repository = repository;
        }

        public async Task<List<TeamViewModel>> Handle(GetTopTeamQuery request, CancellationToken cancellationToken)
        {
            return await this.repository.Teams.Take(request.Count).ToListAsync(cancellationToken);
        }
    }

    public class GetTopTeamQuery : IRequest<List<TeamViewModel>>
    {
        public GetTopTeamQuery(int count)
        {
            this.Count = count;
        }

        public int Count { get; }
    }
}
