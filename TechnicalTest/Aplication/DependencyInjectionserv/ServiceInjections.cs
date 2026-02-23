using TechnicalTest.Aplication.Interface;
using TechnicalTest.Infraestructure.DependencyInjection;
using TechnicalTest.Infraestructure.ExternalServices;
using TechnicalTest.Infraestructure.Repository;

namespace TechnicalTest.Aplication.DependencyInjectionserv
{
    public static class ServiceInjections
    {
        public static IServiceCollection AddServiceInjections(this IServiceCollection service, IConfiguration configuration)
        {
            
            service.AddInfraestructureInjections(configuration);
            service.AddScoped<ICrudRegion, CrudRegionRepository>();

            return service;
        }
    }
}
