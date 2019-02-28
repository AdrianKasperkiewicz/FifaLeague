namespace FL.Application.CommandHandlers.Teams
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using FL.Application.CommandHandlers.Division;
    using FL.Domain;
    using FL.Domain.Aggregates.SeasonAggregate.Events;
    using FL.Domain.Aggregates.TeamAggregate;
    using FluentValidation;
    using MediatR;

    public class CreateTeamHandler : AsyncRequestHandler<CreateTeamsCommand>
    {
        private readonly IRepository<Team> repository;
        private readonly IMediator mediator;

        public CreateTeamHandler(IRepository<Team> repository, IMediator mediator)
        {
            this.repository = repository;
            this.mediator = mediator;
        }

        protected override async Task Handle(CreateTeamsCommand request, CancellationToken cancellationToken)
        {
            foreach (var team in request.Teams)
            {
                var aggregate = new Team(team.Name, team.Email);
                await this.repository.Save(aggregate);

                foreach (var @event in aggregate.GetUncommittedChanges())
                {
                    await this.mediator.Publish(@event);
                }

                await this.mediator.Send(new AddNewTeamToDivisionCommand(aggregate.Id.Value, request.SeasonId, team.DivisionId));
            }
        }
    }

    public class CreateTeamsCommand : IRequest
    {
        public CreateTeamsCommand(Guid seasonId, IList<TeamViewModel> teams)
        {
            this.SeasonId = seasonId;
            this.Teams = teams;
        }

        public IList<TeamViewModel> Teams { get; }

        public Guid SeasonId { get; }
    }

    public class TeamViewModel
    {
        public TeamViewModel(string name, string email, Guid divisionId)
        {
            this.Email = email;
            this.DivisionId = divisionId;
            this.Name = name;
        }

        public string Name { get; }

        public string Email { get; }

        public Guid DivisionId { get; }
    }

    public class CreateTeamsCommandValidator : AbstractValidator<CreateTeamsCommand>
    {
        public CreateTeamsCommandValidator()
        {
            this.RuleFor(x => x.SeasonId)
                .NotEmpty();

            this.RuleForEach(x => x.Teams)
                .SetValidator(new TeamViewModelValidatior());
        }
    }

    internal class TeamViewModelValidatior : AbstractValidator<TeamViewModel>
    {
        public TeamViewModelValidatior()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty();

            this.RuleFor(x => x.Email)
                .EmailAddress();

            this.RuleFor(x => x.DivisionId)
                .NotEmpty()
                .NotNull()
                .NotEqual(Guid.NewGuid());
        }
    }
}