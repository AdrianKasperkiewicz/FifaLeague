using FL.Application.CommandHandlers.Fixtures;
using FL.Domain.Aggregates.FixtureAggregate.Events;
using FL.Shared.Mediator;
using MediatR;

namespace FL.Application.EventHandlers.Fixtures
{
    public class WeekFixtureCreatedEventHandler : NotificationHandler<WeekFixtureCreatedEvent>
    {
        private readonly IMediator mediator;

        public WeekFixtureCreatedEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected override void Handle(WeekFixtureCreatedEvent notification)
        {
            this.mediator.Defer(new StartFixtureCommand(notification.FixtureId), notification.StartDate);
            this.mediator.Defer(new EndFixtureCommand(notification.FixtureId), notification.EndDate);
        }
    }
}
