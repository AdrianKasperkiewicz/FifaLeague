using System;
using System.Collections.Generic;
using System.Text;
using FL.Domain.Aggregates.SeasonAggregate.Events;
using FL.Infrastructure.ReadDatabase.Database;
using MediatR;

namespace FL.Infrastructure.ReadDatabase.EventHandlers
{
    public class CreateSeasonEventHandler : NotificationHandler<SeasonCreated>
    {
        private readonly LeagueReadModelContext context;

        public CreateSeasonEventHandler(LeagueReadModelContext context)
        {
            this.context = context;
        }

        protected override void Handle(SeasonCreated notification)
        {
            var seasonVM = new SeasonViewModel();

            this.context.Season.AddAsync(seasonVM);
            this.context.SaveChangesAsync();
        }
    }
}