using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(s => s.Name)
                .IsRequired();
            builder
                .Property(s => s.IsLead)
                .IsRequired();

        }
    }
}
