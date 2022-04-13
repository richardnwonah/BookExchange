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
        public async Task<Request[]> GetAllRequestAsync(){
        var requests = _context.Requests;          
         return requests.ToArray();
      }
      //End point to add request
       public async Task<bool?> PostRequest(Request request)
       {
              var status = true;

            _context.Requests.Add(request);
            await _context.SaveChangesAsync();


            if(await _context.SaveChangesAsync() > 0)  
        {
            status = false;
        }
            return status;  
       }
       public bool? GenerateBorrowedBook(Guid bookId, Guid borrowerId, Guid lenderId)
       {
           var book = _context.Books.Find(bookId);
          //require Validation

           var _borrowedBook = new BorrowedBook
           {
            BookId = bookId,  
            LenderId = lenderId,
            BorrowerId = borrowerId, 
            BorrowDate = DateTime.Today,
            ReturnDate = DateTime.Today,
            IsReturned = false
           };
             _context.BorrowedBooks.Add(_borrowedBook);
    
           var _availability  = _context.Books
            .FirstOrDefault(A => A.Availability.Equals("NotAvailable"));
               _context.SaveChanges();
               
            return true;

       }

        public async Task<bool?> ApproveRequest(Guid id, ApproveRequestDTO approval)
        {
        var dbRequest = _context.Requests
        .FirstOrDefault(R => R.RequestId.Equals(id));
        dbRequest.ApprovalDate = approval.ApprovalDate;
        dbRequest.ResponseStatus  = approval.ResponseStatus;
        _context.SaveChanges();
           
         GenerateBorrowedBook(approval.BookId, approval.BorrowerId, approval.LenderId);
         return null;
        }
    }
}