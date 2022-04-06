using BookExchange.Core.Models;
using System.Threading.Tasks;
using BookExchange.Api.Data;
using BookExchange.Api.DTOs;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookExchange.Api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
      public async Task<BookDTO[]> GetAllBooksAsync(){
          var books = from b in _context.Books
                select new BookDTO()
                {
                    Id = b.Id,
                    Title = b.Title.ToString(),
                    Description = b.Description.ToString(),
                    ImgUrl = b. ImgUrl.ToString(),
                    ISBN = b.ISBN.ToString(),
                    CategoryId = b.CategoryId,
                    YearOfPublication = b.YearOfPublication,
                    Author = b.Author.ToString(),
                    UserId = b.UserId,
                };

    return books.ToArray();
      }
          public async Task<Book> GetBookByIdAsync(Guid Id)
    {
       var book = await _context.Books.FindAsync(Id);
        if (book == null)
            {
                return null;
            }

            return (book);
     }
    
     public async Task<bool> PostBook(Book book)
        {
            var status = false;
             var User = from users in _context.Users
                           where users.UserId == book.CategoryId
                           select users;

            
            _context.Books.Add(book);
            await _context.SaveChangesAsync();


            if(await _context.SaveChangesAsync() > 0)
        {
            status = false;
        }
            return status;

        }

    public async Task<bool?> PutBook(BookDTO book)
    {
        var entryBook = new Book()
        {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    ImgUrl = book.ImgUrl,
                    ISBN = book.ISBN,
                    CategoryId = book.CategoryId,
                    YearOfPublication = book.YearOfPublication,
                    Author = book.Author,
                    UserId = book.UserId,
        };
         _context.Entry(entryBook).State = EntityState.Modified;
//removed validation block
    return true;

    }
    public async Task<bool?> DeleteBook(Guid Id)
        {
            var book = await _context.Books.FindAsync(Id);
            if (book == null)
            {
                return null;
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}