using Domain.Persistencia.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Singleton.Database
{
    public static class DatabaseConfig
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<SageBackendContext>(
                    options => options.UseSqlServer(configuration["DbSettings:ConnectionString"],
                        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "SageBackend")));

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                SageBackendContext dbContext = serviceScope.ServiceProvider.GetRequiredService<SageBackendContext>();
                dbContext.Database.Migrate(); 
            }
        }
    }
}
