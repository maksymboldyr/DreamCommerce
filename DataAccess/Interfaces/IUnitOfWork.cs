using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositoryBase<Category> CategoryRepository { get; }
        IRepositoryBase<OrderDetail> OrderDetailRepository { get; }
        IRepositoryBase<Order> OrderRepository { get; }
        IRepositoryBase<Product> ProductRepository { get; }
        IRepositoryBase<Subcategory> SubcategoryRepository { get; }
        IRepositoryBase<Tag> TagRepository { get; }
        IRepositoryBase<TagValue> TagValueRepository { get; }
    }
}