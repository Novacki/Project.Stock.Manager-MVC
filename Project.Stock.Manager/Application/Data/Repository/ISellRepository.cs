using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Data.Repository
{
    public interface ISellRepository : IRepository<Sell>
    {
        Sell GetById(Guid id);

        Task<Sell> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    }
}
