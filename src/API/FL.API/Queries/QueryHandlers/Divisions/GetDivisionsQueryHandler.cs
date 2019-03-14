using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FL.API.Queries.QueryHandlers.Divisions
{
    public class GetDivisionsQueryHandler : IRequestHandler<GetDivisionsQuery, IList<DivisionViewModel>>
    {
        private readonly LeagueReadModelContext context;

        public GetDivisionsQueryHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        public async Task<IList<DivisionViewModel>> Handle(GetDivisionsQuery request, CancellationToken cancellationToken)
        {
            return await this.context.Divisions.ToListAsync(cancellationToken);
        }
    }

    public class GetDivisionsQuery : IRequest<IList<DivisionViewModel>>
    {
    }
}
