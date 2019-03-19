using System;
using System.Threading;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.Aggregates.MatchAggregate;
using FluentValidation;
using MediatR;

namespace FL.Application.CommandHandlers.Matches
{
    public class AddMatchResultCommandHandler : IRequestHandler<AddMatchResultCommand, Guid>
    {
        private readonly IRepository<MatchResult> repository;

        public AddMatchResultCommandHandler(IRepository<MatchResult> repository)
        {
            this.repository = repository;
        }

        public async Task<Guid> Handle(AddMatchResultCommand request, CancellationToken cancellationToken)
        {
            var newMatch = new MatchResult(request.HomeTeam.TeamId, request.AwayTeam.TeamId, request.HomeTeam.Goals, request.AwayTeam.Goals, request.Date);
            await this.repository.Save(newMatch);

            return newMatch.Id.Value;
        }
    }

    public class AddMatchResultCommand : IRequest<Guid>
    {
        public AddMatchResultCommand(DateTime date, int matchType, TeamScore homeTeam, TeamScore awayTeam)
        {
            this.Date = date;
            this.MatchType = matchType;
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
        }

        public DateTime Date { get; }

        public int MatchType { get; }

        public TeamScore HomeTeam { get; }

        public TeamScore AwayTeam { get; }
    }

    public class TeamScore
    {
        public TeamScore(Guid teamId, int goals)
        {
            this.TeamId = teamId;
            this.Goals = goals;
        }

        public Guid TeamId { get; }

        public int Goals { get; }
    }

    public class AddMatchResultCommandValidator : AbstractValidator<AddMatchResultCommand>
    {
        public AddMatchResultCommandValidator()
        {
            this.RuleFor(x => x.Date)
                .NotEmpty()
                .NotNull();

            this.RuleFor(x => x.HomeTeam).SetValidator(new TeamScoreValidator());

            this.RuleFor(x => x.HomeTeam).SetValidator(new TeamScoreValidator());
        }
    }

    public class TeamScoreValidator : AbstractValidator<TeamScore>
    {
        public TeamScoreValidator()
        {
            this.RuleFor(x => x.Goals)
                .GreaterThanOrEqualTo(0);

            this.RuleFor(x => x.TeamId)
                .NotEmpty()
                .NotNull()
                .NotEqual(Guid.NewGuid());
        }
    }
}