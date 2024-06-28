using System.Linq.Expressions;

namespace DAL.Repository.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task LoadRelatedDataAsync<TEntity>(TEntity entity, Expression<Func<TEntity, object>> include);

    }
}