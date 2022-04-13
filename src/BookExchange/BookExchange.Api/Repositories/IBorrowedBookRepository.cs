using BookExchange.Core.Models;
using System.Threading.Tasks;
using BookExchange.Api.DTOs;

namespace BookExchange.Api.Repositories
{
    public interface IBorrowedBookRepository
    { 
        Task<BorrowedBook[]> GetAllBorrowedBooks();
    }
}