using System.Linq.Expressions;

namespace DataAccess.Interfaces
{
    public interface IRepositoryBase <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity> GetByIdAsync(string id);
        Task InsertAsync(TEntity entity);
        Task Delete(string id);
        void Update(TEntity entity);
    }
}
