using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data.Repository;
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
        Task Update(User user);
        Task Delete(User user);
        Task<List<User>> GetAll();
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
            if (user == null)
                throw new ArgumentNullException();

            if (UserExist(user))
                throw new Exception("User Exist");

             _userRepository.Add(user);

            await _userRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            if (UserExist(user))
                throw new Exception("User Exist");

            _userRepository.Delete(user);

            await _userRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<User>> GetAll()
        {
            return  await _userRepository.GetAll().ToListAsync().ConfigureAwait(false);
        }

        public User GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task Update(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            if (UserExist(user))
                throw new Exception("User Exist");

            _userRepository.Update(user);

            await _userRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        private bool UserExist(User user)
        {
            var result = _userRepository.GetByUserName(user.Account.UserName);

            if (result != null)
                return true;

            return false;
        }
    }
}
