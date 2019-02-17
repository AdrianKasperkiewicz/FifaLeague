using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FL.Infrastructure.ReadDatabase;
using MediatR;

namespace FL.API.Application.QueryHandlers
{
    public class GetSeasonListQueryHandler : IRequestHandler<GetSeasonListQuery, IList<SeasonViewModel>>
    {
        private readonly ISeasonReadRepository repository;

        public GetSeasonListQueryHandler(ISeasonReadRepository repository)
        {
            this.repository = repository;
        }

        public Task<IList<SeasonViewModel>> Handle(GetSeasonListQuery request, CancellationToken cancellationToken)
        {
            return this.repository.GetSeasons();
        }
    }

    public class GetSeasonListQuery : IRequest<IList<SeasonViewModel>>
    {
    }
}
