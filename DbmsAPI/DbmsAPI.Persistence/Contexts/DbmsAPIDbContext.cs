using DbmsAPI.Domain.Entities;
using DbmsAPI.Domain.Entities.Common;
using DbmsAPI.Domain.Entities.CrossTables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Contexts
{
    public class DbmsAPIDbContext : DbContext
    {
        public DbmsAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Advertise> Advertises { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Advertise>()
                .HasOne(a => a.Product)
                .WithMany(p => p.Advertises)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Advertise>()
                .HasOne(a => a.Seller)
                .WithMany(s => s.Advertises)
                .HasForeignKey(a => a.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithOne(po => po.Product)
                .HasForeignKey(po => po.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne(po => po.Order)
                .HasForeignKey(po => po.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });

            builder.Entity<Product>()
                .HasMany(p => p.Baskets)
                .WithOne(bp => bp.Product)
                .HasForeignKey(bp => bp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Basket>()
                .HasMany(b => b.Products)
                .WithOne(bp => bp.Basket)
                .HasForeignKey(bp => bp.BasketId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BasketProduct>()
                .HasKey(bp => new { bp.BasketId, bp.ProductId });

            builder.Entity<Order>()
                .HasOne(o => o.Seller)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Basket>()
                .HasOne(b => b.Customer)
                .WithOne(c => c.Basket)
                .HasForeignKey<Basket>(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>().UseTpcMappingStrategy();

            builder.Entity<Review>()
                .Property(r => r.Rating)
                .HasConversion<string>();

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var data in datas)
            {
                if (data.Entity is BaseEntity entity)
                {
                    entity.Id = entity.Id == Guid.Empty ? Guid.NewGuid() : entity.Id;

                    if (data.State == EntityState.Added)
                        entity.CreatedAt = DateTime.UtcNow;
                    else
                        entity.UpdatedAt = DateTime.UtcNow;
                }

            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
