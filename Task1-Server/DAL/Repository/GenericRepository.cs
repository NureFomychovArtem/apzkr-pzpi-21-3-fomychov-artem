using DAL.Data;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DBContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected GenericRepository(
        DBContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
        public async Task LoadRelatedDataAsync<TEntity>(TEntity entity, Expression<Func<TEntity, object>> include)
        {
            if (entity == null || include == null)
                return;

            var propertyName = (include.Body as MemberExpression)?.Member.Name;
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Invalid member access expression", nameof(include));

            await _dbContext.Entry(entity).Reference(propertyName).LoadAsync();
        }
    }
}