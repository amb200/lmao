using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class SQLServerDbContext : DbContext
    {
        public SQLServerDbContext(DbContextOptions<SQLServerDbContext> options) : base(options)
        {
        }

        public DbSet<Issue> Models { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure SQL Server-specific mappings
            // modelBuilder.Entity<YourEntity>().Property(e => e.PropertyName).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }

}
