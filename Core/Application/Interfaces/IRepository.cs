using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>?> GetAllWhereWithInculudeAsync(Expression<Func<T, bool>>? expression = null, string[]? includes = null);
        Task<T> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(Expression<Func<T, bool>>? expression = null, string[]? includes = null);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
