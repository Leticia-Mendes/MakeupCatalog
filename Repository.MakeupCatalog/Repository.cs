using Domain.MakeupCatalog;
using Infrastructure.MakeupCatalog;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repo.MakeupCatalog
{
    public class Repository : IRepository
    {
        private readonly MakeupDbContext _context;

        public Repository(MakeupDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get<T>(T entity) where T : class
        {
            return _context.Set<T>().AsNoTracking();
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void SaveChanges<T>(T entity) where T : class
        {
            _context.SaveChanges();
        }

        Product[] IRepository.GetAllProducts(bool includeMakeupType)
        {
            IQueryable<Product> query = _context.Product;

            if (includeMakeupType)
            {
                query = query.Include(mt => mt.MakeupType);
            }

            query = query.AsNoTracking().OrderBy(p => p.ProductId);

            return query.ToArray();
        }

        public Product GetProductById(int productId, bool includeMakeupType)
        {
            IQueryable<Product> query = _context.Product;

            if (includeMakeupType)
            {
                query = query.Include(mt => mt.MakeupType);
            }

            query = query.AsNoTracking().OrderBy(p => p.ProductId)
                         .Where(p => p.ProductId == productId);

            return query.FirstOrDefault();
        }

        public MakeupType[] GetAllMakeupTypes(bool includeProduct)
        {
            IQueryable<MakeupType> query = _context.MakeupType;

            if (includeProduct)
            {
                query = query.Include(p => p.Product);
            }

            query = query.AsNoTracking().OrderBy(mt => mt.MakeupTypeId);

            return query.ToArray();
        }

        public MakeupType GetMakeupTypesById(int makeupTypeId, bool includeProduct)
        {
            IQueryable<MakeupType> query = _context.MakeupType;

            if (includeProduct)
            {
                query = query.Include(p => p.Product);
            }

            query = query.AsNoTracking().OrderBy(mt => mt.MakeupTypeId)
                        .Where(p => p.MakeupTypeId == makeupTypeId);

            return query.FirstOrDefault();
        }
    }
}