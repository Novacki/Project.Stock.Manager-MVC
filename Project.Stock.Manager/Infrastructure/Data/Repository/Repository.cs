using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data;
using Project.Stock.Manager.Application.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Infrastructure.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public virtual IUnitOfWork UnitOfWork => _context;

        public virtual void Add(TEntity obj)
        {
            _entities.Add(obj);
        }

        public virtual void Delete(TEntity obj)
        {
            _entities.Remove(obj);
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual TEntity GetById(Guid id)
        {
            return _entities.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _entities.FindAsync(id, cancellationToken);
        }

        public virtual void Update(TEntity obj)
        {
            _entities.Update(obj);
        }
    }
}
