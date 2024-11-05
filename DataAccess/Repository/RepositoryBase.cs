using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class RepositoryBase<T>(ApplicationDbContext context) : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly DbSet<T> dbSet = context.Set<T>();
        private readonly char[] separator = [','];

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

        public async Task<T> GetByIdAsync(string id)
        {
            var entity = await dbSet.FindAsync(id);
            return entity ?? throw new KeyNotFoundException("Entity not found");
        }

        public async Task<string> InsertAsync(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            var addedEntity = await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();

            return addedEntity.Entity.Id;
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public async Task DeleteAsync(string id)
        {
            T? entityToDelete = await dbSet.FindAsync(id) ?? throw new KeyNotFoundException("Entity not found");
            await DeleteAsync(entityToDelete);
        }

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
}
