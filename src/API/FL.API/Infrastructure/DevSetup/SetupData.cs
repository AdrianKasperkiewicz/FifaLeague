﻿using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FL.API.Infrastructure.DevSetup
{
    public static class SetupData
    {
        public static void AddDeveloperStarterData(this IApplicationBuilder app)
        {
            using (var scopre = app.ApplicationServices.CreateScope())
            {
                var mediator = scopre.ServiceProvider.GetService<IMediator>();

                new SetupTeams(mediator).Seed();
                new SetupSeason(mediator).Seed();
                new SetupDivisionTeams(mediator).Seed();
            }
        }
    }
}
