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
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new NullReferenceException(nameof(customerService));
        }

        public async Task<IActionResult> Index() => View(await _customerService.GetAll());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (customer == null)
                return RedirectToAction(nameof(Error));

            await _customerService.Create(customer);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid? id) 
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Error));

            var customer = await _customerService.GetByIdAsync(id.Value);

            return View(customer); 
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (customer == null)
                return RedirectToAction(nameof(Error));

            await _customerService.Update(customer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Error));

            var customer = await _customerService.GetByIdAsync(id.Value);

            return View(customer);
        }

    
        public async Task<IActionResult> ChangeStatus(Guid? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Error));

           await _customerService.ChangeStatus(id.Value);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
