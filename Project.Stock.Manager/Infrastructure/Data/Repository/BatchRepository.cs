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
    public class BatchRepository : Repository<Batch>, IBatchRepository
    {
        public BatchRepository(ApplicationContext context) : base(context) { }

        public override IQueryable<Batch> GetAll()
        {
            return base.GetAll().Include(x => x.Provider)
                                .Include(x => x.Product);
        }

        public override Batch GetById(int id)
        {
            return _entities.Where(x => x.Id == id).Include(x => x.Provider)
                                                   .Include(x => x.Product)
                                                   .FirstOrDefault();
        }

        public override async Task<Batch> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _entities.Where(x => x.Id == id).Include(x => x.Provider)
                                                         .Include(x => x.Product)
                                                         .FirstOrDefaultAsync();
        }

    }
}
