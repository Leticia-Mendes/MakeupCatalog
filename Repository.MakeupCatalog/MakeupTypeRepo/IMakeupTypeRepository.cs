using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.MakeupCatalog;

namespace Repository.MakeupCatalog.MakeupTypeRepo
{
    public interface IMakeupTypeRepository : IRepository<MakeupType>
    {
        Task<IEnumerable<MakeupType>> GetProductsByMakeupTypes();
    }
}