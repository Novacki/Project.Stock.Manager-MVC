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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context) { }



        public override IQueryable<Product> GetAll()
        {
            return base.GetAll().Include(x => x.Batch);
        }

        public override Product GetById(int id)
        {
            return _entities.Where(x => x.Id == id).Include(x => x.Batch).FirstOrDefault();
        }

        public override async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return  await _entities.Where(x => x.Id == id).Include(x => x.Batch).FirstOrDefaultAsync();
        }
    }
}
