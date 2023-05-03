using Tunnels.Core.Models;

namespace Tunnels.DTOs.User
{
    /// <summary>
    /// CreateUserResponse
    /// </summary>
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RolesEnum Role { get; set; }
    }
}
