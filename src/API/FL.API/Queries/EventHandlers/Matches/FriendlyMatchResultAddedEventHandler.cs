namespace FL.API.Queries.EventHandlers.Matches
{
    using System.Linq;
    using FL.API.Queries.Database;
    using FL.API.Queries.ViewModels;
    using FL.Domain.Aggregates.MatchAggregate.Events;
    using MediatR;

    public class FriendlyMatchResultAddedEventHandler : NotificationHandler<FriendlyMatchResultAddedEvent>
    {
        private readonly LeagueReadModelContext context;

        public FriendlyMatchResultAddedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(FriendlyMatchResultAddedEvent notification)
        {
            var match = new MatchViewModel()
            {
                Date = notification.Date,
                AwayGoals = notification.AwayGoals,
                HomeGoals = notification.HomeGoals,
                HomeTeam = this.context.Teams.First(x => x.Id == notification.HomeTeamId).GetFullName(),
                AwayTeam = this.context.Teams.First(x => x.Id == notification.AwayTeamId).GetFullName()
            };

            this.context.Add(match);
            this.context.SaveChanges();
        }
    }
}
