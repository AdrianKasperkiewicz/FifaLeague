using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FL.Domain;
using FL.Domain.Aggregates.TeamAggregate;
using MediatR;

namespace FL.API.Application.CommandHandlers.Teams
{
    public class CreateTeamHandler : IRequestHandler<CreateTeamCommand, Guid>
    {
        private readonly IRepository<Team> repository;
        private readonly IMediator mediator;

        public CreateTeamHandler(IRepository<Team> repository, IMediator mediator)
        {
           this.repository = repository;
            this.mediator = mediator;
        }

        public Task<Guid> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = new Team(request.Name, request.Email);

           this.repository.Save(team);

           foreach(var @event in team.DomainEvents)
            {
                this.mediator.Publish(@event);
            }

            return Task.FromResult(Guid.NewGuid());
        }
    }

    public class CreateTeamCommand : IRequest<Guid>
    {
        public CreateTeamCommand(string name, string email)
        {
            this.Email = email;
            this.Name = name;
        }

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