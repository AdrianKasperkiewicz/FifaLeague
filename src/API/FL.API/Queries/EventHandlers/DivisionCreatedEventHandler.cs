namespace FL.API.Queries.EventHandlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using FL.API.Queries.Database;
    using FL.Domain.Aggregates.SeasonAggregate.Events;
    using MediatR;

    public class DivisionCreatedEventHandler : INotificationHandler<DivisionCreatedEvent>
    {
        private readonly LeagueReadModelContext context;

        public DivisionCreatedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        public async Task Handle(DivisionCreatedEvent notification, CancellationToken cancellationToken)
        {
            await this.context.Division.AddAsync(new ViewModels.DivisionViewModel { Id = notification.DivisionId, Name = notification.Name, SeasonId = notification.SeasonId });

            await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
