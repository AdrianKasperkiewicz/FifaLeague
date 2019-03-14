using FL.API.Infrastructure.DevSetup;
using FL.API.Infrastructure.SignalRHubs;
using FL.API.IoC;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;

namespace FL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.RegisterApplicationModule();
            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FL League API", Version = "v1" });
            });

            services.AddHangfire(x => x.UseMemoryStorage());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // net core 2.2 issue https://github.com/aspnet/AspNetCore/issues/6166
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            app.UseCors(builder => builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200").AllowCredentials());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FL League API V1");
            });

            app.UseMvc();

            app.UseHangfireServer();

            if (env.IsDevelopment())
            {
                app.AddDeveloperStarterData();
                app.UseHangfireDashboard();
            }

            app.UseSignalR(routes =>
            {
                routes.MapHub<RoomOccupiedHub>("/roomoccupied");
            });
        }
    }
}