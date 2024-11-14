using DataAccess.Entities;

namespace DataAccess.Interfaces;

/// <summary>
/// Interface for a unit of work. Contains repositories for all entities that inherit from <seealso cref="BaseEntity"/>.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Gets the category repository.
    /// </summary>
    IRepositoryBase<Category> CategoryRepository { get; }

    /// <summary>
    /// Gets the subcategory repository.
    /// </summary>
    IRepositoryBase<Subcategory> SubcategoryRepository { get; }

    /// <summary>
    /// Gets the product repository.
    /// </summary>
    IRepositoryBase<Product> ProductRepository { get; }

    /// <summary>
    /// Gets the order repository.
    /// </summary>
    IRepositoryBase<Order> OrderRepository { get; }

    /// <summary>
    /// Gets the order detail repository.
    /// </summary>
    IRepositoryBase<OrderDetail> OrderDetailRepository { get; }

    /// <summary>
    /// Gets the tag repository.
    /// </summary>
    IRepositoryBase<Tag> TagRepository { get; }

    /// <summary>
    /// Gets the tag value repository.
    /// </summary>
    IRepositoryBase<TagValue> TagValueRepository { get; }

    /// <summary>
    /// Gets the cart repository.
    /// </summary>
    IRepositoryBase<Cart> CartRepository { get; }

    /// <summary>
    /// Gets the cart item repository.
    /// </summary>
    IRepositoryBase<CartItem> CartItemRepository { get; }

    /// <summary>
    /// Gets the address repository.
    /// </summary>
    IRepositoryBase<Address> AddressRepository { get; }
}
