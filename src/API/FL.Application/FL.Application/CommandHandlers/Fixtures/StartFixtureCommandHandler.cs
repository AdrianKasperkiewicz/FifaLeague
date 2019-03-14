using System;
using System.Threading;
using System.Threading.Tasks;
using FL.Domain;
using FL.Domain.Aggregates.FixtureAggregate;
using MediatR;

namespace FL.Application.CommandHandlers.Fixtures
{
    public class StartFixtureCommandHandler : AsyncRequestHandler<StartFixtureCommand>
    {
        private readonly IRepository<WeekFixture> repository;

        public StartFixtureCommandHandler(IRepository<WeekFixture> repository)
        {
            this.repository = repository;
        }

        protected override async Task Handle(StartFixtureCommand request, CancellationToken cancellationToken)
        {
            var fixture = await this.repository.Get(request.FixtureId);

            fixture.Start();

            await this.repository.Save(fixture);
        }
    }

    public class StartFixtureCommand : IRequest
    {
        public StartFixtureCommand(Guid fixtureId)
        {
            this.FixtureId = fixtureId;
        }

        public Guid FixtureId { get; }
    }
}
