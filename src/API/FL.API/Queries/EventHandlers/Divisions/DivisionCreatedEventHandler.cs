using System.Threading;
using System.Threading.Tasks;
using FL.API.Queries.Database;
using FL.Domain.Aggregates.SeasonAggregate.Events;
using MediatR;

namespace FL.API.Queries.EventHandlers.Divisions
{
    public class DivisionCreatedEventHandler : INotificationHandler<DivisionCreatedEvent>
    {
        private readonly LeagueReadModelContext context;

        public DivisionCreatedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        public async Task Handle(DivisionCreatedEvent notification, CancellationToken cancellationToken)
        {
            await this.context.Divisions.AddAsync(new ViewModels.DivisionViewModel { Id = notification.DivisionId, Name = notification.Name, SeasonId = notification.SeasonId }, cancellationToken);

            await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
