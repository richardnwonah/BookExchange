using BookExchange.Core.Models;
using System.Threading.Tasks;
using BookExchange.Api.DTOs;

namespace BookExchange.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid UserId);
        Task<GetUserDTO[]> GetAllUsersAsync();
        Task<bool> PostUser(RegistrationDTO user);
        Task<User> Verify(LoginDTO user);
        Task<bool?> DeleteUser(Guid Id);
        void SaveChanges();
       // Task<Book> GetUserByIDAsync(Guid Id);

    }
}