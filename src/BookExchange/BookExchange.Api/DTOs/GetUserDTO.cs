using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookExchange.Api.DTOs
{
    public class GetUserDTO
    { 
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
         public string Username { get; set; }   
         public string Password { get; set; }
         public string? ProfilePicture { get; set; } = "/upload/blank-person.png";
        public string? Status { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}