using System;
using System.Collections.Generic;
using System.Linq;
using BookExchange.Core.Models;
using System.Threading.Tasks;
using BookExchange.Api.Data;

namespace BookExchange.Api.Repositories
{
    public class BorrowedBookRepository : IBorrowedBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BorrowedBookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
      public async Task<BorrowedBook[]> GetAllBorrowedBooks()
      {
       return _context.BorrowedBooks.ToArray();
      }  
      
    }
}