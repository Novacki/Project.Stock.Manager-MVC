using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data.Repository;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Infrastructure.Data.Repository
{
    public class SellRepository : Repository<Sell>, ISellRepository
    {
        public SellRepository(ApplicationContext context) : base(context) { }

        public Sell GetById(Guid id)
        {
            return _entities.Include(x => x.Customer).Include(x => x.Product).Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Sell> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _entities.Include(x => x.Customer).Include(x => x.Product).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public override IQueryable<Sell> GetAll()
        {
            return base.GetAll().Include(x => x.Customer).Include(x => x.Product);
        }

    }
}
