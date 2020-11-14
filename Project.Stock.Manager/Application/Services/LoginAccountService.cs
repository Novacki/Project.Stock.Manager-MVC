using Project.Stock.Manager.Application.Data.Repository;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Services
{
    public interface ILoginAccountService
    {
        Task<bool> Login(Account userAccount);
    }
    public class LoginAccountService : ILoginAccountService
    {
        private readonly IUserRepository _userRepository;

        public LoginAccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository)); 
        }

        public async Task<bool> Login(Account userAccount)
        {
            var userResult = await _userRepository.GetByUserAsync(userAccount.UserName).ConfigureAwait(false);

            if (userResult == null ||!IsValid(userResult, userAccount.Password) )
                return false;

            return true;
        }


        private bool IsValid(User user, string password) => user.Account.Password == password; 
    }
}
