using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Data.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetById(Guid id);

        Task<Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    }
}
