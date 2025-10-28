using Domine.Entities;
using Domine.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public T? Get<TId>(TId id)
        {
            return _context.Set<T>().Find(new object[] { id });
        }

        public async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                .Where(e => e.DeletedAt == null)
                .ToListAsync();
        }

        public async Task Add(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task Delete(T entity)
        {
            entity.DeletedAt = DateTime.UtcNow;
            _context.Set<T>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
