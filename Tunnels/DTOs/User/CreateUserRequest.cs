using System;
using Tunnels.Core.Models;

namespace Tunnels.DTOs.User {
    /// <summary>
    /// CreateUserRequest
    /// </summary>
    public class CreateUserRequest {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateAdded { get; set; }
        public RolesEnum Role { get; set; }
    }
}
