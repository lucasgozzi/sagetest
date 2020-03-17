using Domain.Persistencia.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Singleton.Database
{
    public static class DatabaseConfig
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services, string server, string port, string user, string password)
        {
            System.Console.WriteLine($"Server={server},{port};Initial Catalog=SageBackend;User Id={user};Password={password}");
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<SageBackendContext>(
                    options => options.UseSqlServer($"Server={server},{port};Initial Catalog=SageBackend;User Id={user};Password={password}",
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
