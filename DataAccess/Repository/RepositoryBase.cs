using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> dbSet;

        public RepositoryBase(ApplicationContext context) {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var entity = await dbSet.FindAsync(id);

            if (entity == null) {
                throw new ArgumentException("Entity not found");
            }

            return entity;
        }

        public async Task InsertAsync(T entity)
        {
            await dbSet.AddAsync(entity);          
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(string id)
        {
            T entityToDelete = await dbSet.FindAsync(id);

            if (entityToDelete == null) {
                throw new ArgumentException("Entity not found");
            }

            Delete(entityToDelete);
        }

        private void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
    }
}
