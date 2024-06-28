using DAL.Entities;

namespace DAL.Repository.Interfaces
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
    }
}