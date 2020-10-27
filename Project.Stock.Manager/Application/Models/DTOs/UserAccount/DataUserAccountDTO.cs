using Project.Stock.Manager.Infrastructure.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Models.DTOs.UserAccount
{
    public class DataUserAccountDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public StatusUser Status { get; set; }
        public bool Active { get; set; }
    }
}
