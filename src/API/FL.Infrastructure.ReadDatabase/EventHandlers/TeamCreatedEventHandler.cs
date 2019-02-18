using FL.Domain.Aggregates.SeasonAggregate.Events;
using FL.Domain.Aggregates.TeamAggregate.Events;
using FL.Infrastructure.ReadDatabase.Database;
using MediatR;

namespace FL.Infrastructure.ReadDatabase.EventHandlers
{
    public class TeamCreatedEventHandler : NotificationHandler<TeamCreatedDomainEvent>
    {
        private readonly LeagueReadModelContext context;

        public TeamCreatedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(TeamCreatedDomainEvent notification)
        {
            var vm = new TeamViewModel(notification.Id, notification.Name, notification.Email);
            this.context.Team.AddAsync(vm);
            this.context.SaveChangesAsync();
        }
    }
}
