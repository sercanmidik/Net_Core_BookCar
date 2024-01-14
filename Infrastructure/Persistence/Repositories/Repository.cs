using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookCarContext _context;

        public Repository(BookCarContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
           _context.Set<T>().Add(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>?> GetAllWhereWithInculudeAsync(Expression<Func<T, bool>>? expression = null, string[]? includes = null)
        {
            IQueryable<T> data = expression != null ? _context.Set<T>().Where(expression) : _context.Set<T>();
            if (data != null)
            {
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        data = data.Include(item);
                    }
                }
            }
            return await Task.Run(() => data);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

    

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>>? expression = null, string[]? includes = null)
        {
            IQueryable<T> data = expression != null ? _context.Set<T>().Where(expression) : _context.Set<T>();
            if (data != null)
            {
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        data = data.Include(item);
                    }
                }
            }
            return await Task.Run(() => data.SingleOrDefault());
        }

 

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
           await _context.SaveChangesAsync();
        }
    }
}
