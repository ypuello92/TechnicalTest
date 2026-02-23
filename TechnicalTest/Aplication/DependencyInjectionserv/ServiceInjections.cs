using TechnicalTest.Aplication.Interface;
using TechnicalTest.Aplication.Service;
using TechnicalTest.Infraestructure.DependencyInjection;
using TechnicalTest.Infraestructure.ExternalServices;
using TechnicalTest.Infraestructure.Repository;

namespace TechnicalTest.Aplication.DependencyInjectionserv
{
    public static class ServiceInjections
    {
        public static IServiceCollection AddServiceInjections(this IServiceCollection service, IConfiguration configuration)
        {
            
            service.AddScoped<ICrudRegionService, CrudRegionService>();

            return service;
        }
    }
}
