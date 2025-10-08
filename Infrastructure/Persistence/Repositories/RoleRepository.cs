using Domine.Entities;
using Domine.Enums;
using Domine.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly eCommerceContext _context;
        public RoleRepository(eCommerceContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Role?> Get(RoleType roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        } 
    }
}
