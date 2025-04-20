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
    public class SellerWriteRepository : WriteRepository<Domain.Entities.Seller>, ISellerWriteRepository
    {
        public SellerWriteRepository(DbmsAPIDbContext context) : base(context)
        {
        }
    }
}
