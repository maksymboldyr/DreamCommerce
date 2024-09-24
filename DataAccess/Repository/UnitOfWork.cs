using DataAccess.Entities;
using DataAccess.Entities.Users;

namespace DataAccess.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationContext context;
        private RepositoryBase<Category> categoryRepository;
        private RepositoryBase<Subcategory> subcategoryRepository;
        private RepositoryBase<Product> productRepository;
        private RepositoryBase<Order> orderRepository;
        private RepositoryBase<OrderDetail> orderDetailRepository;

        public UnitOfWork(ApplicationContext context)
        {
            this.context = context;
        }

        public RepositoryBase<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new RepositoryBase<Category>(context);
                }
                return categoryRepository;
            }
        }

        public RepositoryBase<Subcategory> SubcategoryRepository
        {
            get
            {
                if (subcategoryRepository == null)
                {
                    subcategoryRepository = new RepositoryBase<Subcategory>(context);
                }
                return subcategoryRepository;
            }
        }

        public RepositoryBase<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new RepositoryBase<Product>(context);
                }
                return productRepository;
            }
        }

        public RepositoryBase<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new RepositoryBase<Order>(context);
                }
                return orderRepository;
            }
        }

        public RepositoryBase<OrderDetail> OrderDetailRepository
        {
            get
            {
                if (orderDetailRepository == null)
                {
                    orderDetailRepository = new RepositoryBase<OrderDetail>(context);
                }
                return orderDetailRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
