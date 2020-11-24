using Microsoft.AspNetCore.Mvc;
using Project.Stock.Manager.Application.Models.ViewModels;
using Project.Stock.Manager.Application.Services;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Controllers
{
    public class SellController : Controller
    {
        private readonly ISellService _sellService;

        public SellController(ISellService sellService)
        {
            _sellService = sellService ?? throw new ArgumentNullException(nameof(sellService)); 
        }

        public async Task<IActionResult> Index() 
        {
            var sells = await _sellService.GetAll();

            ViewBag.TotalPrice = sells.Select(x => _sellService.TotalPriceBySellId(x.Id)).ToList();

            return View(sells); 
        }

        //public IActionResult Create() => View(new Sell() { Date = DateTime.Now, Products = new List<Product>() });

        [HttpPost]
        public async Task<IActionResult> Create(Sell sell)
        {
            if (sell == null)
                RedirectToAction(nameof(Error));

            await _sellService.Create(sell);

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
