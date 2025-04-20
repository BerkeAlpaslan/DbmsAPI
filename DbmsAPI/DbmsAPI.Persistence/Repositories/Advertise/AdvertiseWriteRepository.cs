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
    public class AdvertiseWriteRepository : WriteRepository<Domain.Entities.Advertise>, IAdvertiseWriteRepository
    {
        public AdvertiseWriteRepository(DbmsAPIDbContext context) : base(context)
        {
        }
    }
}
