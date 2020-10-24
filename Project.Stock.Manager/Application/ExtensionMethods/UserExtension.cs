using Project.Stock.Manager.Application.Models.DTOs;
using Project.Stock.Manager.Application.Models.ViewModels;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.ExtensionMethods
{
    public static class UserExtension
    {
        public static UserAccountViewModel ToUserAccountViewModel(this User user)
        {
            return new UserAccountViewModel()
            {
                Id = user.Id,
                UserName = user.Account.UserName,
                DisplayName = user.DisplayName,
                Active = user.Active,
                Status = user.Status
            };
        }

        public static List<UserAccountViewModel> ToUserAccountViewModel(this List<User> users)
        {
            return users.Select(x => new UserAccountViewModel() 
            { 
                Id = x.Id,
                DisplayName = x.DisplayName,
                UserName = x.Account.UserName,
                Active = x.Active,
                Status = x.Status

            }).ToList();
        }

        public static User ToUser(this UserAccountDTO userAccount)
        {
            return new User()
            {
                Id = new Guid(),
                Name = userAccount.Name,
                DisplayName = userAccount.DisplayName,
                Status = userAccount.Status,
                Active = userAccount.Active,
                Account = new Account()
                {
                    Id = new Guid(),
                    UserName = userAccount.UserName,
                    Password = userAccount.Password
                    
                }
            };
        }
    }
}
