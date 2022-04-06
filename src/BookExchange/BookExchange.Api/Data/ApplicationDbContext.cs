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
             protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

 modelBuilder.Entity<Category>().HasData(new Category {CategoryId = Guid.NewGuid(), Title = "Romance", Description = "Books of affection" });

  modelBuilder.Entity<Category>().HasData(new Category {CategoryId = Guid.NewGuid(),  Title = "Drama", Description = "All out action" });
  
/* modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                Title = "Love languages",
                Description = "How you should be loved",
                ImgUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg",
                ISBN = "4002222",
                Author = "John angel",
                CategoryId = new Guid("4df3edf6-0b7c-46a4-af44-b069c4d5c07e"),
                UserId = new Guid("7918d41f-1c66-4e4f-9b7d-cc8126bfb8ea"),
            });*/

             modelBuilder.Entity<User>().HasData(new User
            {
                UserId = Guid.NewGuid(),
                FirstName = "Vincent",
                LastName = "Nwonah",
                Username = "MrVin",
                Password = "def@123",
                UserType = "Test",
                Status = "Active",   
                Mail = "Vin@gmail",
                Phone = "08037478545",
                RefreshToken = ""
                    });
      }
    }
}