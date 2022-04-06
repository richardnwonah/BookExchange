using BookExchange.Core.Models;
using System.Threading.Tasks;
using BookExchange.Api.DTOs;

namespace BookExchange.Api.Repositories
{
    public interface IBookRepository
    { 
        Task<Book> GetBookByIdAsync(Guid Id);
        Task<BookDTO[]> GetAllBooksAsync();
        Task<bool> PostBook(Book book);
        Task<bool?> PutBook(BookDTO book);
       Task<bool?> DeleteBook(Guid Id);
        //Task<Book> GetBookByCategoryAsync();
    }
}