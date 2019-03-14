using System;
using System.Threading;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.Aggregates.FixtureAggregate;
using MediatR;

namespace FL.Application.CommandHandlers.Fixtures
{
    public class EndFixtureCommandHandler : AsyncRequestHandler<EndFixtureCommand>
    {
        private readonly IRepository<WeekFixture> repository;

        public EndFixtureCommandHandler(IRepository<WeekFixture> repository)
        {
            this.repository = repository;
        }

        protected override async Task Handle(EndFixtureCommand request, CancellationToken cancellationToken)
        {
            var fixture = await this.repository.Get(request.FixtureId);

            fixture.Finish();

            await this.repository.Save(fixture);
        }
    }

    public class EndFixtureCommand : IRequest
    {
        public EndFixtureCommand(Guid fixtureId)
        {
            this.FixtureId = fixtureId;
        }

        public Guid FixtureId { get; }
    }
}
