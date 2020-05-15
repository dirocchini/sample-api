using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.Support.Configuration;

namespace Persistence
{
    public class ApplicationContextSqlServer : DbContext, IApplicationContext
    {
        private readonly DbConnectionConfig _dbConnection;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public ApplicationContextSqlServer(IOptionsSnapshot<DbConnectionConfig> config)
        {
            _dbConnection = config.Value;
            ChangeTracker.LazyLoadingEnabled = false;

            if (Database.GetPendingMigrations().Any())
                Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConnection.GetConnectionString());

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContextSqlServer).Assembly);
        }
    }
}
