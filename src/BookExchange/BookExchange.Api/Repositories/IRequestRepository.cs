using BookExchange.Core.Models;
using System.Threading.Tasks;
using BookExchange.Api.DTOs;

namespace BookExchange.Api.Repositories
{
    public interface IRequestRepository
    { 
    Task<Request[]> GetAllRequestAsync();
    Task<bool?> PostRequest(Request request);
    Task<bool?> ApproveRequest(Guid id, ApproveRequestDTO approval);
    }
}