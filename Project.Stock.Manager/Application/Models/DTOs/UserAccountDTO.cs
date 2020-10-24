using Project.Stock.Manager.Infrastructure.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Models.DTOs
{
    public class UserAccountDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public StatusUser Status { get; set; }
        public bool Active { get; set; }

    }
}
