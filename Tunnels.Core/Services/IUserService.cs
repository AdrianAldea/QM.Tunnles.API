using System.Collections.Generic;
using System.Threading.Tasks;
using Tunnels.Core.Models;

namespace Tunnels.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task<User> ValidateUsernameAndPassword(string username, string password);
    }
}
