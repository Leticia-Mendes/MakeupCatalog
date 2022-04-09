using Domain.MakeupCatalog;
using Microsoft.EntityFrameworkCore;

namespace Database.MakeupCatalog
{
    public class MakeupDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO Move connection string to a secure location
            string mySqlConnection = "Server=localhost; Database=db_MakeupCatalog; Username=root; Password=root";
            optionsBuilder.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));
        }

        public MakeupDbContext(DbContextOptions<MakeupDbContext> options) : base(options)
        {
        }

        public DbSet<MakeupType> MakeupType { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}