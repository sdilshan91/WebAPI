using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using WebApi.Core.IRepositories;
using WebApi.Data;

namespace WebApi.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class

    {
        private ApplicationDbContext _context;
        public DbSet<T> _dbSet;
        public readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = _context.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public virtual async Task<T> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> AddRange(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return true;
        }

        public virtual async Task<bool> Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
