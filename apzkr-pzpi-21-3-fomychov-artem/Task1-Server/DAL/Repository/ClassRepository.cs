using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        public ClassRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            var clasess = await base.GetAllAsync();

            foreach (var @class in clasess)
            {
                await LoadRelatedDataAsync(@class, x => x.School);
            }

            return clasess;
        }

        public async Task<Class> GetByIdAsync(int id)
        {
            var @class = await base.GetByIdAsync(id)
                ?? throw new Exception("Class was not found!");

            await LoadRelatedDataAsync(@class, x => x.School);

            return @class;
        }
    }
}