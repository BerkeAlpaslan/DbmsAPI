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
    public class ReviewWriteRepository : WriteRepository<Domain.Entities.Review>, IReviewWriteRepository
    {
        public ReviewWriteRepository(DbmsAPIDbContext context) : base(context)
        {
        }
    }
}
