using BookExchange.Core.Models;
using System.Threading.Tasks;
using BookExchange.Api.Data;
using BookExchange.Api.DTOs;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookExchange.Api.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       public async Task<bool?> PostRequest(RequestDTO request)
       {
            var status = true;
            var book = await _context.Books.FindAsync(request.BookId);
            if (book == null)
            {
                return null;
            }

               var _request = new Request()
                {
                    
                    RequestId = Guid.NewGuid(),
                    BookId= request.BookId,
                    
                    Book = new Book {
                        Id = book.Id,
                        Title = book.Title,
                        Description = book.Description,
                        ImgUrl = book.ImgUrl,
                        ISBN = book.ISBN,
                        CategoryId = book.CategoryId,
                        Category = book.Category,
                        YearOfPublication = book.YearOfPublication,
                        Author = book.Author,
                        UserId = book.UserId,
                        Owner = book.Owner,
                        Availability = book.Availability
                    },
                    RequesterId = request.RequesterId,
                    ApproverId = request.ApproverId,
                    ReturnDate = request.ReturnDate
                
                };
                                            
            _context.Requests.Add(_request);
            await _context.SaveChangesAsync();


            if(await _context.SaveChangesAsync() > 0)
        {
            status = false;
        }
            return status;  
       }

        public async Task<bool?> ApproveRequest(Guid id, ApproveRequestDTO approval)
        {
            var dbRequest = _context.Requests
            .FirstOrDefault(R => R.RequestId.Equals(id));
        dbRequest.ApprovalDate = approval.ApprovalDate;
        dbRequest.ResponseStatus  = approval.ResponseStatus;
        _context.SaveChanges();
         
         return null;
        }
    }
}