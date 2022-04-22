using Domain.MakeupCatalog;
using System.Linq;

namespace Repo.MakeupCatalog
{
    public interface IRepository
    {
        IQueryable<T> Get<T>(T entity) where T : class;

        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void SaveChanges<T>(T entity) where T : class;

        Product[] GetAllProducts(bool includeMakeupType);

        Product GetProductById(int productId, bool includeMakeupType);

        MakeupType[] GetAllMakeupTypes(bool includeProduct);

        MakeupType GetMakeupTypesById(int makeupTypeId, bool includeProduct);
    }
}