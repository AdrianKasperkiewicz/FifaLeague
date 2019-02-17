using FL.API.Application.CommandHandlers;
using System.Reflection;

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FL.API.Application.Behaviors;
using FluentValidation;
using FL.API.Application.CommandHandlers.Teams;
using FL.Domain;
using FL.Infrastructure.Database;
using FL.Infrastructure.ReadDatabase;
using FL.Infrastructure.ReadDatabase.Database;

namespace FL.API.Application.IoC
{
    public static class FLModule
    {
        public static void RegisterFLModule(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateTeamCommand).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));

            services.AddTransient<IValidator<CreateTeamCommand>, CreateTeamCommandValidator>();
            services.AddTransient<ISeasonReadRepository, SeasonReadRepository>();
            services.AddTransient<AggregateStoreContext>();
            services.AddTransient<LeagueReadModelContext>();
            services.AddScoped(typeof(IRepository<>), typeof(AggregateRepository<>));
        }
    }
}