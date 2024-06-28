using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            var attendances = await base.GetAllAsync();

            foreach (var attendance in attendances)
            {
                await LoadRelatedDataAsync(attendance, x => x.User);
                await LoadRelatedDataAsync(attendance.User, x => x.Role);

            }

            return attendances;
        }

        public async Task<Attendance> GetByIdAsync(int id)
        {
            var attendance = await base.GetByIdAsync(id)
                ?? throw new Exception("Attendance was not found");//Об'єкт не знайдено

            await LoadRelatedDataAsync(attendance, x => x.User);
            await LoadRelatedDataAsync(attendance.User, x => x.Role);

            return attendance;
        }
    }
}