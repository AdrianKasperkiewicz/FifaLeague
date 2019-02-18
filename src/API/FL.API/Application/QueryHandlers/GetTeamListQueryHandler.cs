using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FL.Infrastructure.ReadDatabase;
using MediatR;

namespace FL.API.Application.QueryHandlers
{
    public class GetTeamListQueryHandler : IRequestHandler<GetTeamListQuery, IList<TeamViewModel>>
    {
        private readonly ITeamReadRepository repository;

        public GetTeamListQueryHandler(ITeamReadRepository repository)
        {
            this.repository = repository;
        }

        public Task<IList<TeamViewModel>> Handle(GetTeamListQuery request, CancellationToken cancellationToken)
        {
            return this.repository.Get();
        }
    }
    public class GetTeamListQuery : IRequest<IList<TeamViewModel>>
    {
    }
}
