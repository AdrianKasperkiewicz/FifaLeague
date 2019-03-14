using System.Linq;
using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using FL.Domain.Aggregates.FixtureAggregate.Events;
using MediatR;

namespace FL.API.Queries.EventHandlers.Fixtures
{
    public class FixtureMatchAddedEventHandler : NotificationHandler<FixtureMatchAddedEvent>
    {
        private readonly LeagueReadModelContext context;

        public FixtureMatchAddedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(FixtureMatchAddedEvent notification)
        {
            var fixture = this.context.Fixtures.Single(x => x.FixtureId == notification.FixtureGuid);

            var match = new FixtureMatchViewModel
            {
                HomeTeam = this.context.DivisionTeams.First(x => x.TeamId == notification.HomeTeamId && x.DivisionId == fixture.DivisionId).FullTeamName,
                HomeTeamId = notification.HomeTeamId,
                AwayTeam = this.context.DivisionTeams.First(x => x.TeamId == notification.AwayTeamId && x.DivisionId == fixture.DivisionId).FullTeamName,
                AwayTeamId = notification.HomeTeamId,
                StartDate = fixture.StartDate,
                EndDate = fixture.EndDate,
                FixtureId = fixture.FixtureId,
                SeasonId = fixture.SeasonId,
                DivisionId = fixture.DivisionId,
                WeekNumber = fixture.WeekNumber,
                MatchId = notification.MatchId
            };

            this.context.Add(match);
            this.context.SaveChanges();
        }
    }
}
