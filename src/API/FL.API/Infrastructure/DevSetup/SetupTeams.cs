using Bogus;
using Bogus.Extensions;
using FL.Application.CommandHandlers.Teams;
using MediatR;

namespace FL.API.Infrastructure.DevSetup
{
    public class SetupTeams
    {
        private readonly IMediator mediator;

        public SetupTeams(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Seed()
        {
            var commands = CreateTeamCommandFaker().GenerateBetween(20, 50);

            foreach (var command in commands)
            {
                this.mediator.Send(command);
            }
        }

        private static Faker<CreateTeamCommand> CreateTeamCommandFaker()
        {
            return new Faker<CreateTeamCommand>()
                .CustomInstantiator(f => new CreateTeamCommand(f.Name.FirstName(), f.Name.LastName(), f.Internet.Email()))
                .RuleFor(x => x.Email, (f, x) => f.Internet.Email(x.FirstName, x.LastName));
        }
    }
}
