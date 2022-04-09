using System.Threading.Tasks;
using Repository.MakeupCatalog.MakeupTypeRepo;
using Repository.MakeupCatalog.ProductsRepo;

namespace Repository.MakeupCatalog
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IMakeupTypeRepository MakeupTypeRepository { get; }

        Task Commit();
    }
}