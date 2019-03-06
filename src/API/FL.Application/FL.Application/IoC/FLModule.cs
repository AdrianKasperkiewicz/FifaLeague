using FL.Application.Behaviors;
using FL.Application.CommandHandlers.Seasons;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FL.Application.IoC
{
    public static class FlModule
    {
        public static void RegisterFLModule(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            services.AddTransient<IValidator<CreateSeasonCommand>, CreateSeasonCommandValidator>();
        }
    }
}