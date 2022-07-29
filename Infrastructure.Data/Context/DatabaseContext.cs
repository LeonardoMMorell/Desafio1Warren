using DomainModels;
using EntityFrameworkCore.AutoHistory.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public override int SaveChanges()
        {
            var addedEntities = this.DetectChanges(EntityState.Added);

            this.EnsureAutoHistory();
            var affectedRows = base.SaveChanges();

            this.EnsureAutoHistory(addedEntities);
            affectedRows += base.SaveChanges();

            return affectedRows;
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Infrastructure.Data"));
        }
    }
}