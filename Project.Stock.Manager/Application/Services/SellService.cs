using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data.Repository;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Services
{
    public interface ISellService
    {
        double TotalPriceSellByCustomerId(Guid customerId);

        double TotalPriceBySellId(Guid id);

        double TotalPriceSellOfAllCustomers();

        Task Create(Sell sell);

        Task<Sell> GetByIdAsync(Guid id);

        Task<List<Sell>> GetAll();
    }

    public class SellService : ISellService
    {

        private readonly ISellRepository _sellRepository;

        public SellService(ISellRepository sellRepository)
        {
            _sellRepository = sellRepository ?? throw new ArgumentNullException(nameof(sellRepository)); ;
        }


        public async Task Create(Sell sell)
        {
            _sellRepository.Add(sell);

            await _sellRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<Sell>> GetAll()
        {
            return await _sellRepository.GetAll().ToListAsync().ConfigureAwait(false);
        }

        public async Task<Sell> GetByIdAsync(Guid id)
        {
            return await _sellRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public double TotalPriceSellOfAllCustomers()
        {
            return _sellRepository.GetAll().Sum(x => x.Product.Price);
        }

        public double TotalPriceSellByCustomerId(Guid customerId)
        {
            return  GetAll().Result.Where(x => x.CustomerId == customerId).Sum(x => x.Product.Price);
        }

        public double TotalPriceBySellId(Guid id)
        {
            return GetAll().Result.Where(x => x.Id == id).Sum(x => x.Product.Price);
        }
    }
}
