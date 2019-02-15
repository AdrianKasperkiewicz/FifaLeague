using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace FL.API.Application.CommandHandlers.Seasons
{
    public class CreateSeasonHandler : IRequestHandler<CreateSeasonCommand, Guid>
    {
        public Task<Guid> Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class CreateSeasonCommand : IRequest<Guid>
    {
        public string Name { get; }
    }
}