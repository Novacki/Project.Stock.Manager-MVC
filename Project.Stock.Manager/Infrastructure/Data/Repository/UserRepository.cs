using Microsoft.EntityFrameworkCore;
using Project.Stock.Manager.Application.Data.Repository;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Infrastructure.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context) { }

        public User GetById(Guid id)
        {
            return _entities.Include(x => x.Account).Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return  await _entities.Include(x => x.Account).Where(x => x.Id == id).FirstOrDefaultAsync(); 
        }

        public override IQueryable<User> GetAll()
        {
            return base.GetAll().Include(x => x.Account);
        }

        public User GetByUserName(string userName)
        {
            return _entities.Include(x => x.Account).Where(x => x.Account.UserName == userName).FirstOrDefault();
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _entities.Include(x => x.Account).Where(x => x.Account.UserName == userName).FirstOrDefaultAsync();
        }
    }
}
