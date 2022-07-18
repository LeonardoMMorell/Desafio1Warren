using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}