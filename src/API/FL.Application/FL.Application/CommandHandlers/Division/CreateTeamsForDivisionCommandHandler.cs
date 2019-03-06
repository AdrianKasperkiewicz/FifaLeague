namespace FL.Application.CommandHandlers.Division
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using FL.Domain;
    using FL.Domain.Aggregates.SeasonAggregate;
    using FL.Domain.Aggregates.TeamAggregate;
    using FluentValidation;
    using MediatR;

    public class CreateTeamsForDivisionCommandHandler : AsyncRequestHandler<CreateTeamsForDivisionCommand>
    {
        private readonly IRepository<Team> teamRepository;
        private readonly IRepository<Season> seasonRepository;

        public CreateTeamsForDivisionCommandHandler(IRepository<Team> teamRepository, IRepository<Season> seasonRepository)
        {
            this.teamRepository = teamRepository;
            this.seasonRepository = seasonRepository;
        }

        protected override async Task Handle(CreateTeamsForDivisionCommand request, CancellationToken cancellationToken)
        {
            var season = await this.seasonRepository.Get(request.SeasonId);

            foreach (var division in request.Divisions)
            {
                foreach (var newTeam in division.Teams)
                {
                    var team = new Team(newTeam.FirstName, newTeam.LastName, newTeam.Email);

                    season.AddTeam(division.DivisionId, team.Id.Value);

                    await this.teamRepository.Save(team);
                }
            }

            await this.seasonRepository.Save(season);
        }
    }

    public class CreateTeamsForDivisionCommand : IRequest
    {
        public CreateTeamsForDivisionCommand(Guid seasonId, DivisionViewModel[] divisions)
        {
            this.SeasonId = seasonId;
            this.Divisions = divisions;
        }

        public Guid SeasonId { get; }

        public DivisionViewModel[] Divisions { get; }
    }

    public class DivisionViewModel
    {
        public Guid DivisionId { get; set; }

        public NewTeamViewModel[] Teams { get; set; }
    }

    public class NewTeamViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }

    public class CreateTeamsForDivisionCommandValidator : AbstractValidator<CreateTeamsForDivisionCommand>
    {
        public CreateTeamsForDivisionCommandValidator()
        {
            this.RuleFor(x => x.SeasonId)
                .NotEmpty();

            this.RuleForEach(x => x.Divisions)
                .SetValidator(new DivisionViewModelValidatior());
        }
    }

    internal class DivisionViewModelValidatior : AbstractValidator<DivisionViewModel>
    {
        public DivisionViewModelValidatior()
        {
            this.RuleFor(x => x.DivisionId)
                .NotEmpty();

            this.RuleForEach(x => x.Teams)
             .SetValidator(new NewTeamViewModelValidatior());
        }
    }

    internal class NewTeamViewModelValidatior : AbstractValidator<NewTeamViewModel>
    {
        public NewTeamViewModelValidatior()
        {
            this.RuleFor(x => x.FirstName)
                .NotEmpty();

            this.RuleFor(x => x.Email)
                .EmailAddress();
        }
    }
}
