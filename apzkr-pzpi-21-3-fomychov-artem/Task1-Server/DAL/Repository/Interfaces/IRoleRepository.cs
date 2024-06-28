using DAL.Entities;

namespace DAL.Repository.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role?> GetByRoleNameAsync(RoleName roleName);
    }
}