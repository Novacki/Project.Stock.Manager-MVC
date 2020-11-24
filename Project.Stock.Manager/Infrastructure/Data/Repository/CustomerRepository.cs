using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data.Repository;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Infrastructure.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context) : base(context) { }

        public override IQueryable<Customer> GetAll()
        {
            return base.GetAll().Include(x => x.Sells);
        }

        public Customer GetById(Guid id)
        {
            return _entities.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _entities.Where(x => x.Id == id).Include(x => x.Sells).FirstOrDefaultAsync();
        }
    }
}
