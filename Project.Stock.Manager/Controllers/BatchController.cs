using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Stock.Manager.Application.Models.ViewModels;
using Project.Stock.Manager.Application.Services;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Controllers
{
    public class BatchController : Controller
    {
        private readonly IBatchService _service;
        private readonly IProductService _prodService;
        private readonly IProviderService _provService;

        public BatchController(IBatchService service,
                               IProductService prodService,
                               IProviderService provService)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _prodService = prodService ?? throw new ArgumentNullException(nameof(prodService));
            _provService = provService ?? throw new ArgumentNullException(nameof(provService));
        }

        public async Task<IActionResult> Index()
        {
            var batches = await _service.GetAllAsync();

            return View(batches);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Batch batch)
        {
            if (batch == null)
                return RedirectToAction(nameof(Error));

            await _service.Create(batch);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            var products = await _prodService.GetAllAsync();
            ViewBag.Products = new SelectList(products, "Id", "Name");

            var providers = await _provService.GetAllAsync();
            ViewBag.Providers = new SelectList(providers, "Id", "Nome");

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error));

            var batch = await _service.GetByIdAsync(id.Value);

            if (batch == null)
                return RedirectToAction(nameof(Error));

            var products = await _prodService.GetAllAsync();
            ViewBag.Products = new SelectList(products, "Id", "Name");

            var providers = await _provService.GetAllAsync();
            ViewBag.Providers = new SelectList(providers, "Id", "Nome");

            return View(batch);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Batch batch)
        {
            if (batch == null)
                return RedirectToAction(nameof(Error));

            await _service.Update(batch);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Error));

            var batch = await _service.GetByIdAsync(id.Value);

            if (batch == null)
                return RedirectToAction(nameof(Error));

            return View(batch);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Error));

            var batch = await _service.GetByIdAsync(id.Value);

            if (batch == null)
                return RedirectToAction(nameof(Error));

            return View(batch);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Batch batch)
        {
            if (batch == null)
                return RedirectToAction(nameof(Error));

            await _service.Delete(batch);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
