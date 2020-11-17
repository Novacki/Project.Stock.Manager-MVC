using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data.Repository;
using Project.Stock.Manager.Infrastructure.Model;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Infrastructure.Data.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(ApplicationContext context): base(context) { }


        public override IQueryable<Provider> GetAll()
        {
            return base.GetAll();
        }

        public override Provider GetById(int id)
        {
            return _entities.Where(x => x.Id == id).FirstOrDefault();
        }

        public override async Task<Provider> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _entities.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
