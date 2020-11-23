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
        List<double> TotalPriceSell();

        double TotalPriceAllSell();
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

        public Task Create(Sell sell)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sell>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Sell> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public double TotalPriceAllSell()
        {
            throw new NotImplementedException();
        }

        public List<double> TotalPriceSell()
        {
            throw new NotImplementedException();
        }

        //public async Task Create(Sell sell)
        //{
        //    _sellRepository.Add(sell);

        //    await _sellRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        //}

        //public async Task<List<Sell>> GetAll()
        //{
        //    return await _sellRepository.GetAll().ToListAsync().ConfigureAwait(false);
        //}

        //public async Task<Sell> GetByIdAsync(Guid id)
        //{
        //    return await _sellRepository.GetByIdAsync(id).ConfigureAwait(false);
        //}

        //public double TotalPriceAllSell()
        //{
        //    return _sellRepository.GetAll().Sum(x => x.Products.Sum(x => x.Price));
        //}

        //public List<double> TotalPriceSell()
        //{
        //    return _sellRepository.GetAll().Select(x => x.Products.Sum(x => x.Price)).ToList();
        //}
    }
}
