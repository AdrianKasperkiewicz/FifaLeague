using System.Linq;

using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using FL.Domain.Aggregates.FixtureAggregate.Events;
using MediatR;

namespace FL.API.Queries.EventHandlers
{
    public class WeekFixtureCreatedEventHandler : NotificationHandler<WeekFixtureCreatedEvent>
    {
        private readonly LeagueReadModelContext context;

        public WeekFixtureCreatedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(WeekFixtureCreatedEvent notification)
        {
            foreach (var match in notification.MatchList)
            {
                var home = this.context.DivisionTeams.First(x => x.TeamId == match.Key).FullTeamName;
                var away = this.context.DivisionTeams.First(x => x.TeamId == match.Value).FullTeamName;
                var divisin = this.context.Divisions.First(x => x.Id == notification.DivisionId).Name;
                this.context.DivisionsMatches.Add(new DivisionMatchViewModel()
                {
                    HomeTeamId = match.Key,
                    HomeTeam = home,
                    AwayTeamId = match.Value,
                    AwayTeam = away,
                    DivisionId = notification.DivisionId,
                    Division = divisin,
                    FixtureWeek = notification.FixtureWeekNumber
                });
            }

            this.context.SaveChanges();
        }
    }
}
