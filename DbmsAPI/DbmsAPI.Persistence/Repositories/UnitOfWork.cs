using DbmsAPI.Application.Repositories;
using DbmsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbmsAPIDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DbmsAPIDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
                await _transaction.DisposeAsync();
        }

        public async Task RollbackAsync()
        {
            
            if (_transaction != null)
                await _transaction.RollbackAsync();
        }
    }
}
