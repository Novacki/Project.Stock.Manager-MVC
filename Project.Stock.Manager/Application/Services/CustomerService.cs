using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data.Repository;
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
        Task ChangeStatus(Guid id);
        Task Create(Customer customer);

    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new NullReferenceException(nameof(customerRepository));
        }

        public async Task Create(Customer customer)
        {
            _customerRepository.Add(customer);
            await _customerRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task ChangeStatus(Guid id)
        {
            var customer = GetById(id);
            customer.Active = !customer.Active;
            await Update(customer);
            
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _customerRepository.GetAll().OrderBy(x => x.Name).ToListAsync().ConfigureAwait(false);
        }

        public Customer GetById(Guid id)
        {
            return _customerRepository.GetById(id);
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _customerRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task Update(Customer customer)
        {
            _customerRepository.Update(customer);
            await _customerRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
