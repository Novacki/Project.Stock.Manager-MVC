using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data.Repository;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Services
{
    public interface IBatchService
    {
        Task Create(Batch batch);

        Task<List<Batch>> GetAllAsync();

        Batch GetById(int id);

        Task<Batch> GetByIdAsync(int id);

        Task Delete(Batch batch);

        Task Update(Batch batch);
    }

    public class BatchService : IBatchService
    {
        private readonly IBatchRepository _batchRepository;

        public BatchService(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository ?? throw new ArgumentNullException(nameof(batchRepository));
        }

        public async Task Create(Batch batch)
        {
            _batchRepository.Add(batch);

            await _batchRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(Batch batch)
        {
            _batchRepository.Delete(batch);

            await _batchRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<Batch>> GetAllAsync()
        {
            return await _batchRepository.GetAll().OrderBy(x => x.Provider.Nome).ToListAsync().ConfigureAwait(false);
        }

        public Batch GetById(int id)
        {
            return _batchRepository.GetById(id);
        }

        public async Task<Batch> GetByIdAsync(int id)
        {
            return await _batchRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task Update(Batch batch)
        {
            _batchRepository.Update(batch);

            await _batchRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
