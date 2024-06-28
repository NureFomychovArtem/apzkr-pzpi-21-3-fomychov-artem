using DAL.Entities;

namespace DAL.Repository.Interfaces
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        Task<IEnumerable<Answer>> GetAllAsync();
        Task<Answer> GetByIdAsync(int id);
    }
}