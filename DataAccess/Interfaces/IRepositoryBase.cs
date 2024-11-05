using System.Linq.Expressions;

namespace DataAccess.Interfaces;

/// <summary>
/// Interface for a generic repository.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepositoryBase<T> where T : class
{
    /// <summary>
    /// Gets all entities. Can be filtered, ordered, and include properties.
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="orderBy"></param>
    /// <param name="includeProperties"></param>
    /// <returns>Collection of <seealso cref="T"/> entities.</returns>
    Task<IEnumerable<T>> GetAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "");

    /// <summary>
    /// Gets an entity by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> GetByIdAsync(string id);

    /// <summary>
    /// Inserts an entity to the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<string> InsertAsync(T entity);

    /// <summary>
    /// Updates an entity in the database.
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(string id);
}
