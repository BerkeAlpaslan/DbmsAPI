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
    public class CategoryReadRepository : ReadRepository<Domain.Entities.Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(DbmsAPIDbContext context) : base(context)
        {
        }
    }
}
