using System.Linq;

using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using FL.Domain.Aggregates.SeasonAggregate.Events;
using MediatR;

namespace FL.API.Queries.EventHandlers
{
    public class TeamAddedToDivisionEventHandler : NotificationHandler<TeamAddedToDivisionEvent>
    {
        private readonly LeagueReadModelContext context;

        public TeamAddedToDivisionEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(TeamAddedToDivisionEvent notification)
        {
            var team = this.context.Teams.First(x => x.Id == notification.TeamId);

            this.context.Add(new DivisionTeamViewModel()
            {
                DivisionId = notification.DivisionId,
                TeamId = notification.TeamId,
                FullTeamName = $"{team.FirstName} {team.LastName}",
                Email = team.Email
            });

            this.context.SaveChanges();
        }
    }
}
