using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Users.Domain.Models
{
    public class User : Base
    {
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("active")]
        public bool Active { get; set; }
    }
}
