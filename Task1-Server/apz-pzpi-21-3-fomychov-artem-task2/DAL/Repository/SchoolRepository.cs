using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        private readonly DBContext _dbContext;

        public SchoolRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}