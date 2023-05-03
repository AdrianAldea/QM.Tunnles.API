using System;
using System.Collections.Generic;

namespace Tunnels.Core.Models {
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RolesEnum Role { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
