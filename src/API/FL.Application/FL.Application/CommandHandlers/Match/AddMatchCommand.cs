using System;
using MediatR;

namespace FL.Application.CommandHandlers.Match
{
    public class AddMatchCommand : IRequest<Guid>
    {
    }
}