using DbmsAPI.Application.Repositories.Category;
using DbmsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepository<Domain.Entities.Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(DbmsAPIDbContext context) : base(context)
        {
        }
    }
}
