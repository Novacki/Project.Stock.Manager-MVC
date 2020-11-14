using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        User GetById(Guid id);

        Task<User> GetByUserAsync(string user);

        bool ExistUser(User user);

        Task<bool> ExistUserAsync(User user);
    }
}
