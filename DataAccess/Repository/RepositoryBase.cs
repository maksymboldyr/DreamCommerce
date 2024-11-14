using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository;

/// <summary>
/// Base repository class for entities that inherit from <seealso cref="BaseEntity"/>. An implementation of <seealso cref="IRepositoryBase{T}"/>.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="context"></param>
public class RepositoryBase<T>(ApplicationDbContext context) : IRepositoryBase<T> where T : BaseEntity
{
    /// <summary>
    /// DbSet for the <seealso cref="{T}"/> entity.
    /// </summary>
    protected readonly DbSet<T> dbSet = context.Set<T>();

    /// <summary>
    /// Array of separator characters for splitting strings.
    /// </summary>
    private readonly char[] separator = [','];

    /// <summary>
    /// Gets all entities of type <seealso cref="{T}"/> from the database. Can be filtered, ordered, and include properties.
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="orderBy"></param>
    /// <param name="includeProperties"></param>
    /// <returns>A collection of <seealso cref="{T}"/> entities.</returns>
    public async Task<IEnumerable<T>> GetAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<T> query = dbSet.AsNoTracking();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (separator, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        return orderBy != null
            ? await orderBy(query).ToListAsync()
            : await query.ToListAsync();
    }

    /// <summary>
    /// Gets an entity by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<T> GetByIdAsync(string id)
    {
        var entity = await dbSet.FindAsync(id);
        return entity ?? throw new KeyNotFoundException("Entity not found");
    }

    /// <summary>
    /// Inserts an entity to the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<string> InsertAsync(T entity)
    {
        entity.CreatedAt = DateTime.Now;
        var addedEntity = await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();

        return addedEntity.Entity.Id;
    }

    /// <summary>
    /// Updates an entity in the database.
    /// </summary>
    /// <param name="entity"></param>
    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.Now;
        dbSet.Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task DeleteAsync(string id)
    {
        T? entityToDelete = await dbSet.FindAsync(id) ?? throw new KeyNotFoundException("Entity not found");
        await DeleteAsync(entityToDelete);
    }

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="entityToDelete"></param>
    /// <returns></returns>
    private async Task DeleteAsync(T entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
        await context.SaveChangesAsync();
    }
}
