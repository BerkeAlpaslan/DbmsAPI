using DbmsAPI.Application.Repositories.Product;
using DbmsAPI.Domain.Entities.CrossTables;
using DbmsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
    {
        private readonly DbmsAPIDbContext _context;
        public ProductWriteRepository(DbmsAPIDbContext context) : base(context)
        {
            _context = context;
        }

        public DbSet<ProductOrder> ProductOrder => _context.Set<ProductOrder>();
        public DbSet<BasketProduct> BasketProduct => _context.Set<BasketProduct>();

        public async Task<bool> AddProductToBasket(string productId, string orderId)
        {
            EntityEntry<BasketProduct> entityEntry = await BasketProduct.AddAsync(new BasketProduct
            {
                ProductId = Guid.Parse(productId),
                BasketId = Guid.Parse(orderId)
            });

            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddProductToOrder(string productId, string orderId)
        {
            EntityEntry<ProductOrder> entityEntry = await ProductOrder.AddAsync(new ProductOrder
            {
                ProductId = Guid.Parse(productId),
                OrderId = Guid.Parse(orderId)
            });

            return entityEntry.State == EntityState.Added;
        }
    }
}
