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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly eCommerceContext _context;
        public UserRepository(eCommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Where(e => e.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<User?> GetAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
