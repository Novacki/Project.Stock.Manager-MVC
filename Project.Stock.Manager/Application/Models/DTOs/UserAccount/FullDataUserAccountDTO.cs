using Project.Stock.Manager.Infrastructure.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Models.DTOs.UserAccount
{
    public class FullDataUserAccountDTO : DataUserAccountDTO
    {
      public string Password { get; set; }
    }
}
