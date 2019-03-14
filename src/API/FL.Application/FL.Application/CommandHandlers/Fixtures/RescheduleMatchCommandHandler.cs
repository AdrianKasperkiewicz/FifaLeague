using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.Aggregates.FixtureAggregate;
using FluentValidation;
using MediatR;

namespace FL.Application.CommandHandlers.Fixtures
{
    public class RescheduleMatchCommandHandler : AsyncRequestHandler<RescheduleMatchCommand>
    {
        private readonly IRepository<WeekFixture> fixtureRepository;

        public RescheduleMatchCommandHandler(IRepository<WeekFixture> fixtureRepository)
        {
            this.fixtureRepository = fixtureRepository;
        }

        protected override async Task Handle(RescheduleMatchCommand request, CancellationToken cancellationToken)
        {
            // TODO should be saga or domain service??
            var orginFixture = await this.fixtureRepository.Get(request.OrginFixtureId);
            var destinationFixture = await this.fixtureRepository.Get(request.DestinationFixtureId);

            if (orginFixture.DivisionId != destinationFixture.DivisionId)
            {
                throw new ArgumentException("Cannot move match beetween divisions");
            }

            var matchToMove = orginFixture.Matches.First(x => x.Id.Value == request.MatchId);

            orginFixture.PostponeMatch(request.MatchId);
            destinationFixture.Reschedule(matchToMove.HomeTeam, matchToMove.AwayTeam);

            await this.fixtureRepository.Save(destinationFixture);
            await this.fixtureRepository.Save(orginFixture);
        }
    }

    public class RescheduleMatchCommand : IRequest
    {
        public RescheduleMatchCommand(Guid matchId, Guid orginFixtureId, Guid destinationFixtureId)
        {
            this.MatchId = matchId;
            this.OrginFixtureId = orginFixtureId;
            this.DestinationFixtureId = destinationFixtureId;
        }

        public Guid MatchId { get; }

        public Guid OrginFixtureId { get; }

        public Guid DestinationFixtureId { get; }
    }

    public class RescheduleMatchCommandValidator : AbstractValidator<RescheduleMatchCommand>
    {
        public RescheduleMatchCommandValidator()
        {
            this.RuleFor(x => x.MatchId)
                .NotEmpty()
                .NotNull()
                .NotEqual(Guid.NewGuid());

            this.RuleFor(x => x.OrginFixtureId)
                  .NotEmpty()
                  .NotNull()
                  .NotEqual(Guid.NewGuid());

            this.RuleFor(x => x.DestinationFixtureId)
                  .NotEmpty()
                  .NotNull()
                  .NotEqual(Guid.NewGuid());
        }
    }
}
