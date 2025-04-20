using DbmsAPI.Application.Repositories;
using DbmsAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly Contexts.DbmsAPIDbContext _context;

        public WriteRepository(Contexts.DbmsAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T? entity = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

            if (entity == null)
                return false;

            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<bool> UpdateAsync(string id)
        {
            T? entity = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

            if (entity == null)
                return false;

            Table.Update(entity);
            return true;
        }

        public bool UpdateRange(List<T> datas)
        {
            Table.UpdateRange(datas);
            return true;
        }

        public Task<int> SaveAsync() => _context.SaveChangesAsync();
    }
}
