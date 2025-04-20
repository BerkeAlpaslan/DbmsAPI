using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Advertise;
using DbmsAPI.Application.Repositories.Basket;
using DbmsAPI.Application.Repositories.Category;
using DbmsAPI.Application.Repositories.Customer;
using DbmsAPI.Application.Repositories.Order;
using DbmsAPI.Application.Repositories.Product;
using DbmsAPI.Application.Repositories.Review;
using DbmsAPI.Application.Repositories.Seller;
using DbmsAPI.Persistence.Contexts;
using DbmsAPI.Persistence.Repositories;
using DbmsAPI.Persistence.Repositories.Advertise;
using DbmsAPI.Persistence.Repositories.Basket;
using DbmsAPI.Persistence.Repositories.Category;
using DbmsAPI.Persistence.Repositories.Customer;
using DbmsAPI.Persistence.Repositories.Order;
using DbmsAPI.Persistence.Repositories.Product;
using DbmsAPI.Persistence.Repositories.Review;
using DbmsAPI.Persistence.Repositories.Seller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbmsAPIDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

            services.AddScoped<IDbConnection>(provider => new NpgsqlConnection(configuration.GetConnectionString("PostgreSQL")));

            services.AddScoped<IAdvertiseReadRepository, AdvertiseReadRepository>();
            services.AddScoped<IAdvertiseWriteRepository, AdvertiseWriteRepository>();
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
            services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();
            services.AddScoped<ISellerReadRepository, SellerReadRepository>();
            services.AddScoped<ISellerWriteRepository, SellerWriteRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
