using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

namespace FL.Application.CommandHandlers.Fixtures
{
    public class EndFixtureCommandHandler : AsyncRequestHandler<EndFixtureCommand>
    {
        protected override Task Handle(EndFixtureCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
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
