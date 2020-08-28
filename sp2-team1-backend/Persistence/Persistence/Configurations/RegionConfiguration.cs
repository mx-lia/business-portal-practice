using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(s => s.Name)
                .IsRequired();
        }
    }
}
