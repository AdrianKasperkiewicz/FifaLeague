using Microsoft.Extensions.DependencyInjection;

namespace FutbinService.IoC
{
    public static class FutbinServiceIoC
    {
        public static void FutbinServiceModule(this IServiceCollection services)
        {
            services.AddHttpClient<FutbinHttpClient>();
            services.AddTransient<IPlayerService, PlayerSearch>();
        }
    }
}