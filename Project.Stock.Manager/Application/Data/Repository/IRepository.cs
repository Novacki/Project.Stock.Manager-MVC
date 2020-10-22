using Project.Stock.Manager.Application.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetAll();
        IUnitOfWork UnitOfWork { get; }

    }
}
