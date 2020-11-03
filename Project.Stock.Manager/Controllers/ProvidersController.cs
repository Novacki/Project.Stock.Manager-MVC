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
    public class ProvidersController : Controller 
    {
        private readonly IProviderService _providerService;

        public ProvidersController(IProviderService providerService)
        {
            _providerService = providerService ?? throw new ArgumentNullException(nameof(providerService)); ;
        }

        public async Task<IActionResult> Index()
        {
            var providers = await _providerService.GetAllAsync();

            return View(providers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Provider provider)
        {
            if (provider == null)
                return RedirectToAction(nameof(Error));

            await _providerService.Create(provider);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Error));

            var provider = await _providerService.GetByIdAsync(id.Value);

            if (provider == null)
                return RedirectToAction(nameof(Error));

            return View(provider);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error));

            var provider = await _providerService.GetByIdAsync(id.Value);

            if (provider == null)
                return RedirectToAction(nameof(Error));

            return View(provider);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Provider provider)
        {
            if (provider == null)
                return RedirectToAction(nameof(Error));

            await _providerService.Update(provider);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Error));

            var provider = await _providerService.GetByIdAsync(id.Value);

            if (provider == null)
                return RedirectToAction(nameof(Error));

            return View(provider);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Provider provider)
        {
            if (provider == null)
                return RedirectToAction(nameof(Error));

            await _providerService.Delete(provider);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
