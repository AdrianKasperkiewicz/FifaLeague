using System;
using System.Linq;

using FL.API.Queries.Database;
using FL.Domain.Aggregates.SeasonAggregate.Events;
using MediatR;

namespace FL.API.Queries.EventHandlers
{
    public class SeasonStartedEventHandler : NotificationHandler<SeasonStartedEvent>
    {
        private readonly LeagueReadModelContext context;

        public SeasonStartedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(SeasonStartedEvent notification)
        {
            var season = this.context.Seasons.First(x => x.Id == notification.SeasonId);

            season.IsRunning = true;

            this.context.Seasons.Update(season);
            this.context.SaveChanges();
        }
    }
}
