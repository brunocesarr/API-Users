using System;

namespace API.Users.Domain.Models
{
    public class User : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime createdAt { get; set; }
        public bool Active { get; set; }
    }
}
