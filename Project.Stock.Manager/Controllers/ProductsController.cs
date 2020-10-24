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
    public class ProductsController : Controller 
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (product == null)
                return RedirectToAction(nameof(Error));

            await _service.Create(product);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var product = await _service.GetByIdAsync(id.Value);

            if (product == null)
                return RedirectToAction(nameof(Error));

            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var product = await _service.GetByIdAsync(id.Value);

            if (product == null)
                return RedirectToAction(nameof(Error));

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (product == null)
                return RedirectToAction(nameof(Error));

            await _service.Update(product);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _service.GetByIdAsync(id.Value);

            if (product == null)
                return RedirectToAction(nameof(Error));

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            if (product == null)
                return RedirectToAction(nameof(Error));

           await _service.Delete(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
