namespace FL.API.Queries.QueryHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FL.API.Queries.Database;
    using FL.API.Queries.ViewModels;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetDivisionByNameQueryHandler : IRequestHandler<GetDivisionByNameQuery, IList<DivisionViewModel>>
    {
        private readonly LeagueReadModelContext repository;

        public GetDivisionByNameQueryHandler(LeagueReadModelContext repository)
        {
            this.repository = repository;
        }

        public async Task<IList<DivisionViewModel>> Handle(GetDivisionByNameQuery request, CancellationToken cancellationToken)
        {
            return await this.repository
                .Divisions
                .Where(x => x.Name.Contains(request.Name))
                .ToListAsync();
        }
    }

    public class GetDivisionByNameQuery : IRequest<IList<DivisionViewModel>>
    {
        public GetDivisionByNameQuery(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
