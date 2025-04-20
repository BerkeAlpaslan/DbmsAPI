using DbmsAPI.Application.Repositories;
using DbmsAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly Contexts.DbmsAPIDbContext _context;

        public ReadRepository(Contexts.DbmsAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();
            
            T? entity = await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            
            if (entity == null)
                throw new Exception("Entity not found");
            
            return entity;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            T? entity = await query.FirstOrDefaultAsync(method);

            if (entity == null)
                throw new Exception("Entity not found");

            return entity;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }
    }
}
