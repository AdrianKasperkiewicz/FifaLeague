using System;
using System.Threading;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.Aggregates.MatchAggregate;
using FluentValidation;
using MediatR;

namespace FL.Application.CommandHandlers.Matches
{
    public class AddLeagueMatchResultCommandHandler : IRequestHandler<AddLeagueMatchResultCommand, Guid>
    {
        private readonly IRepository<MatchResult> repository;

        public AddLeagueMatchResultCommandHandler(IRepository<MatchResult> repository)
        {
            this.repository = repository;
        }

        public async Task<Guid> Handle(AddLeagueMatchResultCommand request, CancellationToken cancellationToken)
        {
            var newMatch = new MatchResult(request.FixtureId, request.HomeTeam, request.AwayTeam, request.HomeGoals, request.AwayGoals);
            await this.repository.Save(newMatch);

            return newMatch.Id.Value;
        }
    }

    public class AddLeagueMatchResultCommand : IRequest<Guid>
    {
        public AddLeagueMatchResultCommand(Guid homeTeam, Guid awayTeam, int homeGoals, int awayGoals, Guid fixtureId)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.HomeGoals = homeGoals;
            this.AwayGoals = awayGoals;
            this.FixtureId = fixtureId;
        }

        public Guid HomeTeam { get; }

        public Guid AwayTeam { get; }

        public int HomeGoals { get; }

        public int AwayGoals { get; set; }

        public Guid FixtureId { get; set; }
    }

    public class AddLeagueMatchResultCommandValidator : AbstractValidator<AddLeagueMatchResultCommand>
    {
        public AddLeagueMatchResultCommandValidator()
        {
            this.RuleFor(x => x.AwayTeam)
                .NotEmpty()
                .NotNull()
                .NotEqual(Guid.NewGuid());

            this.RuleFor(x => x.HomeTeam)
                .NotEmpty()
                .NotNull()
                .NotEqual(Guid.NewGuid());

            this.RuleFor(x => x.FixtureId)
                .NotEmpty()
                .NotNull()
                .NotEqual(Guid.NewGuid());

            this.RuleFor(x => x.HomeGoals)
                .GreaterThanOrEqualTo(0);

            this.RuleFor(x => x.AwayGoals)
                .GreaterThanOrEqualTo(0);
        }
    }
}