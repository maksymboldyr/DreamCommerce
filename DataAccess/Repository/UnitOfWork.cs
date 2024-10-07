using DataAccess.Entities;
using DataAccess.Entities.Users;
using DataAccess.Interfaces;
using System;

namespace DataAccess.Repository
{
    public class UnitOfWork(ApplicationDbContext context) : IDisposable, IUnitOfWork
    {

        // Repositories for each entity
        private IRepositoryBase<Category>? categoryRepository;
        private IRepositoryBase<Subcategory>? subcategoryRepository;
        private IRepositoryBase<Product>? productRepository;
        private IRepositoryBase<Order>? orderRepository;
        private IRepositoryBase<OrderDetail>? orderDetailRepository;
        private IRepositoryBase<Tag>? tagRepository;
        private IRepositoryBase<TagValue>? tagValueRepository;

        public IRepositoryBase<Category> CategoryRepository
        {
            get => categoryRepository ??= new RepositoryBase<Category>(context);
        }

        public IRepositoryBase<Subcategory> SubcategoryRepository
        {
            get => subcategoryRepository ??= new RepositoryBase<Subcategory>(context);
        }

        public IRepositoryBase<Product> ProductRepository
        {
            get => productRepository ??= new RepositoryBase<Product>(context);
        }

        public IRepositoryBase<Order> OrderRepository
        {
            get => orderRepository ??= new RepositoryBase<Order>(context);
        }

        public IRepositoryBase<OrderDetail> OrderDetailRepository
        {
            get => orderDetailRepository ??= new RepositoryBase<OrderDetail>(context);
        }

        public IRepositoryBase<Tag> TagRepository
        {
            get => tagRepository ??= new RepositoryBase<Tag>(context);
        }

        public IRepositoryBase<TagValue> TagValueRepository
        {
            get => tagValueRepository ??= new RepositoryBase<TagValue>(context);
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
