using DemoDataConfiguration.Setups;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DemoDataConfiguration
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
            }
        }
    }
}
