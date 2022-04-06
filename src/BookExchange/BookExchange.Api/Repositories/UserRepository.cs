using BookExchange.Core.Models;
using System.Threading.Tasks;
using BookExchange.Api.Data;
using BookExchange.Api.DTOs;

namespace BookExchange.Api.Repositories;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
      public async Task<User[]> GetAllUsersAsync(){
          return _context.Users.ToArray();
      }
      
     public async Task<bool> PostUser(RegistrationDTO user)
        {
            var status = true;

               var _user = new User()
                {
                    UserId = Guid.NewGuid(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Mail = user.Mail,
                    Phone = user.Phone,
                };
                                            
            _context.Users.Add(_user);
            await _context.SaveChangesAsync();


            if(await _context.SaveChangesAsync() > 0)
        {
            status = false;
        }
            return status;

    }
    
     public async Task<LoginDTO> Verify(LoginDTO user)
        {   
        var _user = _context.Users
        .FirstOrDefault(u => (u.Username == user.Username) &&
                        (u.Password == user.Password));


        if(user == null)
        {
         return null;
        }
         return user;
        }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
 }