using FL.API.Queries.Database;
using FL.Application.IoC;
using FL.Domain;
using FL.Infrastructure.Database;
using FL.Services.FootballPlayers.IoC;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FL.API.IoC
{
    public static class ApplicationIoC
    {
        public static void RegisterApplicationModule(this IServiceCollection services)
        {
            services.AddTransient<AggregateStoreContext>();
            services.AddTransient<LeagueReadModelContext>();

            services.AddDbContext<AggregateStoreContext>(context => context.UseInMemoryDatabase("AggregateStore"));
            services.AddDbContext<LeagueReadModelContext>(context => context.UseInMemoryDatabase("LeagueReadDatabase"));

            services.AddMediatR();

            services.AddScoped(typeof(IRepository<>), typeof(AggregateRepository<>));

            services.AddEntityFrameworkInMemoryDatabase();

            services.RegisterFifaLeagueModule();
            services.RegisterPlayerServiceModule();
        }
    }
}
