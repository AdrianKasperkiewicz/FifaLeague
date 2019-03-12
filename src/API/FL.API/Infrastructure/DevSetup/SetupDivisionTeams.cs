namespace FL.API.Infrastructure.DevSetup
{
    using System;

    using FL.API.Queries.QueryHandlers;
    using FL.Application.CommandHandlers.Division;
    using MediatR;

    public class SetupDivisionTeams
    {
        private readonly IMediator mediator;

        public SetupDivisionTeams(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Seed()
        {
            var divisions = this.mediator.Send(new GetDivisionsQuery()).Result;
            var teams = this.mediator.Send(new GetTeamListQuery()).Result;
            Random rand = new Random();

            foreach (var team in teams)
            {
               var division = divisions[rand.Next(0, divisions.Count)];
                this.mediator.Send(new AddTeamForDivisionCommand(division.SeasonId, division.Id, team.Id));
            }
        }
    }
}
