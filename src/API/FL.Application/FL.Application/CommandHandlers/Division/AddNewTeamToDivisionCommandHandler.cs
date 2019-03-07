namespace FL.Application.CommandHandlers.Division
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FL.Domain;
    using FL.Domain.Aggregates.SeasonAggregate;
    using FluentValidation;
    using MediatR;

    public class AddNewTeamToDivisionCommandHandler : AsyncRequestHandler<AddNewTeamToDivisionCommand>
    {
        private readonly IRepository<Season> repository;

        public AddNewTeamToDivisionCommandHandler(IRepository<Season> repository)
        {
            this.repository = repository;
        }

        protected override async Task Handle(AddNewTeamToDivisionCommand request, CancellationToken cancellationToken)
        {
            var aggregate = await this.repository.Get(request.SeasonId);

            aggregate.AddTeam(request.TeamId, request.DivisionId);

            await this.repository.Save(aggregate);
        }
    }

    public class AddNewTeamToDivisionCommand : IRequest
    {
        public AddNewTeamToDivisionCommand(Guid teamId, Guid seasonId, Guid divisionId)
        {
            this.TeamId = teamId;
            this.SeasonId = seasonId;
            this.DivisionId = divisionId;
        }

        public Guid TeamId { get; }

        public Guid SeasonId { get; }

        public Guid DivisionId { get; }
    }

    public class AddNewTeamToDivisionCommandValidator : AbstractValidator<AddNewTeamToDivisionCommand>
    {
        public AddNewTeamToDivisionCommandValidator()
        {
            this.RuleFor(x => x.SeasonId)
                .NotEmpty()
                .NotNull()
                .NotEqual(Guid.NewGuid());

            this.RuleFor(x => x.TeamId)
                  .NotEmpty()
                  .NotNull()
                  .NotEqual(Guid.NewGuid());
        }
    }
}
