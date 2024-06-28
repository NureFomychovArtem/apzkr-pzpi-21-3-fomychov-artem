using DAL.Entities;

namespace DAL.Repository.Interfaces
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<IEnumerable<Request>> GetAllAsync();
        Task<Request> GetByIdAsync(int id);
    }
}