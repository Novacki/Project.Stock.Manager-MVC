using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Models.ViewModels
{
    public class UserAccountChangePasswordViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
