using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

namespace FL.Application.CommandHandlers.Fixtures
{
    // TODO Comamnd validator
    public class StartFixtureCommandHandler : AsyncRequestHandler<StartFixtureCommand>
    {
        protected override Task Handle(StartFixtureCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
