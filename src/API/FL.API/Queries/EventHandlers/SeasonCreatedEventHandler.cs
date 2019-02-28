using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using FL.Domain.Aggregates.SeasonAggregate.Events;
using MediatR;

namespace FL.API.Queries.EventHandlers
{
    public class SeasonCreatedEventHandler : NotificationHandler<SeasonCreated>
    {
        private readonly LeagueReadModelContext context;

        public SeasonCreatedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(SeasonCreated notification)
        {
            var seasonVM = new SeasonViewModel(notification.SeasonId);

            this.context.Season.AddAsync(seasonVM);
            this.context.SaveChangesAsync();
        }
    }
}