using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .ToTable("Customers");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder
                .Property(e => e.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder
                .HasMany(e => e.Orders)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasData(new
            {
                Id = 1,
                Name = "Best Customer Ever",
                Email = "email_me@domain.com"
            });

        }
    }
}
