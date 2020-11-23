using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetByIdAsync(Guid id);
        Customer GetById(Guid id);
        Task Update(Customer customer);
        Task Deactivate(Guid id);
        Task Create(Customer customer);

    }
    public class CustomerService : ICustomerService
    {
        public Task Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task Deactivate(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
