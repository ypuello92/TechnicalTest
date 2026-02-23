using Microsoft.EntityFrameworkCore;
using TechnicalTest.Infraestructure.Persistence;

namespace TechnicalTest.Infraestructure.DependencyInjection
{
    public static class SqlServerConnection
    {
        public static IServiceCollection AddSqlServerConnection(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            service.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString, sql =>
            {
                sql.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
            }));

            return service;
        }
    }
}
