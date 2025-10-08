using Domine.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
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
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
