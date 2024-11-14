using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repository
{
    /// <summary>
    /// Unit of work implementation. Manages repositories for entities that inherit from <seealso cref="BaseEntity"/>.
    /// </summary>
    /// <param name="context"></param>
    public class UnitOfWork(ApplicationDbContext context) : IDisposable, IUnitOfWork
    {
        #region Private fields
        private bool disposed = false;
        private IRepositoryBase<Category>? categoryRepository;
        private IRepositoryBase<Subcategory>? subcategoryRepository;
        private IRepositoryBase<Product>? productRepository;
        private IRepositoryBase<Order>? orderRepository;
        private IRepositoryBase<OrderDetail>? orderDetailRepository;
        private IRepositoryBase<Tag>? tagRepository;
        private IRepositoryBase<TagValue>? tagValueRepository;
        private IRepositoryBase<Cart>? cartRepository;
        private IRepositoryBase<CartItem>? cartItemRepository;
        private IRepositoryBase<Address>? addressRepository;
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the category repository.
        /// </summary>
        public IRepositoryBase<Category> CategoryRepository
        {
            get => categoryRepository ??= new RepositoryBase<Category>(context);
        }

        /// <summary>
        /// Gets the subcategory repository.
        /// </summary>
        public IRepositoryBase<Subcategory> SubcategoryRepository
        {
            get => subcategoryRepository ??= new RepositoryBase<Subcategory>(context);
        }

        /// <summary>
        /// Gets the product repository.
        /// </summary>
        public IRepositoryBase<Product> ProductRepository
        {
            get => productRepository ??= new RepositoryBase<Product>(context);
        }

        /// <summary>
        /// Gets the order repository.
        /// </summary>
        public IRepositoryBase<Order> OrderRepository
        {
            get => orderRepository ??= new OrderRepository(context);
        }

        /// <summary>
        /// Gets the order detail repository.
        /// </summary>
        public IRepositoryBase<OrderDetail> OrderDetailRepository
        {
            get => orderDetailRepository ??= new RepositoryBase<OrderDetail>(context);
        }

        /// <summary>
        /// Gets the tag repository.
        /// </summary>
        public IRepositoryBase<Tag> TagRepository
        {
            get => tagRepository ??= new RepositoryBase<Tag>(context);
        }

        /// <summary>
        /// Gets the tag value repository.
        /// </summary>
        public IRepositoryBase<TagValue> TagValueRepository
        {
            get => tagValueRepository ??= new RepositoryBase<TagValue>(context);
        }

        /// <summary>
        /// Gets the cart repository.
        /// </summary>
        public IRepositoryBase<Cart> CartRepository
        {
            get => cartRepository ??= new RepositoryBase<Cart>(context);
        }

        /// <summary>
        /// Gets the cart item repository.
        /// </summary>
        public IRepositoryBase<CartItem> CartItemRepository
        {
            get => cartItemRepository ??= new RepositoryBase<CartItem>(context);
        }

        /// <summary>
        /// Gets the address repository.
        /// </summary>
        public IRepositoryBase<Address> AddressRepository
        {
            get => addressRepository ??= new RepositoryBase<Address>(context);
        }
        #endregion

        /// <summary>
        /// Disposes the context.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }

        /// <summary>
        /// Disposes the unit of work.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
