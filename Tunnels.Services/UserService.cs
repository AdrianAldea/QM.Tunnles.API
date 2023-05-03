using Tunnels.Core;
using Tunnels.Core.Models;
using Tunnels.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Tunnels.Services {
    public class UserService : IUserService {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUser(User user) {
            var userCreated = await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();
            return userCreated;
        }

        public async Task<IEnumerable<User>> GetAllAUsers() {
            return await _unitOfWork.Users.GetAllUsers();
        }

        public async Task<User> GetUserById(int id) {
            return await _unitOfWork.Users.GetById(id);
        }

        public async Task<User> ValidateUsernameAndPassword(string username, string password) {
            var users = await _unitOfWork.Users.GetAllUsers();
            var userFound = users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (userFound != null) {
                return await Task.FromResult(userFound);
            }
            else {
                return await Task.FromResult<User>(new User());
            };
        }
    }
}
