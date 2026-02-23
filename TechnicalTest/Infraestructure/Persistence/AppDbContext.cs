using Microsoft.EntityFrameworkCore;
using TechnicalTest.Domain.Entities;

namespace TechnicalTest.Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<Region> Region { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica automáticamente TODAS las configuraciones
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}
