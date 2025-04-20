using DbmsAPI.Application.Repositories.Order;
using DbmsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Repositories.Order
{
    public class OrderWriteRepository : WriteRepository<Domain.Entities.Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(DbmsAPIDbContext context) : base(context)
        {
        }
    }
}
