using System;
using System.Collections.Generic;
using System.Linq;
using BookExchange.Core.Models;
using System.Threading.Tasks;
using BookExchange.Api.Data;

namespace BookExchange.Api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
          private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
      public async Task<Category[]> GetAllCategoriesAync()
      {
       return _context.Categories.ToArray();
      }  
        public async Task<bool> PostCategory(Category category)
        {
            var status = false;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();


            if(await _context.SaveChangesAsync() > 0)
        {
            status = false;
        }
            return status;

        }
    }
}