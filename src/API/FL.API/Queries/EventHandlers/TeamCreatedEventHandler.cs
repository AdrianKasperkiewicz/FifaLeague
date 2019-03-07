﻿using FL.API.Queries.Database;
using FL.API.Queries.ViewModels;
using FL.Domain.Aggregates.TeamAggregate.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var vm = new TeamViewModel(notification.EventId, notification.Email, notification.FirstName, notification.LastName);

            this.context.Teams.AddAsync(vm);
            this.context.SaveChangesAsync();
        }
    }
}