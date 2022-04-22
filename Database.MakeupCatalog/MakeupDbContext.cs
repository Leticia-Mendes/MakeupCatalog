using Domain.MakeupCatalog;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MakeupCatalog
{
    public class MakeupDbContext : DbContext
    {
        public MakeupDbContext(DbContextOptions<MakeupDbContext> options) : base(options)
        {
        }

        public DbSet<MakeupType> MakeupType { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.MakeupType)
                .WithMany(m => m.Product);
        }
    }
}