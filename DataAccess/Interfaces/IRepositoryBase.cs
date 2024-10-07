using System.Linq.Expressions;

namespace DataAccess.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        Task<T> GetByIdAsync(string id);
        Task InsertAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(string id);
    }
}
