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

         public async Task<User> GetUserByIdAsync(Guid UserId)
         {
            var user = await _context.Users.FindAsync(UserId);
            if (user == null)
            {
                return null;
            }

            return (user);
         }
         public async Task<GetUserDTO[]> GetAllUsersAsync(){
             var users = from u in _context.Users
                select new GetUserDTO()
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName.ToString(),
                    LastName = u.LastName.ToString(),
                    Username = u.Username.ToString(),
                    ProfilePicture = u.ProfilePicture.ToString(),
                    Status = u.Status,
                    Mail = u.Mail,
                    Password = u.Password,
                    Phone = u.Phone.ToString(),
                };

              return users.ToArray();
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
                    Password = user.Password,
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
    
     public async Task<User> Verify(LoginDTO user)
        {   
        var _user = _context.Users
        .FirstOrDefault(u => (u.Username == user.Username) &&
                        (u.Password == user.Password));


        if(_user == null)
        {
         return null;
        }
         return _user;
        }
      public async Task<bool?> DeleteUser(Guid Id)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null)
            {
                return null;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
 }