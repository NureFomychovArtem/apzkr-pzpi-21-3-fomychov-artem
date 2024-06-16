using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            var teachers = await base.GetAllAsync();

            foreach (var teacher in teachers)
            {
                await LoadRelatedDataAsync(teacher, x => x.User);
                await LoadRelatedDataAsync(teacher, x => x.Class);
                await LoadRelatedDataAsync(teacher.Class, x => x.School);
                await LoadRelatedDataAsync(teacher.User, x => x.Role);
            }

            return teachers;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var teacher = await base.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");//Об'єкт не знайдено

            await LoadRelatedDataAsync(teacher, x => x.User);
            await LoadRelatedDataAsync(teacher, x => x.Class);
            await LoadRelatedDataAsync(teacher.Class, x => x.School);
            await LoadRelatedDataAsync(teacher.User, x => x.Role);

            return teacher;
        }
    }
}