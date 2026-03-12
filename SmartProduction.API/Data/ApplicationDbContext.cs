using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SmartProduction.API.Entities;

namespace SmartProduction.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasIndex(p => p.SKU).IsUnique();
        }
    }
}
