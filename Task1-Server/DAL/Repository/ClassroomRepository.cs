using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository
{
    public class ClassroomRepository : GenericRepository<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Classroom>> GetAllAsync()
        {
            var classrooms = await base.GetAllAsync();

            foreach (var classroom in classrooms)
            {
                await LoadRelatedDataAsync(classroom, x => x.School);
            }

            return classrooms;
        }

        public async Task<Classroom> GetByIdAsync(int id)
        {
            var classroom = await base.GetByIdAsync(id)
                ?? throw new Exception("Classroom was not found!");

            await LoadRelatedDataAsync(classroom, x => x.School);

            return classroom;
        }
    }
}