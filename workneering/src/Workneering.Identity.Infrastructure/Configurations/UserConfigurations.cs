﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workneering.Identity.Domain.Entities;

namespace Workneering.Identity.Infrastructure.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "IdentitySchema");

        // Each User can have many entries in the UserRole join table
        builder.HasMany(e => e.UserRoles)
            .WithOne(e => e.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        builder.HasMany(e => e.Claims)
            .WithOne(claim => claim.User)
            .IsRequired();

        builder.OwnsOne(i => i.Address, address =>
        {
            address.Property(a => a.City).HasColumnName("City");
            address.Property(a => a.CountryId).HasColumnName("CountryId");
            address.Property(a => a.ZipCode).HasColumnName("ZipCode");
            address.Property(a => a.Address).HasColumnName("Address");
        });

    }
}