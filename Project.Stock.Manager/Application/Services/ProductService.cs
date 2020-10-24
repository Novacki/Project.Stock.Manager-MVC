using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data.Repository;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Services
{
    public interface IProductService
    {
        Task Create(Product product);

        Task<List<Product>> GetAllAsync();

        Product GetById(int id);

        Task<Product> GetByIdAsync(int id);

        Task Delete(Product product);

        Task Update(Product product);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task Create(Product product)
        {
            if (product == null)
                throw new NullReferenceException();

            _productRepository.Add(product);

            await _productRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(Product product)
        {
            if (product == null)
                throw new NullReferenceException();

            _productRepository.Delete(product);

            await _productRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAll().ToListAsync().ConfigureAwait(false);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task Update(Product product)
        {
            if (product == null)
                throw new NullReferenceException();

            _productRepository.Update(product);

            await _productRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
