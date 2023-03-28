using DAL.Abstractions;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenereicRepository<T> where T : class
    {
        protected ApiDbContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ApiDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetPagination(int page, int numberOfEntities)
        {
            if (page == 0) page = 1;
            if (numberOfEntities == 0) numberOfEntities = int.MaxValue;
            int skip = (page - 1) * numberOfEntities;
            return await _dbSet.Skip(skip).Take(numberOfEntities).ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task Add(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            Console.WriteLine(result);
        }
        public virtual async Task Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public virtual async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
