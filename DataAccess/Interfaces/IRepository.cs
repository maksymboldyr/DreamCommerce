using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IRepository
    {
        public Task<bool> Create(BaseEntity entity);
        public Task<bool> Update(BaseEntity entity);
        public Task<bool> Delete(BaseEntity entity);
        public Task<object> GetById(int id);
        public Task<IEnumerable<object>> GetAll();
    }
}
