using MediatR;
using System;

namespace FL.API.Application.CommandHandlers.Match
{
    public class AddMatchCommand : IRequest<Guid>
    {
    }
}
