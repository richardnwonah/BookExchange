using BookExchange.Core.Models;
using System.Threading.Tasks;
using BookExchange.Api.DTOs;

namespace BookExchange.Api.Repositories
{
    public interface IRequestRepository
    { 
    Task<bool?> PostRequest(RequestDTO request);
    Task<bool?> ApproveRequest(Guid id, ApproveRequestDTO approval);
    }
}