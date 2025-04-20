using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Repositories.Product
{
    public interface IProductWriteRepository : IWriteRepository<Domain.Entities.Product>
    {
        Task<bool> AddProductToOrder(string productId, string orderId);
        Task<bool> AddProductToBasket(string productId, string orderId);
    }
}
