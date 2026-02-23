using Microsoft.EntityFrameworkCore;
using TechnicalTest.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalTest.Infraestructure.Persistence
{
    public class RegionConfig : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> entity)
        {
            entity.ToTable("Region");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd(); //autoincrementable

            entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Departments);
        }
    }
}
