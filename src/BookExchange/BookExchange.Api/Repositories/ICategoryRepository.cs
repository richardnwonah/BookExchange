using BookExchange.Core.Models;
using System.Threading.Tasks;

namespace BookExchange.Api.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category[]> GetAllCategoriesAync();
       // Task<Category> GetCategoryByIDAsync(Guid Id);
       Task<bool> PostCategory(Category categoory);
    }
}