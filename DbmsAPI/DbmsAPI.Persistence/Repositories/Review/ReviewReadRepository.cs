using DbmsAPI.Application.Repositories.Review;
using DbmsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Repositories.Review
{
    public class ReviewReadRepository : ReadRepository<Domain.Entities.Review>, IReviewReadRepository
    {
        public ReviewReadRepository(DbmsAPIDbContext context) : base(context)
        {
        }
    }
}
