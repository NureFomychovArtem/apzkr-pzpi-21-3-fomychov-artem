using DAL.Entities;

namespace DAL.Repository.Interfaces
{
    public interface IClassroomRepository : IGenericRepository<Classroom>
    {
        Task<IEnumerable<Classroom>> GetAllAsync();
        Task<Classroom> GetByIdAsync(int id);
    }
}