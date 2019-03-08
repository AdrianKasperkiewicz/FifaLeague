using System;

using FL.Domain;
using FL.Domain.Aggregates.FixtureAggregate;
using FL.Domain.Aggregates.SeasonAggregate;
using FL.Domain.Aggregates.SeasonAggregate.Events;
using FL.Domain.Factories;
using MediatR;

namespace FL.Application.EventHandlers.Fixtures
{
    public class SeasonStartedEventHandler : NotificationHandler<SeasonStartedEvent>
    {
        private readonly IRepository<WeekFixture> fixtureRepository;

        public SeasonStartedEventHandler(IRepository<WeekFixture> fixtureRepository)
        {
            this.fixtureRepository = fixtureRepository;
        }

        protected override void Handle(SeasonStartedEvent notification)
        {
            var fixtures = new FixtureFactory(notification.SeasonId, notification.TeamsDivisions, notification.FirstMatchDate)
                .Build();

            foreach (var fixture in fixtures)
            {
                this.fixtureRepository.Save(fixture);
            }
        }
    }
}
