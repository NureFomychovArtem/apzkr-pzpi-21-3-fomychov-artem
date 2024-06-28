using DAL.Entities;

namespace DAL.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByFingerprintAsync(string fingerprint);
    }
}