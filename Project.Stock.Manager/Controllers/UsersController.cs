using Microsoft.AspNetCore.Mvc;
using Project.Stock.Manager.Application.Extensions;
using Project.Stock.Manager.Application.Models.DTOs.UserAccount;
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
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService)); ;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAll();

            return View(users.ToUserAccountDetailsViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FullDataUserAccountDTO userAccount)
        {
            if (userAccount == null)
                return RedirectToAction(nameof(Error));

            await _userService.Create(userAccount.ToUser());

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if(!id.HasValue)
                return RedirectToAction(nameof(Error));

            var user = await _userService.GetByIdAsync(id.Value).ConfigureAwait(false);

            return View(user.ToUserAccountDetailsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DataUserAccountDTO user)
        {
            if(user == null)
                return RedirectToAction(nameof(Error));

            await _userService.Update(user);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
