using Microsoft.AspNetCore.Mvc;
using Project.Stock.Manager.Application.Services;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Controllers
{
    public class LoginAccountController : Controller 
    { 
        private readonly ILoginAccountService _loginAccountService;

        public LoginAccountController(ILoginAccountService loginAccountService)
        {
            _loginAccountService = loginAccountService ?? throw new ArgumentNullException(nameof(loginAccountService)); 
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account userAccount)
        {
            if (string.IsNullOrEmpty(userAccount.UserName) || string.IsNullOrEmpty(userAccount.Password)) 
            {
                ViewData["Error"] = "The values can't there empty!";
                return View();
            }

            if (await _loginAccountService.Login(userAccount)) 
            {
                ViewData["Login"] = "Success";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            ViewData["Error"] = "Incorrect User or Password!";

            return View();
        }
    }
}
