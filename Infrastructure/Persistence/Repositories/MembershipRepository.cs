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
    public class MembershipRepository : BaseRepository<Membership>, IMembershipRepository
    {
        private readonly eCommerceContext _context;
        public MembershipRepository(eCommerceContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Membership?> Get(MembershipType membership)
        {
            return await _context.Memberships.FirstOrDefaultAsync(m => m.MembershipType == membership);
        }
    }
}
