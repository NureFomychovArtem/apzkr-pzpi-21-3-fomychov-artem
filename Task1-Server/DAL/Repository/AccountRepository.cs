using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly DBContext _dbContext;

        public AccountRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}