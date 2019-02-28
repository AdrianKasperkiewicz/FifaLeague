﻿using FL.API.Queries.Database;
using FL.Application;
using FL.Domain.Aggregates.TeamAggregate.Events;
using MediatR;

namespace FL.API.Queries.EventHandlers
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
            var vm = new TeamViewModel(notification.EventId, notification.Name, notification.Email);
            this.context.Team.AddAsync(vm);
            this.context.SaveChangesAsync();
        }
    }
}