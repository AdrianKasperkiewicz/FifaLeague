using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using FL.Domain.Aggregates.FixtureAggregate.Events;
using MediatR;

namespace FL.API.Queries.EventHandlers.Fixtures
{
    public class WeekFixtureCreatedEventHandler : NotificationHandler<WeekFixtureCreatedEvent>
    {
        private readonly LeagueReadModelContext context;

        public WeekFixtureCreatedEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(WeekFixtureCreatedEvent notification)
        {
            var fixture = new FixtureViewModel
            {
                FixtureId = notification.FixtureId,
                SeasonId = notification.SeasonId,
                StartDate = notification.StartDate,
                EndDate = notification.EndDate,
                DivisionId = notification.DivisionId,
                WeekNumber = notification.FixtureWeekNumber,
            };

            this.context.Add(fixture);
            this.context.SaveChanges();
        }
    }
}
