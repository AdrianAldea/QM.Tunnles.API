using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tunnels.Core.Models;
using Tunnels.Core.Repositories;

namespace Tunnels.DAL.Repositories {
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TunnelsDbContext context)
            : base(context)
        { }

        public async Task<User> GetById(int id)
        {
            return await TunnelsDbContext.Users.FindAsync(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await TunnelsDbContext.Users.ToListAsync();
        }

        private TunnelsDbContext TunnelsDbContext => Context as TunnelsDbContext;
    }
}
