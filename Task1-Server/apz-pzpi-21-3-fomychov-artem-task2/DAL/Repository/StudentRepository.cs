using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var students = await base.GetAllAsync();

            foreach (var student in students)
            {
                await LoadRelatedDataAsync(student, x => x.User);
                await LoadRelatedDataAsync(student, x => x.Class);
                await LoadRelatedDataAsync(student.Class, x => x.School);
                await LoadRelatedDataAsync(student.User, x => x.Role);

            }

            return students;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await base.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");//Об'єкт не знайдено

            await LoadRelatedDataAsync(student, x => x.User);
            await LoadRelatedDataAsync(student, x => x.Class);
            await LoadRelatedDataAsync(student.Class, x => x.School);
            await LoadRelatedDataAsync(student.User, x => x.Role);

            return student;
        }
    }
}