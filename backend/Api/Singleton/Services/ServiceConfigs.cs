using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;

namespace Api.Singleton.Services
{
    //TODO: Incluir Métodos para adicionar novos servicos ao escopo, grarantindo apenas uma instância por objeto
    public static class ServiceConfigs
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<PeopleRepository>();
            services.AddScoped<AddressRepository>();
            services.AddScoped<PeopleService>();
            services.AddScoped<AddressService>();
        }

    }
}
