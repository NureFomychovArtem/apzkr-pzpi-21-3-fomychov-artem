using DAL.Entities;

namespace DAL.Repository.Interfaces
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        Task<IEnumerable<Attendance>> GetAllAsync();
        Task<Attendance> GetByIdAsync(int id);
    }
}