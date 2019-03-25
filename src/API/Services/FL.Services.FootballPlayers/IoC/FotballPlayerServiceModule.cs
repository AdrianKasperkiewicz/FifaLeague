namespace FL.Services.FootballPlayers.IoC
{
    using System;

    using FL.Services.FootballPlayers.Database;
    using FL.Services.FootballPlayers.HttpApi;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Refit;

    public static class FotballPlayerServiceModule
    {
        public static void RegisterPlayerServiceModule(this IServiceCollection services)
        {
            services.AddRefitClient<IFutHeadAPI>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://www.futhead.com/"));

            services.AddTransient<IPlayerService, PlayerService>();
            services.AddDbContext<FootballPlayersDatabase>(context => context.UseInMemoryDatabase("FootballPlayersDatabase"));
        }
    }
}
