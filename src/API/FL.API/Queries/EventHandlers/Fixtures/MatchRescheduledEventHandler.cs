namespace FL.API.Queries.EventHandlers.Fixtures
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using FL.API.Queries.Database;
    using FL.API.Queries.ViewModels;
    using FL.Domain.Aggregates.FixtureAggregate.Events;
    using MediatR;

    public class MatchRescheduledEventHandler : INotificationHandler<MatchRescheduledEvent>
    {
        private readonly LeagueReadModelContext dbContext;

        public MatchRescheduledEventHandler(LeagueReadModelContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(MatchRescheduledEvent notification, CancellationToken cancellationToken)
        {
            var fixture = this.dbContext.Fixtures.Single(x => x.FixtureId == notification.FixtureId);
            var homeTeam = this.dbContext.Teams.First(x => x.Id == notification.HomeTeamId);
            var awayTeam = this.dbContext.Teams.First(x => x.Id == notification.AwayTeamId);

            var match = new FixtureMatchViewModel
            {
                HomeTeam = $"{homeTeam.FirstName} {homeTeam.LastName}",
                HomeTeamId = notification.HomeTeamId,
                AwayTeam = $"{awayTeam.FirstName} {awayTeam.LastName}",
                AwayTeamId = notification.HomeTeamId,
                StartDate = fixture.StartDate,
                EndDate = fixture.EndDate,
                FixtureId = fixture.FixtureId,
                SeasonId = fixture.SeasonId,
                DivisionId = fixture.DivisionId,
                WeekNumber = fixture.WeekNumber,
                MatchId = notification.MatchId,
                Rescheluded = true
            };

            await this.dbContext.AddAsync(match);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
