namespace FL.API.Queries.EventHandlers.Fixtures
{
    using System.Linq;

    using FL.API.Queries.Database;
    using FL.Domain.Aggregates.FixtureAggregate.Events;
    using MediatR;

    public class MatchPostponedEventHandler : NotificationHandler<MatchPostponedEvent>
    {
        private readonly LeagueReadModelContext context;

        public MatchPostponedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(MatchPostponedEvent notification)
        {
            var match = this.context.FixtureMatches.First(x => x.MatchId == notification.MatchId);
            match.Posponed = true;

            this.context.Update(match);
            this.context.SaveChanges();
        }
    }
}
