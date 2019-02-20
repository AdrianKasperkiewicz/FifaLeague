using FL.Domain.Aggregates.SeasonAggregate.Events;
using FL.Infrastructure.ReadDatabase.Database;
using MediatR;

namespace FL.Infrastructure.ReadDatabase.EventHandlers
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
            var seasonVM = new SeasonViewModel(notification.Id);

            this.context.Season.AddAsync(seasonVM);
            this.context.SaveChangesAsync();
        }
    }
}