using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data.Repository;
using Project.Stock.Manager.Application.Extensions;
using Project.Stock.Manager.Application.Models.DTOs.UserAccount;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Services
{
    public interface IUserService
    {
        Task Create(User user);
        Task Update(DataUserAccountDTO userAccount);
        Task Update(FullDataUserAccountDTO userAccount);
        Task Delete(Guid id);
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        User GetById(Guid id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task Create(User user)
        {
            if (_userRepository.ExistUser(user))
                throw new Exception("User Exist");

            _userRepository.Add(user);

            await _userRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(Guid id)
        {
            var user = GetById(id);

            _userRepository.Delete(user);

            await _userRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return  await _userRepository.GetAll().OrderBy(x => x.DisplayName).ToListAsync().ConfigureAwait(false);
        }

        public User GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task Update(DataUserAccountDTO userAccount)
        {
            var user = GetById(userAccount.Id);
            
            if (user.Account.UserName != userAccount.UserName && _userRepository.ExistUser(userAccount.ToUser()))
                throw new Exception("User Exist");

            userAccount.ToUser(user);

            _userRepository.Update(user);

            await _userRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(FullDataUserAccountDTO userAccount)
        {
            var result = GetById(userAccount.Id);

            result.Account.Password = userAccount.Password;

            _userRepository.Update(result);

            await _userRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

    }
}
