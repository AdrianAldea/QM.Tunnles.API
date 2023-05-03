using Tunnels.Core.Models;

namespace Tunnels.DTOs.User
{
    /// <summary>
    /// GetUserResponse
    /// </summary>
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RolesEnum Role { get; set; }
    }
}
