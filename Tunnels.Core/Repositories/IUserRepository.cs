using Tunnels.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tunnels.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetById(int id);
        Task<List<User>> GetAllUsers();
    }
}
