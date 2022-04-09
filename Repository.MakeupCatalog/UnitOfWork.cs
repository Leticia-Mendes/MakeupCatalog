using Database.MakeupCatalog;
using Repository.MakeupCatalog.MakeupTypeRepo;
using Repository.MakeupCatalog.ProductsRepo;
using System.Threading.Tasks;

namespace Repository.MakeupCatalog
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductRepository _productRepository;
        private MakeupTypeRepository _makeupTypeRepository;
        public MakeupDbContext _context;

        public UnitOfWork(MakeupDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ??= new ProductRepository(_context);
            }
        }

        public IMakeupTypeRepository MakeupTypeRepository
        {
            get
            {
                return _makeupTypeRepository ??= new MakeupTypeRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}