using BLL.DTO;

namespace BLL.Service.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDTO>> GetAllAsync();
        Task<IEnumerable<AttendanceDTO>> GetByUserIdAsync(int id);
        Task<AttendanceDTO> GetByIdAsync(int id);
        Task<StatisticsAttendance> GetStatisticsByUserIdAsync(int id);
        Task<AttendanceDTO> CreateAsync(CreateAttendanceDTO data);
        Task UpdateAsync(int id, UpdateAttendanceDTO data);
        Task DeleteAsync(int id);
    }
}