using DbmsAPI.Application.Repositories.Seller;
using DbmsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Repositories.Seller
{
    public class SellerReadRepository : ReadRepository<Domain.Entities.Seller>, ISellerReadRepository
    {
        public SellerReadRepository(DbmsAPIDbContext context) : base(context)
        {
        }
    }
}
