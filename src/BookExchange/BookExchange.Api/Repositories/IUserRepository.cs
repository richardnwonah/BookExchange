using BookExchange.Core.Models;
using System.Threading.Tasks;
using BookExchange.Api.DTOs;

namespace BookExchange.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User[]> GetAllUsersAsync();
        Task<bool> PostUser(RegistrationDTO user);
        Task<LoginDTO> Verify(LoginDTO user);
        void SaveChanges();
       // Task<Book> GetUserByIDAsync(Guid Id);

    }
}