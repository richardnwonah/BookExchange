using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BookExchange.Core.Models;

namespace BookExchange.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<User> Users {get; set;}
         public DbSet<Request> Requests {get; set;}
        public DbSet<BorrowedBook> BorrowedBooks {get; set;}
         
    }
}