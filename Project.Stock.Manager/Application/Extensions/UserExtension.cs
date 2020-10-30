using Project.Stock.Manager.Application.Models.DTOs.UserAccount;
using Project.Stock.Manager.Application.Models.ViewModels;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Extensions
{
    public static class UserExtension
    {
        public static UserAccountDetailsViewModel ToUserAccountDetailsViewModel(this User user)
        {
            return new UserAccountDetailsViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.Account.UserName,
                DisplayName = user.DisplayName,
                Active = user.Active,
                Status = user.Status
            };
        }

        public static UserAccountChangePasswordViewModel ToUserAccountChangePasswordViewModel(this User user)
        {
            return new UserAccountChangePasswordViewModel()
            {
                Id = user.Id,
                UserName = user.Account.UserName,
             
            };
        }

        public static List<UserAccountDetailsViewModel> ToUserAccountDetailsViewModel(this List<User> users)
        {
            return users.Select(x => new UserAccountDetailsViewModel() 
            { 
                Id = x.Id,
                Name = x.Name,
                DisplayName = x.DisplayName,
                UserName = x.Account.UserName,
                Active = x.Active,
                Status = x.Status

            }).ToList();
        }

        public static User ToUser(this FullDataUserAccountDTO userAccount)
        {
            return new User()
            {
                Id = new Guid(),
                Name = userAccount.Name,
                DisplayName = string.Concat(userAccount.Name.Split(" ").FirstOrDefault()," ",userAccount.Name.Split(" ").LastOrDefault()),
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

        public static User ToUser(this DataUserAccountDTO userAccount)
        {
            return new User()
            {
                Name = userAccount.Name,
                DisplayName = string.Concat(userAccount.Name.Split(" ").FirstOrDefault(), " ", userAccount.Name.Split(" ").LastOrDefault()),
                Status = userAccount.Status,
                Active = userAccount.Active,
                Account = new Account()
                {
                    UserName = userAccount.UserName,
                }
            };
        }

        public static void ToUser(this DataUserAccountDTO userAccount, User user)
        {
            user.Name = userAccount.Name;
            user.DisplayName = string.Concat(userAccount.Name.Split(" ").FirstOrDefault(), " ", userAccount.Name.Split(" ").LastOrDefault());
            user.Status = userAccount.Status;
            user.Active = userAccount.Active;
            user.Account.UserName = userAccount.UserName;
        }

       
    }
}
