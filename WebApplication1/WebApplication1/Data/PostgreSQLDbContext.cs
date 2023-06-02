using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class PostgreSQLDbContext : DbContext
    {
        public PostgreSQLDbContext(DbContextOptions<PostgreSQLDbContext> options) : base(options)
        {
        }
        public DbSet<Issue> Models { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure PostgreSQL-specific mappings
            // modelBuilder.Entity<YourEntity>().Property(e => e.PropertyName).IsRequired();

            base.OnModelCreating(modelBuilder);
        }


    }
}
