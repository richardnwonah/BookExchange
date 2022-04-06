namespace BookExchange.Api.DTOs
{
    public class LoginDTO
    {
        public string Username { get; set; }
         public string Password { get; set; }
          public string? RefreshToken { get; set; }
         public DateTime? RefreshTokenExpiryTime { get; set; }
       
    }
}