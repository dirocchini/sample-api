using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .ToTable("OrderItems");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Sku)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder
                .Property(e => e.Amount)
                .IsRequired()
                .HasColumnType("integer");

            builder
                .Property(e => e.Price)
                .IsRequired()
                .HasColumnType("float");



            builder.HasData(new
            {
                Id = 1,
                Sku = "SKU23654",
                Amount = 2,
                Price = 2235.3,
                OrderId = 1
            },
            new
            {
                Id = 2,
                Sku = "SKU235884",
                Amount = 5,
                Price = 127.33,
                OrderId = 1
            }, new
            {
                Id = 3,
                Sku = "SKU235884-66",
                Amount = 7,
                Price = 17.39,
                OrderId = 2
            },
            new
            {
                Id = 4,
                Sku = "SKU5884-5",
                Amount = 2,
                Price = 119.39,
                OrderId = 3
            }
            );
        }
    }
}
