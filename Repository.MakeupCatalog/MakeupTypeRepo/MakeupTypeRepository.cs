using System.Collections.Generic;
using System.Threading.Tasks;
using Database.MakeupCatalog;
using Domain.MakeupCatalog;
using Microsoft.EntityFrameworkCore;

namespace Repository.MakeupCatalog.MakeupTypeRepo
{
    public class MakeupTypeRepository : Repository<MakeupType>, IMakeupTypeRepository
    {
        public MakeupTypeRepository(MakeupDbContext context) : base(context)
        {
        }

        async Task<IEnumerable<MakeupType>> IMakeupTypeRepository.GetProductsByMakeupTypes()
        {
            return await Get().Include(x => x.Products).ToListAsync();
        }
    }
}