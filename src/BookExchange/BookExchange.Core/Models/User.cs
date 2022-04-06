using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookExchange.Core.Models
{
    public class User
    { 
        [Key]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
         public string Username { get; set; }
         public string Password { get; set; }
        public string? ProfilePicture { get; set; } = "/upload/blank-person.png";
        public string? UserType { get; set; }
        public string? Status { get; set; }
        public List<Book>? Books { get; set; }    
        public DateTime? CreatedAt { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string? RefreshToken { get; set; }
         public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}