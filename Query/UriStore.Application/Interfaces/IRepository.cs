using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync<Tkey>(Tkey id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync<TKey>(TKey id);
        Task UpdateAsync(T entity);
    }
}
