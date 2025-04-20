using DbmsAPI.Application.Repositories.Advertise;
using DbmsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Repositories.Advertise
{
    public class AdvertiseReadRepository : ReadRepository<Domain.Entities.Advertise>, IAdvertiseReadRepository
    {
        public AdvertiseReadRepository(DbmsAPIDbContext context) : base(context)
        {
        }
    }
}
