using Microsoft.EntityFrameworkCore;
using TechnicalTest.Aplication.Interface;
using TechnicalTest.Infraestructure.ExternalServices;
using TechnicalTest.Infraestructure.Persistence;
using TechnicalTest.Infraestructure.Repository;

namespace TechnicalTest.Infraestructure.DependencyInjection
{
    public static class InfraestructureInjections
    {
        public static IServiceCollection AddInfraestructureInjections(this IServiceCollection service, IConfiguration configuration)
        {
            var baseUrl = configuration["ExternalApi:BaseUrl"] ?? throw new InvalidOperationException("ExternalApi no configurado.");

            service.AddHttpClient<IRegionListClient, RegionApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            service.AddScoped<ICrudRegion, CrudRegionRepository>();

            return service;
        }
    }
}
