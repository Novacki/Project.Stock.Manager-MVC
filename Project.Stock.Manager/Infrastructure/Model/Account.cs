using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Infrastructure.Model
{
    public class Account
    {
        public Account() { }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User User { get; set; }

    }
}
