using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(s => s.UserName)
                .IsRequired();
            builder
                .Property(s => s.Password)
                .IsRequired();
            builder
                .Property(s => s.Email)
                .IsRequired();
        }
    }
}
