﻿namespace FL.Application.CommandHandlers.Teams
{
    using System.Threading;
    using System.Threading.Tasks;

    using FL.Domain;
    using FL.Domain.Aggregates.TeamAggregate;
    using FluentValidation;
    using MediatR;

    public class CreateTeamHandler : AsyncRequestHandler<CreateTeamCommand>
    {
        private readonly IRepository<Team> repository;

        public CreateTeamHandler(IRepository<Team> repository)
        {
            this.repository = repository;
        }

        protected override async Task Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var aggregate = new Team(request.FirstName, request.LastName, request.Email);

            await this.repository.Save(aggregate);
        }
    }

    public class CreateTeamCommand : IRequest
    {
        public CreateTeamCommand(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }
    }

    public class CreateTeamsCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamsCommandValidator()
        {
            this.RuleFor(x => x.FirstName)
                .NotEmpty();

            this.RuleFor(x => x.Email)
                .EmailAddress();
        }
    }
}