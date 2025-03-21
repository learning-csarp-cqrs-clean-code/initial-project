﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Entities;

namespace InfrastructureLayer.Persistence.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profil>
    {
        public void Configure(EntityTypeBuilder<Profil> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(255).IsRequired();
        }
    }
}
