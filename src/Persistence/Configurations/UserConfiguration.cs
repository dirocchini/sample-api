using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users");

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
                .HasIndex(e => e.Email)
                .IsUnique();

            builder
                .Property(e => e.Password)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder
                .Property(e => e.Salt)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder
                .Property(e => e.CreatedOn)
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}
