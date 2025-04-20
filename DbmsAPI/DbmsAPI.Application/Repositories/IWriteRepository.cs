using DbmsAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool RemoveRange(List<T> datas);
        Task<bool> UpdateAsync(string id);
        bool UpdateRange(List<T> datas);
        Task<int> SaveAsync();
    }
}
