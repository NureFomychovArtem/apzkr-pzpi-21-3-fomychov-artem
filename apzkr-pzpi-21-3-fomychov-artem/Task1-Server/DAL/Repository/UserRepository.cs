using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await base.GetAllAsync();

            foreach (var user in users)
            {
                await LoadRelatedDataAsync(user, x => x.Account);
                await LoadRelatedDataAsync(user, x => x.Role);
            }

            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await base.GetByIdAsync(id)
                ?? throw new Exception("User was not found!");

            await LoadRelatedDataAsync(user, x => x.Account);
            await LoadRelatedDataAsync(user, x => x.Role);

            return user;
        }

        public async Task<User> GetByFingerprintAsync(string fingerprint)
        {
            var user = (await base.GetAllAsync()).FirstOrDefault(x => x.Fingerprint == fingerprint);

            await LoadRelatedDataAsync(user, x => x.Account);
            await LoadRelatedDataAsync(user, x => x.Role);

            return user;
        }
    }
}