using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using FL.Domain.Aggregates.SeasonAggregate.Events;
using MediatR;

namespace FL.API.Queries.EventHandlers.Seasons
{
    public class SeasonCreatedEventHandler : NotificationHandler<SeasonCreatedEvent>
    {
        private readonly LeagueReadModelContext context;

        public SeasonCreatedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(SeasonCreatedEvent notification)
        {
            var seasonVM = new SeasonViewModel(notification.SeasonId);

            this.context.Seasons.AddAsync(seasonVM);
            this.context.SaveChangesAsync();
        }
    }
}