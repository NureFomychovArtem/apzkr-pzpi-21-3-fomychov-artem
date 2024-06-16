using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly DBContext _dbContext;

        public RoleRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role?> GetByRoleNameAsync(RoleName roleName)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == roleName);
        }
    }
}