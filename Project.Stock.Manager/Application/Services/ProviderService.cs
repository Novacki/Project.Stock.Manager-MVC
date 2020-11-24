using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data.Repository;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Services
{
    public interface IProviderService
    {
        Task Create(Provider provider);

        Task<List<Provider>> GetAllAsync();

        Provider GetById(int id);

        Task<Provider> GetByIdAsync(int id);

        Task Delete(Provider provider);

        Task Update(Provider provider);
    }
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository ?? throw new ArgumentNullException(nameof(providerRepository)); 
        }

        public async Task Create(Provider provider)
        {
            _providerRepository.Add(provider);

            await _providerRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(Provider provider)
        {
            _providerRepository.Delete(provider);

            await _providerRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<Provider>> GetAllAsync()
        {
            return await _providerRepository.GetAll().OrderBy(x => x.Name).ToListAsync().ConfigureAwait(false);
        }

        public Provider GetById(int id)
        {
            return _providerRepository.GetById(id);
        }

        public async Task<Provider> GetByIdAsync(int id)
        {
            return await _providerRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task Update(Provider provider)
        {
            _providerRepository.Update(provider);

            await _providerRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
