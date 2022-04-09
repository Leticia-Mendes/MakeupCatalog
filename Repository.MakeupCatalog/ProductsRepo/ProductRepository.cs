using Database.MakeupCatalog;
using Domain.MakeupCatalog;

namespace Repository.MakeupCatalog.ProductsRepo
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MakeupDbContext context) : base(context)
        {
        }
    }
}