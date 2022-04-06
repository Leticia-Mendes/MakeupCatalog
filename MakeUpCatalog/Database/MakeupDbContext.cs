using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakeUpCatalog.Domain;
using Microsoft.EntityFrameworkCore;

namespace MakeUpCatalog.Database
{
    public class MakeupDbContext : DbContext
    {
        public MakeupDbContext(DbContextOptions<MakeupDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
