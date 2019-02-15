using System;
using System.Threading;
using System.Threading.Tasks;

using FL.Domain;
using FluentValidation;
using FL.Domain.Aggregates.TeamAggregate;
using MediatR;

namespace FL.API.Application.CommandHandlers
{
    public class CreateTeamHandler : IRequestHandler<CreateTeamCommand, Guid>
    {
        private readonly ITeamRepository repository;

        public CreateTeamHandler(ITeamRepository repository)
        {
           this.repository = repository;
        }

        public Task<Guid> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = new Team(request.Name, request.Email);

           this.repository.Save(team);

            return Task.FromResult(Guid.NewGuid());
        }
    }

    public class CreateTeamCommand : IRequest<Guid>
    {
        public string Name { get; }

        public string Email { get; }
    }

    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}