namespace BookExchange.Api.Services;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookExchange.Core.Models;
using BookExchange.Api.Helpers;
using BookExchange.Api.Models;
using BookExchange.Api.Data;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    Task<User[]> GetAll();
    User GetById(Guid userId);
}

public class UserService : IUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
   
     private readonly ApplicationDbContext _context;
    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings, ApplicationDbContext context)
    {
        _context = context;
        _appSettings = appSettings.Value;

    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public async Task<User[]> GetAll()
    {
        return _context.Users.ToArray();;
    }

    public User GetById(Guid userId)
    {
        return _context.Users.FirstOrDefault(x => x.UserId == userId);
    }

    // helper methods

    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("userId", user.UserId.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}