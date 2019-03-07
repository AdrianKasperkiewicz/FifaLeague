using System.Threading;
using System.Threading.Tasks;
using FL.Domain;
using FL.Domain.Aggregates.SeasonAggregate;
using MediatR;

namespace FL.Application.CommandHandlers.Division
{
    public class AssignTeamToDivisionCommandHandler : AsyncRequestHandler<AssignTeamToDivisionCommand>
    {
        private readonly IRepository<Season> repository;

        public AssignTeamToDivisionCommandHandler(IRepository<Season> repository)
        {
            this.repository = repository;
        }

        protected override async Task Handle(AssignTeamToDivisionCommand request, CancellationToken cancellationToken)
        {
            var aggregate = await this.repository.Get(request.SeasonId);

            aggregate.AddTeam(request.TeamId, request.DivisionId);

            await this.repository.Save(aggregate);
        }
    }
}