using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    class ResetPasswordTokenConfiguration : IEntityTypeConfiguration<ResetPasswordToken>
    {
        public void Configure(EntityTypeBuilder<ResetPasswordToken> builder)
        {
            builder
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(s => s.Token)
                .IsRequired();
        }
    }
}
