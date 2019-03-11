using System.Collections.Generic;
using System.Linq;

using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using FL.Domain.Aggregates.FixtureAggregate.Events;
using MediatR;

namespace FL.API.Queries.EventHandlers
{
    public class WeekFixtureCreatedEventHandler : NotificationHandler<WeekFixtureCreatedEvent>
    {
        private LeagueReadModelContext context;

        public WeekFixtureCreatedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(WeekFixtureCreatedEvent notification)
        {
            var fixtures = new List<FixtureViewModel>();
            foreach (var match in notification.MatchList)
            {
                fixtures.Add(
                    new FixtureViewModel
                    {
                        HomeTeam = this.context.DivisionTeams.First(x => x.TeamId == match.Key && x.DivisionId == notification.DivisionId).FullTeamName,
                        HomeTeamId = match.Key,
                        AwayTeam = this.context.DivisionTeams.First(x => x.TeamId == match.Value && x.DivisionId == notification.DivisionId).FullTeamName,
                        AwayTeamId = match.Value,
                        StartDate = notification.StartDate,
                        EndDate = notification.EndDate,
                        FixtureId = notification.FixtureId,
                        SeasonId = notification.SeasonId,
                        DivisionId = notification.DivisionId,
                        WeekNumber = notification.FixtureWeekNumber
                    });
            }

            this.context.AddRange(fixtures);
            this.context.SaveChanges();
        }
    }
}
