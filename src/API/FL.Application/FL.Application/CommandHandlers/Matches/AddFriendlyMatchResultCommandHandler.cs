using System;
using System.Threading;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.Aggregates.MatchAggregate;
using FluentValidation;
using MediatR;

namespace FL.Application.CommandHandlers.Matches
{
    public class AddFriendlyMatchResultCommandHandler : IRequestHandler<AddFriendlyMatchResultCommand, Guid>
    {
        private readonly IRepository<MatchResult> repository;

        public AddFriendlyMatchResultCommandHandler(IRepository<MatchResult> repository)
        {
            this.repository = repository;
        }

        public async Task<Guid> Handle(AddFriendlyMatchResultCommand request, CancellationToken cancellationToken)
        {
            var newMatch = new MatchResult(request.HomeTeam, request.AwayTeam, request.HomeGoals, request.AwayGoals);
            await this.repository.Save(newMatch);

            return newMatch.Id.Value;
        }
    }

    public class AddFriendlyMatchResultCommand : IRequest<Guid>
    {
        public Guid HomeTeam { get; }

        public Guid AwayTeam { get; }

        public int HomeGoals { get; }

        public int AwayGoals { get; set; }
    }

    public class AddFriendlyMatchResultCommandValidator : AbstractValidator<AddFriendlyMatchResultCommand>
    {
        public AddFriendlyMatchResultCommandValidator()
        {
            this.RuleFor(x => x.AwayTeam)
                .NotEmpty()
                .NotNull()
                .NotEqual(Guid.NewGuid());

            this.RuleFor(x => x.HomeTeam)
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