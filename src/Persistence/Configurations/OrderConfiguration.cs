using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Orders");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Description)
                .IsRequired()
                .HasColumnType("varchar(500)");


            builder
                .Property(e => e.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime");


            builder
                .HasOne(e => e.Customer)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasData(new
            {
                Id = 1,
                Description = "Mother's Day buying",
                CreatedDate = new DateTime(2020, 05, 14, 13,52,00),
                CustomerId = 1
            },
            new
            {
                Id = 2,
                Description = "Home office tools",
                CreatedDate = new DateTime(2020,03,11,16,45,00),
                CustomerId = 1
            }, new
            {
                Id = 3,
                Description = "Desktop upgrade",
                CreatedDate =new DateTime(2019,11,11,10,01,00),
                CustomerId = 2
            }
            );
        }
    }
}
